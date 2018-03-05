using System;

namespace RSUI.BA.Rating.Model.Entities.Shared
{
    public class ClassCodeBase
    {
        public string Number { get; set; }
		public string Subcode { get; set; }
		public string Description { get; set; }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is ClassCodeBase && Number != null && Subcode != null)
            {
                var temp = obj as ClassCodeBase;
                return Number.Equals(temp.Number) && Subcode.Equals(temp.Subcode);
            }
            return false;
        }
    }
}
