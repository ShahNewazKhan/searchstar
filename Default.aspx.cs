using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strDir = MapPath("./texts/files");
        string[] arrFiles = Directory.GetFiles(strDir, "*.*");

        for (int ndx = 0; ndx < arrFiles.Length; ndx++)
        {
            // Get filename portion only
            string strFile = Path.GetFileName(arrFiles[ndx]);
            
            // required if the filename contains any spaces, etc.
            strFile = Server.UrlPathEncode(strFile);

            System.IO.StreamReader rdr = new System.IO.StreamReader(arrFiles[ndx]);

            taFileBody.InnerText = rdr.ReadToEnd() ;
        }

    }
}