using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo2
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"]!= null) Response.Redirect("~/TrangChu.aspx");

            if (IsPostBack)
            {

            }
            else {

            }
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username, pass;
            username = tbUsername.Text;
            pass = tbPass.Text;
            if (ProcessDangNhap(username, pass)) {
                Session["Username"] = username;
                Response.Redirect("~/TrangChu.aspx");
            }
            
        }

        private bool ProcessDangNhap(string username, string pass)
        {
            //throw new NotImplementedException();
            return true;
        }
    }
}