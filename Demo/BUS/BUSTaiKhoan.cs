using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.BUS
{
    public class BUSTaiKhoan
    {
        public int InsertTaiKhoan(string Username, string Pass, out int Result) {
            DAL.DAOTaiKhoan DAO = new DAL.DAOTaiKhoan();
            int kq = 0;
            Result = 0;
            try {
                kq = DAO.InsertTaiKhoan(Username, Pass, out Result);
            }
            catch (Exception ex) {
                throw ex;
            }
            return kq;
        }
    }
}