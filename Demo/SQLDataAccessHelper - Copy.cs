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
        public static DataTable ExecuteQuery(CommandType enumCommandType, string CommandText, string[] InputParameter, object[] InputValueCollection, string[] OutputParameter, ref object[] OutputValueCollection)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connect = new SqlConnection(SQLDataAccessHelper.ConnectionString)) {
                try {
                    connect.Open();
                    SqlCommand command = connect.CreateCommand();
                    command.CommandType = enumCommandType;
                    command.CommandText = CommandText;

                    if (InputParameter != null) {
                        for (int i = 0; i < InputParameter.Length; i++)
                            command.Parameters.AddWithValue(InputParameter[i], InputValueCollection[i]);
                    }
                    if (OutputParameter != null) {
                        for (int i = 0; i < OutputParameter.Length; i++)
                            command.Parameters.AddWithValue(OutputParameter[i], OutputValueCollection[i]).Direction = ParameterDirection.Output;
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                    adapter.Dispose();
                }
                catch (Exception ex) { throw ex; }
                finally {connect.Close();}
            }
            return dt;
        }

        public static DataTable ExecuteSP (string SPName, string[] InputParameter, object[] InputValueCollection, string[] OutputParameter, ref object[] OutputValueCollection)
        {
            return ExecuteQuery(CommandType.StoredProcedure, SPName, InputParameter, InputValueCollection, OutputParameter, ref OutputValueCollection);
        }
        public static DataTable ExecuteSP (string SPName)
        {
            object[] outvaluecollection = null;
            return ExecuteQuery(CommandType.StoredProcedure, SPName, null, null, null, ref outvaluecollection);
        }
        public static DataTable ExecuteQueryString (string Query, string[] InputParameter, object[] InputValueCollection, string[] OutputParameter, ref object[] OutputValueCollection)
        {
            return ExecuteQuery(CommandType.Text, Query, InputParameter, InputValueCollection, OutputParameter, ref OutputValueCollection);
        }
        public static DataTable ExecuteQueryString (string Query)
        {
            object[] outvaluecollection = null;
            return ExecuteQuery(CommandType.Text, Query, null, null, null, ref outvaluecollection);
        }



        //END OK REgion---------------------------------------------------------------------


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
        public static int ExecuteNoneQuery(CommandType EnumCommandType, string CommandText, string[] InputParameter, object[] InputValueCollection, string[] OutputParameter, ref object[] OutputValueCollection)
        {
            int n = 0;
            using (SqlConnection connect = new SqlConnection(ConnectionString))            {
                try {
                    connect.Open();
                    SqlCommand command = connect.CreateCommand();
                    command.CommandType = EnumCommandType;
                    command.CommandText = CommandText;

                    if (InputParameter != null){
                        for (int i = 0; i < InputParameter.Length; i++)
                            command.Parameters.AddWithValue(InputParameter[i], InputValueCollection[i]);
                    }
                    if (OutputParameter != null) {
                        for(int i=0; i < OutputParameter.Length; i++)
                            command.Parameters.AddWithValue(OutputParameter[i], OutputValueCollection[i]).Direction = ParameterDirection.Output;
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
        public static int ExecuteNoneQuerySP(string SPName, string[] InputParameter, object[] InputValueCollection, string[] OutputParameter, ref object[] OutputValueCollection)
        {
            return ExecuteNoneQuery(CommandType.StoredProcedure, SPName, InputParameter, InputValueCollection, OutputParameter, ref OutputValueCollection);
        }
        public static int ExecuteNoneQuerySP(string SPName)
        {
            object[] OutputValueCollection = null;
            return ExecuteNoneQuery(CommandType.StoredProcedure, SPName, null, null, null, ref OutputValueCollection);
        }

        public static int ExecuteNoneQueryString(string QueryString, string[] InputParameter, object[] InputValueCollection, string[] OutputParameter, ref object[] OutputValueCollection)
        {
            return ExecuteNoneQuery(CommandType.Text, QueryString, InputParameter, InputValueCollection, OutputParameter, ref OutputValueCollection);
        }
        public static int ExecuteNoneQueryString(string QueryString)
        {
            object[] OutputValueCollection = null;
            return ExecuteNoneQuery(CommandType.Text, QueryString, null, null, null, ref OutputValueCollection);
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
