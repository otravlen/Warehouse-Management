using DotNetEnv;

namespace Backend
{
	public class Config
	{
		public Config() 
		{
			SetConnectionString();
		}

		private string SQLConnectiongString;

		public string GetConnectionString() => SQLConnectiongString;
		private void SetConnectionString()
		{
			string server = Env.GetString("SERVER");
			string dataBase = Env.GetString("DATABASE");
			string trustedConnection = "True";
			string cert = "True";

			SQLConnectiongString =
				$"Server={server};" +
				$"Database={dataBase};" +
				$"Trusted_Connection={trustedConnection};" +
				$"TrustServerCertificate={cert}";
		}	
	}
}
