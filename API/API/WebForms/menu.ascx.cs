using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Food_Bank_Web
{
    public partial class menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UpdateMenu();
            }
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
                        case "map":
                            pageName = "maps.aspx";
                            break;
                        case "settings":
                            pageName = "settings.aspx";
                            break;
                        case "logout":
                            Logout();
                            pageName = "login.aspx";
                            break;
                        default:
                            break;
                    }

                    Response.Redirect(pageName);
                }
            }
        }
        public void UpdateMenu()
        {
            string pageName = Request.Path;
            int lastSlash = Request.Path.LastIndexOf('/');
            if (lastSlash >= 0 && lastSlash < Request.Path.Length)
            {
                pageName = Request.Path.Substring(lastSlash + 1, Request.Path.Length - lastSlash - 1);
            }

            liSettings.Attributes["class"] = "";
            liDonations.Attributes["class"] = "";
            liShortages.Attributes["class"] = "";
            liLogout.Attributes["class"] = "";

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

        private void Logout()
        {
        }
    }
}