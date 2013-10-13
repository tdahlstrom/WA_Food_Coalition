using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Shortages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtTest = new DataTable();
        dtTest.Columns.Add("FoodBank");
        dtTest.Columns.Add("FoodType");

        DataRow r = dtTest.NewRow();
        r["FoodBank"] = "Gingerbread House";
        r["FoodType"] = "Cookies";
        dtTest.Rows.Add(r);

        r = dtTest.NewRow();
        r["FoodBank"] = "Candy Land";
        r["FoodType"] = "Gummy Bear";
        dtTest.Rows.Add(r);

        r = dtTest.NewRow();
        r["FoodBank"] = "Bear Mountain";
        r["FoodType"] = "Honey";
        dtTest.Rows.Add(r);

        gvShortages.DataSource = dtTest;
        gvShortages.DataBind();
    }
}