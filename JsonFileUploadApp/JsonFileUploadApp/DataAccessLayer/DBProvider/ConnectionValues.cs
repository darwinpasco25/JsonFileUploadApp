using System.Configuration;

namespace JsonFileUploadApp.DataAccessLayer.DBProvider
{
    public class ConnectionValues
    {

        public string defaultConn()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
    }
}
