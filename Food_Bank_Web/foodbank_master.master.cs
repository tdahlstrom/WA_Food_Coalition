﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class foodbank_master : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblPageFooter.Text = string.Concat("&copy; Washington Food Coalition ",
                                            DateTime.Now.ToString("yyyy"));

        string pageName = Request.Path;
        int lastSlash = Request.Path.LastIndexOf('/');
        if (lastSlash >= 0 && lastSlash < Request.Path.Length)
        {
            pageName = Request.Path.Substring(lastSlash + 1, Request.Path.Length - lastSlash - 1);
        }

        lblPageTitle.Text = string.Concat("Page Title: ", pageName);
        if (pageName.Equals("signin.aspx", StringComparison.OrdinalIgnoreCase))
        {
            placeholderHeader.Visible = false;
        }        
    }
}
