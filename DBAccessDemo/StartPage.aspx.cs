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
using System.Text.RegularExpressions;

public partial class StartPage : System.Web.UI.Page
{
    private String[,] EmployeesLogon;
    private String Title;

    protected void Page_Load(object sender, EventArgs e)
    {
       btnOrder.Focus();
       EmployeesLogon = (((Business)Application["Business"])).getEmployeesInformation();
    }

    protected void btnViewCatalog_Click(object sender, EventArgs e)
    {
        // validate email address using regular expression

        if (IsValidEmail(txtEMail.Text))
        {
                // store valid email in Session variable
                Session.Add("Return EMail", txtEMail.Text);
                // display catalog page
                Server.Transfer("CatalogDisplay.aspx");
        }
        else
        {
            // Add message and redisplay this page
            Response.Write("You must enter a valid email address to continue");
            // set focus to email field
        }
    }

    // from MSDN .NET Framework Developer's Guide
    private bool IsValidEmail(string strIn)
    {
        // Return true if strIn is in valid e-mail format.
        return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }

    private bool IsValidLogon(string account, string password)
    {
        String passwordCheck = null;
        for (int i = 0; i < EmployeesLogon.GetLength(0); i++)
        {
            if (EmployeesLogon[i, 2] == account)
            {
                passwordCheck = EmployeesLogon[i, 16];
                Title = EmployeesLogon[i, 3];
            }
        }
        if (passwordCheck == password)
        return true;
        else return false;
    }
    protected void btnOrder_Click(object sender, EventArgs e)
    {
        txtEMail.Focus();
        panelOrder.Visible = true;
        panelStart.Visible = false;
    }
    protected void btnMaintenance_Click(object sender, EventArgs e)
    {
        txtAccountID.Focus();
        panelMaintenance.Visible = true;
        panelStart.Visible = false;
    }
    protected void btnLogon_Click(object sender, EventArgs e)
    {
        if (txtAccountID.Text != null && txtPassword.Text != null)
        {
            if (IsValidLogon(txtAccountID.Text, txtPassword.Text))
            {

                Session.Add("Title", Title);
                Server.Transfer("Maintenance.aspx");
            }
            else
            {
                Response.Write("Invalid logon information");
            }
        }
        else
        {
            // Add message and redisplay this page
            Response.Write("You must enter a valid AccountID and Password");
            // set focus to email field
        }
    }
}
