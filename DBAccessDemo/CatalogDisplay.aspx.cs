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
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class CatalogDisplay : System.Web.UI.Page
{
    // a constant to manage the cell number that contains the Product ID
    private const int PRODUCT_ID_CELL_INDEX = 4;
    private enum status { Employees, VicePresident, Salesman, NonSalesRepresentative };
  

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (IsExistEmail())
        {
            if (Session["cart"] == null)
            {
                btnCheckout.Visible = false;
            }
            fillDataGrid();
        }
        else
        {
            Server.Transfer("StartPage.aspx");
        }
    }

    private void fillDataGrid()
    {

        dgProducts.BorderStyle = BorderStyle.Outset;
        dgProducts.BorderWidth = Unit.Pixel(3);
        string[,] productsInformation = ((Business)Application["Business"]).getProductsInformation();




        DataTable tbProducts = new DataTable("Products");

        DataColumn categoryNameCol = new DataColumn("Category Name");
        categoryNameCol.ReadOnly = false;
        categoryNameCol.DataType = System.Type.GetType("System.String");
        tbProducts.Columns.Add(categoryNameCol);

        DataColumn productNameCol = new DataColumn("Product Name");
        productNameCol.ReadOnly = false;
        productNameCol.DataType = System.Type.GetType("System.String");
        tbProducts.Columns.Add(productNameCol);

        DataColumn companyNameCol = new DataColumn("Company Name");
        companyNameCol.ReadOnly = false;
        companyNameCol.DataType = System.Type.GetType("System.String");
        tbProducts.Columns.Add(companyNameCol);

        DataColumn productIDCol = new DataColumn("Product ID");
        productIDCol.ReadOnly = false;
        productIDCol.DataType = System.Type.GetType("System.String");
        tbProducts.Columns.Add(productIDCol);



        // Loading up Categories in combo list
        for (int i = 0; i < productsInformation.GetLength(0); i++)
        {
            DataRow row = tbProducts.NewRow();

            row["Category Name"] = productsInformation[i, 3];
            row["Product Name"] = productsInformation[i, 1];
            row["Company Name"] = productsInformation[i, 5];
            row["Product ID"] = productsInformation[i, 0];

            tbProducts.Rows.Add(row);
        }

        dgProducts.DataSource = tbProducts;

        dgProducts.DataBind();
    }

    private bool IsExistEmail()
    {
        // Return true if there has email informtion stored in session
        if (Session["Return EMail"] != null )
            return true;
        return false;
    }

    /// <summary>
    /// View Details was clicked for a product
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dgProducts_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        // Capture selected Product ID using Selected Row index and fixed Cell index
        Session.Add("Current Item",
            dgProducts.Items[dgProducts.SelectedIndex]
                .Cells[PRODUCT_ID_CELL_INDEX].Text);
        //  display a product page for that item
        // Page will read the Session variable in its Page_Load and get necessary data
        Server.Transfer("FrmItemOrder.aspx");
    }

    protected void btnCancel_Click(object sender, System.EventArgs e)
    {
        Session.RemoveAll(); 
        Server.Transfer("StartPage.aspx"); 
    }

    protected void btnCheckout_Click(object sender, System.EventArgs e)
    {

        Response.Clear();
        //Server.Transfer("FrmOrderReview.aspx");
        Response.Redirect("FrmOrderReview.aspx", true);
    }

}
