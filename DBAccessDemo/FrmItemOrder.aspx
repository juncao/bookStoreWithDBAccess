<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmItemOrder.aspx.cs" Inherits="FrmItemOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:Label ID="Label1" runat="server" Style="z-index: 100; left: 19px; position: absolute;
          top: 93px">Label</asp:Label>
       <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Style="z-index: 101;
          left: 22px; position: absolute; top: 361px" Text="Return to Catalog" Width="200px" />
       <asp:Button ID="btnOrder" runat="server" OnClick="btnOrder_Click" Style="z-index: 102;
          left: 365px; position: absolute; top: 359px" Text="Order" Width="100px" />
       <asp:Label ID="Label8" runat="server" Style="z-index: 103; left: 19px; position: absolute;
          top: 317px">Quanity Desired at QuantityPerUnit</asp:Label>
       <asp:Label ID="Label6" runat="server" Style="z-index: 104; left: 19px; position: absolute;
          top: 280px" Width="22px">Label</asp:Label>
       <asp:TextBox ID="TextBox6" runat="server" Enabled="False" Style="z-index: 105; left: 137px;
          position: absolute; top: 276px; text-align: right;" Width="320px"></asp:TextBox>
       <asp:Label ID="Label5" runat="server" Style="z-index: 106; left: 19px; position: absolute;
          top: 242px">Label</asp:Label>
       <asp:TextBox ID="TextBox5" runat="server" Enabled="False" Style="z-index: 107; left: 137px;
          position: absolute; top: 239px" Width="320px"></asp:TextBox>
       <asp:Label ID="Label4" runat="server" Style="z-index: 108; left: 19px; position: absolute;
          top: 205px">Label</asp:Label>
       <asp:TextBox ID="TextBox4" runat="server" Enabled="False" Style="z-index: 109; left: 137px;
          position: absolute; top: 202px" Width="320px"></asp:TextBox>
       <asp:Label ID="Label3" runat="server" Style="z-index: 110; left: 19px; position: absolute;
          top: 168px">Label</asp:Label>
       <asp:TextBox ID="TextBox3" runat="server" Enabled="False" Style="z-index: 111; left: 137px;
          position: absolute; top: 165px" Width="320px"></asp:TextBox>
       <asp:TextBox ID="TextBox2" runat="server" Enabled="False" Style="z-index: 112; left: 137px;
          position: absolute; top: 128px" Width="320px"></asp:TextBox>
       <asp:Label ID="Label2" runat="server" Style="z-index: 113; left: 19px; position: absolute;
          top: 131px">Label</asp:Label>
       <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Style="z-index: 114; left: 137px;
          position: absolute; top: 91px" Width="320px"></asp:TextBox>
       <asp:Label ID="Label7" runat="server" Font-Size="Large" Height="32px" Style="z-index: 115;
          left: 19px; position: absolute; top: 54px" Width="444px">Product Details new</asp:Label>
       <asp:TextBox ID="txtQuantity" runat="server" Style="z-index: 117; left: 297px; position: absolute;
          top: 314px; text-align: right;" Width="160px"></asp:TextBox>
    
    <asp:Panel ID="duplicateProductPanel" runat="server" 
            Style="z-index: 120;
          left: 23px; position: absolute; top: 366px; height: 96px; right: 699px; width: 371px;" 
            Visible="False">
        <div class="style1">
            &nbsp;<asp:Button ID="replaceButton" runat="server" onclick="replaceButton_Click" 
                Text="Replace existing order by new order" Width="270px" />
            <asp:Button ID="addValueButton" runat="server" onclick="addValueButton_Click" 
                style="margin-left: 4px" Text="Add quantity to existing order " Width="270px" />
            &nbsp;<br /> &nbsp;<asp:Button ID="ignoreButton" runat="server" 
                onclick="ignoreButton_Click" style="margin-left: 0px" Text="Ignore new order" 
                Width="270px" />
            <br />
        </div>
    </asp:Panel>
    </div>
    
    </form>
</body>
</html>
