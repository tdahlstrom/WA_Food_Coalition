using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void MenuClick(object sender, EventArgs e)
    {
        if (sender.GetType() == typeof(LinkButton))
        {
            LinkButton menuItem = (LinkButton)sender;
            string pageName = string.Empty;
            if (menuItem != null)
            {
                switch (menuItem.Text.ToLower())
                {
                    case "donations":
                        pageName = "donations.aspx";
                        break;
                    case "shortages":
                        pageName = "shortages.aspx";
                        break;
                    case "settings":
                        pageName = "settings.aspx";
                        break;
                    default:
                        break;
                }

                Response.Redirect(pageName);
            }
        }
    }
    public void UpdateMenu(string pageName)
    {
        liSettings.Attributes["class"] = "";
        liDonations.Attributes["class"] = "";
        liShortages.Attributes["class"] = "";

        switch (pageName.ToLower())
        {
            case "settings.aspx":
                liSettings.Attributes["class"] = "active";
                break;
            case "donations.aspx":
            case "donationdetail.aspx":
                liDonations.Attributes["class"] = "active";
                break;
            case "shortages.aspx":
                liShortages.Attributes["class"] = "active";
                break;
            default:
                break;
        }
    }
}