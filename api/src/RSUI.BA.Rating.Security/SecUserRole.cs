namespace RSUI.BA.Rating.Security
{
    public class SecUserRole
    {
		public int SecRoleId { get; set; }
		public int CategoryId { get; set; }
		public int IsFixed { get; set; }
		public string RoleName { get; set; }
		public string Comment { get; set; }
	}
}