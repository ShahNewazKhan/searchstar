using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private const string exclusionRelDir = @"./SearchStar/exclusion/exclusion.txt";
    private string[] exclusionList;
    private List<string> returnedFileDirs = null;
    private int listPosition;


    protected void Page_Load(object sender, EventArgs e)
    {
        //read in exclusion file    
        exclusionList = File.ReadAllLines(MapPath(exclusionRelDir));

        //if session variables have been set, set the variables to those. else set them to default
        if(Session["dir_list"] != null && Session["dir_position"] != null){
            listPosition = (int)Session["dir_position"];
            returnedFileDirs = (List<string>)Session["dir_list"];
        }
        else
        {
            listPosition = 0;
            returnedFileDirs = new List<string>();
        }


        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        returnedFileDirs = new List<string>();
        
        //get search string
        string searchString = txtbxSearch.Text;

        if (searchString == String.Empty)
        {
            lblErrorMessage.Text = "To search, please enter data into the search box";
        }
        else
        {
            lblErrorMessage.Text = "";
            //remove the unwanted words from the search string
            string[] searchWords = removeIgnoredWords(searchString.Split(' '));
            //get all of the dirs to all the files
            string[] fileList = Directory.GetFiles(MapPath("./SearchStar/files/"));

            //go through all files and find matching words to them
            foreach (string fileDir in fileList)
            {
                if (findMatches(fileDir, searchWords))
                {
                    returnedFileDirs.Add(fileDir);
                }
            }

            //return first file back to screen and set appropriate buttons
            string dirToShow = returnedFileDirs.ElementAt(listPosition);
            txtbxPageContent.Text = File.ReadAllText(dirToShow);

            //update the buttons
            updateButtons();

            //update the labels
            updateLabels(dirToShow);

            //save state to session
            saveToSession();
        }
        

    }
    // saves the array and what position the user currently is in the list to the session
    private void saveToSession()
    {
        Session["dir_list"] = returnedFileDirs;
        Session["dir_position"] = listPosition;
    }
    //updates all of the label attributes on the page
    private void updateLabels(string dirToShow)
    {
        //update label information
        lblPageCount.Text = "Result " + (listPosition + 1) + " of " + returnedFileDirs.Count;

        //update currently open doc
        lblPageName.Text = "Document: " + Path.GetFileName(dirToShow);
    }
    //updates all of the button attributes on the page
    private void updateButtons()
    {
        if (listPosition <= 0)
        {
            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
            btnLast.Enabled = true;
            btnNext.Enabled = true;
        }
        else if (listPosition >= returnedFileDirs.Count - 1)
        {
            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;
            btnLast.Enabled = false;
            btnNext.Enabled = false;
        }
        else
        {
            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;
            btnLast.Enabled = true;
            btnNext.Enabled = true;
        }
    }
    // finds all matches in the fileDir that contain any of the words in the searchWords array
    private bool findMatches(string fileDir, string[] searchWords)
    {
        string fileContent = File.ReadAllText(fileDir);
        string[] fileWords = fileContent.Split(' ');

        foreach (string word in fileWords)
        {
            foreach (string searchWord in searchWords)
            {
                if (word.Contains(searchWord))
                {
                    return true;
                }
            }
        }
        return false;
    }

    // removes from the search words all illegal words
    private string[] removeIgnoredWords(string[] words)
    {
        List<string> filteredWordsList = new List<string>();
        foreach(string word in words){
            bool exclusionFound = false;
            foreach (string excludedWord in exclusionList)
            {
                if (word.Equals(excludedWord))
                {
                    exclusionFound = true;
                    break;
                }
            }
            if (!exclusionFound)
            {
                filteredWordsList.Add(word);
            }

        }
        return filteredWordsList.ToArray<string>();
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        listPosition = 0;

        //return first file back to screen and set appropriate buttons
        string dirToShow = returnedFileDirs.ElementAt(listPosition);
        txtbxPageContent.Text = File.ReadAllText(dirToShow);

        //update the buttons
        updateButtons();

        //update the labels
        updateLabels(dirToShow);

        saveToSession();

    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        listPosition--;

        //return first file back to screen and set appropriate buttons
        string dirToShow = returnedFileDirs.ElementAt(listPosition);
        txtbxPageContent.Text = File.ReadAllText(dirToShow);

        //update the buttons
        updateButtons();

        //update the labels
        updateLabels(dirToShow);

        //save the state
        saveToSession();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        listPosition++;

        //return first file back to screen and set appropriate buttons
        string dirToShow = returnedFileDirs.ElementAt(listPosition);
        txtbxPageContent.Text = File.ReadAllText(dirToShow);

        //update the buttons
        updateButtons();

        //update the labels
        updateLabels(dirToShow);

        //save the state
        saveToSession();
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {
        listPosition = returnedFileDirs.Count-1;

        //return first file back to screen and set appropriate buttons
        string dirToShow = returnedFileDirs.ElementAt(listPosition);
        txtbxPageContent.Text = File.ReadAllText(dirToShow);

        //update the buttons
        updateButtons();

        //update the labels
        updateLabels(dirToShow);

        //save the state
        saveToSession();
    }

    protected void imgBtnPrint_Click(object sender, ImageClickEventArgs e)
    {
        string content = txtbxPageContent.Text;
        if (String.IsNullOrEmpty(content))
        {
            lblErrorMessage.Text = "You must have a file loaded in order to print it";
        }
        else
        {
            lblErrorMessage.Text = "";
            Session["print_data"] = returnedFileDirs.ElementAt(listPosition);
            Response.Redirect("PrintPage.aspx"); 
        }
        
    }
    protected void imgbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        string content = txtbxPageContent.Text;
        if (String.IsNullOrEmpty(content))
        {
            lblErrorMessage.Text = "You must have a file loaded in order to download it";
        }
        else
        {
            lblErrorMessage.Text = "";
            string dirToShow = returnedFileDirs.ElementAt(listPosition);

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(dirToShow) + ";");
            response.TransmitFile(dirToShow);
            response.Flush();
            response.End();
        }
        
    }

}