using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo2
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


        }
    }
}