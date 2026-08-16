using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;


namespace DAL.Helper
{
    public class SQLHelper
    {
        private static readonly string _sqlConnectionString = "";
        static SQLHelper()
        {
            _sqlConnectionString = ConfigurationHelper.GetConfig("Parkingconfig:ConnectionString");

        }

        public static DataSet ExecuteDataset(string spName, Dictionary<string, dynamic> parameters = null)
        {

            Microsoft.Data.SqlClient.SqlParameter[] param = new Microsoft.Data.SqlClient.SqlParameter[] { };
            using (Microsoft.Data.SqlClient.SqlConnection connection = new Microsoft.Data.SqlClient.SqlConnection(_sqlConnectionString))
            {
                connection.Open();
                if (parameters != null )
                {
                    param = DictionaryToSqlParameterArray(parameters);
                }

                using (Microsoft.Data.SqlClient.SqlCommand cmd = CreateCommand(connection, CommandType.StoredProcedure, spName, param))
                {
                    return CreateDataSet(cmd);
                }

            }

        }




        private static Microsoft.Data.SqlClient.SqlCommand CreateCommand
            (Microsoft.Data.SqlClient.SqlConnection connection ,CommandType commandType,string spName,params object[] values) 
        {
            try
            {
                if(connection!=null && connection.State == ConnectionState.Closed)
                {
                    connection.Open();

                }
                var command = new Microsoft.Data.SqlClient.SqlCommand
                {
                    Connection = connection,
                    CommandText = spName,
                    CommandType = commandType
                };

                // Append each parameter to the command
                if (values == null || values.Length == 0)
                {
                    if (values == null)
                    {
                        return command;
                    }
                    else
                    {
                         int j = 0;
                        foreach (var item in values)
                        {
                         
                            command.Parameters[j].Value = DBNull.Value;
                            j++;
                        }
                     
                    }
                }
                else
                {
                    int k = 0;
                    foreach (var item in values)
                    {

                        command.Parameters.Add(Checkvalue(values[k]));
                        k++;
                    }
                   
                        

                }
                           
                                            
                  return command;
                }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }










        private static Microsoft.Data.SqlClient.SqlParameter[] DictionaryToSqlParameterArray(Dictionary<string, dynamic> parameters)
        {
            var sqlParameterCollection = new List<Microsoft.Data.SqlClient.SqlParameter>();
            foreach (var parameter in parameters)
            {
                sqlParameterCollection.Add(new Microsoft.Data.SqlClient.SqlParameter(parameter.Key, parameter.Value));
               
            }
            return sqlParameterCollection.ToArray();
        }
                private static DataSet CreateDataSet(Microsoft.Data.SqlClient.SqlCommand command)
        {
            try
            {
                using (Microsoft.Data.SqlClient.SqlDataAdapter dataAdapter = new Microsoft.Data.SqlClient.SqlDataAdapter(command))
                {
                    //command.ExecuteNonQuery();
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet); command.Connection.Close();
                    return dataSet;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
        private static object Checkvalue(object value)
    {
            try
            {
                if (value == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return value;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        } 
    
    
    
    
    
    
    
    }
}
