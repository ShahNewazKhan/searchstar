<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 150px;
            height: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: xx-large">
    
        <img alt="Search Logo" class="auto-style1" src="Images/SearchLogo.png" />File Search</div>
        <p>
            <asp:TextBox ID="txtbxSearch" runat="server" Width="533px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" Width="139px" />
            <asp:Button ID="btnFirst" runat="server" OnClick="btnFirst_Click" Text="First" />
            <asp:Button ID="btnPrevious" runat="server" OnClick="btnPrevious_Click" Text="Previous" />
            <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Next" />
            <asp:Button ID="btnLast" runat="server" OnClick="btnLast_Click" Text="Last" />
        </p>
        <p>
            <asp:Label ID="lblPageName" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblPageCount" runat="server"></asp:Label>
        </p>
        <asp:TextBox ID="txtbxPageContent" runat="server" Height="374px" TextMode="MultiLine" Width="672px"></asp:TextBox>
        <asp:ImageButton ID="imgBtnPrint" runat="server" Height="48px" ImageUrl="~/Images/print-button.png" OnClick="imgBtnPrint_Click" Width="55px" />
        <asp:ImageButton ID="imgbtnSave" runat="server" Height="46px" ImageUrl="~/Images/save-icon.png" OnClick="imgbtnSave_Click" Width="53px" />
        <br />

        
        

        <p>
            &nbsp;</p>

        
        

        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>

        
        

    </form>

</body>
</html>
