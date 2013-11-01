<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CatalogDisplay.aspx.cs" Inherits="CatalogDisplay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
       &nbsp;
       <asp:Panel ID="Panel1" runat="server" Height="50px" Style="z-index: 100; left: 10px;
          position: absolute; top: 18px" Width="526px">
       <asp:Button ID="btnCheckout" runat="server" OnClick="btnCheckout_Click" Style="z-index: 100;
          left: 1px; position: relative; top: 12px" Text="Review and Checkout" Width="200px" />
       <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Style="z-index: 102;
          left: 216px; position: relative; top: 12px" Text="Cancel Order" Width="100px" />
       </asp:Panel>
       &nbsp;
       <asp:DataGrid ID="dgProducts" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
          BorderStyle="Solid" BorderWidth="1px" CellPadding="2" ForeColor="Black" Height="123px"
          OnSelectedIndexChanged="dgProducts_SelectedIndexChanged" PageSize="3" Style="z-index: 101;
          left: 11px; position: absolute; top: 68px" Width="228px" AllowSorting="True">
          <Columns>
             <asp:ButtonColumn CommandName="Select" HeaderText="Click to view" Text="View Details">
                <ItemStyle Wrap="False" />
             </asp:ButtonColumn>
          </Columns>
       </asp:DataGrid>
 
    </form>
</body>
</html>
