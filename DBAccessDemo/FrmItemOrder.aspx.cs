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
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


// Note: TextBox6 and txtQuantity have been right aligned
// as is appropriate for the presentation of numbers
// This is done using the Format|Style menu item
public partial class FrmItemOrder : System.Web.UI.Page
{
    // A way to simplify other code
    // These are references to arrays of references
    private Label[] labelArray = null;
    private TextBox[] textBoxArray = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        InitializeArrays();

        string[,] productsInformation = ((Business)Application["Business"]).getProductsInformation();
        string[] currentItemInformation = new string[productsInformation.GetLength(1)];

        // Loading up Categories in combo list
        for (int i = 0; i < productsInformation.GetLength(0); i++)
        {
            if ((String)Session["Current Item"] == productsInformation[i, 0])
            {
                for (int j = 0; j < currentItemInformation.Length; j++)
                {
                    currentItemInformation[j] = productsInformation[i, j];
                }
            }
        }

        if (currentItemInformation[0] != null)
        {
            labelArray[0].Text = "ProductID";
            labelArray[1].Text = "ProductName";
            labelArray[2].Text = "CategoryName";
            labelArray[3].Text = "CompanyName";
            labelArray[4].Text = "QuantityPerUnit";
            labelArray[5].Text = "UnitPrice";


            textBoxArray[0].Text = currentItemInformation[0];
            textBoxArray[1].Text = currentItemInformation[1];
            textBoxArray[2].Text = currentItemInformation[3];
            textBoxArray[3].Text = currentItemInformation[5];
            textBoxArray[4].Text = currentItemInformation[8];
            textBoxArray[5].Text = currentItemInformation[7];

        }
        // Set the user Focus on  the textbox they need to use
        txtQuantity.Focus();
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {   
        // Clear the messages
        Response.Clear();
        // Clear the current item
        Session.Remove("Current Item");
        // Go back to catalog form
        Server.Transfer("CatalogDisplay.aspx");
    }
    protected void btnOrder_Click(object sender, EventArgs e)
    {
        //Check for Shoppingcart object
        // Create first if not there
        if (Session["cart"] == null)
            Session["cart"] = new ShoppingCart();
        int quantity = 0;

        // make sure there is text
        if (txtQuantity.Text.Trim().Length != 0)
        {
            // try to convert text to int  ???
            try
            {
                quantity = int.Parse(txtQuantity.Text);
                // check for this item in the cart
                // Note this only makes sense if the "cart" exists
                // since it checks for an individual item in the cart
                if (((ShoppingCart)Session["cart"]).keyExists(int.Parse(TextBox1.Text)))
                {
                    // Set return and order button to invisible.
                    // Show error message to let user make choice to continue.
                    btnReturn.Visible = false;
                    btnOrder.Visible = false;
                    duplicateProductPanel.Visible = true;
                    Response.Write("Item already in cart. Please choose one of the following options.");
                }
                else  // This is a new item
                {
                    // Make the item
                    OrderItem item = new OrderItem(
                        int.Parse(TextBox1.Text), TextBox2.Text,
                        double.Parse(TextBox6.Text),
                        int.Parse(txtQuantity.Text));
                    // add to cart  
                    ((ShoppingCart)Session["cart"]).addToCart(item);

                    this.btnReturn_Click(sender, e);
                }
            }
            catch (FormatException) 
            {
                Response.Write("Please enter a number for the quaitity.");
                txtQuantity.Text = null;
            }
            catch (ArgumentException)
            {
                Response.Write("Numeric data must not be negative");
                txtQuantity.Text = null;
            } 
        }
        else
        {
            Response.Write("Nothing Ordered<br>You must order some of the product or return to the Catalog");
        }
    }

    private void InitializeArrays()
    {
        // First create arrays of 6 references
        // No Label or TextBox objects are created
        // They already exist, we are simply going to give them another set of names
        // that are array elements
        labelArray = new Label[6];
        textBoxArray = new TextBox[6];

        // Now assign the Controls to their array references
        labelArray[0] = Label1;
        labelArray[1] = Label2;
        labelArray[2] = Label3;
        labelArray[3] = Label4;
        labelArray[4] = Label5;
        labelArray[5] = Label6;

        textBoxArray[0] = TextBox1;
        textBoxArray[1] = TextBox2;
        textBoxArray[2] = TextBox3;
        textBoxArray[3] = TextBox4;
        textBoxArray[4] = TextBox5;
        textBoxArray[5] = TextBox6;

        // Now we can manipulate the controls using the arrays
    } // end of InitializeArrays

    protected void replaceButton_Click(object sender, EventArgs e)
    {
        int quantity = 0;
        try // Try if the input value is a number
        {   
            quantity = int.Parse(txtQuantity.Text);
            if (quantity < 0) // If input value is a negative number, reset textBox
            {
                Response.Write("Numeric data must not be negative");
                txtQuantity.Text = null;
            }
            else
            {   //  Replace quantity by new input value
                int productID = int.Parse(TextBox1.Text);
                ((ShoppingCart)Session["cart"]).replaceQuantity(productID, quantity);
                this.btnReturn_Click(sender, e);
            }

        }
        catch (FormatException)
        {
            Response.Write("Please enter a number for the quaitity.");
            txtQuantity.Text = null;
        }
    }

    protected void addValueButton_Click(object sender, EventArgs e)
    {
        int quantity = 0;
        try // Try if the input value is a number
        { 
            quantity = int.Parse(txtQuantity.Text);
            if (quantity < 0) // If input value is a negative number, reset textBox
            {
                Response.Write("Numeric data must not be negative");
                txtQuantity.Text = null;
            }
            else
            {    //  Add new input value to quantity
                int productID = int.Parse(TextBox1.Text);
                ((ShoppingCart)Session["cart"]).addQuantity(productID, quantity);
                this.btnReturn_Click(sender, e);
            }
        }
        catch (FormatException)
        {
            Response.Write("Please enter a number for the quaitity.");
            txtQuantity.Text = null;
        }
        

    }
    protected void ignoreButton_Click(object sender, EventArgs e)
    {   
        // don't save anything, just go back to the category page
        this.btnReturn_Click(sender, e);
    }
}
