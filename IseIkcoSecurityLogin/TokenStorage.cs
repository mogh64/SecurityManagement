
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Data;

namespace ISE.SecurityLogin
{

    public class TokenStorage
    {

        private static int lifeTimeMinute = 1;

        public static TokenData CheckToken(string token) {
            return GetData(token);
        } 
            

        public static TokenData GetData(string tokenId)
        {
            try
            {
                TokenData data = new TokenData();
                Guid guid = new Guid(tokenId);
                OracleConnection connection = new OracleConnection("DATA SOURCE=ISE;PASSWORD=ise3a9aram;PERSIST SECURITY INFO=True;USER ID=isebase");
                OracleCommand command = new OracleCommand {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetRemoteToken"
                };
                command.Parameters.Add("id", OracleDbType.Varchar2, 0x20).Value = tokenId.ToUpper();
                command.Parameters.Add("nationalCode", OracleDbType.Varchar2, 12).Direction = ParameterDirection.Output;
                command.Parameters.Add("personelCode", OracleDbType.Varchar2, 12).Direction = ParameterDirection.Output;
                command.Parameters.Add("expiredTime", OracleDbType.Date).Direction = ParameterDirection.Output;
                command.Parameters.Add("appCode", OracleDbType.Int32).Direction = ParameterDirection.Output;
                connection.Open();
                command.ExecuteScalar();
                data.NationalCode = command.Parameters["nationalCode"].Value.ToString();
                data.PersonelCode = command.Parameters["personelCode"].Value.ToString();
                OracleDate date = (OracleDate) command.Parameters["expiredTime"].Value;
                data.ExpiredDate = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
                data.AppCode = Convert.ToInt16(command.Parameters["appCode"].Value.ToString());
                connection.Close();
                connection.Dispose();
                command.Dispose();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static void SaveToken(TokenData token)
        {
            try
            {
                OracleConnection connection = new OracleConnection("DATA SOURCE=ISE;PASSWORD=ise3a9aram;PERSIST SECURITY INFO=True;USER ID=isebase");
                OracleCommand selectCommand = new OracleCommand {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "CreateLoginToken"
                };
                selectCommand.Parameters.Add("id", OracleDbType.Varchar2, 0x20).Value = token.Token.ToUpper();
                selectCommand.Parameters.Add("nationalCode", OracleDbType.Varchar2, 12).Value = token.NationalCode;
                selectCommand.Parameters.Add("personelCode", OracleDbType.Varchar2, 12).Value = token.PersonelCode;
           
                selectCommand.Parameters.Add("appCode", OracleDbType.Int32).Value = token.AppCode;
                DataTable dataTable = new DataTable();
                new OracleDataAdapter(selectCommand).Fill(dataTable);
                connection.Close();
                connection.Dispose();
                selectCommand.Dispose();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static int StoreToken(TokenData tokenData)
        {
            SaveToken(tokenData);
            return 0;
        }

    }
}
