using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSUI.BA.Rating.Model
{
	public class TerritoryResponseModel
	{
		public IEnumerable<TerritoryModel> Territories { get; set; }
		public IEnumerable<string> ApiMessage { get; set; }
	}

	public class TerritoryModel
	{
		public string TerritoryCode { get; set; }
		public string TerritoryState { get; set; }
	}

	public class CityResultModel
	{
		public IEnumerable<string> Warnings { get; set; }
		public string City { get; set; }
		public string ZipCode { get; set; }
		public string County { get; set; }
		public string State { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public IEnumerable<string> Territories { get; set; }
	}
}
