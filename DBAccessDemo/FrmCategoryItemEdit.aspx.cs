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
/// Class name: FrmCategoryItemEdit
/// Class description: Provide categoried maintenace page
/// you can view and edit informations of particular category.
/// you can always link back to maintenance page 
/// you can delete particular category record 
/// by clicking "delete" button.
/// You can also insert new category record
/// by clicking "insert" button
/// when insertation, it will check whether 
/// the category name existed in record
/// if no, commit inserting
/// otherwise show item existing information
/// and ask for your action either updating or cancel
/// cancel is to clear all the filed information filled out
/// And then employee can re-entery for inserting other record.
/// Side effects (if any) including Errors and Exceptions:
/// 1-"Updating causes a problem:Miss required information!Please check follow filed: CategoryName."
/// 2-"Inserting causes a problem:Miss required information!Please check follow filed: CategoryName."
/// 3-"Category name exist ,You can change the name or update the category information."
/// Constraints: 
///     Name filed-It is required filed which should be filled out
///                Its maximum length is 15.
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
public partial class FrmCategoryItemEdit : System.Web.UI.Page
{
    // These are references to arrays of references
    private Label[] labelArray = null;
    private TextBox[] textBoxArray = null;
    // The values used for database access method parameters
    private String[] updateValues;
    string[,] categoryInformation;

    #region Page_Load(object sender, EventArgs e)
    /// <summary>
    /// Method name: Page_Load
    /// Method description: 
    /// get all categories informations from business object which
    /// is store in Session varable
    /// Show information for particular category
    /// show some button for editing the category
    /// Parameter list (one or more lines per parameter): 
    /// sender-object
    /// e-EventArgs
    /// Return type and value: N/A
    /// Side effects (if any) including Errors and Exceptions: N/A
    /// Constraints: none
    /// Assumptions: none
    /// Required libraries: 
    ///     System.Web.UI.WebControls;
    ///     System.Web.UI.WebControls.WebParts;
    ///     System.Web.UI.HtmlControls;
    /// Any warnings for maintenance: none
    /// Unresolved issues: none
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        InitializeArrays();

        categoryInformation = ((Business)Application["Business"]).getCategoryInformation();
        string[] currentItemInformation = new string[categoryInformation.GetLength(1)];

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
                if (Session["Editing Category Item"] != null)
                {
                    // Loading up Categories in combo list
                    for (int i = 0; i < categoryInformation.GetLength(0); i++)
                    {
                        if ((String)Session["Editing Category Item"] == categoryInformation[i, 0])
                        {
                            for (int j = 0; j < currentItemInformation.Length; j++)
                            {
                                currentItemInformation[j] = categoryInformation[i, j];
                            }
                        }
                    }

                    //Edit:Update,Delete
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    //no-editing action
                    btnInsert.Visible = false;
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnInsert.Visible = true;
                }

                if (currentItemInformation[0] != null)
                {
                    textBoxArray[0].Text = currentItemInformation[0];
                    textBoxArray[1].Text = currentItemInformation[1];
                    textBoxArray[2].Text = currentItemInformation[2];
                }
                labelArray[0].Text = "CategoryID";
                labelArray[1].Text = "CategoryName";
                labelArray[2].Text = "Description";

            }

            // Set the user Focus on  the textbox they need to use
            textBoxArray[1].Focus();
        }
    }
    #endregion

    # region btnReturn_Click(object sender, EventArgs e)
    /// <summary>
    /// Method name: btnReturn_Click
    /// Method description: 
    /// this method invokes by clicking the return button
    /// it is to link back to maintain page
    /// Parameter list (one or more lines per parameter): sender and e
    /// Return type and value: void
    /// Side effects (if any) including Errors and Exceptions: N/A
    /// Constraints: none
    /// Assumptions: none
    /// Required libraries: System.Data.OleDb;
    /// Any warnings for maintenance: none
    /// Unresolved issues: none
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // Clear the current item
        Session.Remove("Editing Category Item");
        // Go back to catalog form
        Server.Transfer("Maintenance.aspx");
    }
    #endregion

    #region btnUpdate_Click(object sender, EventArgs e)
    /// <summary>
    /// Method name: btnUpdate_Click
    /// Method description: 
    /// this method invokes by clicking the Update button
    /// it is to invoke UpdateByID method
    /// and then link back to maintain page
    /// Parameter list (one or more lines per parameter): sender and e
    /// Return type and value: void
    /// Side effects (if any) including Errors and Exceptions: N/A
    /// Constraints: none
    /// Assumptions: none
    /// Required libraries: System.Data.OleDb;
    /// Any warnings for maintenance: none
    /// Unresolved issues: none
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            UpdateByID(textBoxArray[0].Text);
            // Clear the current item
            Session.Remove("Editing Category Item");
            // Go back to catalog form
            Server.Transfer("Maintenance.aspx");
        }
        catch (ArgumentNullException arEx)
        {
            Response.Write(arEx.Message);
            TextBox1.Focus();
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);           
        }

    }
    # endregion

    # region btnInsert_Click(object sender, EventArgs e)
    /// <summary>
    /// Method name: btnInsert_Click
    /// Method description: 
    /// this method invokes by clicking the Insert button
    /// it is to invoke insertData method
    /// and then link back to maintain page
    /// Parameter list (one or more lines per parameter): sender and e
    /// Return type and value: void
    /// Side effects (if any) including Errors and Exceptions: N/A
    /// Constraints: none
    /// Assumptions: none
    /// Required libraries: System.Data.OleDb;
    /// Any warnings for maintenance: none
    /// Unresolved issues: none
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
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

   

    #region replace existing record during inserting
    /// <summary>
    /// Method name: btnReplace_Click
    /// Method description: 
    /// this method invokes by clicking the Replace button
    /// it is to invoke UpdateByID method
    /// and then link back to maintain page
    /// Parameter list (one or more lines per parameter): sender and e
    /// Return type and value: void
    /// Side effects (if any) including Errors and Exceptions: N/A
    /// Constraints: none
    /// Assumptions: none
    /// Required libraries: System.Data.OleDb;
    /// Any warnings for maintenance: none
    /// Unresolved issues: none
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void btnReplace_Click(object sender, EventArgs e)
    {
        String categoryID = (String)Session["Existing Category Item"];

        try
        {
            UpdateByID(categoryID);
            // Clear the current item
            Session.Remove("Existing Category Item");
            // Go back to catalog form
            Server.Transfer("Maintenance.aspx");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);

        }

    }
    #endregion



    #region cancel the filled information during inserting
    /// <summary>
    /// Method name: btnCancel_Click
    /// Method description: 
    /// this method invokes by clicking the Cancel button
    /// and then clear up all the informaion filled up
    /// Parameter list (one or more lines per parameter): sender and e
    /// Return type and value: void
    /// Side effects (if any) including Errors and Exceptions: N/A
    /// Constraints: none
    /// Assumptions: none
    /// Required libraries: System.Data.OleDb;
    /// Any warnings for maintenance: none
    /// Unresolved issues: none
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //// Clear the current item
        Session.Remove("Existing Category Item");
        //----------------reset all textbox vlaues------
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
    #endregion

    #endregion

    # region btnDelete_Click(object sender, EventArgs e)
    /// <summary>
    /// Method name: btnDelete_Click
    /// Method description: 
    /// this method invokes by clicking the Cancel button
    /// and then delete record of current item by calling method deleteCategoryInfo
    /// of business which storing in session 
    /// sequently, redirect to maintain page.
    /// Parameter list (one or more lines per parameter): sender and e
    /// Return type and value: void
    /// Side effects (if any) including Errors and Exceptions: N/A
    /// Constraints: none
    /// Assumptions: none
    /// Required libraries: System.Data.OleDb;
    /// Any warnings for maintenance: none
    /// Unresolved issues: none
    /// </summary>
    /// <param name="sender">object</param>
    /// <param name="e">System.EventArgs</param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        (((Business)Application["Business"])).deleteCategoryInfo(textBoxArray[0].Text);
        // Go back to catalog form
        Session.Remove("Editing Category Item");
        Server.Transfer("Maintenance.aspx");
    }
    #endregion

    #region help methods
    /// <summary>
    /// Method name: insertData
    /// Method description: 
    /// invoke by method btnInsert_Click(object sender, EventArgs e)
    /// it is to insert new category record to database 
    /// through call method insertCategory of business object 
    /// which is store in Session varable.
    /// Parameter list (one or more lines per parameter): categoryID-String
    /// Return type and value: N/A
    /// Side effects (if any) including Errors and Exceptions:
    /// 1-"Category name exist <br>You can change the name or update the category information."
    /// 2-"Inserting causes a problem:Miss required information!Please check follow filed: CategoryName."
    /// Constraints: category name can not existing in store when inserting
    /// Assumptions: none
    /// Required libraries: 
    ///     using System;
    ///     System.Data;
    ///     System.Web.UI.WebControls;
    ///     System.Web.UI.WebControls.WebParts;
    ///     System.Web.UI.HtmlControls;
    /// Any warnings for maintenance: none
    /// Unresolved issues: none
    /// </summary>
    private void insertData()
    {
        if (!isRequiredFiledEmpty())
        {
            for (int i = 0; i < categoryInformation.GetLength(0); i++)
            {
                if (textBoxArray[1].Text == categoryInformation[i, 1])
                {
                    Session["Existing Category Item"] = categoryInformation[i, 0];
                    throw new System.ArgumentException("Category name exist <br>You can change the name or update the category information.");

                }
            }
            tansferValue();
            (((Business)Application["Business"])).insertCategory(updateValues[1], updateValues[2]);
            Array.Clear(updateValues, 0, 2);
        }
        else
        {
            throw new Exception("Inserting causes a problem:Miss required information!Please check follow filed: CategoryName.");
        }
    }
    /// <summary>
    /// Method name: InitializeArrays
    /// Method description: 
    /// 
    /// Parameter list (one or more lines per parameter): none
    /// Return type and value: N/A
    /// Side effects (if any) including Errors and Exceptions: N/A
    /// Constraints: none
    /// Assumptions: none
    /// Required libraries: 
    ///     System.Web.UI.WebControls;
    ///     System.Web.UI.WebControls.WebParts;
    ///     System.Web.UI.HtmlControls;
    /// Any warnings for maintenance: none
    /// Unresolved issues: none
    /// </summary>
    private void InitializeArrays()
    {
        labelArray = new Label[3];
        textBoxArray = new TextBox[3];
        updateValues = new String[3];
        // Now assign the Controls to their array references
        labelArray[0] = Label1;
        labelArray[1] = Label2;
        labelArray[2] = Label3;

        textBoxArray[0] = TextBox1;
        textBoxArray[1] = TextBox2;
        textBoxArray[2] = TextBox3;

    } // end of InitializeArrays

    /// <summary>
    /// Method name: UpdateByID
    /// Method description: 
    /// invoke by method btnUpdate_Click(object sender, EventArgs e)
    /// it is to update category information 
    /// through call method updateCategoryInfo of business object 
    /// which is store in Session varable.
    /// Parameter list (one or more lines per parameter): categoryID-String
    /// Return type and value: N/A
    /// Side effects (if any) including Errors and Exceptions:
    /// "Updating causes a problem:Miss required information!Please check follow filed: CategoryName."
    /// Constraints: require field, such as name, can not be empty
    /// Assumptions: none
    /// Required libraries: 
    ///     using System;
    ///     System.Data;
    ///     System.Web.UI.WebControls;
    ///     System.Web.UI.WebControls.WebParts;
    ///     System.Web.UI.HtmlControls;
    /// Any warnings for maintenance: none
    /// Unresolved issues: none
    /// </summary>
    private void UpdateByID(String categoryID)
    {

        if (!isRequiredFiledEmpty())
        {
            tansferValue();
            (((Business)Application["Business"])).updateCategoryInfo(categoryID, updateValues[1], updateValues[2]);
            Array.Clear(updateValues, 0, 2);
        }
        else
        {
            throw new ArgumentNullException("Updating causes a problem:Miss required information!Please check follow filed: CategoryName.");
        }

    }


    /// <summary>
    /// Method name: isRequiredFiledEmpty
    /// Method description: 
    /// Check whether the name filed is un-filed 
    /// before commit unpdate process.
    /// Parameter list (one or more lines per parameter): none
    /// Return type and value: bool
    /// Side effects (if any) including Errors and Exceptions: N/A
    /// Constraints: none
    /// Assumptions: none
    /// Required libraries: 
    ///     System.Web.UI.WebControls;
    ///     System.Web.UI.WebControls.WebParts;
    ///     System.Web.UI.HtmlControls;
    /// Any warnings for maintenance: none
    /// Unresolved issues: none
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
    #endregion

}