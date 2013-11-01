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
/// for the Customer who was stored in Session varable
/// Provided update and delete functions.
/// If there is no Customer stored in Session varable
/// allow to insert new Customer information
/// </summary>
public partial class FrmCustomersItemEdit : System.Web.UI.Page
{
    private TextBox[] textBoxArray;
    // The values used for database access method arguments
    private String[] updateValues;
    String[,] CustomersInformation;

    protected void Page_Load(object sender, EventArgs e)
    {
        InitializeArray();
        CustomersInformation = (((Business)Application["Business"])).getCustomerInformation();
        if (Session["Title"] == null)
        {
            Response.Redirect("StartPage.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                // If there is valid session varavle, load the Customer informations
                if (Session["Editing Customer Item"] != null)
                {
                    for (int i = 0; i < CustomersInformation.GetLength(0); i++)
                    {
                        if ((String)Session["Editing Customer Item"] == CustomersInformation[i, 0])
                        {
                            for (int j = 0; j < textBoxArray.Length; j++)
                            {
                                textBoxArray[j].Text = CustomersInformation[i, j];
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
            textBoxArray[0].Focus();
        }
    }

    private void InitializeArray()
    {
        textBoxArray = new TextBox[11];

        textBoxArray[0] = txtCustomerID;
        textBoxArray[1] = txtCompanyName;
        textBoxArray[2] = txtContactName;
        textBoxArray[3] = txtContactTitle;
        textBoxArray[4] = txtAddres;
        textBoxArray[5] = txtCity;
        textBoxArray[6] = txtRegion;
        textBoxArray[7] = txtPostalCode;
        textBoxArray[8] = txtCountry;
        textBoxArray[9] = txtPhone;
        textBoxArray[10] = txtFax;

        updateValues = new String[11];
    }
    /// <summary>
    /// Do nothing and go back to catalog view page
    /// </summary>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // Clear the current item
        Session.Remove("Editing Customer Item");
        // Go back to catalog form
        Server.Transfer("Maintenance.aspx");
    }
    /// <summary>
    /// Update Customer information, then back to catalog view page
    /// </summary>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        String categoryID = (String)Session["Editing Customer Item"];
        try
        {
            UpdateByID(categoryID);
            // Clear the current item
            Session.Remove("Editing Customer Item");
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
    /// Insert new Customer information, then back to catalog view page
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
    /// replace existing Customer information by new input values
    /// </summary>
    protected void btnReplace_Click(object sender, EventArgs e)
    {
        String categoryID = (String)Session["Existing Customer Item"];

        try
        {
            UpdateByID(categoryID);
            // Clear the current item
            Session.Remove("Existing Customer Item");
            // Go back to catalog form
            Server.Transfer("Maintenance.aspx");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);

        }

    }
    /// <summary>
    /// Do not replace existing Customer information 
    /// Reset or texyBoxes let user input new values
    /// </summary>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // Clear the current item
        Session.Remove("Existing Customer Item");
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
    /// Delete current shown Customer information
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        (((Business)Application["Business"])).deleteCustomerInfo(textBoxArray[0].Text);
        // Go back to catalog form
        Session.Remove("Editing Customer Item");
        Server.Transfer("Maintenance.aspx");
    }

    /// <summary>
    /// Insert new Customer information to database.
    /// Will check is Customer already existing first.
    /// Check are all required key not empty before insert.
    /// </summary>
    private void insertData()
    {
        if (!isRequiredFiledEmpty())
        {
            if ((textBoxArray[0].Text.Trim().Length == 5)&&(allUppercase()))
            {
                for (int i = 0; i < CustomersInformation.GetLength(0); i++)
                {
                    if (textBoxArray[0].Text == CustomersInformation[i, 0])
                    {
                        Session["Existing Customer Item"] = CustomersInformation[i, 0];
                        throw new System.ArgumentException("Customer exist ! You can change Customer or update the Customer information.");
                    }
                }

                tansferValue();

                (((Business)Application["Business"])).insertCustomer(updateValues[0],
                    updateValues[1], updateValues[2], updateValues[3], updateValues[4], updateValues[5],
                    updateValues[6], updateValues[7], updateValues[8], updateValues[9], updateValues[10]);
                Array.Clear(updateValues, 0, 11);
            }
            else
                throw new Exception("Please check follow fileds: CustomerID. CustomerID have to contains 5 Uppercase letters.");
        }
        else
        {
            throw new Exception("Inserting causes a problem: Miss required information! Please check follow fileds: CustomerID, CompanyName");
        }
    }

    /// <summary>
    /// Update Customer information
    /// Will check are all required filed not empty first
    /// </summary>
    private void UpdateByID(String categoryID)
    {

        if (!isRequiredFiledEmpty())
        {
            tansferValue();

            (((Business)Application["Business"])).updateCustomerInfo(categoryID,updateValues[0],
                updateValues[1], updateValues[2], updateValues[3], updateValues[4], updateValues[5],
                updateValues[6], updateValues[7], updateValues[8], updateValues[9], updateValues[10]);
            Array.Clear(updateValues, 0, 11);
        }
        else
        {
            throw new ArgumentNullException("Updating causes a problem: Miss required information! Please check follow filed: CustomerID, CustomerName.");
        }

    }


    /// <summary>
    /// Check whether the name filed is un-filed 
    /// Return true if at least one of the required filed is emepty.
    /// </summary>
    private bool isRequiredFiledEmpty()
    {
        if ((textBoxArray[0].Text.Trim().Length != 0)&&(textBoxArray[1].Text.Trim().Length != 0))
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// Check is CustomerID only contains uppercase letters
    /// </summary>
    /// <returns></returns>
    private bool allUppercase()
    {
        String text = textBoxArray[0].Text;
        foreach (char c in text)
        {
            if (char.IsLower(c))
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
            if (textBoxArray[i].Text == "")
                updateValues[i] = "NULL";
            else
                updateValues[i] = "'" + textBoxArray[i].Text + "'";
        }
    }
}
