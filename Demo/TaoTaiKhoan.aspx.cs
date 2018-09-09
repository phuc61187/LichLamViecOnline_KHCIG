using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class TaoTaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btClearField_Click(object sender, EventArgs e)
        {
            tbUsername.Text = string.Empty;
            tbPass1.Text = string.Empty;
            tbPass2.Text = string.Empty;
        }

        protected void btTaoTK_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO dbo.TaiKhoan(Username,  Pass,  Enable,  Note) VALUES (  N'{0}',  N'{1}',  N'{2}',  N'{3}')";
            sql = string.Format(sql, tbUsername.Text, tbPass1.Text, true, string.Empty);
            int kq = 0;
            try
            {
                string sqlconnnectionstring = @"Data Source = PHUCDESKW\SQLEXPRESS2014; Initial Catalog = LichLamViecOnline_v1; Persist Security Info = True; User ID = KHCIGDB_User ;  Password = D@n9n4ab ";
                SQLDataAccessHelper.ConnectionString = sqlconnnectionstring;
                kq = SQLDataAccessHelper.ExecNoneQueryString(sql, null, null);

            }
            catch (Exception  ex)
            {
                throw ex;
            }
            if (kq == 1) Response.Write("SUccess"); else Response.Write("Fail");
        }
    }
}