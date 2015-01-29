using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrintPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string fileToPrint = (string)Session["print_data"];
        Session.Remove("print_data");
        lblData.Text = File.ReadAllText(fileToPrint);
    }
}