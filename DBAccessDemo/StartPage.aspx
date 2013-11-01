<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StartPage.aspx.cs" Inherits="StartPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       &nbsp;
       </div>
    <asp:Panel ID="panelOrder" runat="server" 
        Style="z-index: 105; left: 14px; position: absolute; top: 43px; height: 256px; width: 331px;" 
        BackColor="White" Visible="False">
        <asp:Label ID="lblEMailPrompt" runat="server" Style="z-index: 100; left: 32px; position: absolute;
          top: 41px"> Enter the email that is to receive final confirmation</asp:Label>
        <asp:Button ID="btnViewCatalog" runat="server" 
    OnClick="btnViewCatalog_Click" Style="z-index: 101;
          left: 34px; position: absolute; top: 133px" Text="View Catalog" 
    Height="27px" Width="169px" />
        <asp:TextBox ID="txtEMail" runat="server" Style="z-index: 102; left: 34px; position: absolute;
          top: 94px">a@b.com</asp:TextBox>
        <asp:Label ID="lblStartButtonPrompt" runat="server" Height="24px" Style="z-index: 103;
          left: 36px; position: absolute; top: 175px" Width="232px">Click to start order process</asp:Label>
    </asp:Panel>
    <asp:Panel ID="panelMaintenance" runat="server" 
        Style="z-index: 105; left: 21px; position: absolute; top: 47px; height: 278px; width: 480px;" 
        BackColor="White" Visible="False">
        <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 32px; position: absolute;
          top: 41px; right: 233px;"> Enter the Username and Password (Case Senstive) </asp:Label>
        <asp:Button ID="btnLogon" runat="server" 
    OnClick="btnLogon_Click" Style="z-index: 101;
          left: 34px; position: absolute; top: 133px" Text="Logon" 
    Height="27px" Width="169px" />
        <asp:TextBox ID="txtAccountID" runat="server" Style="z-index: 102; left: 34px; position: absolute;
          top: 94px"></asp:TextBox>
        <asp:Label ID="lblStartLogon" runat="server" Height="24px" Style="z-index: 103;
          left: 36px; position: absolute; top: 175px" Width="232px">Click to start maintenance process</asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" Style="z-index: 103;
          left: 214px; position: absolute; top: 94px" Width="232px" 
            TextMode="Password"></asp:TextBox>
    </asp:Panel>
    <asp:Panel ID="panelStart" runat="server" 
        Style="z-index: 106; left: 35px; position: absolute; top: 67px; height: 111px; width: 262px;" 
        BackColor="White">
        <asp:Label ID="lblSelection" runat="server" Text="Please select from:"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnOrder" runat="server" Text="Place Order" 
            onclick="btnOrder_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnMaintenance" runat="server" Text="Maintenance" 
            onclick="btnMaintenance_Click" />
    </asp:Panel>
   
    </form>
</body>
</html>
