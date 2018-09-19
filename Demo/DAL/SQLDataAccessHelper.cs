using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Demo
{
    public static class SQLDataAccessHelper
    {

        public static string ConnectionString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumCommandType">Enum CommandType: CommandType Text or CommandType StoreProcedure</param>
        /// <param name="query_string">Query string</param>
        /// <param name="parameter">Danh sách tham số</param>
        /// <param name="valuecollection">Danh sách giá trị tương ứng tham số</param>
        /// <exception cref="InvalidOperationException">Open() or Fill()</exception>
        /// <exception cref="SqlException">Open()</exception>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">Open()</exception>
        /// <exception cref="ArgumentException">.CommandType</exception>
        /// <exception cref="SqlException">lỗi SqlException</exception>
        /// <exception cref="IndexOutOfRangeException">kiểm tra lại số lượng danh sách tham số IndexOutOfRangeException</exception>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteQuery(CommandType enumCommandType, string CommandText, 
            List<string> InputParamNames, List<object> InputValueCollection, 
            List<string> OutputParamNames, List<SqlDbType> OutputParamDBType, out List<object> OutputValueCollection, 
            string ReturnParamName, SqlDbType? ReturnParamSqlDBType, out object ReturnValue
            )
        {
            DataTable dt = new DataTable();
            OutputValueCollection = new List<object>();
            ReturnValue = new object();
            using (SqlConnection connect = new SqlConnection(SQLDataAccessHelper.ConnectionString)) {
                try {
                    connect.Open();
                    SqlCommand command = connect.CreateCommand();
                    command.CommandType = enumCommandType;
                    command.CommandText = CommandText;
                    int i = 0, k = 0;
                    if (InputParamNames != null && InputParamNames.Count > 0) {
                        for (i = 0; i < InputParamNames.Count; i++)
                            command.Parameters.AddWithValue(InputParamNames[i], InputValueCollection[i]);
                    }
                    if (OutputParamNames != null && OutputParamNames.Count > 0) {
                        for (k = 0; k < OutputParamNames.Count; k++)
                            command.Parameters.Add(OutputParamNames[k], OutputParamDBType[k]).Direction = ParameterDirection.Output;
                    }
                    
                    if (!string.IsNullOrEmpty(ReturnParamName)) {
                        SqlParameter temp1 = new SqlParameter(ReturnParamName, (SqlDbType)ReturnParamSqlDBType);
                        command.Parameters.Add(temp1).Direction = ParameterDirection.ReturnValue;
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                    if (OutputParamNames != null && OutputParamNames.Count > 0) {
                        for (k = 0; k < OutputParamNames.Count; k++) {
                            object temp = command.Parameters[OutputParamNames[k].ToString()].Value;
                            OutputValueCollection.Add(temp);
                        }
                    }
                    if (!string.IsNullOrEmpty(ReturnParamName)) {
                        ReturnValue = command.Parameters[ReturnParamName.ToString()].Value;
                    }

                    adapter.Dispose();
                }
                catch (Exception ex) { throw ex; }
                finally {connect.Close();}
            }
            return dt;
        }

        public static DataTable ExecuteSP(string SPName)
        {
            List<object> temp2;
            object temp3;
            return ExecuteQuery(CommandType.StoredProcedure, SPName, null, null, null, null, out temp2, string.Empty, null, out temp3);
        }
        public static DataTable ExecuteSP(string SPName, List<string> InputParameter, List<object> InputValueCollection)
        {
            List<object> temp2;
            object temp3;
            return ExecuteQuery(CommandType.StoredProcedure, SPName, InputParameter, InputValueCollection, null, null, out temp2, string.Empty, null, out temp3);
        }
        public static DataTable ExecuteSP(string SPName, List<string> InputParameter, List<object> InputValueCollection, List<string> OutputParameter, List<SqlDbType> OutputParamDBType, out List<object> OutputValueCollection)
        {
            object temp3;
            return ExecuteQuery(CommandType.StoredProcedure, SPName, InputParameter, InputValueCollection, OutputParameter, OutputParamDBType, out OutputValueCollection, string.Empty, null, out temp3);
        }
        public static DataTable ExecuteQueryString(string Query)
        {
            List<object> temp2;
            object temp3;
            return ExecuteQuery(CommandType.Text, Query, null, null, null, null, out temp2, string.Empty, null, out temp3);
        }
        public static DataTable ExecuteQueryString(string Query, List<string> InputParameter, List<object> InputValueCollection)
        {
            List<object> temp2;
            object temp3;
            return ExecuteQuery(CommandType.Text, Query, InputParameter, InputValueCollection, null, null, out temp2, string.Empty, null, out temp3);
        }
        public static DataTable ExecuteQueryString(string Query, List<string> InputParameter, List<object> InputValueCollection, List<string> OutputParameter, List<SqlDbType> OutputParamDBType, out List<object> OutputValueCollection)
        {
            object temp3;
            return ExecuteQuery(CommandType.Text, Query, InputParameter, InputValueCollection, OutputParameter, OutputParamDBType, out OutputValueCollection, string.Empty, null, out temp3);
        }




        #region ExecuteNoneQuery

        /// <summary>
        /// 
        /// </summary>
        /// <param name="executeString"></param>
        /// <param name="parameter"></param>
        /// <param name="valuecollection"></param>
        /// <exception cref="InvalidOperationException">Open() or Fill()</exception>
        /// <exception cref="SqlException">Open();ExecuteNonQuery()</exception>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">Open()</exception>
        /// <exception cref="ArgumentException">.CommandType</exception>
        /// <returns>DataTable</returns>
        /// <exception cref="SqlException">lỗi SqlException</exception>
        /// <exception cref="IndexOutOfRangeException">kiểm tra lại số lượng danh sách tham số IndexOutOfRangeException</exception>
        /// <exception cref="InvalidCastException">ExecuteNonQuery()</exception>
        /// <exception cref="System.IO.IOException">ExecuteNonQuery()</exception>
        /// <exception cref="InvalidOperationException">ExecuteNonQuery()</exception>
        /// <exception cref="ObjectDisposedException">ExecuteNonQuery()</exception>
        /// <returns>int n: kết quả số lượng dòng bị ảnh hưởng bởi thao tác</returns>
        public static int ExecuteNoneQuery(CommandType EnumCommandType, string CommandText, List<string> InputParamNames, List<object> InputValueCollection, 
            List<string> OutputParamNames, List<SqlDbType> OutputParamDBType, out List<object> OutputValueCollection,
            string ReturnParamName, SqlDbType? ReturnParamSqlDBType, out object ReturnValue)
        {
            int n = 0;
            OutputValueCollection = new List<object>();
            ReturnValue = new object();
            using (SqlConnection connect = new SqlConnection(ConnectionString)) {
                try {
                    connect.Open();
                    SqlCommand command = connect.CreateCommand();
                    command.CommandType = EnumCommandType;
                    command.CommandText = CommandText;
                    int i = 0, k = 0;
                    if (InputParamNames != null && InputParamNames.Count > 0) {
                        for (i = 0; i < InputParamNames.Count; i++)
                            command.Parameters.AddWithValue(InputParamNames[i], InputValueCollection[i]);
                    }
                    if (OutputParamNames != null && OutputParamNames.Count > 0) {
                        for (k = 0; k < OutputParamNames.Count; k++)
                            command.Parameters.Add(OutputParamNames[k], OutputParamDBType[k]).Direction = ParameterDirection.Output;
                    }

                    if (!string.IsNullOrEmpty(ReturnParamName)) {
                        SqlParameter temp1 = new SqlParameter(ReturnParamName, (SqlDbType)ReturnParamSqlDBType);
                        command.Parameters.Add(temp1).Direction = ParameterDirection.ReturnValue;
                    }

                    n = command.ExecuteNonQuery();
                    if (OutputParamNames != null && OutputParamNames.Count > 0) {
                        for (k = 0; k < OutputParamNames.Count; k++) {
                            object temp = command.Parameters[OutputParamNames[k].ToString()].Value;
                            OutputValueCollection.Add(temp);
                        }
                    }
                    if (!string.IsNullOrEmpty(ReturnParamName)) {
                        ReturnValue = command.Parameters[ReturnParamName.ToString()].Value;
                    }
                }
                catch (Exception ex) {
                    throw ex;
                }
                finally { connect.Close(); }
            }
            return n;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="executeString"></param>
        /// <param name="parameter"></param>
        /// <param name="valuecollection"></param>
        /// <exception cref="InvalidOperationException">Open() or Fill()</exception>
        /// <exception cref="SqlException">Open();ExecuteNonQuery()</exception>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">Open()</exception>
        /// <exception cref="ArgumentException">.CommandType</exception>
        /// <returns>DataTable</returns>
        /// <exception cref="SqlException">lỗi SqlException</exception>
        /// <exception cref="IndexOutOfRangeException">kiểm tra lại số lượng danh sách tham số IndexOutOfRangeException</exception>
        /// <exception cref="InvalidCastException">ExecuteNonQuery()</exception>
        /// <exception cref="System.IO.IOException">ExecuteNonQuery()</exception>
        /// <exception cref="InvalidOperationException">ExecuteNonQuery()</exception>
        /// <exception cref="ObjectDisposedException">ExecuteNonQuery()</exception>
        /// <returns>int n: kết quả số lượng dòng bị ảnh hưởng bởi thao tác</returns>
        public static int ExecuteNoneQuery(CommandType EnumCommandType, string CommandText, List<string> InputParameter, List<object> InputValueCollection)
        {
            int n = 0;
            using (SqlConnection connect = new SqlConnection(ConnectionString)) {
                try {
                    connect.Open();
                    SqlCommand command = connect.CreateCommand();
                    command.CommandType = EnumCommandType;
                    command.CommandText = CommandText;

                    if (InputParameter != null) {
                        for (int i = 0; i < InputParameter.Count; i++)
                            command.Parameters.AddWithValue(InputParameter[i], InputValueCollection[i]);
                    }

                    n = command.ExecuteNonQuery();
                }
                catch (Exception ex) {
                    throw ex;
                }
                finally { connect.Close(); }
            }
            return n;
        }
        #endregion
        public static int ExecuteNoneQuerySP(string SPName)
        {
            List<object> temp2;
            object temp3;
            return ExecuteNoneQuery(CommandType.StoredProcedure, SPName, null, null, null, null, out temp2, string.Empty, null, out temp3);
        }
        public static int ExecuteNoneQuerySP(string SPName, List<string> InputParameter, List<object> InputValueCollection)
        {
            List<object> temp2;
            object temp3;
            return ExecuteNoneQuery(CommandType.StoredProcedure, SPName, InputParameter, InputValueCollection, null, null, out temp2, string.Empty, null, out temp3);
        }
        public static int ExecuteNoneQuerySP(string SPName, List<string> InputParameter, List<object> InputValueCollection, List<string> OutputParameter, List<SqlDbType> OutputParamDBType, out List<object> OutputValueCollection)
        {
            object temp3;
            return ExecuteNoneQuery(CommandType.StoredProcedure, SPName, InputParameter, InputValueCollection, OutputParameter, OutputParamDBType, out OutputValueCollection, string.Empty, null, out temp3);
        }
        public static int ExecuteNoneQueryString(string Query)
        {
            List<object> temp2;
            object temp3;
            return ExecuteNoneQuery(CommandType.Text, Query, null, null, null, null, out temp2, string.Empty, null, out temp3);
        }
        public static int ExecuteNoneQueryString(string Query, List<string> InputParameter, List<object> InputValueCollection)
        {
            List<object> temp2;
            object temp3;
            return ExecuteNoneQuery(CommandType.Text, Query, InputParameter, InputValueCollection, null, null, out temp2, string.Empty, null, out temp3);
        }
        public static int ExecuteNoneQueryString(string Query, List<string> InputParameter, List<object> InputValueCollection, List<string> OutputParameter, List<SqlDbType> OutputParamDBType, out List<object> OutputValueCollection)
        {
            object temp3;
            return ExecuteNoneQuery(CommandType.Text, Query, InputParameter, InputValueCollection, OutputParameter, OutputParamDBType, out OutputValueCollection, string.Empty, null, out temp3);
        }



        /// <summary>
        /// Kiểm tra có kết nối được cơ sở dữ liệu hay không
        /// </summary>
        /// <returns>true if successful</returns>
        public static bool TestConnection(string pConnectionString)
        {
            bool kq = false;
            using (SqlConnection connection = new SqlConnection(pConnectionString))
                try {
                    connection.Open();
                    kq = true;
                }
                catch (Exception ex) {
                    throw ex;                    
                }
                finally {
                    connection.Close();
                }
            return kq;
        }


    }

}
