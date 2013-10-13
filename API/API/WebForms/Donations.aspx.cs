using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Food_Bank_Web
{
    public partial class Donations : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ViewDonationDetail(object sender, CommandEventArgs e)
        {
            Response.Redirect("DonationDetail.aspx?donationId=" + e.CommandArgument);
        }
    }
}