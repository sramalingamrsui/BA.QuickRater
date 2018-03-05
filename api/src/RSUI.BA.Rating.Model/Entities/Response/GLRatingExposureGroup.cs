using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using RSUI.BA.Rating.Model.Entities.Shared;

namespace RSUI.BA.Rating.Model.Entities.Response
{
    public class GLRatingExposureGroup
    {
        public int GroupID { get; set; }
        public RatingExposureGroupType GroupType { get; set; }
        public string GroupTypeString
        {
            get { return GroupType.ToString(); }
        }

        [JsonIgnore]
        [XmlIgnore]
        public bool GroupIsHidden { get; set; }

        public List<GLRatingExposure> Exposures;
        public override bool Equals(object obj)
        {
            if (obj != null && obj is GLRatingExposureGroup)
            {
                var temp = obj as GLRatingExposureGroup;
                return GroupID.Equals(temp.GroupID);
            }
            return false;
        }
    }
}
