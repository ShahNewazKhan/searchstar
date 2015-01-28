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
        <asp:TextBox ID="tbSearchField" runat="server" Width="400px"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Button" />
    </form>
</body>
</html>
