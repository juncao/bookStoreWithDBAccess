<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmCategoryItemEdit.aspx.cs" Inherits="FrmCategoryItemEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<div>

       <asp:Label ID="Label0" runat="server" Font-Size="Large" Height="32px" Style="z-index: 115;
          left: 19px; position: absolute; top: 54px" Width="444px">Category Details new</asp:Label>

       <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 19px; position: absolute;
          top: 94px">Label</asp:Label>
       <asp:Label ID="Label2" runat="server" Style="z-index: 113; left: 19px; position: absolute;
          top: 131px">Label</asp:Label>
       <asp:Label ID="Label3" runat="server" Style="z-index: 110; left: 19px; position: absolute;
          top: 168px; right: 868px;">Label</asp:Label>       



       <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Style="z-index: 114; left: 137px;
          position: absolute; top: 91px" Width="320px"></asp:TextBox>
       <asp:TextBox ID="TextBox2" runat="server" Style="z-index: 112; left: 137px;
          position: absolute; top: 128px" Width="320px" MaxLength="15"></asp:TextBox>
       <asp:TextBox ID="TextBox3" runat="server" Style="z-index: 111; left: 137px;
          position: absolute; top: 165px" Width="320px"></asp:TextBox>


       <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Style="z-index: 101;
          left: 20px; position: absolute; top: 365px; " Text="Return to maintenance page" 
            Width="200px" />
       <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Style="z-index: 101;
          left: 246px; position: absolute; top: 365px" Text="Update" Width="100px" 
           Visible="False" />
       <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Style="z-index: 101;
          left: 380px; position: absolute; top: 365px; right: 441px;" Text="Insert" Width="100px" 
           Visible="False" />
       <asp:Button ID="btnReplace" runat="server" OnClick="btnReplace_Click" Style="z-index: 101;
          left: 15px; position: absolute; top: 431px" Text="Replace" Width="100px" 
           Visible="False" />
       <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Style="z-index: 101;
          left: 142px; position: absolute; top: 428px; right: 679px;" Text="Cancel" 
           Width="100px" Visible="False" />


    </div>
    <p>
        &nbsp;</p>
       <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Style="z-index: 101;
          left: 381px; position: absolute; top: 431px" Text="Delete" 
        Width="100px" />


    </form>
</body>
</html>
