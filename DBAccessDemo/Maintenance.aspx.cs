/*******************************************************************/
/**                                                               **/
/**    Group Number                :  7                           **/
/**    Student Name                :  Jun Cao, Desen Guo          **/
/**                                :  Yue Cheng, Hong Li          **/
/**    Student Number              :  040-710-235                 **/
/**                                :  040-517-971                 **/
/**                                :  040-712-989                 **/
/**                                :  040-713-870                 **/
/**    Course Number               :  CST8256                     **/
/**    Lab Section Number          :  442                         **/
/**    Professor Name              :  John Tappin                 **/
/**    Assignment Name/Number/Date :  Assignment 4                **/
/**                                                               **/
/** ****************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Drawing;

/// <summary>
/// Class name: Maintenance
/// Class description: Provide categoried maintenace page
/// you can view partial information of every category in each row.
/// Paging the list of categories. Every page has 10 rows.
/// you can link to FrmCategoryItemEdit page to update information
/// or delete particular category record 
/// by clicking edit which show in first column of a row.
/// You can also insert new category record
/// by clicking "insert new category button" 
/// and then going to FrmCategoryItemEdit page
/// for making inserting  
/// Side effects (if any) including Errors and Exceptions: N/A
/// Constraints: none
/// Assumptions: none
/// Required libraries: 
///     using System;
///     System.Data;
///     System.Web.UI.WebControls;
///     System.Web.UI.WebControls.WebParts;
///     System.Web.UI.HtmlControls;
///     System.Data.OleDb;
///     System.Drawing;
/// Any warnings for maintenance: none
/// Unresolved issues: none
/// </summary>
public partial class Maintenance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check is there an actived view
            if (Session["ActiveViewIndex"] == null)
            {
                MainView.ActiveViewIndex = 0;
                Session.Add("ActiveViewIndex", 0);
            }
            else
            {
                MainView.ActiveViewIndex = (int)Session["ActiveViewIndex"];
            }
            // Check title to decide which tab user can view
            if (Session["Title"] == null)
            {
                Response.Redirect("StartPage.aspx");
            }
            else if (Session["Title"].ToString() == "Sales Representative")
            {
                Tab1.Enabled = true;
                Tab2.Enabled = false; 
                Tab3.Enabled = false;
                Tab4.Enabled = false;
                Tab5.Enabled = false;
                Tab6.Enabled = false;
                // Change css style for disabled tabs.
                Tab2.CssClass = "Disabled";
                Tab3.CssClass = "Disabled";
                Tab4.CssClass = "Disabled";
                Tab5.CssClass = "Disabled";
                Tab6.CssClass = "Disabled";
                // Fill datas into enabled views.
                FillCustomerGrid();
            }
            else if (Session["Title"].ToString() == "Vice President, Sales")
            {
                // Vice President, Sales can see all views
                Tab1.Enabled = true;
                Tab2.Enabled = true;
                Tab3.Enabled = true;
                Tab4.Enabled = true;
                Tab5.Enabled = true;
                Tab6.Enabled = true;
                FillCustomerGrid();
                FillProductGrid();
                FillEmployeeGrid();
                FillCategoryGrid();
                FillShipperGrid();
                FillSupplierGrid();
            }
            else
            {
                Tab1.Enabled = true;
                Tab2.Enabled = false;
                Tab3.Enabled = true;
                Tab4.Enabled = true;
                Tab5.Enabled = true;
                Tab6.Enabled = true;
                Tab2.CssClass = "Disabled";
                FillCustomerGrid();
                FillProductGrid();
                FillCategoryGrid();
                FillShipperGrid();
                FillSupplierGrid();
            }

        }
    }

    #region choose Tabs

    // Whean user click on some tabs.
    // Change the view to match tab selections.
    // Change clicked tab's style to Clicked,
    // Also change other tabs to Initial style if is enabled.
    protected void Tab1_Click(object sender, EventArgs e)
    {
        Tab1.CssClass = "Clicked";
        if (Tab2.Enabled == true) Tab2.CssClass = "Initial";
        if (Tab3.Enabled == true) Tab3.CssClass = "Initial";
        if (Tab4.Enabled == true) Tab4.CssClass = "Initial";
        if (Tab5.Enabled == true) Tab5.CssClass = "Initial";
        if (Tab6.Enabled == true) Tab6.CssClass = "Initial";
        MainView.ActiveViewIndex = 0;
        Session["ActiveViewIndex"] = 0;

    }

    protected void Tab2_Click(object sender, EventArgs e)
    {
        Tab1.CssClass = "Initial";
        Tab2.CssClass = "Clicked";
        if (Tab3.Enabled == true) Tab3.CssClass = "Initial";
        if (Tab4.Enabled == true) Tab4.CssClass = "Initial";
        if (Tab5.Enabled == true) Tab5.CssClass = "Initial";
        if (Tab6.Enabled == true) Tab6.CssClass = "Initial";
        MainView.ActiveViewIndex = 1;
        Session["ActiveViewIndex"] = 1;
    }

    protected void Tab3_Click(object sender, EventArgs e)
    {
        Tab1.CssClass = "Initial";
        if (Tab2.Enabled == true) Tab2.CssClass = "Initial";
        Tab3.CssClass = "Clicked";
        if (Tab4.Enabled == true) Tab4.CssClass = "Initial";
        if (Tab5.Enabled == true) Tab5.CssClass = "Initial";
        if (Tab6.Enabled == true) Tab6.CssClass = "Initial";
        MainView.ActiveViewIndex = 2;
        Session["ActiveViewIndex"] = 2;
    }

    protected void Tab4_Click(object sender, EventArgs e)
    {
        Tab1.CssClass = "Initial";
        if (Tab2.Enabled == true) Tab2.CssClass = "Initial";
        if (Tab3.Enabled == true) Tab3.CssClass = "Initial";
        Tab4.CssClass = "Clicked";
        if (Tab5.Enabled == true) Tab5.CssClass = "Initial";
        if (Tab6.Enabled == true) Tab6.CssClass = "Initial";
        MainView.ActiveViewIndex = 3;
        Session["ActiveViewIndex"] = 3;
    }
    protected void Tab5_Click(object sender, EventArgs e)
    {
        Tab1.CssClass = "Initial";
        if (Tab2.Enabled == true) Tab2.CssClass = "Initial";
        if (Tab3.Enabled == true) Tab3.CssClass = "Initial";
        if (Tab4.Enabled == true) Tab4.CssClass = "Initial";
        Tab5.CssClass = "Clicked";
        if (Tab6.Enabled == true) Tab6.CssClass = "Initial";
        MainView.ActiveViewIndex = 4;
        Session["ActiveViewIndex"] = 4;
    }
    protected void Tab6_Click(object sender, EventArgs e)
    {
        Tab1.CssClass = "Initial";
        if (Tab2.Enabled == true) Tab2.CssClass = "Initial";
        if (Tab3.Enabled == true) Tab3.CssClass = "Initial";
        if (Tab4.Enabled == true) Tab4.CssClass = "Initial";
        if (Tab5.Enabled == true) Tab5.CssClass = "Initial";
        Tab6.CssClass = "Clicked";
        MainView.ActiveViewIndex = 5;
        Session["ActiveViewIndex"] = 5;
    }
    #endregion

    #region grid views page change
    public void dgCustomers_PageChange(Object sender, DataGridPageChangedEventArgs e)
    {

        // Set CurrentPageIndex to the page the user clicked.
        dgCustomers.CurrentPageIndex = e.NewPageIndex;

        // Rebind the data. 
        FillCustomerGrid();
        //dgCustomers.DataBind();

    }
    public void dgEmployees_PageChange(Object sender, DataGridPageChangedEventArgs e)
    {

        // Set CurrentPageIndex to the page the user clicked.
        dgEmployees.CurrentPageIndex = e.NewPageIndex;

        FillEmployeeGrid();

    }
    public void dgCategories_PageChange(Object sender, DataGridPageChangedEventArgs e)
    {

        // Set CurrentPageIndex to the page the user clicked.
        dgCategories.CurrentPageIndex = e.NewPageIndex;

        FillCategoryGrid();

    }
    public void dgProducts_PageChange(Object sender, DataGridPageChangedEventArgs e)
    {

        // Set CurrentPageIndex to the page the user clicked.
        dgProducts.CurrentPageIndex = e.NewPageIndex;

        FillProductGrid();

    }
    public void dgShippers_PageChange(Object sender, DataGridPageChangedEventArgs e)
    {

        // Set CurrentPageIndex to the page the user clicked.
        dgShippers.CurrentPageIndex = e.NewPageIndex;

        FillShipperGrid();

    }
    public void dgSuppliers_PageChange(Object sender, DataGridPageChangedEventArgs e)
    {

        // Set CurrentPageIndex to the page the user clicked.
        dgSuppliers.CurrentPageIndex = e.NewPageIndex;

        FillSupplierGrid();

    }
    #endregion 

    #region fill gird methods
    private void FillCustomerGrid()
    {
        dgCustomers.DataSource = null;

        string[,] customerInformation = ((Business)Application["Business"]).getCustomerInformation();

        DataTable tbCustomer = new DataTable("Customer");

        DataColumn customerIDCol = new DataColumn("CustomerID");
        customerIDCol.ReadOnly = false;
        customerIDCol.DataType = System.Type.GetType("System.String");
        tbCustomer.Columns.Add(customerIDCol);

        DataColumn companyNameCol = new DataColumn("CompanyName");
        companyNameCol.ReadOnly = false;
        companyNameCol.DataType = System.Type.GetType("System.String");
        tbCustomer.Columns.Add(companyNameCol);

        DataColumn contactNameCol = new DataColumn("ContactName");
        contactNameCol.ReadOnly = false;
        contactNameCol.DataType = System.Type.GetType("System.String");
        tbCustomer.Columns.Add(contactNameCol);

        DataColumn ContactTitleCol = new DataColumn("ContactTitle");
        ContactTitleCol.ReadOnly = false;
        ContactTitleCol.DataType = System.Type.GetType("System.String");
        tbCustomer.Columns.Add(ContactTitleCol);

        // Loading up Customers in combo list
        for (int i = 0; i < customerInformation.GetLength(0); i++)
        {
            DataRow row = tbCustomer.NewRow();

            row["CustomerID"] = customerInformation[i, 0];
            row["CompanyName"] = customerInformation[i, 1];
            row["ContactName"] = customerInformation[i, 2];
            row["ContactTitle"] = customerInformation[i, 3];
            tbCustomer.Rows.Add(row);

        }

        dgCustomers.DataSource = tbCustomer;
        dgCustomers.DataBind();

    }

    private void FillEmployeeGrid()
    {

        string[,] employeeInformation = ((Business)Application["Business"]).getEmployeesInformation();

        DataTable tbEmployee = new DataTable("Employee");

        DataColumn employeeIDCol = new DataColumn("EmployeeID");
        employeeIDCol.ReadOnly = false;
        employeeIDCol.DataType = System.Type.GetType("System.String");
        tbEmployee.Columns.Add(employeeIDCol);

        DataColumn lastNameCol = new DataColumn("LastName");
        lastNameCol.ReadOnly = false;
        lastNameCol.DataType = System.Type.GetType("System.String");
        tbEmployee.Columns.Add(lastNameCol);

        DataColumn firstNameCol = new DataColumn("FirstName");
        firstNameCol.ReadOnly = false;
        firstNameCol.DataType = System.Type.GetType("System.String");
        tbEmployee.Columns.Add(firstNameCol);

        DataColumn titleCol = new DataColumn("Title");
        titleCol.ReadOnly = false;
        titleCol.DataType = System.Type.GetType("System.String");
        tbEmployee.Columns.Add(titleCol);



        // Loading up Employees in combo list
        for (int i = 0; i < employeeInformation.GetLength(0); i++)
        {
            DataRow row = tbEmployee.NewRow();

            row["EmployeeID"] = employeeInformation[i, 0];
            row["LastName"] = employeeInformation[i, 1];
            row["FirstName"] = employeeInformation[i, 2];
            row["Title"] = employeeInformation[i, 3];

            tbEmployee.Rows.Add(row);
        }

        dgEmployees.DataSource = tbEmployee;
        dgEmployees.DataBind();
    }

    private void FillCategoryGrid()
    {
        dgCategories.DataSource = null;
        string[,] categoryInformation = ((Business)Application["Business"]).getCategoryInformation();

        DataTable tbCategory = new DataTable("Category");

        DataColumn CategoryIDCol = new DataColumn("CategoryID");
        CategoryIDCol.ReadOnly = false;
        CategoryIDCol.DataType = System.Type.GetType("System.String");
        tbCategory.Columns.Add(CategoryIDCol);

        DataColumn CategoryNameCol = new DataColumn("CategoryName");
        CategoryNameCol.ReadOnly = false;
        CategoryNameCol.DataType = System.Type.GetType("System.String");
        tbCategory.Columns.Add(CategoryNameCol);

        DataColumn DescriptionCol = new DataColumn("Description");
        DescriptionCol.ReadOnly = false;
        DescriptionCol.DataType = System.Type.GetType("System.String");
        tbCategory.Columns.Add(DescriptionCol);

        // Loading up Categories in combo list
        for (int i = 0; i < categoryInformation.GetLength(0); i++)
        {
            DataRow row = tbCategory.NewRow();

            row["CategoryID"] = categoryInformation[i, 0];
            row["CategoryName"] = categoryInformation[i, 1];
            row["Description"] = categoryInformation[i, 2];

            tbCategory.Rows.Add(row);
        }


        dgCategories.DataSource = tbCategory;
        dgCategories.DataBind();

    }

    private void FillProductGrid()
    {
        dgProducts.DataSource = null;
        string[,] productsInformation = ((Business)Application["Business"]).getProductsInformation();


        DataTable tbProducts = new DataTable("Products");


        DataColumn productIDCol = new DataColumn("ProductID");
        productIDCol.ReadOnly = false;
        productIDCol.DataType = System.Type.GetType("System.String");
        tbProducts.Columns.Add(productIDCol);


        DataColumn productNameCol = new DataColumn("ProductName");
        productNameCol.ReadOnly = false;
        productNameCol.DataType = System.Type.GetType("System.String");
        tbProducts.Columns.Add(productNameCol);

        DataColumn productUnitPriceCol = new DataColumn("UnitPrice");
        productUnitPriceCol.ReadOnly = false;
        productUnitPriceCol.DataType = System.Type.GetType("System.String");
        tbProducts.Columns.Add(productUnitPriceCol);

        // Loading up Products in combo list
        for (int i = 0; i < productsInformation.GetLength(0); i++)
        {
            DataRow row = tbProducts.NewRow();

            row["ProductID"] = productsInformation[i, 0];
            row["ProductName"] = productsInformation[i, 1];
            row["UnitPrice"] = productsInformation[i, 7];

            tbProducts.Rows.Add(row);
        }

        dgProducts.DataSource = tbProducts;

        dgProducts.DataBind();
    }

    private void FillShipperGrid()
    {
        dgShippers.DataSource = null;

        string[,] shippersInformation = ((Business)Application["Business"]).getShippersInformation();


        DataTable tbShippers = new DataTable("Shippers");


        DataColumn ShipperIDCol = new DataColumn("ShipperID");
        ShipperIDCol.ReadOnly = false;
        ShipperIDCol.DataType = System.Type.GetType("System.String");
        tbShippers.Columns.Add(ShipperIDCol);


        DataColumn CompanyNameCol = new DataColumn("CompanyName");
        CompanyNameCol.ReadOnly = false;
        CompanyNameCol.DataType = System.Type.GetType("System.String");
        tbShippers.Columns.Add(CompanyNameCol);

        DataColumn PhoneCol = new DataColumn("Phone");
        PhoneCol.ReadOnly = false;
        PhoneCol.DataType = System.Type.GetType("System.String");
        tbShippers.Columns.Add(PhoneCol);

        // Loading up Shippers in combo list
        for (int i = 0; i < shippersInformation.GetLength(0); i++)
        {
            DataRow row = tbShippers.NewRow();

            row["ShipperID"] = shippersInformation[i, 0];
            row["CompanyName"] = shippersInformation[i, 1];
            row["Phone"] = shippersInformation[i, 2];

            tbShippers.Rows.Add(row);
        }

        dgShippers.DataSource = tbShippers;

        dgShippers.DataBind();
    }

    private void FillSupplierGrid()
    {
        dgSuppliers.DataSource = null;

        string[,] SupplierInformation = ((Business)Application["Business"]).getSupplierInformation();

        DataTable tbSuppliers = new DataTable("Suppliers");

        DataColumn SupplierIDCol = new DataColumn("SupplierID");
        SupplierIDCol.ReadOnly = false;
        SupplierIDCol.DataType = System.Type.GetType("System.String");
        tbSuppliers.Columns.Add(SupplierIDCol);


        DataColumn CompanyNameCol = new DataColumn("CompanyName");
        CompanyNameCol.ReadOnly = false;
        CompanyNameCol.DataType = System.Type.GetType("System.String");
        tbSuppliers.Columns.Add(CompanyNameCol);

        DataColumn ContactNameCol = new DataColumn("ContactName");
        ContactNameCol.ReadOnly = false;
        ContactNameCol.DataType = System.Type.GetType("System.String");
        tbSuppliers.Columns.Add(ContactNameCol);

        DataColumn ContactTitleCol = new DataColumn("ContactTitle");
        ContactTitleCol.ReadOnly = false;
        ContactTitleCol.DataType = System.Type.GetType("System.String");
        tbSuppliers.Columns.Add(ContactTitleCol);

        // Loading up Suppliers in combo list
        for (int i = 0; i < SupplierInformation.GetLength(0); i++)
        {
            DataRow row = tbSuppliers.NewRow();

            row["SupplierID"] = SupplierInformation[i, 0];
            row["CompanyName"] = SupplierInformation[i, 1];
            row["ContactName"] = SupplierInformation[i, 2];
            row["ContactTitle"] = SupplierInformation[i, 3];

            tbSuppliers.Rows.Add(row);
        }

        dgSuppliers.DataSource = tbSuppliers;

        dgSuppliers.DataBind();
    }

    #endregion

    #region button clicks
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        // Drop session and go back to start page.
        Session.Abandon();
        Server.Transfer("StartPage.aspx");
    }
    // When any view's slected index changed.
    // Transgfers to the detail information page.
    // Also add the selected item's ID to session
    protected void dgCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session.Add("Editing Customer Item",
            dgCustomers.Items[dgCustomers.SelectedIndex].Cells[1].Text);
        Server.Transfer("FrmCustomersItemEdit.aspx");
    }
    protected void dgEmployees_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session.Add("Editing Employee Item",
            dgEmployees.Items[dgEmployees.SelectedIndex].Cells[1].Text);
        Server.Transfer("FrmEmployeesItemEdit.aspx");
    }
    protected void dgCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session.Add("Editing Category Item",
            dgCategories.Items[dgCategories.SelectedIndex].Cells[1].Text);
        Server.Transfer("FrmCategoryItemEdit.aspx");
    }
    protected void dgProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session.Add("Editing Product Item",
            dgProducts.Items[dgProducts.SelectedIndex].Cells[1].Text);
        Server.Transfer("FrmProductItemEdit.aspx");
    }
    protected void dgShippers_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session.Add("Editing Shipper Item",
            dgShippers.Items[dgShippers.SelectedIndex].Cells[1].Text);
        Server.Transfer("FrmShippersItemEdit.aspx");
    }
    protected void dgSuppliers_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session.Add("Editing Supplier Item",
            dgSuppliers.Items[dgSuppliers.SelectedIndex].Cells[1].Text);
        Server.Transfer("FrmSuppliersItemEdit.aspx");
    }

    // Transfer user to detail information page
    // Because no item's ID selected, there will be all blank textBoxes for uer to input informations
    protected void btnInsertNewCustomer_Click(object sender, EventArgs e)
    {
        Server.Transfer("FrmCustomersItemEdit.aspx");
    }
    protected void btnInsertNewEmployee_Click(object sender, EventArgs e)
    {
        Server.Transfer("FrmEmployeesItemEdit.aspx");
    }
    protected void btnInsertNewCategory_Click(object sender, EventArgs e)
    {  
        Server.Transfer("FrmCategoryItemEdit.aspx");
    }
    protected void btnInsertNewProduct_Click(object sender, EventArgs e)
    {
        Server.Transfer("FrmProductItemEdit.aspx");
    }
    protected void btnInsertNewShipper_Click(object sender, EventArgs e)
    {
        Server.Transfer("FrmShippersItemEdit.aspx");
    }
    protected void btnInsertNewSupplier_Click(object sender, EventArgs e)
    {
        Server.Transfer("FrmSuppliersItemEdit.aspx");
    }
    #endregion

}
   