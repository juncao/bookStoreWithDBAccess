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
using System.Web.UI;
using System.Web.UI.WebControls;



/// <summary>
/// Get and display all informations from business object
/// for the Product who was stored in Session varable
/// Provided update and delete functions.
/// If there is no Product stored in Session varable
/// allow to insert new Product information
/// </summary>
public partial class FrmProductItemEdit : System.Web.UI.Page
{
    private TextBox[] textBoxArray;
    // The values used for database access method arguments
    private String[] updateValues;
    String[,] ProductsInformation;

    protected void Page_Load(object sender, EventArgs e)
    {
        InitializeArray();
        ProductsInformation = (((Business)Application["Business"])).getProductsInformation();

        if (Session["Title"] == null)
        {
            Response.Redirect("StartPage.aspx");
        }
        else if (Session["Title"].ToString() == "Sales Representative")
        {
            Response.Redirect("Maintenance.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                // If there is valid session varavle, load the Product informations
                if (Session["Editing Product Item"] != null)
                {
                    for (int i = 0; i < ProductsInformation.GetLength(0); i++)
                    {
                        if ((String)Session["Editing Product Item"] == ProductsInformation[i, 0])
                        {
                            for (int j = 0; j < textBoxArray.Length; j++)
                            {
                                 if (j != 3 && j !=5)
                                textBoxArray[j].Text = ProductsInformation[i, j];
                            }
                        }
                    }

                    //Edit setting: Allow Update,Delete
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnInsert.Visible = false;
                }
                else
                {
                    // Insert setting
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnInsert.Visible = true;
                }

            }
            textBoxArray[1].Focus();
        }
    }


    private void InitializeArray()
    {
        textBoxArray = new TextBox[12];

        textBoxArray[0] = txtProductID;
        textBoxArray[1] = txtProductName;
        textBoxArray[2] = txtSupplierID;
        textBoxArray[3] = null;
        textBoxArray[4] = txtCategoryID;
        textBoxArray[5] = null;
        textBoxArray[6] = txtQuantityPerUnit;
        textBoxArray[7] = txtUnitPrice;
        textBoxArray[8] = txtUnitsInStock;
        textBoxArray[9] = txtUnitsOnOrder;
        textBoxArray[10] = txtReorderLevel;
        textBoxArray[11] = txtDiscontinued;


        updateValues = new String[12];
    }
    /// <summary>
    /// Do nothing and go back to catalog view page
    /// </summary>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // Clear the current item
        Session.Remove("Editing Product Item");
        // Go back to catalog form
        Server.Transfer("Maintenance.aspx");
    }
    /// <summary>
    /// Update Product information, then back to catalog view page
    /// </summary>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateByID(textBoxArray[0].Text);
            // Clear the current item
            Session.Remove("Editing Product Item");
            // Go back to catalog form
            Server.Transfer("Maintenance.aspx");
        }
        catch (ArgumentNullException arEx)
        {
            Response.Write(arEx.Message);
            textBoxArray[1].Focus();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    /// <summary>
    /// Insert new Product information, then back to catalog view page
    /// </summary>
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            insertData();
            // Go back to catalog form
            Server.Transfer("Maintenance.aspx");

        }
        catch (ArgumentException ArEx)
        {
            Response.Write(ArEx.Message);
            btnUpdate.Visible = false;
            btnInsert.Visible = false;
            btnReturn.Visible = false;
            btnReplace.Visible = true;
            btnCancel.Visible = true;
        }
        catch (Exception otherEx)
        {
            Response.Write(otherEx.Message);
        }
    }
    /// <summary>
    /// replace existing Product information by new input values
    /// </summary>
    protected void btnReplace_Click(object sender, EventArgs e)
    {
        String categoryID = (String)Session["Existing Product Item"];

        try
        {
            UpdateByID(categoryID);
            // Clear the current item
            Session.Remove("Existing Product Item");
            // Go back to catalog form
            Server.Transfer("Maintenance.aspx");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);

        }

    }
    /// <summary>
    /// Do not replace existing Product information 
    /// Reset or texyBoxes let user input new values
    /// </summary>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // Clear the current item
        Session.Remove("Existing Product Item");
        //reset all textbox vlaues
        foreach (TextBox tb in textBoxArray)
        {
            tb.Text = "";
        }
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnInsert.Visible = true;
        btnReplace.Visible = false;
        btnCancel.Visible = false;
        btnReturn.Visible = true;
    }

    /// <summary>
    /// Delete current shown Product information
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        (((Business)Application["Business"])).deleteProductInfo(textBoxArray[0].Text);
        // Go back to catalog form
        Session.Remove("Editing Product Item");
        Server.Transfer("Maintenance.aspx");
    }

    /// <summary>
    /// Insert new Product information to database.
    /// Will check is Product already existing first.
    /// Check are all required key not empty before insert.
    /// </summary>
    private void insertData()
    {
        if (!isRequiredFiledEmpty())
        {
                for (int i = 0; i < ProductsInformation.GetLength(0); i++)
                {
                    if (textBoxArray[0].Text == ProductsInformation[i, 0])
                    {
                        Session["Existing Product Item"] = ProductsInformation[i, 0];
                        throw new System.ArgumentException("Product exist ! You can change Product or update the Product information.");
                    }
                }

                tansferValue();

                (((Business)Application["Business"])).insertProduct(updateValues[1], updateValues[2], updateValues[4],
                    updateValues[6], updateValues[7], updateValues[8], updateValues[9]
                    , updateValues[10], updateValues[11]);
                Array.Clear(updateValues, 0, 12);
        }
        else
        {
            throw new Exception("Inserting causes a problem: Miss required information! Please check follow fileds: ProductName");
        }
    }

    /// <summary>
    /// Update Product information
    /// Will check are all required filed not empty first
    /// </summary>
    private void UpdateByID(String productID)
    {

        if (!isRequiredFiledEmpty())
        {
            tansferValue();

            (((Business)Application["Business"])).updateProductInfo(productID, updateValues[1], updateValues[2], updateValues[4],
                updateValues[6], updateValues[7], updateValues[8], updateValues[9]
                , updateValues[10], updateValues[11]);
            Array.Clear(updateValues, 0, 12);
        }
        else
        {
            throw new ArgumentNullException("Updating causes a problem: Miss required information! Please check follow filed: ProductName.");
        }

    }


    /// <summary>
    /// Check whether the name filed is un-filed 
    /// Return true if at least one of the required filed is emepty.
    /// </summary>
    private bool isRequiredFiledEmpty()
    {
        if (textBoxArray[1].Text.Trim().Length != 0)
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// Check textBox values. 
    /// If the texBox is empty, change input string to NULL
    /// If there has a value, check the type of value then
    /// transfer the String to correct format that can use directly by the DBAccess Layer
    /// </summary>
    private void tansferValue()
    {
        for (int i = 0; i < textBoxArray.Length; i++)
        {
            if (i == 3 || i == 5)
                updateValues[i] = null;
            else if (textBoxArray[i].Text == "")
                updateValues[i] = "NULL";
                else if (i == 1 || i == 6)
                    updateValues[i] = "'" + textBoxArray[i].Text + "'";
                else updateValues[i] = textBoxArray[i].Text;
        }
    }
}
