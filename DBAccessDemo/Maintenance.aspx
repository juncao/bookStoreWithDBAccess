<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Maintenance.aspx.cs" Inherits="Maintenance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">


<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
  .Initial
  {
    color: Black;
  }
  .Disabled
  {
    color: White;
    background: url("../Images/SelectedButton.png") no-repeat right top;
  }
  .Clicked
  {
    color: Red;
  }
  </style>
</head>
<body style="font-family: tahoma">
  <form id="form1" runat="server">
    <div style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
          <asp:Button Text="Customers" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server"
              OnClick="Tab1_Click" />
          <asp:Button Text="Employees" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server"
              OnClick="Tab2_Click" />
          <asp:Button Text="Categories" BorderStyle="None" ID="Tab3" CssClass="Initial" runat="server"
              OnClick="Tab3_Click" />
          <asp:Button Text="Products" BorderStyle="None" ID="Tab4" CssClass="Initial" runat="server"
              OnClick="Tab4_Click" />
          <asp:Button Text="Shippers" BorderStyle="None" ID="Tab5" CssClass="Initial" runat="server"
              OnClick="Tab5_Click" />
          <asp:Button Text="Suppliers" BorderStyle="None" ID="Tab6" CssClass="Initial" runat="server"
              OnClick="Tab6_Click" />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnLogout" runat="server" onclick="btnLogout_Click" 
              Text="Logout" />
&nbsp;<asp:MultiView ID="MainView" runat="server">
            <asp:View ID="View1" runat="server">
              <div style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                    <h3 style="height: 52px">
                        Customers</h3>                        
                      <asp:Panel ID="PanelCustomer" runat="server" style="height: 457px" 
                        ScrollBars="Auto">
                        <asp:DataGrid ID="dgCustomers" runat="server" 
                            AllowSorting="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                            OnSelectedIndexChanged="dgCustomers_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanged="dgCustomers_PageChange"
                             >
                            <Columns>
                                <asp:ButtonColumn CommandName="Select" HeaderText="Click to view" 
                                    Text="View Details">
                                    <ItemStyle Wrap="False" />
                                </asp:ButtonColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="Justify" Mode="NumericPages" PageButtonCount="3" 
                                VerticalAlign="Middle" NextPageText="" PrevPageText="" />
                        </asp:DataGrid>
                          <asp:Button ID="btnInsertNewCustomer" runat="server" 
                              onclick="btnInsertNewCustomer_Click" Text="Insert New Customer" />
                        </asp:Panel>              
              </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                    <h3 style="height: 50px">
                        Employees</h3>
                    <asp:Panel ID="PanelEmployees" runat="server" style="height: 457px">
                        <asp:DataGrid ID="dgEmployees" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                          BorderStyle="Solid" BorderWidth="1px" CellPadding="2" ForeColor="Black" Height="123px"
                          OnSelectedIndexChanged="dgEmployees_SelectedIndexChanged"  AllowSorting="True" PageSize="5" AllowPaging="True"
                          OnPageIndexChanged="dgEmployees_PageChange"
                          >
                          <Columns>
                                <asp:ButtonColumn CommandName="Select" HeaderText="Click to view" Text="View Details">
                                    <ItemStyle Wrap="False" />
                                </asp:ButtonColumn>
                          </Columns>
                            <PagerStyle Mode="NumericPages" />
                        </asp:DataGrid>
                        <asp:Button ID="btnInsertNewEmployee" runat="server" 
                            onclick="btnInsertNewEmployee_Click" Text="Insert New Employee" />
                    </asp:Panel> 
              </div>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                    <h3 style="height: 50px">
                        Categories</h3>
                     <asp:Panel ID="PanelCategories" runat="server" style="height: 457px">
                        <asp:DataGrid ID="dgCategories" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                          BorderStyle="Solid" BorderWidth="1px" CellPadding="2" ForeColor="Black" Height="123px"
                          OnSelectedIndexChanged="dgCategories_SelectedIndexChanged" 
                             AllowSorting="True" PageSize="5" AllowPaging="True"
                             OnPageIndexChanged="dgCategories_PageChange"
                          >
                          <Columns>
                                <asp:ButtonColumn CommandName="Select" HeaderText="Click to view" Text="View Details">
                                    <ItemStyle Wrap="False" />
                                </asp:ButtonColumn>
                          </Columns>
                            <PagerStyle Mode="NumericPages" />
                        </asp:DataGrid>
                        <asp:Button ID="btnInsertNewCategory" runat="server" 
                             onclick="btnInsertNewCategory_Click" Text="Insert New Category" />
                    </asp:Panel> 
              </div>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <div style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                    <h3 style="height: 50px">
                        Products</h3>
                     <asp:Panel ID="PanelProducts" runat="server" style="height: 457px">
                        <asp:DataGrid ID="dgProducts" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                          BorderStyle="Solid" BorderWidth="1px" CellPadding="2" ForeColor="Black" Height="123px"
                          OnSelectedIndexChanged="dgProducts_SelectedIndexChanged" AllowSorting="True" 
                             PageSize="5" AllowPaging="True" OnPageIndexChanged="dgProducts_PageChange"
                          >
                          <Columns>
                                <asp:ButtonColumn CommandName="Select" HeaderText="Click to view" Text="View Details">
                                    <ItemStyle Wrap="False" />
                                </asp:ButtonColumn>
                          </Columns>
                            <PagerStyle Mode="NumericPages" />
                        </asp:DataGrid>
                         <asp:Button ID="btnInsertNewProduct" runat="server" 
                             onclick="btnInsertNewProduct_Click" Text="Insert New Product" />
                    </asp:Panel> 
              </div>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <div style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                    <h3 style="height: 50px">
                        Shippers</h3>
                    <asp:Panel ID="PanelShippers" runat="server" style="height: 457px">
                        <asp:DataGrid ID="dgShippers" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                          BorderStyle="Solid" BorderWidth="1px" CellPadding="2" ForeColor="Black" Height="123px"
                          OnSelectedIndexChanged="dgShippers_SelectedIndexChanged" AllowSorting="True" 
                            PageSize="5" AllowPaging="True" OnPageIndexChanged="dgShippers_PageChange"
                          >
                          <Columns>
                                <asp:ButtonColumn CommandName="Select" HeaderText="Click to view" Text="View Details">
                                    <ItemStyle Wrap="False" />
                                </asp:ButtonColumn>
                          </Columns>
                            <PagerStyle Mode="NumericPages" />
                        </asp:DataGrid>
                        <asp:Button ID="btnInsertNewShipper" runat="server" 
                            onclick="btnInsertNewShipper_Click" Text="Insert New Shipper" />
                    </asp:Panel> 
              </div>
            </asp:View>
            <asp:View ID="View6" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                  <td>
                    <h3 style="height: 50px">
                        Suppliers</h3>
                    <asp:Panel ID="PanelSuppliers" runat="server" style="height: 457px">
                        <asp:DataGrid ID="dgSuppliers" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                          BorderStyle="Solid" BorderWidth="1px" CellPadding="2" ForeColor="Black" Height="123px"
                          OnSelectedIndexChanged="dgSuppliers_SelectedIndexChanged" 
                            AllowSorting="True" PageSize="5" AllowPaging="True" OnPageIndexChanged="dgSuppliers_PageChange"
                          >
                          <Columns>
                                <asp:ButtonColumn CommandName="Select" HeaderText="Click to view" Text="View Details">
                                    <ItemStyle Wrap="False" />
                                </asp:ButtonColumn>
                          </Columns>
                            <PagerStyle Mode="NumericPages" />
                        </asp:DataGrid>
                        <asp:Button ID="btnInsertNewSupplier" runat="server" 
                            onclick="btnInsertNewSupplier_Click" Text="Insert New Supplier" />
                    </asp:Panel> 
                  </td>
                </tr>
              </table>
            </asp:View>
          </asp:MultiView>
        </div>
  </form>
</body>
</html>
