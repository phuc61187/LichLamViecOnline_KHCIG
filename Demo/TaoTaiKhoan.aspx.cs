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
            int kq = 0, Result = 0 ;
            try
            {
                kq = new BUS.BUSTaiKhoan().InsertTaiKhoan(tbUsername.Text, tbPass1.Text, out Result);
            }
            catch (Exception  ex)
            {
                throw ex;
            }
            if (kq == 1) {
                // OK
            }
            else {
                if (Result == -1) {
                    //tai khoan da ton tai
                }
            }
        }
    }
}