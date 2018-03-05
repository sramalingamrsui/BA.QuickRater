namespace RSUI.BA.Rating.Model
{

    public class RatesModel
    {
        public string PremisesUnmodifiedIncreasedLimitsFactor { get; set; }
        public string PremisesIncreasedLimitsFactor { get; set; }
        public string PremisesLossCostModifier { get; set; }
        public string PremiseDeductibleFactor { get; set; }
        public string PremisesUnmodifiedRate { get; set; }
		public string PremisesRate { get; set; }
		public bool IsPremisesRateEditable { get; set; }
        public string ProductsUnmodifiedIncreasedLimitsFactor { get; set; }
        public string ProductsIncreasedLimitsFactor { get; set; }
        public string ProductsLossCostModifier { get; set; }
        public string ProductsDeductibleFactor { get; set; }
        public string ProductsUnmodifiedRate { get; set; }
		public string ProductsRate { get; set; }
		public bool IsProductsRateEditable { get; set; }
        public bool IsProductsIncluded { get; set; }

        public string AdditionalModifier { get; set; }
        public string CompanyLossCostMultiplier { get; set; }
        public bool IsPremisesARated { get; set; }
        public bool IsProductsARated { get; set; }
    }
}
