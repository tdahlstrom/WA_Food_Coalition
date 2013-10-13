using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Donations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtTest = new DataTable();
        dtTest.Columns.Add("FoodType", typeof(string));
        dtTest.Columns.Add("FoodAmount", typeof(string));
        dtTest.Columns.Add("Address", typeof(string));
        dtTest.Columns.Add("Distance", typeof(float));
        dtTest.Columns.Add("Status", typeof(string));
        dtTest.Columns.Add("DonationID", typeof(int));

        DataRow r = dtTest.NewRow();
        r["FoodType"] = "Cat food";
        r["FoodAmount"] = "20 cans";
        r["Address"] = "Test Dr, City";
        r["Distance"] = 1.23;
        r["Status"] = "IP";
        r["DonationID"] = 1;

        dtTest.Rows.Add(r);
        r = dtTest.NewRow();
        r["FoodType"] = "Turkey Legs";
        r["FoodAmount"] = "100 lb";
        r["Address"] = "Road, City";
        r["Distance"] = 2.33;
        r["Status"] = "Open";
        r["DonationID"] = 2;

        dtTest.Rows.Add(r);
        r = dtTest.NewRow();
        r["FoodType"] = "Baby Food";
        r["FoodAmount"] = "2 cans";
        r["Address"] = "Street, City";
        r["Distance"] = 11.23;
        r["Status"] = "Closed";
        r["DonationID"] = 3;
        dtTest.Rows.Add(r);

        gvDonations.DataSource = dtTest;
        gvDonations.DataBind();
    }

    protected void ViewDonationDetail(object sender, CommandEventArgs e)
    {
        Response.Redirect("DonationDetail.aspx?donationId=" + e.CommandArgument);
    }

    protected void gvDonation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string rowClickScript = string.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dv = (DataRowView)e.Row.DataItem;
            if (dv!= null && dv.Row != null)
            {
                rowClickScript = string.Concat("window.open('DonationDetail.aspx?donationId=", dv.Row["DonationID"], "');");
            }
            e.Row.Attributes.Add("onclick", rowClickScript);
        }
    }
}
