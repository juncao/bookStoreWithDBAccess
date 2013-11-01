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
/// for the employee who was stored in Session varable
/// Provided update and delete functions.
/// If there is no employee stored in Session varable
/// allow to insert new employee information
/// </summary>
public partial class FrmEmployeesItemEdit : System.Web.UI.Page
{
    private TextBox[] textBoxArray;
    // The values used for database access method arguments
    private String[] updateValues; 
    String[,] EmployeesInformation;

    protected void Page_Load(object sender, EventArgs e)
    {
        InitializeArray();
        EmployeesInformation = (((Business)Application["Business"])).getEmployeesInformation();

        if (Session["Title"] == null)
        {
            Response.Redirect("StartPage.aspx");
        }
        else if (Session["Title"].ToString() != "Vice President, Sales")
        {
            Response.Redirect("Maintenance.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                // If there is valid session varavle, load the employee informations
                if (Session["Editing Employee Item"] != null)
                {
                    for (int i = 0; i < EmployeesInformation.GetLength(0); i++)
                    {
                        if ((String)Session["Editing Employee Item"] == EmployeesInformation[i, 0])
                        {
                            for (int j = 0; j < textBoxArray.Length; j++)
                            {
                                textBoxArray[j].Text = EmployeesInformation[i, j];
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
        textBoxArray = new TextBox[17];

        textBoxArray[0] = txtEmployeeID;
        textBoxArray[1] = txtLastName;
        textBoxArray[2] = txtFirstName;
        textBoxArray[3] = txtTitle;
        textBoxArray[4] = txtTitleOfCourtesy;
        textBoxArray[5] = txtBirthDate;
        textBoxArray[6] = txtHireDate;
        textBoxArray[7] = txtAddress;
        textBoxArray[8] = txtCity;
        textBoxArray[9] = txtRegion;
        textBoxArray[10] = txtPostalCode;
        textBoxArray[11] = txtCountry;
        textBoxArray[12] = txtHomePhone;
        textBoxArray[13] = txtExtension;
        textBoxArray[14] = txtPhoto;
        textBoxArray[15] = txtNotes;
        textBoxArray[16] = txtReportsTo;

        updateValues = new String[17];
    }
    /// <summary>
    /// Do nothing and go back to catalog view page
    /// </summary>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // Clear the current item
        Session.Remove("Editing Employee Item");
        // Go back to catalog form
        Server.Transfer("Maintenance.aspx");
    }
    /// <summary>
    /// Update employee information, then back to catalog view page
    /// </summary>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateByID(textBoxArray[0].Text);
            // Clear the current item
            Session.Remove("Editing Employee Item");
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
    /// Insert new employee information, then back to catalog view page
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
    /// replace existing employee information by new input values
    /// </summary>
    protected void btnReplace_Click(object sender, EventArgs e)
    {
        String categoryID = (String)Session["Existing Employee Item"];

        try
        {
            UpdateByID(categoryID);
            // Clear the current item
            Session.Remove("Existing Employee Item");
            // Go back to catalog form
            Server.Transfer("Maintenance.aspx");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);

        }

    }
    /// <summary>
    /// Do not replace existing employee information 
    /// Reset or texyBoxes let user input new values
    /// </summary>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        // Clear the current item
        Session.Remove("Existing Employee Item");
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
    /// Delete current shown employee information
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        (((Business)Application["Business"])).deleteEmployeeInfo(textBoxArray[0].Text);
        // Go back to catalog form
        Session.Remove("Editing Employee Item");
        Server.Transfer("Maintenance.aspx");
    }

    /// <summary>
    /// Insert new employee information to database.
    /// Will check is employee already existing first.
    /// Check are all required key not empty before insert.
    /// </summary>
    private void insertData()
    {
        if (!isRequiredFiledEmpty())
        {
            for (int i = 0; i < EmployeesInformation.GetLength(0); i++)
            {
                if ((textBoxArray[1].Text == EmployeesInformation[i, 1]) && (textBoxArray[2].Text == EmployeesInformation[i, 2]))
                {
                    Session["Existing Employee Item"] = EmployeesInformation[i, 0];
                    throw new System.ArgumentException("Employee name exist ! You can change the name or update the Employee information.");
                }
            }

            tansferValue();

            (((Business)Application["Business"])).insertEmployee(
                updateValues[1], updateValues[2], updateValues[3], updateValues[4], updateValues[5],
                updateValues[6], updateValues[7], updateValues[8], updateValues[9], updateValues[10],
                updateValues[11], updateValues[12], updateValues[13], updateValues[14], updateValues[15],
                updateValues[16]);
            Array.Clear(updateValues, 0, 16);
        }
        else
        {
            throw new Exception("Inserting causes a problem: Miss required information! Please check follow fileds: LastName, FirstName.");
        }
    }

    /// <summary>
    /// Update employee information
    /// Will check are all required filed not empty first
    /// </summary>
    private void UpdateByID(String categoryID)
    {

        if (!isRequiredFiledEmpty())
        {
            tansferValue();

            (((Business)Application["Business"])).updateEmployeeInfo(categoryID,
                updateValues[1], updateValues[2], updateValues[3], updateValues[4], updateValues[5],
                updateValues[6], updateValues[7], updateValues[8], updateValues[9], updateValues[10],
                updateValues[11], updateValues[12], updateValues[13], updateValues[14], updateValues[15],
                updateValues[16]);
            Array.Clear(updateValues, 0, 16);
        }
        else
        {
            throw new ArgumentNullException("Updating causes a problem:Miss required information!Please check follow filed: CategoryName.");
        }

    }


    /// <summary>
    /// Check whether the name filed is un-filed 
    /// Return true if at least one of the required filed is emepty.
    /// </summary>
    private bool isRequiredFiledEmpty()
    {
        if ((textBoxArray[1].Text.Trim().Length != 0) && (textBoxArray[2].Text.Trim().Length != 0))
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
                if (i == 5 || i == 6)
                {
                    DateTime value;
                    if (!DateTime.TryParse(textBoxArray[i].Text, out value))
                        throw new Exception("Not vaild DataTime");
                    else updateValues[i] = "'" + value.ToString() + "'";
                }  // not work
                else if (i == 16)
                    updateValues[i] = textBoxArray[i].Text;
                else
                    updateValues[i] = "'" + textBoxArray[i].Text + "'";
        }
    }
}
