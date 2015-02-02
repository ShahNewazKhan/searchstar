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
    protected static List<string> filesFound = new List<string>(); // List of files with search term
    protected static List<string> filesFound2 = new List<string>(); //List of files found with short path name
    protected List<string> searchTerm = new List<string>(); // List of search terms

    protected System.IO.StreamReader rdr;

    protected static int currentFile;

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

        //Exit if search term contains black space since it's alreay Split with ' '
        if (searchTerm.Contains(""))
            return;

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

            rdr = new System.IO.StreamReader(arrFiles[ndx]);

            string fileContents = rdr.ReadToEnd();
            bool found = false;

            for (int i = 0; i < searchTerm.Count; i++ )
            {
                if (fileContents.Contains(searchTerm[i]))
                {
                    found = true;
                }
                else
                {
                    break;
                }
                    
            }

            if (found)
            {
                filesFound.Add(arrFiles[ndx]);
                filesFound2.Add(strFile);
            }
                
        }

        if (filesFound.Count > 0)
        {
            currentFile = 1;

            lblDocumentName.Text = filesFound2[0];
            lblPageOf.Text = currentFile + " of " + filesFound.Count.ToString();
            rdr = new System.IO.StreamReader(filesFound[0]);
            taFileBody.InnerText = rdr.ReadToEnd();

            btnFirst.Enabled = false;
            btnBack.Enabled = false;
        }
    }
    protected void btnFirst_Click(object sender, ImageClickEventArgs e)
    {
        if(filesFound.Count() > 0)
        {
            currentFile = 1;

            lblDocumentName.Text = filesFound2[0];
            lblPageOf.Text = currentFile + " of " + filesFound.Count.ToString();
            rdr = new System.IO.StreamReader(filesFound[0]);
            taFileBody.InnerText = rdr.ReadToEnd();

            btnFirst.Enabled = false;
            btnBack.Enabled = false;

            btnLast.Enabled = true;
            btnNext.Enabled = true;
        }
    }
    protected void btnLast_Click(object sender, ImageClickEventArgs e)
    {
        if (filesFound.Count() > 0)
        {
            currentFile = filesFound.Count;

            lblDocumentName.Text = filesFound2[ currentFile - 1 ];
            lblPageOf.Text = currentFile + " of " + filesFound.Count.ToString();
            rdr = new System.IO.StreamReader(filesFound[currentFile - 1]);
            taFileBody.InnerText = rdr.ReadToEnd();

            btnLast.Enabled = false;
            btnNext.Enabled = false;

            btnFirst.Enabled = true;
            btnBack.Enabled = true;
        }

        taFileBody.InnerText = taFileBody.InnerText + " \n Button Back is " + btnBack.Enabled.ToString() +
            "\n CurrentFile is " + currentFile.ToString();
    }
    protected void btnBack_Click(object sender, ImageClickEventArgs e)
    {
        lblDocumentName.Text = currentFile.ToString();
        if (filesFound.Count() > 0 && currentFile > 1)
        {
            currentFile = --currentFile;

            lblDocumentName.Text = filesFound2[currentFile - 1];
            lblPageOf.Text = currentFile + " of " + filesFound.Count.ToString();
            rdr = new System.IO.StreamReader(filesFound[currentFile - 1]);
            taFileBody.InnerText = rdr.ReadToEnd();

            btnLast.Enabled = true;
            btnNext.Enabled = true;
        }
        else if( currentFile == 1 )
        {
            btnFirst.Enabled = false;
            btnBack.Enabled = false;
        }
    }
    protected void btnNext_Click(object sender, ImageClickEventArgs e)
    {
        lblDocumentName.Text = "Next clicked";
        if (filesFound.Count() > 0 && currentFile < filesFound.Count() )
        {
            currentFile = ++currentFile;

            lblDocumentName.Text = filesFound2[currentFile - 1];
            lblPageOf.Text = currentFile + " of " + filesFound.Count.ToString();
            rdr = new System.IO.StreamReader(filesFound[currentFile - 1]);
            taFileBody.InnerText = rdr.ReadToEnd();

            btnFirst.Enabled = true;
            btnBack.Enabled = true;
        }
        else if( currentFile == filesFound.Count())
        {
            btnLast.Enabled = false;
            btnNext.Enabled = false;
        }
    }
}