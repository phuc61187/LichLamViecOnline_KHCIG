using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e) {
            //tbd region
            SQLDataAccessHelper.ConnectionString = Properties.Settings.Default.ConnectionString.ToString();
            //tbd endregion

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = string.Format ("Xin chào, {0}.", ((Session["Username"] != null) ? Session["Username"] : "Khách"));
        }
    }
}