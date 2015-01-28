<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 244px;
            height: 183px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="logo" class="auto-style1" src="Assets/logo.png" /></div>
        <asp:TextBox ID="tbSearchField" runat="server" Width="443px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="search" />
        &nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btnFirst" runat="server" Height="60px" ImageUrl="~/Assets/first.png" Width="80px" />
        <asp:ImageButton ID="btnBack" runat="server" Height="60px" ImageUrl="~/Assets/back.png" Width="80px" />
        &nbsp;<asp:ImageButton ID="btnNext" runat="server" Height="60px" ImageUrl="~/Assets/next.png" Width="80px" />
        <asp:ImageButton ID="btnLast" runat="server" Height="60px" ImageUrl="~/Assets/last.png" Width="80px" />
        <br />
        <br />
        <asp:Label ID="lblDocumentName" runat="server" BackColor="#66CCFF" Text="Document Name" Width="450px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPageOf" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
