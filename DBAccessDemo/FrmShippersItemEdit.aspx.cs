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
/// for the Shipper who was stored in Session varable
/// Provided update and delete functions.
/// If there is no Shipper stored in Session varable
/// allow to insert new Shipper information
/// </summary>
public partial class FrmShippersEditing : System.Web.UI.Page
{
    private TextBox[] textBoxArray;
    // The values used for database access method arguments
    private String[] updateValues;
    String[,] ShippersInformation;

    protected void Page_Load(object sender, EventArgs e)
    {
        InitializeArray();
        ShippersInformation = (((Business)Application["Business"])).getShippersInformation();
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
                // If there is valid session varavle, load the Shipper informations
                if (Session["Editing Shipper Item"] != null)
                {
                    for (int i = 0; i < ShippersInformation.GetLength(0); i++)
                    {
                        if ((String)Session["Editing Shipper Item"] == ShippersInformation[i, 0])
                        {
                            for (int j = 0; j < textBoxArray.Length; j++)
                            {
                                textBoxArray[j].Text = ShippersInformation[i, j];
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
        textBoxArray = new TextBox[3];

        textBoxArray[0] = txtShipperID;
        textBoxArray[1] = txtCompanyName;
        textBoxArray[2] = txtPhone;


        updateValues = new String[3];
    }
    /// <summary>
    /// Do nothing and go back to catalog view page
    /// </summary>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // Clear the current item
        Session.Remove("Editing Shipper Item");
        // Go back to catalog form
        Server.Transfer("Maintenance.aspx");
    }
    /// <summary>
    /// Update Shipper information, then back to catalog view page
    /// </summary>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateByID(textBoxArray[0].Text);
            // Clear the current item
            Session.Remove("Editing Shipper Item");
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
    /// Insert new Shipper information, then back to catalog view page
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
    /// replace existing Shipper information by new input values
    /// </summary>
    protected void btnReplace_Click(object sender, EventArgs e)
    {
        String categoryID = (String)Session["Existing Shipper Item"];

        try
        {
            UpdateByID(categoryID);
            // Clear the current item
            Session.Remove("Existing Shipper Item");
            // Go back to catalog form
            Server.Transfer("Maintenance.aspx");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);

        }

    }
    /// <summary>
    /// Do not replace existing Shipper information 
    /// Reset or texyBoxes let user input new values
    /// </summary>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // Clear the current item
        Session.Remove("Existing Shipper Item");
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
    /// Delete current shown Shipper information
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        (((Business)Application["Business"])).deleteShipperInfo(textBoxArray[0].Text);
        // Go back to catalog form
        Session.Remove("Editing Shipper Item");
        Server.Transfer("Maintenance.aspx");
    }

    /// <summary>
    /// Insert new Shipper information to database.
    /// Will check is Shipper already existing first.
    /// Check are all required key not empty before insert.
    /// </summary>
    private void insertData()
    {
        if (!isRequiredFiledEmpty())
        {
            for (int i = 0; i < ShippersInformation.GetLength(0); i++)
            {
                if (textBoxArray[1].Text == ShippersInformation[i, 1])
                {
                    Session["Existing Shipper Item"] = ShippersInformation[i, 0];
                    throw new System.ArgumentException("Shipper exist ! You can change Shipper or update the Shipper information.");
                }
            }

            tansferValue();

            (((Business)Application["Business"])).insertShipper(updateValues[1], updateValues[2]);
            Array.Clear(updateValues, 0, 3);
        }
        else
        {
            throw new Exception("Inserting causes a problem: Miss required information! Please check follow fileds: CompanyName");
        }
    }

    /// <summary>
    /// Update Shipper information
    /// Will check are all required filed not empty first
    /// </summary>
    private void UpdateByID(String shipperID)
    {

        if (!isRequiredFiledEmpty())
        {
            tansferValue();

            (((Business)Application["Business"])).updateShipperInfo(shipperID,
                updateValues[1], updateValues[2]);
            Array.Clear(updateValues, 0, 3);
        }
        else
        {
            throw new ArgumentNullException("Updating causes a problem: Miss required information! Please check follow filed: CompanyName.");
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
            if (textBoxArray[i].Text == "")
                updateValues[i] = "NULL";
            else
                updateValues[i] = "'" + textBoxArray[i].Text + "'";
        }
    }
}
