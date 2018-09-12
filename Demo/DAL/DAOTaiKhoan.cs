using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Demo.DAL
{
    public class DAOTaiKhoan
    {
        public int InsertTaiKhoan(string Username, string Pass, out int Result)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            int kq = 0;
            List<object> OutputValueCollection = new List<object>(); 
            try {
                kq = SQLDataAccessHelper.ExecuteNoneQuerySP(spn.sp_TaiKhoan_Insert.ToString(), 
                    new List<string> { spvn.Username.ToString(), spvn.Pass.ToString(), spvn.Enable.ToString(), spvn.Note.ToString() },
                    new List<object> { Username, Pass, true, string.Empty},
                    new List<string> { spvn.Result.ToString()},
                    new List<SqlDbType> { SqlDbType.Int},
                    out OutputValueCollection
                    );
                Result = (int)OutputValueCollection[0];
            }
            catch (Exception ex) { throw ex; }
            return kq;
        }
    }
}