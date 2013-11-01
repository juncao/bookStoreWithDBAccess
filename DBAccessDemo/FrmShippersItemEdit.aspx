<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmShippersItemEdit.aspx.cs" Inherits="FrmShippersEditing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="lblShipperID" runat="server" Style="z-index: 100; left: 15px; position: absolute;
          top: 93px; right: 786px;">ShipperID</asp:Label>
          <asp:Label ID="lblCompanyName" runat="server" Style="z-index: 113; left: 15px; position: absolute;
          top: 131px">Company Name</asp:Label>
          <asp:Label ID="lblPhone" runat="server" Style="z-index: 110; left: 15px; position: absolute;
          top: 168px">Phone</asp:Label>
         
          
          

          <asp:TextBox ID="txtShipperID" runat="server" Enabled="False" Style="z-index: 114; left: 137px;
          position: absolute; top: 91px" Width="320px"></asp:TextBox>
          <asp:TextBox ID="txtCompanyName" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 128px" Width="320px" MaxLength="40"></asp:TextBox>
          <asp:TextBox ID="txtPhone" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 165px" Width="320px" MaxLength="24"></asp:TextBox>               
          
       <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Style="z-index: 101;
          left: 13px; position: absolute; top: 250px; margin-bottom: 15px;" Text="Return to maintenance page" 
            Width="200px" />
       <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Style="z-index: 101;
          left: 252px; position: absolute; top: 250px; right: 563px;" Text="Update" Width="100px" 
           Visible="False" />
       <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Style="z-index: 101;
          left: 376px; position: absolute; top: 250px; right: 439px;" Text="Insert" Width="100px" 
           Visible="False" />
       <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Style="z-index: 101;
          left: 135px; position: absolute; top: 310px; right: 680px;" Text="Cancel" 
           Width="100px" Visible="False" />


       <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Style="z-index: 101;
          left: 377px; position: absolute; top: 310px" Text="Delete" 
        Width="100px" />


       <asp:Button ID="btnReplace" runat="server" OnClick="btnReplace_Click" Style="z-index: 101;
          left: 13px; position: absolute; top: 310px; height: 26px;" Text="Replace" Width="100px" 
           Visible="False" />

       
          
       <asp:Label ID="lblShippersDetails" runat="server" Font-Size="Large" 
            Height="32px" Style="z-index: 115;
          left: 19px; position: absolute; top: 54px" Width="444px">Shippers Details</asp:Label>
    </div>
    </form>
</body>
</html>
