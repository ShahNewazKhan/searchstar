using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{

    protected List<string> exclusions = new List<string>(); // List to all the exclusion words
    protected List<string> filesFound = new List<string>(); // List of files with search term
    protected List<string> searchTerm = new List<string>(); // List of search terms

    protected void Page_Load(object sender, EventArgs e)
    {
        string strDir = MapPath("./texts/exclusion");
        string[] arrFiles = Directory.GetFiles(strDir, "*.*");

        System.IO.StreamReader rdr = new System.IO.StreamReader(arrFiles[0]);

        exclusions = rdr.ReadToEnd().Split('\n').ToList<string>();
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        searchTerm = tbSearchField.Text.Split(' ').ToList<string>();

        for (int i = 0; i < exclusions.Count; i++)
        {
            //Trim newline from each exclusion item
            exclusions[i] = exclusions[i].Trim();
            
            if (searchTerm.Contains( exclusions[i] ) )
                searchTerm.Remove( exclusions[i] );
        }

        string strDir = MapPath("./texts/files");
        string[] arrFiles = Directory.GetFiles(strDir, "*.*");

        
        for (int ndx = 0; ndx < arrFiles.Length; ndx++)
        {
            // Get filename portion only
            string strFile = Path.GetFileName(arrFiles[ndx]);
            
            // Required if the filename contains any spaces, etc.
            strFile = Server.UrlPathEncode(strFile);

            System.IO.StreamReader rdr = new System.IO.StreamReader(arrFiles[ndx]);

            string fileContents = rdr.ReadToEnd();

            for (int i = 0; i < searchTerm.Count; i++ )
                if ( fileContents.Contains( searchTerm[i] ) )
                    filesFound.Add( arrFiles[ndx] );

            taFileBody.InnerText = "Files found: " + filesFound.Count.ToString();
        }

    }
}