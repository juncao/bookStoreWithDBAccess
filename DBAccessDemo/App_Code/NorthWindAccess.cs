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
using System.Data.OleDb;

/// <summary>
/// The The Data Access Layer of an application
/// Modified on John Tappin's  2005 version
/// This updated verison can reply 2 d string list for 
/// Customers, Employees, Suppliers, Shippers, Categories and Products
/// Also have insert, update, delet functions for all above 6 tables
/// </summary>
public class NorthWindAccess
{
    #region The data members
    public event Business.Update employeeInfChange;
    public event Business.Update customerInfChange;
    public event Business.Update productInfChange;
    public event Business.Update categoryInfChange;
    public event Business.Update ShipperInfChange;
    public event Business.Update SupplierInfChange;
   
    private OleDbConnection NWConnection;
    private OleDbCommand NWSelectCommand;
    private OleDbCommand NWInsertCommand;
    private OleDbCommand NWUpdateCommand;
    private OleDbCommand NWDeleteCommand;
    private OleDbDataAdapter NWDataAdapter;
    private DataSet dsNW;

    private DataSet dsNorthWind;
	#endregion


    #region	NorthWindAccess(String connectionString)
    /// <summary>
    ///  The NorthWindAccess Data Layer Constructor
    /// </summary>
    public NorthWindAccess(String connectionString)
	{
		#region instantiate the OleDb Objects
		NWDataAdapter = new OleDbDataAdapter();
		NWSelectCommand = new OleDbCommand();
		NWInsertCommand = new OleDbCommand();
		NWUpdateCommand = new OleDbCommand();
		NWDeleteCommand = new OleDbCommand();
		NWConnection = new OleDbConnection();
		#endregion

		#region Initialize the DataAdapter with the command objects
		NWDataAdapter.DeleteCommand = NWDeleteCommand;
		NWDataAdapter.InsertCommand = NWInsertCommand;
		NWDataAdapter.SelectCommand = NWSelectCommand;
		NWDataAdapter.UpdateCommand = NWUpdateCommand;
		#endregion
		
			
		#region initialize the Connection object
		
        NWConnection.ConnectionString = connectionString;
   

		#endregion

        #region instantiate and initialize DataSet and DataTable Objects
        dsNorthWind = new DataSet();       

        // Employees Table Info
        NWDataAdapter.TableMappings.AddRange(
            new System.Data.Common.DataTableMapping[] {
                new System.Data.Common.DataTableMapping("Employees", "Employees", 
                    new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"),
                        new System.Data.Common.DataColumnMapping("LastName", "LastName"),
                        new System.Data.Common.DataColumnMapping("FirstName", "FirstName"),
                        new System.Data.Common.DataColumnMapping("Title", "Title"),
                        new System.Data.Common.DataColumnMapping("TitleOfCourtesy", "TitleOfCoutesy"),
                        new System.Data.Common.DataColumnMapping("BirthDate", "BirthDate"),
                        new System.Data.Common.DataColumnMapping("HireDate", "HireDate"),
                        new System.Data.Common.DataColumnMapping("Address", "Address"),
                        new System.Data.Common.DataColumnMapping("City", "City"),
                        new System.Data.Common.DataColumnMapping("Region", "Region"),
                        new System.Data.Common.DataColumnMapping("PostalCode", "PostalCode"),
                        new System.Data.Common.DataColumnMapping("Country", "Country"),
                        new System.Data.Common.DataColumnMapping("HomePhone", "HomePhone"),
                        new System.Data.Common.DataColumnMapping("Extension", "Extension"),
                        new System.Data.Common.DataColumnMapping("Photo", "Photo"),
                        new System.Data.Common.DataColumnMapping("Notes", "Notes"),
                        new System.Data.Common.DataColumnMapping("ReportsTo", "ReportsTo"), 
                        new System.Data.Common.DataColumnMapping("Password", "Password"), 
                    })});

        // Customers Table Info
        NWDataAdapter.TableMappings.AddRange(
            new System.Data.Common.DataTableMapping[] {
                new System.Data.Common.DataTableMapping("Customers", "Customers", 
                    new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
                        new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"),
                        new System.Data.Common.DataColumnMapping("ContactName", "ContactName"),
                        new System.Data.Common.DataColumnMapping("ContactTitle", "ContactTitle"),
                        new System.Data.Common.DataColumnMapping("Address", "Address"),
                        new System.Data.Common.DataColumnMapping("city", "city"),
                        new System.Data.Common.DataColumnMapping("Region", "Region"),
                        new System.Data.Common.DataColumnMapping("PostalCode", "PostalCode"),
                        new System.Data.Common.DataColumnMapping("Country", "Country"),
                        new System.Data.Common.DataColumnMapping("Phone", "Phone"),
                        new System.Data.Common.DataColumnMapping("Fax", "Fax"),
                    })});

        // Products Table Info
        NWDataAdapter.TableMappings.AddRange(
        new System.Data.Common.DataTableMapping[] {
                new System.Data.Common.DataTableMapping("Products", "Products",                
                    new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ProductID", "ProductID"),
                        new System.Data.Common.DataColumnMapping("ProductName", "ProductName"),
                        new System.Data.Common.DataColumnMapping("CategoryID", "CategoryID"),
                        new System.Data.Common.DataColumnMapping("CategoryName", "CategoryName"),
                        new System.Data.Common.DataColumnMapping("SupplierID", "SupplierID"),
                        new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"),
                        new System.Data.Common.DataColumnMapping("QuantityPerUnit", "QuantityPerUnit"),
                        new System.Data.Common.DataColumnMapping("UnitPrice", "UnitPrice"),
                        new System.Data.Common.DataColumnMapping("UnitsInStock", "UnitsInStock"),
                        new System.Data.Common.DataColumnMapping("UnitsOnOrder", "UnitsOnOrder"),
                        new System.Data.Common.DataColumnMapping("ReorderLevel", "ReorderLevel"),
                        new System.Data.Common.DataColumnMapping("Discontinued", "Discontinued"),

                    })});
        // Categories Table Info
        NWDataAdapter.TableMappings.AddRange(
        new System.Data.Common.DataTableMapping[] {
                new System.Data.Common.DataTableMapping("Categories", "Categories",                
                    new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CategoryID", "CategoryID"),
                        new System.Data.Common.DataColumnMapping("CategoryName", "CategoryName"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("Picture", "Picture"),
                    })});

        // Shippers Table Info
        NWDataAdapter.TableMappings.AddRange(
        new System.Data.Common.DataTableMapping[] {
                new System.Data.Common.DataTableMapping("Shippers", "Shippers",                
                    new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ShipperID", "ShipperID"),
                        new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"),
                        new System.Data.Common.DataColumnMapping("Phone", "Phone"),
                    })});

        // Shippers Table Info
        NWDataAdapter.TableMappings.AddRange(
        new System.Data.Common.DataTableMapping[] {
                new System.Data.Common.DataTableMapping("Suppliers", "Suppliers",                
                    new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("SupplierID", "SupplierID"),
                        new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"),
                        new System.Data.Common.DataColumnMapping("ContactName", "ContactName"),
                        new System.Data.Common.DataColumnMapping("ContactTitle", "ContactTitle"),
                        new System.Data.Common.DataColumnMapping("Address", "Address"),
                        new System.Data.Common.DataColumnMapping("City", "City"),
                        new System.Data.Common.DataColumnMapping("Region", "Region"),
                        new System.Data.Common.DataColumnMapping("PostalCode", "PostalCode"),
                        new System.Data.Common.DataColumnMapping("Country", "Country"),
                        new System.Data.Common.DataColumnMapping("Phone", "Phone"),
                        new System.Data.Common.DataColumnMapping("Fax", "Fax"),
                        new System.Data.Common.DataColumnMapping("HomePage", "HomePage"),
                    })});


        #endregion

        #region Initialize the DataAdapter with the command objects
        NWSelectCommand = new OleDbCommand();
        NWDataAdapter = new OleDbDataAdapter();
        #endregion
        updateDateSet();
    }
    #endregion

    #region Select informations and fill DataSet updateDateSet()
    public void updateDateSet()
    {
        #region set connection and the TableMappings for the DataAdapter (Employees Table Info)
        NWSelectCommand.Connection = NWConnection;
        NWSelectCommand.CommandText = "SELECT EmployeeID,LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address"
        + ",City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,Password FROM Employees";

        dsNorthWind.Clear();
        NWConnection.Open();
        NWDataAdapter.SelectCommand = NWSelectCommand;
        NWDataAdapter.Fill(dsNorthWind, "Employees");
        NWConnection.Close();
        #endregion

        #region set connection and the TableMappings for the DataAdapter (Customers Table Info)
        NWSelectCommand.Connection = NWConnection;
        NWSelectCommand.CommandText = "SELECT Address, City, CompanyName, ContactName, ContactTitle, Country, CustomerID" +
            ", Fax, Phone, PostalCode, Region FROM Customers";

        

        //NWDataAdapter.SelectCommand = NWSelectCommand;
        //NWDataAdapter.Fill(dsNorthWind, "Customers");
        //dsNorthWind.Tables.Add(dtCustomers);

        NWConnection.Open();
        NWDataAdapter.SelectCommand = NWSelectCommand;
        NWDataAdapter.Fill(dsNorthWind, "Customers");
        NWConnection.Close();
        #endregion

        #region set connection and the TableMappings for the DataAdapter (Products Table Information)
        NWSelectCommand.Connection = NWConnection;
        NWSelectCommand.CommandText = "SELECT  " +
            "Products.ProductID, Products.ProductName, " +
            "Categories.CategoryID,Categories.CategoryName, " +
            "Suppliers.SupplierID,Suppliers.CompanyName, " +
            "Products.QuantityPerUnit, " +
            "Products.UnitPrice, Products.UnitsInStock, " +
            "Products.UnitsOnOrder, Products.ReorderLevel,Products.Discontinued "+
            "FROM Categories " +
            "INNER JOIN (Suppliers " +
            "INNER JOIN Products " +
            "ON Suppliers.SupplierID = Products.SupplierID) " +
            "ON Categories.CategoryID = Products.CategoryID";


        //"SELECT ProductID, ProductName, SupplierID, "
        //                        + "CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, "
        //                        + "UnitsOnOrder, ReorderLevel, Discontinued FROM Products";

        

       
        NWConnection.Open();
        NWDataAdapter.SelectCommand = NWSelectCommand;
        NWDataAdapter.Fill(dsNorthWind, "Products");
        NWConnection.Close();
        #endregion

        #region set connection and the TableMappings for the DataAdapter (Categories Table Info)
        NWSelectCommand.Connection = NWConnection;
        NWSelectCommand.CommandText = "SELECT CategoryID,CategoryName,Description FROM Categories";
        //NWSelectCommand.CommandText = "SELECT EmployeeID,LastName FROM Employees";


        NWConnection.Open();
        NWDataAdapter.SelectCommand = NWSelectCommand;
        NWDataAdapter.Fill(dsNorthWind, "Categories");
        NWConnection.Close();
        #endregion

        #region set connection and the TableMappings for the DataAdapter (Shippers Table Info)
        NWSelectCommand.Connection = NWConnection;
        NWSelectCommand.CommandText = "SELECT ShipperID,CompanyName,Phone FROM Shippers";
 
        NWConnection.Open();
        NWDataAdapter.SelectCommand = NWSelectCommand;
        NWDataAdapter.Fill(dsNorthWind, "Shippers");
        NWConnection.Close();
        #endregion

        #region set connection and the TableMappings for the DataAdapter (Suppliers Table Info)
        NWSelectCommand.Connection = NWConnection;
        NWSelectCommand.CommandText = "SELECT SupplierID,CompanyName,ContactName,ContactTitle,Address, City,"
        + "Region,PostalCode,Country,Phone,Fax,HomePage FROM Suppliers";

        NWConnection.Open();
        NWDataAdapter.SelectCommand = NWSelectCommand;
        NWDataAdapter.Fill(dsNorthWind, "Suppliers");
        NWConnection.Close();
        #endregion
    }
        #endregion

    #region Get Tables Information

    #region	public String [,] getCustomerInformation()
    /// <summary>
	/// getCustomerNamesAndIDs()
	/// returned array has as many elements in the first dimension
	/// as there are records
	/// It has two elements in the second dimension
	/// </summary>
	/// <returns>A 2 dimensional string array 
	/// </returns>
	public String [,] getCustomerInformation()
	{
        String[,] CustomersList = null;
			
		// Allocate the 2 d array
        CustomersList = new String[dsNorthWind.Tables["Customers"].Rows.Count, dsNorthWind.Tables["Customers"].Columns.Count];

		// load the array
		int i = 0;
        foreach (DataRow customer in dsNorthWind.Tables["Customers"].Rows)
		{
            CustomersList[i, 0] = customer["CustomerID"].ToString();
            CustomersList[i, 1] = customer["CompanyName"].ToString();
            CustomersList[i, 2] = customer["ContactName"].ToString();
            CustomersList[i, 3] = customer["ContactTitle"].ToString();
            CustomersList[i, 4] = customer["Address"].ToString();
            CustomersList[i, 5] = customer["City"].ToString();
            CustomersList[i, 6] = customer["Region"].ToString();
            CustomersList[i, 7] = customer["PostalCode"].ToString();
            CustomersList[i, 8] = customer["Country"].ToString();
            CustomersList[i, 9] = customer["Phone"].ToString();
            CustomersList[i, 10] = customer["Fax"].ToString();
			i++;
		}
		return CustomersList;
	}

    #endregion
 
    #region	public String [,] getEmployeesInformation()
    public String[,] getEmployeesInformation()
    {

        String[,] EmployeesList = null;

        // Allocate the 2 d array
        EmployeesList = new String[dsNorthWind.Tables["Employees"].Rows.Count, dsNorthWind.Tables["Employees"].Columns.Count];

        // load the array
        int i = 0;
        foreach (DataRow employee in dsNorthWind.Tables["Employees"].Rows)
        {
            EmployeesList[i, 0] = employee["EmployeeID"].ToString();
            EmployeesList[i, 1] = employee["LastName"].ToString();
            EmployeesList[i, 2] = employee["FirstName"].ToString();
            EmployeesList[i, 3] = employee["Title"].ToString();
            EmployeesList[i, 4] = employee["TitleOfCourtesy"].ToString();
            EmployeesList[i, 5] = employee["BirthDate"].ToString();
            EmployeesList[i, 6] = employee["HireDate"].ToString();
            EmployeesList[i, 7] = employee["Address"].ToString();
            EmployeesList[i, 8] = employee["City"].ToString();
            EmployeesList[i, 9] = employee["Region"].ToString();
            EmployeesList[i, 10] = employee["PostalCode"].ToString();
            EmployeesList[i, 11] = employee["Country"].ToString();
            EmployeesList[i, 12] = employee["HomePhone"].ToString();
            EmployeesList[i, 13] = employee["Extension"].ToString();
            EmployeesList[i, 14] = employee["Photo"].ToString();
            EmployeesList[i, 15] = employee["Notes"].ToString();
            EmployeesList[i, 16] = employee["ReportsTo"].ToString();
            EmployeesList[i, 16] = employee["Password"].ToString();
            i++;
        }
        return EmployeesList;
    }
    #endregion      

    #region	public String [,] getProductsInformation()
    public String[,] getProductsInformation()
    {
        String[,] ProductsList = null;

        // Allocate the 2 d array
        ProductsList = new String[dsNorthWind.Tables["Products"].Rows.Count, dsNorthWind.Tables["Products"].Columns.Count];

        // load the array
        int i = 0;
        foreach (DataRow product in dsNorthWind.Tables["Products"].Rows)
        {
            ProductsList[i, 0] = product["ProductID"].ToString();
            ProductsList[i, 1] = product["ProductName"].ToString();
            ProductsList[i, 2] = product["CategoryID"].ToString();
            ProductsList[i, 3] = product["CategoryName"].ToString();
            ProductsList[i, 4] = product["SupplierID"].ToString();
            ProductsList[i, 5] = product["CompanyName"].ToString();
            ProductsList[i, 6] = product["QuantityPerUnit"].ToString();
            ProductsList[i, 7] = product["UnitPrice"].ToString();
            ProductsList[i, 8] = product["UnitsInStock"].ToString();
            ProductsList[i, 9] = product["UnitsOnOrder"].ToString();
            ProductsList[i, 10] = product["ReorderLevel"].ToString();
            ProductsList[i, 11] = product["Discontinued"].ToString();
            i++;
        }
        return ProductsList;
    }
    #endregion

    #region	public String [,] getCategoryInformation()
    public String[,] getCategoryInformation()
    {
        String[,] CategoryList = null;

        // Allocate the 2 d array
        CategoryList = new String[dsNorthWind.Tables["Categories"].Rows.Count, dsNorthWind.Tables["Categories"].Columns.Count];

        // load the array
        int i = 0;
        foreach (DataRow product in dsNorthWind.Tables["Categories"].Rows)
        {
            CategoryList[i, 0] = product["CategoryID"].ToString();
            CategoryList[i, 1] = product["CategoryName"].ToString();
            CategoryList[i, 2] = product["Description"].ToString();
            //CategoryList[i, 3] = product["Picture"].ToString();
            
            i++;
        }
        return CategoryList;
    }
    #endregion

    #region	public String [,] getShippersInformation()
    public String[,] getShippersInformation()
    {
        String[,] ShippersList = null;

        // Allocate the 2 d array
        ShippersList = new String[dsNorthWind.Tables["Shippers"].Rows.Count, dsNorthWind.Tables["Shippers"].Columns.Count];
        // load the array
        int i = 0;
        foreach (DataRow product in dsNorthWind.Tables["Shippers"].Rows)
        {
            ShippersList[i, 0] = product["ShipperID"].ToString();
            ShippersList[i, 1] = product["CompanyName"].ToString();
            ShippersList[i, 2] = product["Phone"].ToString();

            i++;
        }
        return ShippersList;
    }
    #endregion

    #region	public String [,] getSupplierInformation()
    public String[,] getSupplierInformation()
    {
        String[,] SupplierList = null;

        // Allocate the 2 d array
        SupplierList = new String[dsNorthWind.Tables["Suppliers"].Rows.Count, dsNorthWind.Tables["Suppliers"].Columns.Count];
        // load the array
        int i = 0;
        foreach (DataRow product in dsNorthWind.Tables["Suppliers"].Rows)
        {
            SupplierList[i, 0] = product["SupplierID"].ToString();
            SupplierList[i, 1] = product["CompanyName"].ToString();
            SupplierList[i, 2] = product["ContactName"].ToString();
            SupplierList[i, 3] = product["ContactTitle"].ToString();
            SupplierList[i, 4] = product["Address"].ToString();
            SupplierList[i, 5] = product["City"].ToString();
            SupplierList[i, 6] = product["Region"].ToString();
            SupplierList[i, 7] = product["PostalCode"].ToString();
            SupplierList[i, 8] = product["Country"].ToString();
            SupplierList[i, 9] = product["Phone"].ToString();
            SupplierList[i, 10] = product["Fax"].ToString();
            SupplierList[i, 11] = product["HomePage"].ToString();

            i++;
        }
        return SupplierList;
    }
    #endregion

    #endregion

    #region DABaccess method for Products

    public void updateUnitsInStock(int productID, int decrement)
    {
        try
        {
            NWConnection.Open();
            // Query string concatenates fixed text with the user's selection
            string updates = "UPDATE [Products] SET Products.UnitsInStock = (Products.UnitsInStock -"
                + decrement + ") WHERE Products.ProductID = " + productID;
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand(updates, NWConnection);
            cmd.ExecuteNonQuery();

            if (productInfChange != null)
                productInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }
    }

    public int checkUnitsInStock(String productID)
    {
        int stock = 0;

        string sql = "SELECT UnitsInStock FROM Products WHERE ProductID =" + productID;
        try
        {
            NWConnection.Open();
            OleDbCommand cmd = new OleDbCommand(sql, NWConnection);
            stock = Convert.ToInt32(cmd.ExecuteScalar());// Get unitsInStock value
            cmd.Dispose();

            if (productInfChange != null)
                productInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }
        return stock;
    }

    public void insertProduct(String ProductName, String CategoryID, 
        String SupplierID, String QuantityPerUnit, String UnitPrice, String UnitsInStock,
        String UnitsOnOrder, String ReorderLevel, String Discontinued)
    {
        try
        {

            string insert = "INSERT INTO [Products]  (ProductName, CategoryID, " +
        "SupplierID,  QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel,  Discontinued ) VALUES (" +
        ProductName + "," + CategoryID + ","  + UnitsOnOrder + "," +
        QuantityPerUnit + "," + UnitPrice + "," + UnitsInStock + 
        "," + UnitsOnOrder + "," + ReorderLevel + "," + Discontinued + ")";
            OleDbCommand cmd = new OleDbCommand(insert, NWConnection);

            NWConnection.Open();
            cmd.ExecuteNonQuery();

            if (productInfChange != null)
                productInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }

    }

    public void updateProductInfo(String ProductID, String ProductName, String CategoryID,
        String SupplierID, String QuantityPerUnit, String UnitPrice, String UnitsInStock,
        String UnitsOnOrder, String ReorderLevel, String Discontinued)
    {
        try
        {
            string updates = "UPDATE [Products] SET " +
                    "ProductName = " + ProductName + ", " + "CategoryID = " + CategoryID + ", " +
                    "SupplierID =" + SupplierID + ", " + "QuantityPerUnit = " + QuantityPerUnit + ", " +
                    "UnitPrice = " + UnitPrice + ", " + "UnitsInStock =" + UnitsInStock + ", " +
                    "UnitsOnOrder = " + UnitsOnOrder + ", " + "ReorderLevel = " + ReorderLevel + ", " +
                    "Discontinued = " + Discontinued + 
                     " WHERE ProductID = " + ProductID;
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand(updates, NWConnection);

            NWConnection.Open();
            cmd.ExecuteNonQuery();

            if (productInfChange != null)
                productInfChange();
        }
        catch (Exception )
        {
        }
        finally
        {
            NWConnection.Close();
        }
    }

    public void deleteProductInfo(String ProductID)
    {
        try
        {
            string delete1 = "DELETE * from [Order Details]  WHERE ProductID = " + ProductID;
            string delete2 = "DELETE * from [Products]  WHERE ProductID = " + ProductID ;

            NWConnection.Open();
            OleDbCommand cmd1 = new OleDbCommand(delete1, NWConnection);
            cmd1.ExecuteNonQuery();
            OleDbCommand cmd2 = new OleDbCommand(delete2, NWConnection);
            cmd2.ExecuteNonQuery();

            if (customerInfChange != null)
                customerInfChange();

        }
        catch (Exception e)
        {
        }
        finally
        {
            NWConnection.Close();
        }

    }

    #endregion 

    #region DABaccess method for Customer
    public void insertCustomer(String CustomerID, String CompanyName, String ContactName,
        String ContactTitle, String Address, String City, String Region, String PostalCode,
        String Country, String Phone, String Fax)
    {
        try
        {
            string insert = "INSERT INTO [Customers]  (CustomerID, CompanyName,  ContactName," +
        "ContactTitle, Address, City, Region, PostalCode, Country, Phone,  Fax ) VALUES (" +
        CustomerID +"," + CompanyName +"," +ContactName +"," + ContactTitle +"," +  Address
        + "," + City + "," + Region + "," + PostalCode + "," + Country + "," + Phone + "," + Fax + ")";
            OleDbCommand cmd = new OleDbCommand(insert, NWConnection);

            NWConnection.Open();
            cmd.ExecuteNonQuery();

            if (customerInfChange != null)
                customerInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }

    }

    public void updateCustomerInfo(String CustomerID,String newCustomerID, String CompanyName, String ContactName,
        String ContactTitle, String Address, String City, String Region, String PostalCode,
        String Country, String Phone, String Fax)
    {
        try
        {

            string updates = "UPDATE [Customers] SET  CustomerID = " + newCustomerID + ", " +
                    "CompanyName = " + CompanyName + ", " + "ContactName = " + ContactName + ", " +
                    "ContactTitle = " + ContactTitle + ", " + "Address = " + Address + ", " +
                    "City = " + City + ", " + "Region = " + Region + ", " +
                    "PostalCode = " + PostalCode + ", " + "Country = " + Country + ", " +
                    "Phone = " + Phone + ", " + "Fax = " + Fax +
                    " WHERE CustomerID = '" + CustomerID +"'";
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbCommand cmd = new OleDbCommand(updates, NWConnection);
    
        NWConnection.Open();
        cmd.ExecuteNonQuery();

        if (customerInfChange != null)
            customerInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }
    }

    public void deleteCustomerInfo(String CustomerID)
    {

        try
        {
        string delete1 = "UPDATE [Orders] SET CustomerID = NULL WHERE CustomerID = '" + CustomerID+ "'" ;
        string delete2 = "DELETE * from [Customers]  WHERE CustomerID = '" + CustomerID +"'";

        NWConnection.Open();
        OleDbCommand cmd1 = new OleDbCommand(delete1, NWConnection);
        cmd1.ExecuteNonQuery();
        OleDbCommand cmd2 = new OleDbCommand(delete2, NWConnection);
        cmd2.ExecuteNonQuery();

        if (customerInfChange != null)
            customerInfChange();

        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }

    }
    #endregion

    #region DABaccess method for Employee
    public void insertEmployee(String LastName, String FirstName, String Title,String TitleOfCourtesy,
        String BirthDate, String HireDate, String Address, String City,
        String Region, String PostalCode, String Country, String HomePhone,
        String Extension, String Photo, String Notes, String ReportsTo)
    {
        try
        {

            string insert = "INSERT INTO [Employees]  (LastName, FirstName,  Title," +
       "TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode,  Country," +
           "HomePhone,Extension,Photo,Notes,ReportsTo) VALUES (" +
       LastName + "," + FirstName + "," + Title + "," + TitleOfCourtesy + "," + BirthDate + ","
       + HireDate +"," + Address +"," + City +"," + Region +"," +PostalCode  +","+ 
       Country +"," + HomePhone+"," + Extension +"," + Photo +","+ Notes  +","+ ReportsTo + ")";

        //    string insert = "INSERT INTO [Employees]  (LastName, FirstName,  Title," +
        //"TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode,  Country,"+
        //    "HomePhone,Extension,Photo,Notes,ReportsTo) VALUES ('" +
        //LastName + "','" + FirstName + "','" + Title + "','" + TitleOfCourtesy + "','" + BirthDate
        //+ "','" + HireDate + "','" + Address + "','" + City + "','" + Region + "','" +
        //PostalCode + "','" + Country +"','"+  HomePhone + "','" + Extension + "','" + Photo + "','" +
        //    Notes + "'," + ReportsTo + ")";

            OleDbCommand cmd = new OleDbCommand(insert, NWConnection);

            NWConnection.Open();
            cmd.ExecuteNonQuery();

            if (employeeInfChange != null)
                employeeInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }

    }

    public void updateEmployeeInfo(String EmployeeID, String LastName, String FirstName, String Title, String TitleOfCourtesy,
        String BirthDate, String HireDate, String Address, String City,
        String Region, String PostalCode, String Country, String HomePhone,
        String Extension, String Photo, String Notes, String ReportsTo)
    {
         try
        {
            string update = "UPDATE [Employees] SET LastName = " + LastName  + ", " +
                    "FirstName =" + FirstName + ", " + "Title = " + Title + ", " + "TitleOfCourtesy = " + TitleOfCourtesy + ", " +
                    "BirthDate = " + BirthDate + ", " + "HireDate = " + HireDate + ", " + "Address = " + Address + ", " +
                    "City = " + City + ", " + "Region = " + Region + ", " +
                    "PostalCode = " + PostalCode + ", " + "Country = " + Country + ", " +
                    "HomePhone = " + HomePhone + ", " + "Extension = " + Extension + ", " +
                    "Photo = " + Photo + ", " + "Notes = " + Notes + ", " + "ReportsTo = " + ReportsTo + 
                     " WHERE EmployeeID = " + EmployeeID;
            OleDbCommand cmd = new OleDbCommand(update, NWConnection);

            NWConnection.Open();
            cmd.ExecuteNonQuery();

            if (employeeInfChange != null)
                employeeInfChange();

        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }

    }

    public void deleteEmployeeInfo(String EmployeeID)
    {
        try
        {
            string delete1 = "UPDATE [Orders] SET EmployeeID = NULL WHERE EmployeeID = " + EmployeeID;
            string delete2 = "DELETE * from [Employees]  WHERE EmployeeID = " + EmployeeID;

            NWConnection.Open();
            OleDbCommand cmd1 = new OleDbCommand(delete1, NWConnection);
            cmd1.ExecuteNonQuery();
            OleDbCommand cmd2 = new OleDbCommand(delete2, NWConnection);
            cmd2.ExecuteNonQuery();

            if (employeeInfChange != null)
                employeeInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }

    }

    #endregion

    #region DABaccess method for Category
    public void insertCategory(String CategoryName, String Description)
    {
        try
        {

            string insert = "INSERT INTO [Categories] (CategoryName, Description ) VALUES ("
                                + CategoryName + ", " + Description + ")";
            OleDbCommand cmd = new OleDbCommand(insert, NWConnection);

            NWConnection.Open();
            cmd.ExecuteNonQuery();

            if (categoryInfChange != null)
                categoryInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }

        
    }

    public void updateCategoryInfo(String CategoryID, String CategoryName, String Description)
    {
        try
        {
            string updates = "UPDATE [Categories] SET CategoryName = " + CategoryName + 
                ", Description =" + Description + " " +
                " WHERE CategoryID = " + CategoryID;

            OleDbCommand cmd = new OleDbCommand(updates, NWConnection);

            NWConnection.Open();
            cmd.ExecuteNonQuery();

            if (categoryInfChange != null)
                categoryInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }

    }

    public void deleteCategoryInfo(String CategoryID)
    {
        try
        {

            string delete1 = "UPDATE [Products] SET CategoryID = NULL WHERE CategoryID = " + CategoryID;
            string delete2 = "DELETE * from [Categories]  WHERE CategoryID = " + CategoryID;

            NWConnection.Open();
            OleDbCommand cmd1 = new OleDbCommand(delete1, NWConnection);
            cmd1.ExecuteNonQuery();
            OleDbCommand cmd2 = new OleDbCommand(delete2, NWConnection);
            cmd2.ExecuteNonQuery();

            if (categoryInfChange != null)
                categoryInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }
    }

    #endregion

    #region DABaccess method for Shippers
    public void insertShipper(String CompanyName, String Phone)
    {
        try
        {

            string insert = "INSERT INTO [Shippers] (CompanyName,Phone) VALUES ("
                                + CompanyName + ", " + Phone + ")";
            OleDbCommand cmd = new OleDbCommand(insert, NWConnection);

            NWConnection.Open();
            cmd.ExecuteNonQuery();

            if (ShipperInfChange != null)
                ShipperInfChange();

        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }


    }

    public void updateShipperInfo(String ShipperID, String CompanyName, String Phone)
    {
        try
        {
            string updates = "UPDATE [Shippers] SET CompanyName= " + CompanyName + ", "+
                "Phone = "+ Phone + " WHERE ShipperID = " + ShipperID;

            OleDbCommand cmd = new OleDbCommand(updates, NWConnection);

            NWConnection.Open();
            cmd.ExecuteNonQuery();

            if (ShipperInfChange != null)
                ShipperInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }

    }

    public void deleteShipperInfo(String ShipperID)
    {
        try
        {
            string delete1 = "UPDATE [Orders] SET ShipVia = NULL WHERE ShipVia = " + ShipperID;
            string delete2 = "DELETE * from [Shippers]  WHERE ShipperID = " + ShipperID;

            NWConnection.Open();
            OleDbCommand cmd1 = new OleDbCommand(delete1, NWConnection);
            cmd1.ExecuteNonQuery();
            OleDbCommand cmd2 = new OleDbCommand(delete2, NWConnection);
            cmd2.ExecuteNonQuery();
            if (ShipperInfChange != null)
                ShipperInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }
    }

    #endregion

    #region DABaccess method for Suppliers
    public void insertSupplier(String CompanyName, String ContactName,
        String ContactTitle, String Address, String City, String Region,
        String PostalCode, String Country, String Phone, String Fax, String HomePage)
    {
        try
        {
            string insert = "INSERT INTO [Suppliers] (CompanyName, ContactName,  ContactTitle," +
        "Address, City, Region, PostalCode, Country, Phone, Fax, HomePage) VALUES (" +
        CompanyName + "," + ContactName + "," + ContactTitle + "," + Address + "," + City
        + "," + Region + "," + PostalCode + "," + Country + "," + Phone + "," +
        Fax + "," + HomePage + " )";

            OleDbCommand cmd = new OleDbCommand(insert, NWConnection);

            NWConnection.Open();
            cmd.ExecuteNonQuery();

            if (SupplierInfChange != null)
                SupplierInfChange();

        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }


    }

    public void updateSupplierInfo(String SupplierID, String CompanyName, String ContactName,
        String ContactTitle, String Address, String City, String Region,
        String PostalCode, String Country, String Phone, String Fax, String HomePage)
    {
        try
        {
            string updates = "UPDATE [Suppliers] SET CompanyName = " + CompanyName + ", " +
                    "ContactName = " + ContactName + ", " + "ContactTitle = " + ContactTitle + ", " + "Address = " + Address + ", " +
                    "City =" + City + ", " + "Region = " + Region + ", " + "PostalCode = " + PostalCode + ", " +
                    "Country = " + Country + ", " + "Phone = " + Phone + ", " +
                    "Fax = " + Fax + ", " + "HomePage = " + HomePage  +
                    " WHERE SupplierID = " + SupplierID;

            OleDbCommand cmd = new OleDbCommand(updates, NWConnection);

            NWConnection.Open();
            cmd.ExecuteNonQuery();

            if (ShipperInfChange != null)
                ShipperInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }

    }

    public void deleteSupplierInfo(String SupplierID)
    {
        try
        {
            string delete1 = "UPDATE [Products] SET SupplierID = NULL WHERE SupplierID = " + SupplierID;
            string delete2 = "DELETE * from [Suppliers]  WHERE SupplierID = " + SupplierID;

            NWConnection.Open();
            OleDbCommand cmd1 = new OleDbCommand(delete1, NWConnection);
            cmd1.ExecuteNonQuery();
            OleDbCommand cmd2 = new OleDbCommand(delete2, NWConnection);
            cmd2.ExecuteNonQuery();

            if (ShipperInfChange != null)
                ShipperInfChange();
        }
        catch (Exception)
        {
        }
        finally
        {
            NWConnection.Close();
        }
    }

    #endregion
}
