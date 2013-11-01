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
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Net.Mail;

public partial class FrmOrderReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Session["cart"] != null && ((ShoppingCart)Session["cart"]).HasItems)
        {
            Response.Write("<br>FrmOrderReview<br><br><br>");
            Response.Write("Your cart contains : <br>");

            ShoppingCart theCart = (ShoppingCart)(Session["cart"]);
            showOrder(theCart.Values);
        }
        else
        {
            Response.Clear();
            Response.Write("Your cart is empty. <br> ");
            btnConfirm.Visible = false;
        }
    }

    protected void btnCancel_Click(object sender, System.EventArgs e)
    {
        Response.Clear();
        Server.Transfer("CatalogDisplay.aspx");
    }

    /// <summary>
    /// Confirm the order
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnConfirm_Click(object sender, System.EventArgs e)
    {
        // Check quantities available
        // Confirming all in stock items and new total
        if (checkAvailables() != null)
        {
            lblOutOfStock.Text = "These proudcts are out of stock:<br>" + checkAvailables();
        }
        else
        {
            upDateItemInStock();

            // Build and send email to customer
            if (Session["Return EMail"] != null)
            {
                String email = (string)Session["Return EMail"];
                sendEmail(email);
            }
            // clear all session variables
            Session.RemoveAll();
            Response.Clear();
            // return to start page
            Response.Redirect("FrmOrderConfirmation.aspx", true);
        }
    }

    /// <summary>
    /// showOrder displays the OrderItems in a table
    /// using HTMLTextWriter
    /// Adapted from Russell Text chapter 10
    /// </summary>
    /// <param name="values"></param>
    private void showOrder(ICollection values)
    {
        double total = 0;

        HtmlTable tbl = new HtmlTable();
        //StringBuilder sb = new StringBuilder(3000);
        //StringWriter sw = new StringWriter(sb);
        // HtmlTextWriter htw = new HtmlTextWriter(sw);

        HtmlTableRow row;
        HtmlTableCell cell;
        tbl.Border = 1;
        tbl.Align = "left";

        // Now add a Cell for each property and item
        // there are 5 cells per row
        foreach (OrderItem item in values)
        {
            row = new HtmlTableRow();
            tbl.Rows.Add(row);

            cell = new HtmlTableCell();
            cell.Attributes.Add("style",
                "color:black; " +
                "background:lightYellow");
            cell.Align = "Right";
            cell.InnerText = item.ProductID.ToString();
            row.Cells.Add(cell);

            cell = new HtmlTableCell();
            cell.Attributes.Add("style", "color:blue; background:lightYellow");
            cell.Align = "Left";
            cell.InnerText = item.ProductName.ToString();
            row.Cells.Add(cell);

            double price = item.UnitPrice;
            int quantity = item.QuantityOrdered;
            double lineTotal = Math.Round(price * quantity, 2);
            total += lineTotal;

            cell = new HtmlTableCell();
            cell.Attributes.Add("style",
                "color:black; " +
                "background:lightYellow");
            cell.Align = "Right";
            cell.InnerText = quantity.ToString();
            row.Cells.Add(cell);

            cell = new HtmlTableCell();
            cell.Attributes.Add("style",
                "color:black; " +
                "background:lightYellow");
            cell.Align = "Right";
            cell.InnerText = price.ToString("F");
            row.Cells.Add(cell);

            cell = new HtmlTableCell();
            cell.Attributes.Add("style",
                "color:black; " +
                "background:lightYellow");
            cell.Align = "Right";
            cell.InnerText = lineTotal.ToString("C");
            row.Cells.Add(cell);

            cell = new HtmlTableCell();

            Button newButton = new Button();
            newButton.ID = item.ProductID.ToString();
            newButton.Text = "Delete";
            newButton.UseSubmitBehavior = true;
            newButton.Click += new EventHandler(newButton_Click);
            newButton.Visible = true;
            cell.Controls.Add(newButton);
            row.Cells.Add(cell);


        }

        // Now we need the Total
        // Mostly an empty row with nothing except the last cell
        row = new HtmlTableRow();
        tbl.Rows.Add(row);
        // deadcell 1
        cell = new HtmlTableCell();
        row.Cells.Add(cell);
        // deadcell 2
        cell = new HtmlTableCell();
        row.Cells.Add(cell);
        // deadcell 3
        cell = new HtmlTableCell();
        row.Cells.Add(cell);
        // deadcell 4
        cell = new HtmlTableCell();
        row.Cells.Add(cell);

        // total cell
        cell = new HtmlTableCell();
        cell.Attributes.Add("style",
            "color:black; " +
            "background:lightYellow");
        cell.Align = "Right";
        cell.InnerText = total.ToString("C");
        row.Cells.Add(cell);
        tbl.EnableViewState = true;
        PlaceHolder1.Controls.Add(tbl);

    }

    protected void newButton_Click(object sender, System.EventArgs e)
    {
        PlaceHolder1.Controls.Clear();
        ShoppingCart theCart = (ShoppingCart)(Session["cart"]);
        theCart.deleteFromCart(int.Parse(((Button)sender).ID));
        // Re-check is the chart empty after delete items
        if (theCart.HasItems)
            showOrder(theCart.Values);
        else
        {
            Response.Clear();
            Response.Write("Your cart is empty. <br> ");
            btnConfirm.Visible = false;
            lblOutOfStock.Text = "";
        }
    }

    // Check if enough product in stock
    protected string checkAvailables()
    {
        ShoppingCart theCart = (ShoppingCart)(Session["cart"]);
        String notInStockItems = null;

        foreach (OrderItem item in theCart.Values)
        {
            int stock = ((Business)Application["Business"]).checkUnitsInStock(item.ProductID.ToString());
            if (!item.isInStock(stock))
            {    // If item is out ou stock, add ProductName to string notInStockItems
                notInStockItems += (Environment.NewLine + item.ProductName);
            }
        }
        return notInStockItems;
    }

    private void upDateItemInStock()
    {
        ShoppingCart theCart = (ShoppingCart)(Session["cart"]);
        try
        {
            foreach (OrderItem item in theCart.Values)
            {
                int q = item.QuantityOrdered;
                int ID = item.ProductID;

                ((Business)Application["Business"]).updateUnitsInStock(ID, q);

            }
        }
        catch (Exception)
        {

        }

    }

    private void sendEmail(string emailAddress)
    {
        try
        {
            // Set up mail
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("northwind1385@gmail.com");
            mail.To.Add(emailAddress);
            mail.Subject = "Order Confirmation";
            mail.Body = ((ShoppingCart)(Session["Cart"])).ToString();
            // Set up mail server 
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("northwind1385@gmail.com", "northwind1385");
            SmtpServer.EnableSsl = true;
            // Send mail
            SmtpServer.Send(mail);
            Response.Write("Email Send");
        }
        catch (SmtpException)
        {
            Response.Write("Email not send ");
        }
    }
}
