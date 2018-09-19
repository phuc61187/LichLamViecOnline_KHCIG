using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.DEMO
{
    public partial class DemoTimeEditDevExpress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TimeSpan timespan = ASPxTimeEdit1.Value.ToString();
            //Label1.te
        }

        protected void ASPxTimeEdit1_DateChanged(object sender, EventArgs e)
        {
            object obj = ASPxTimeEdit1.Value;
            string obj2 = ASPxTimeEdit1.Text;
            try {
                TextBox1.Text += obj.ToString() + "\n";
                TextBox1.Text += obj.GetType().ToString() + "\n";
                TextBox1.Text += string.Format("CastValue: {0} \n");
                TextBox1.Text += string.Format("Text: {0} \n", obj2);
            }
            catch (Exception ex) {
                TextBox1.Text += ex.ToString() + "\n";
            }

        }

        protected void ASPxTimeEdit1_ValueChanged(object sender, EventArgs e)
        {
            DateTime obj = (DateTime)ASPxTimeEdit1.Value;
            string obj2 = ASPxTimeEdit1.Text;
            
            try {
                TextBox1.Text += obj.ToString() + "\n";
                TextBox1.Text += obj.GetType().ToString() + "\n";
                TextBox1.Text += string.Format("ValueChangeCastValue: {0} \n");
                TextBox1.Text += string.Format("ValueChangeText: {0} \n", obj2);
            }
            catch (Exception ex) {
                TextBox1.Text += ex.ToString() + "\n";
            }

        }

        protected void ASPxTimeEdit2_DateChanged(object sender, EventArgs e)
        {

        }

        protected void ASPxTimeEdit2_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}