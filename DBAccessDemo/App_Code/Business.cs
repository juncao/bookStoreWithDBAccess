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
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Business Layer of an application
/// There are methods can access Data Access Layer.
/// This layer can be used for all view pages to
/// get and pass data to database.
/// </summary>
public class Business
{
    private NorthWindAccess DBData;
    private string[,] customers;
    private string[,] products;
    private string[,] employees;
    private string[,] Categories;
    private string[,] shippers;
    private string[,] Suppliers;

    public delegate String[,] Update();

    public Business(NorthWindAccess s)
	{
        DBData = s;

        getCustomerInformation();
        getProductsInformation();
        getEmployeesInformation();
        getCategoryInformation();
        getShippersInformation();
        getSupplierInformation();

        DBData.employeeInfChange += new Update(getEmployeesInformation);
        DBData.customerInfChange += new Update(getCustomerInformation);
        DBData.productInfChange += new Update(getProductsInformation);
        DBData.categoryInfChange += new Update(getCategoryInformation);
        DBData.ShipperInfChange += new Update(getShippersInformation);
        DBData.SupplierInfChange += new Update(getSupplierInformation);

	}



    #region Get string[,] infomations for different tables
    public String[,] getCustomerInformation()
    {
        DBData.updateDateSet();
        customers = DBData.getCustomerInformation();
        return customers;
    }

    public String[,] getProductsInformation()
    {
            DBData.updateDateSet();
        products = DBData.getProductsInformation();
        return products;
    }

    public String[,] getEmployeesInformation()
    {
            DBData.updateDateSet();
        employees = DBData.getEmployeesInformation();
        return employees;
    }

    public String[,] getCategoryInformation()
    {
            DBData.updateDateSet();
        Categories = DBData.getCategoryInformation();
        return Categories;
    }

    public String[,] getShippersInformation()
    {
            DBData.updateDateSet();
        shippers = DBData.getShippersInformation();
        return shippers;
    }

    public String[,] getSupplierInformation()
    {
            DBData.updateDateSet();
        Suppliers = DBData.getSupplierInformation();
        return Suppliers;
    }

    #endregion

    #region Employee update
    public void insertEmployee(String LastName, String FirstName, String Title, String TitleOfCourtesy,
        String BirthDate, String HireDate, String Address, String City,
        String Region, String PostalCode, String Country, String HomePhone,
        String Extension, String Photo, String Notes, String ReportsTo)
    {
        DBData.insertEmployee( LastName,  FirstName,  Title, TitleOfCourtesy,
         BirthDate,  HireDate,  Address,  City,
         Region,  PostalCode,  Country,  HomePhone,
         Extension,  Photo,  Notes,  ReportsTo);
    }

    public void updateEmployeeInfo(String EmployeeID, String LastName, String FirstName, String Title, String TitleOfCourtesy,
        String BirthDate, String HireDate, String Address, String City,
        String Region, String PostalCode, String Country, String HomePhone,
        String Extension, String Photo, String Notes, String ReportsTo)
    {
        DBData.updateEmployeeInfo( EmployeeID,  LastName,  FirstName,  Title,  TitleOfCourtesy,
         BirthDate,  HireDate,  Address,  City,
         Region,  PostalCode,  Country,  HomePhone,
         Extension,  Photo,  Notes,  ReportsTo);
    }

    public void deleteEmployeeInfo(String EmployeeID)
    {
        DBData.deleteEmployeeInfo(EmployeeID);
    }
    #endregion

    #region Customer update
    public void insertCustomer(String CustomerID, String CompanyName, String ContactName,
        String ContactTitle, String Address, String City, String Region, String PostalCode,
        String Country, String Phone, String Fax)
    {
        DBData.insertCustomer(CustomerID, CompanyName, ContactName,
         ContactTitle,  Address,  City,  Region,  PostalCode,
         Country,  Phone,  Fax);
    }

    public void updateCustomerInfo(String CustomerID, String newCustomerID,  String CompanyName, String ContactName,
        String ContactTitle, String Address, String City, String Region, String PostalCode,
        String Country, String Phone, String Fax)
    {
        DBData.updateCustomerInfo( CustomerID, newCustomerID, CompanyName,  ContactName,
         ContactTitle,  Address,  City,  Region,  PostalCode,
         Country,  Phone,  Fax);
    }

    public void deleteCustomerInfo(String CustomerID)
    {
        DBData.deleteCustomerInfo(CustomerID);
    }
    #endregion

    #region Category update
    public void insertCategory(String CategoryName, String Description)
    {
        DBData.insertCategory(CategoryName, Description);
    }

    public void updateCategoryInfo(String CategoryID, String CategoryName, String Description)
    {
        DBData.updateCategoryInfo(CategoryID, CategoryName, Description);
    }

    public void deleteCategoryInfo(String CategoryID)
    {
        DBData.deleteCategoryInfo(CategoryID);
    }

    #endregion

    #region Product update
    public void updateUnitsInStock(int productID, int quantity)
    {
        DBData.updateUnitsInStock(productID, quantity);
    }

    public int checkUnitsInStock(String productID)
    {
        return DBData.checkUnitsInStock(productID);
    }

    public void insertProduct(String ProductName, String CategoryID,
        String SupplierID, String QuantityPerUnit, String UnitPrice, String UnitsInStock,
        String UnitsOnOrder, String ReorderLevel, String Discontinued)
    {
        DBData.insertProduct( ProductName,  CategoryID, 
         SupplierID,  QuantityPerUnit,  UnitPrice,  UnitsInStock,
         UnitsOnOrder,  ReorderLevel,  Discontinued);
    }

    public void updateProductInfo(String ProductID, String ProductName, String CategoryID,
        String SupplierID, String QuantityPerUnit, String UnitPrice, String UnitsInStock,
        String UnitsOnOrder, String ReorderLevel, String Discontinued)
    {
        DBData.updateProductInfo( ProductID,  ProductName,  CategoryID,
         SupplierID,  QuantityPerUnit,  UnitPrice,  UnitsInStock,
         UnitsOnOrder,  ReorderLevel,  Discontinued);
    }

    public void deleteProductInfo(String ProductID)
    {
        DBData.deleteProductInfo(ProductID);
    }
    #endregion

    #region Shipper update
    public void insertShipper(String CompanyName, String Phone)
    {
        DBData.insertShipper( CompanyName,  Phone);
    }

    public void updateShipperInfo(String ShipperID, String CompanyName, String Phone)
    {
        DBData.updateShipperInfo( ShipperID,  CompanyName,  Phone);
    }

    public void deleteShipperInfo(String ShipperID)
    {
        DBData.deleteShipperInfo(ShipperID);
    }

    #endregion

    #region Supplier update
    public void insertSupplier(String CompanyName, String ContactName,
        String ContactTitle, String Address, String City, String Region,
        String PostalCode, String Country, String Phone, String Fax, String HomePage)
    {
        DBData.insertSupplier( CompanyName,  ContactName,
         ContactTitle,  Address,  City,  Region,
         PostalCode,  Country,  Phone,  Fax,  HomePage);
    }

    public void updateSupplierInfo(String SupplierID, String CompanyName, String ContactName,
        String ContactTitle, String Address, String City, String Region,
        String PostalCode, String Country, String Phone, String Fax, String HomePage)
    {
        DBData.updateSupplierInfo( SupplierID,  CompanyName,  ContactName,
         ContactTitle,  Address,  City,  Region,
         PostalCode,  Country,  Phone,  Fax,  HomePage);
    }

    public void deleteSupplierInfo(String SupplierID)
    {
        DBData.deleteSupplierInfo(SupplierID);
    }

    #endregion


}