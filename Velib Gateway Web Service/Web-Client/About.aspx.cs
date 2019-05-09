using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Client.IntermediaryDecaux;

namespace Web_Client
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ValidateForm(object sender, EventArgs e)
        {
            Button1.Text += 1;
            IntermediaryDecauxClient client = new IntermediaryDecauxClient();
            TextBox1.Text = client.GetCities(14);
        }
    }
}