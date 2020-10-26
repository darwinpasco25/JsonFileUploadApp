using JsonFileUploadApp.DataAccessLayer.DBProvider;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;


namespace JsonFileUploadApp.DataAccessLayer.DAO
{
    public class SalesDAO
    {

        public SalesDAO()
        {
        }

        ///<summary>
        ///<para>Increase the max allowed packet of the mysql database for large files</para>
        ///<para>valid only for this database session</para>
        ///<para>Use only if necessary</para>
        ///</summary>
        public void SetMaxAllowedPacket()
        {
            ConnectionValues ConnStr = new ConnectionValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.defaultConn());

            try
            {
                sqldb.ExecuteReader("SetMaxAllowedPacket", CommandType.StoredProcedure);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///<para>Submit the json to string to a stored procedure in the database</para>
        ///<para>Returns an output parameter indicating whethe the upload is successful(1) or not successful(0 or mysql error code) </para>
        ///</summary>
        public void ImportSalesFile(string JSONString, out int outResult)
        {
            ConnectionValues ConnStr = new ConnectionValues();
            MySqlDatabase sqldb = new MySqlDatabase(ConnStr.defaultConn());

            MySqlParameter[] @params = new MySqlParameter[2];

            @params[0] = new MySqlParameter(Parameters.JSON_STRING, MySqlDbType.JSON);
            @params[0].Value = JSONString;

            @params[1] = new MySqlParameter(Parameters.RESULT, MySqlDbType.Int32);
            @params[1].Direction = ParameterDirection.Output;

            try
            {
                sqldb.ExecuteReader("ImportSalesData", CommandType.StoredProcedure, @params);
                outResult = int.Parse(@params[1].Value.ToString());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
          }
    }
}
