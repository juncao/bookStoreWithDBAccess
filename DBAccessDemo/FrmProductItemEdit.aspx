<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmProductItemEdit.aspx.cs" Inherits="FrmProductItemEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label0" runat="server" Font-Size="Large" Height="32px" Style="z-index: 115;
          left: 19px; position: absolute; top: 40px" Width="444px">Product Details new</asp:Label>

       <asp:Label ID="lblProductID" runat="server" Style="z-index: 100; left: 19px; position: absolute;
          top: 90px">ProductID</asp:Label>
       <asp:Label ID="lblProductName" runat="server" Style="z-index: 101; left: 19px; position: absolute;
          top: 130px">ProductName</asp:Label>
       <asp:Label ID="lblSupplierID" runat="server" Style="z-index: 102; left: 19px; position: absolute;
          top: 170px">SupplierID</asp:Label> 
       <asp:Label ID="lblCategoryID" runat="server" Style="z-index: 103; left: 19px; position: absolute;
          top: 210px">CategoryID</asp:Label>
       <asp:Label ID="lblQuantityPerUnit" runat="server" Style="z-index: 104; left: 19px; position: absolute;
          top: 250px">lblQuantityPerUnit</asp:Label>
       <asp:Label ID="lblUnitPrice" runat="server" Style="z-index: 105; left: 19px; position: absolute;
          top: 290px">UnitPrice</asp:Label>
       <asp:Label ID="lblUnitsInStock" runat="server" Style="z-index: 106; left: 19px; position: absolute;
          top: 330px">UnitsInStock</asp:Label>
       <asp:Label ID="lblUnitsOnOrder" runat="server" Style="z-index: 107; left: 19px; position: absolute;
          top: 370px">UnitsOnOrder</asp:Label>
       <asp:Label ID="lblReorderLevel" runat="server" Style="z-index: 108; left: 19px; position: absolute;
          top: 410px">ReorderLevel</asp:Label>
       <asp:Label ID="lblDiscontinued" runat="server" Style="z-index: 110; left: 19px; position: absolute;
          top: 450px">Discontinued</asp:Label>             



       <asp:TextBox ID="txtProductID" runat="server" Enabled="False" Style="z-index: 114; left: 137px;
          position: absolute; top: 90px" Width="320px"></asp:TextBox>
       <asp:TextBox ID="txtProductName" runat="server" Style="z-index: 112; left: 137px;
          position: absolute; top: 130px" Width="320px" MaxLength="40"></asp:TextBox>
       <asp:TextBox ID="txtSupplierID" runat="server" Style="z-index: 111; left: 137px;
          position: absolute; top: 170px" Width="320px"></asp:TextBox>
       <asp:TextBox ID="txtCategoryID" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 210px" Width="320px"></asp:TextBox>
       <asp:TextBox ID="txtQuantityPerUnit" runat="server" Style="z-index: 112; left: 137px;
          position: absolute; top: 250px" Width="320px" MaxLength="20"></asp:TextBox>
       <asp:TextBox ID="txtUnitPrice" runat="server" Style="z-index: 111; left: 137px;
          position: absolute; top: 290px" Width="320px"></asp:TextBox>
       <asp:TextBox ID="txtUnitsInStock" runat="server" Style="z-index: 114; left: 137px;
          position: absolute; top: 330px" Width="320px"></asp:TextBox>
       <asp:TextBox ID="txtUnitsOnOrder" runat="server" Style="z-index: 112; left: 137px;
          position: absolute; top: 370px" Width="320px"></asp:TextBox>
       <asp:TextBox ID="txtReorderLevel" runat="server" Style="z-index: 111; left: 137px;
          position: absolute; top: 410px" Width="320px"></asp:TextBox>
       <asp:TextBox ID="txtDiscontinued" runat="server" Style="z-index: 111; left: 137px;
          position: absolute; top: 450px" Width="320px" MaxLength="1"></asp:TextBox>


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


    </div>
    </form>
</body>
</html>
