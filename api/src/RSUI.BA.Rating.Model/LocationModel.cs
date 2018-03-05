using System.Xml.Serialization;
using Newtonsoft.Json;
using NHibernate.Cfg;
using Environment = System.Environment;

namespace RSUI.BA.Rating.Model
{
    public class LocationModel
    {
        [JsonProperty(Order = 100)]
        public int PremisesNumber { get; set; }
        [JsonProperty(Order = 400)]
        public string City { get; set; }
        [JsonProperty(Order = 500)]
        public string ZipCode { get; set; }
        [JsonProperty(Order = 700)]
        public string State { get; set; }
        [JsonProperty(Order = 900)]
        public string TerritoryCode { get; set; }

        public override string ToString()
        {
            return string.Format(
                    "City: {1}{0}ZipCode: {2}{0}State: {3}{0}TerritoryCode: {4}{0}PremisesNumber: {5}{0}",Environment.NewLine,
                    City, ZipCode, State, TerritoryCode, PremisesNumber);
        }
    }
}
