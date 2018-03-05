using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using Autofac.Features.Indexed;
using log4net;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using RSUI.BA.Rating.Data.Entities;
using RSUI.BA.Rating.Data.IoC;
using RSUI.BA.Rating.GL.BizLogic.DTO;
using RSUI.BA.Rating.GL.BizLogic.Interface;
using RSUI.BA.Rating.Model;
using RSUI.BA.Rating.Data.Helpers;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.GL.BizLogic.Impl
{
    public class GLHelper : IGLHelper
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(GLHelper));
        protected ISession RatingDBSession { get { return _sessions[Databases.Rating]; } }
        private IIndex<Databases, ISession> _sessions { get; set; }
        private IGLLookUp _glLookUp;

        public GLHelper(IIndex<Databases, ISession> sessions, IGLLookUp glLookUp)
        {
            _glLookUp = glLookUp;
            _sessions = sessions;
        }

        private ISOFactorsDTO GetIsoFactors(int rateAsClassCode, string state, string territory, string deductible, int limitOcc, int limitAgg, string effectivDate,int originalClassCodeNumber)
        {

            //TODO get the carrier to use from the config (the DB will not use carrier for the department or area within RSUI so we can use multiple LCMS)
            //Carrier_ID
            var lcmID = "1";
            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Carrier_ID"]))
            {
                lcmID =ConfigurationManager.AppSettings["Carrier_ID"];
            }

            var sql = new StringBuilder();
            sql.Append("EXEC USP_GetUWISOFactors " + rateAsClassCode + ", '" + state + "', '" + territory + "', '" + deductible + "', '" + limitOcc + "', '" + limitAgg + "', '" + effectivDate + "', " + lcmID + "," + originalClassCodeNumber);

            var query = RatingDBSession.CreateSQLQuery(sql.ToString());
            query.SetResultTransformer(Transformers.AliasToBean(typeof(ISOFactorsDTO)));
            query.AddScalar("ClassCode", NHibernateUtil.Int32);
            query.AddScalar("StateCode", NHibernateUtil.String);
            query.AddScalar("Territory", NHibernateUtil.String);
            query.AddScalar("Deductible", NHibernateUtil.String);
            query.AddScalar("OccLimit", NHibernateUtil.String);
            query.AddScalar("AggLimit", NHibernateUtil.String);
            query.AddScalar("PremLossCost", NHibernateUtil.Decimal);
            query.AddScalar("ProdLossCost", NHibernateUtil.Decimal);
            query.AddScalar("PremILFRate", NHibernateUtil.Decimal);
            query.AddScalar("ProdILFRate", NHibernateUtil.Decimal);
            query.AddScalar("PremDeductibleFactor", NHibernateUtil.Decimal);
            query.AddScalar("ProdDeductibleFactor", NHibernateUtil.Decimal);
            query.AddScalar("LCM", NHibernateUtil.Decimal);
            query.AddScalar("Surcharge", NHibernateUtil.Decimal);
            query.AddScalar("ProductsHazrdLevel", NHibernateUtil.String);
            query.AddScalar("PremisesHazardLevel", NHibernateUtil.String);
            query.AddScalar("PremisesLossCostIndicator", NHibernateUtil.String);
            query.AddScalar("ProductsLossCostIndicator", NHibernateUtil.String);
            query.AddScalar("PremisesELP", NHibernateUtil.Decimal);
            query.AddScalar("ProductsELP", NHibernateUtil.Decimal);

            var factors = query.List<ISOFactorsDTO>();

            return factors.FirstOrDefault();
        }

        private LiquorRateDTO GetLiquorFactors(int classcode, string state, int limitOcc, int limitAgg)
        {
            var lcmID = "2";
            if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["Carrier_ID"]))
            {
                lcmID = ConfigurationManager.AppSettings["Carrier_ID"];
            }

            var sql = new StringBuilder();
            sql.Append("EXEC USP_GetLiquorRate " + classcode + ", '" + state + "', " + limitOcc + ", " + limitAgg + ", " + lcmID );

            var query = RatingDBSession.CreateSQLQuery(sql.ToString());
            query.SetResultTransformer(Transformers.AliasToBean(typeof(LiquorRateDTO)));
            query.AddScalar("ClassCode", NHibernateUtil.Int32);
            query.AddScalar("State", NHibernateUtil.String);
            query.AddScalar("OccLimit", NHibernateUtil.Int32);
            query.AddScalar("AggLimit", NHibernateUtil.Int32);
            query.AddScalar("LossCost", NHibernateUtil.Decimal);
            query.AddScalar("ILFRate", NHibernateUtil.Decimal);
            query.AddScalar("LCM", NHibernateUtil.Decimal);
            query.AddScalar("Surcharge", NHibernateUtil.Decimal);
            query.AddScalar("UnmodifiedRate", NHibernateUtil.Decimal);
            query.AddScalar("Rate", NHibernateUtil.Decimal);

            var rate = query.List<LiquorRateDTO>();

            return rate.FirstOrDefault();
        }

        public RatesModel GetISORate(string limts, string deductible, LocationModel location, MstClassCode classCode, string effectiveDate)
        {
            int occLimit, aggLimit;
            string deductibleMassaged;

            ParseLimits(out aggLimit, out occLimit, limts);
            deductibleMassaged = !string.IsNullOrEmpty(deductible) && FormatAndParseUtils.IsNumeric(deductible) ? FormatAndParseUtils.RemoveSpecialCharacters(deductible) : "0";

            var isoFactors = GetIsoFactors(classCode.IsoClassCode.ClassCode, location.State, 
                location.TerritoryCode, deductibleMassaged, occLimit, aggLimit, effectiveDate,
                classCode.ClassCode);

            if (isoFactors == null) return null;

            var isoRates = ConvertToISORatesModel(classCode, isoFactors);

            return isoRates;
        }

        private RatesModel ConvertToISORatesModel(MstClassCode classCode, ISOFactorsDTO isoFactors)
        {
            var isoRates = new RatesModel
            {
                AdditionalModifier = isoFactors.Surcharge.ToString("0.000"),
                IsProductsIncluded = !string.IsNullOrEmpty(isoFactors.ProductsHazrdLevel) && isoFactors.ProductsHazrdLevel.Equals("-"),
                IsPremisesARated = !string.IsNullOrEmpty(isoFactors.PremisesLossCostIndicator) && isoFactors.PremisesLossCostIndicator.Equals("A"),
                IsProductsARated = !string.IsNullOrEmpty(isoFactors.ProductsLossCostIndicator) && isoFactors.ProductsLossCostIndicator.Equals("A")
            };

			var premLostCost = isoFactors.PremLossCost;
			if (isoRates.IsPremisesARated)
			{
				premLostCost = (classCode.Elp?.PremiseElp != null && classCode.Elp.PremiseElp > 0)
					? classCode.Elp.PremiseElp.Value
					: isoFactors.PremisesELP;
			}

			var prodLostCost = isoFactors.ProdLossCost;
			if (isoRates.IsProductsARated)
			{
				prodLostCost = (classCode.Elp?.ProductsElp != null && classCode.Elp.ProductsElp > 0)
				? classCode.Elp.ProductsElp.Value
				: isoFactors.ProductsELP;
			}

			var premisesUnmodifiedRate = (isoFactors.LCM * premLostCost * isoFactors.Surcharge);
			var productsUnmodifiedRate = (isoFactors.LCM * prodLostCost * isoFactors.Surcharge);
			isoRates.PremisesLossCostModifier = premLostCost.ToString("0.000");
            isoRates.ProductsLossCostModifier = prodLostCost.ToString("0.000");
            isoRates.CompanyLossCostMultiplier = isoFactors.LCM.ToString("0.000");
            isoRates.PremisesUnmodifiedRate = premisesUnmodifiedRate.ToString("0.000");
            isoRates.ProductsUnmodifiedRate = productsUnmodifiedRate.ToString("0.000");

            decimal premUnmodifiedIlfRate = isoFactors.PremILFRate;
            decimal prodUnmodifiedIlfRate = isoFactors.ProdILFRate;
            if (string.IsNullOrEmpty(isoRates.PremisesUnmodifiedRate) || decimal.Parse(isoRates.PremisesUnmodifiedRate) <= 0)
            {
                isoRates.IsPremisesRateEditable = true;
				premUnmodifiedIlfRate = 1;
            }

            if (!isoRates.IsProductsIncluded && (string.IsNullOrEmpty(isoRates.ProductsUnmodifiedRate) || decimal.Parse(isoRates.ProductsUnmodifiedRate) <= 0))
            {
                isoRates.IsProductsRateEditable = true;
				prodUnmodifiedIlfRate = 1;
            }

            isoRates.PremisesUnmodifiedIncreasedLimitsFactor = premUnmodifiedIlfRate.ToString("0.000");
            isoRates.ProductsUnmodifiedIncreasedLimitsFactor = prodUnmodifiedIlfRate.ToString("0.000");

			decimal premIlfRate = (premUnmodifiedIlfRate - isoFactors.PremDeductibleFactor);
			decimal prodIlfRate = (prodUnmodifiedIlfRate - isoFactors.ProdDeductibleFactor);

			isoRates.PremisesIncreasedLimitsFactor = premIlfRate.ToString("0.000");
            isoRates.ProductsIncreasedLimitsFactor = prodIlfRate.ToString("0.000");

			isoRates.PremisesRate = (premIlfRate * premisesUnmodifiedRate).ToString("0.000");
			isoRates.ProductsRate = (prodIlfRate * productsUnmodifiedRate).ToString("0.000");

			return isoRates;
        }

        public void ParseLimits(out int aggLimit, out int occLimit, string aggregateOccurenceLimits)
        {
            var limits = aggregateOccurenceLimits.Split('/');
            var cultureInfo = new CultureInfo("en-US");
            occLimit = int.Parse(limits[0], NumberStyles.Any, cultureInfo);
            aggLimit = int.Parse(limits[1], NumberStyles.Any, cultureInfo);
        }

        public void LoadGlTables()
        {
			if (_glLookUp.MstClassCodes == null)
			{
				_glLookUp.MstClassCodes = RatingDBSession.Query<MstClassCode>().ToList();
			}

			if (_glLookUp.MstStates == null)
			{
				_glLookUp.MstStates = RatingDBSession.Query<MstState>().ToList();
			}
		}
    }
}
