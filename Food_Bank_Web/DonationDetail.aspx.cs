using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DonationDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblFoodType.Text = "Cat Food";
        lblFoodAmount.Text = "20 cans";
        lblAddress.Text = "123 Test Dr, City, State 12345";
        lblDistance.Text = "2.35 miles";
        lblContactName.Text = "Donald Duck";
        lblContact.Text = "123-456-7690";
        HideAll();
        phOpen.Visible = true;
    }

    protected void btnPickup_Click(object sender, EventArgs e)
    {
        HideAll();
        phInProcess.Visible = true;
    }

    protected void btnDone_Click(object sender, EventArgs e)
    {
        HideAll();
        phClose.Visible = true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        HideAll();
        phOpen.Visible = true;
    }

    protected void btnUndo_Click(object sender, EventArgs e)
    {
        HideAll();
        phOpen.Visible = true;
    }

    private void HideAll()
    {
        phOpen.Visible = false;
        phInProcess.Visible = false;
        phClose.Visible = false;
    }
}