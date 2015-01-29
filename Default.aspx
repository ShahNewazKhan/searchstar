﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 244px;
            height: 183px;
        }
        #TextArea1 {
            height: 395px;
            width: 811px;
        }
        #taTextBody {
            height: 449px;
            width: 770px;
        }
        #textArea {
            height: 407px;
            width: 770px;
        }
        #taFileBody {
            height: 279px;
            width: 617px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="logo" class="auto-style1" src="Assets/logo.png" /></div>
        <asp:TextBox ID="tbSearchField" runat="server" Width="443px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="search" />
        &nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btnFirst" runat="server" Height="60px" ImageUrl="~/Assets/first.png" Width="80px" />
        <asp:ImageButton ID="btnBack" runat="server" Height="60px" ImageUrl="~/Assets/back.png" Width="80px" />
        &nbsp;<asp:ImageButton ID="btnNext" runat="server" Height="60px" ImageUrl="~/Assets/next.png" Width="80px" />
        <asp:ImageButton ID="btnLast" runat="server" Height="60px" ImageUrl="~/Assets/last.png" Width="80px" />
        <br />
        <br />
        <asp:Label ID="lblDocumentName" runat="server" BackColor="White" Text="Document Name" Width="450px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPageOf" runat="server" BackColor="White" Text="File 1 of 5"></asp:Label>
&nbsp;&nbsp;
        <br />
        <br />
        <textarea id="taFileBody" name="S1" runat="server"></textarea></form>
</body>
</html>
