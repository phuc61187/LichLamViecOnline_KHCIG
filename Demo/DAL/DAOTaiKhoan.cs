using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Demo.DAL
{
    public class DAOTaiKhoan
    {
        public int InsertTaiKhoan(string Username, string Pass, out int Result)
        {
            int kq = 0;
            Result = 0;
            try {
                kq = SQLDataAccessHelper.ExecuteNoneQuerySP(spn.sp_TaiKhoan_Insert.ToString(), 
                    new string[] { spvn.Username.ToString(), spvn.Pass.ToString(), spvn.Enable.ToString(), spvn.Note.ToString() },
                    new object[] { Username, Pass, true, string.Empty},
                    new string[] { spvn.Result.ToString()},
                    new object[] { Result}); 
            }
            catch (Exception ex) { throw ex; }
            return kq;
        }
    }
}