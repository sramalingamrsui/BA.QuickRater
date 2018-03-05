using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace RSUI.BA.Rating.Security
{
	public class SecDataContext : DataContext
	{

		public SecDataContext(string fileOrServerOrConnection)
			: base(fileOrServerOrConnection)
		{
		}


		public SecDataContext(IDbConnection connection)
			: base(connection)
		{
		}

		[Function(Name = "usp_sec_GetRolesForUser", IsComposable = false)]
		public ISingleResult<SecUserRole> GetRolesForUser(
			[Parameter(Name = "UserName", DbType = "VarChar(60)")]
			string userName,
			[Parameter(Name = "SecApplicationID", DbType = "Int")]
			int? secApplicationID)
		{
			IExecuteResult objResult = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userName, secApplicationID);

			ISingleResult<SecUserRole> objresults =
				(ISingleResult<SecUserRole>)objResult.ReturnValue;

			return objresults;
		}
	}
}
