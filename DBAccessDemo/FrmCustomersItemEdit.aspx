<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmCustomersItemEdit.aspx.cs" Inherits="FrmCustomersItemEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
          <asp:Label ID="lblCustomerID" runat="server" Style="z-index: 100; left: 15px; position: absolute;
          top: 93px; right: 786px;">CustomerID</asp:Label>
          <asp:Label ID="lblCompanyName" runat="server" Style="z-index: 113; left: 15px; position: absolute;
          top: 131px">Company Name</asp:Label>
          <asp:Label ID="lblContactName" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 168px">Contact Name</asp:Label>
          <asp:Label ID="lblContactTitle" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 206px; height: 18px; width: 110px;">Contact Title</asp:Label>
          <asp:Label ID="Address" runat="server" Style="z-index: 104; left: 15px; position: absolute;
          top: 257px" Width="22px">Address</asp:Label>
          <asp:Label ID="lblCity" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 289px">City</asp:Label>
           <asp:Label ID="lblRegion" runat="server" Style="z-index: 106; left: 15px; position: absolute;
          top: 323px; height: 14px;">Region</asp:Label>
          <asp:Label ID="lblPostalCode" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 354px">Postal Code</asp:Label>
           <asp:Label ID="lblCountry" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 387px">Country</asp:Label>
          <asp:Label ID="lblPhone" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 421px">Phone</asp:Label>
          <asp:Label ID="lblFax" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 459px">Fax</asp:Label>
           


          <asp:TextBox ID="txtCustomerID" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 91px" Width="320px" MaxLength="5"></asp:TextBox>
           <asp:TextBox ID="txtCompanyName" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 128px" Width="320px" MaxLength="40"></asp:TextBox>
          <asp:TextBox ID="txtContactName" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 165px" Width="320px" MaxLength="30"></asp:TextBox>               
          <asp:TextBox ID="txtContactTitle" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 209px" Width="320px" MaxLength="30"></asp:TextBox>
          <asp:TextBox ID="txtAddres" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 251px;" Width="320px" MaxLength="60"></asp:TextBox>
          <asp:TextBox ID="txtCity" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 289px" Width="320px" MaxLength="15"></asp:TextBox>
          <asp:TextBox ID="txtRegion" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 319px" Width="320px" MaxLength="15"></asp:TextBox>
          <asp:TextBox ID="txtPostalCode" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 350px" Width="320px" MaxLength="10"></asp:TextBox>
          <asp:TextBox ID="txtCountry" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 383px; right: 416px;" Width="320px" MaxLength="15"></asp:TextBox>
          <asp:TextBox ID="txtPhone" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 418px" Width="320px" MaxLength="24"></asp:TextBox>
          <asp:TextBox ID="txtFax" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 453px" Width="320px" MaxLength="24"></asp:TextBox>
          

       <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Style="z-index: 101;
          left: 13px; position: absolute; top: 497px; margin-bottom: 15px;" Text="Return to maintenance page" 
            Width="200px" />
       <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Style="z-index: 101;
          left: 252px; position: absolute; top: 494px; right: 563px;" Text="Update" Width="100px" 
           Visible="False" />
       <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Style="z-index: 101;
          left: 376px; position: absolute; top: 493px; right: 439px;" Text="Insert" Width="100px" 
           Visible="False" />
       <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Style="z-index: 101;
          left: 135px; position: absolute; top: 536px; right: 680px;" Text="Cancel" 
           Width="100px" Visible="False" />


       <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Style="z-index: 101;
          left: 377px; position: absolute; top: 528px" Text="Delete" 
        Width="100px" />


       <asp:Button ID="btnReplace" runat="server" OnClick="btnReplace_Click" Style="z-index: 101;
          left: 13px; position: absolute; top: 537px; height: 26px;" Text="Replace" Width="100px" 
           Visible="False" />

       
          
       <asp:Label ID="lblCustomersDetails" runat="server" Font-Size="Large" 
            Height="32px" Style="z-index: 115;
          left: 19px; position: absolute; top: 54px" Width="444px">Customers Details</asp:Label>
    </div>
    </form>
</body>
</html>
