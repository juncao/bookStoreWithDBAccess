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

/// <summary>
/// Summary description for OrderItem.
/// Really nothing to do here
/// This is a data type to manage OrderItems
/// </summary>
public class OrderItem
{
	private int productID;
	private string prodName;
	private double unitPrice;
	private int quantityOrdered;
	
	private string exceptionStr;

	/*public OrderItem()
	{
		exceptionStr = "Numeric data must not be negative";
		productID = 0;
		prodName = "";
		unitPrice = 0;
		quantityOrdered = 0;
	}*/

	
	public OrderItem(int id, string name, double price, int quantity)
	{
		prodName = name;
		exceptionStr = "Numeric data must not be negative";
		if ( id < 0 || price < 0 || quantity < 0)
		{
			throw new System.ArgumentException(exceptionStr);
		}
		else
		{
			productID = id;
			unitPrice = price;
			quantityOrdered = quantity;
		}
	}

    public bool isInStock(int stock)
    {
        if (quantityOrdered < stock) return true;           
        else return false;
    }
	
	
	#region Public Properties
	public int ProductID
	{
		get
		{
			return productID;
		}
	}

	public string ProductName
	{
		get 
		{
			return prodName;
		}
	}


	public double UnitPrice
	{
		get
		{
			return unitPrice;
		}
	}


	public int QuantityOrdered
	{
		get
		{
			return quantityOrdered;
		}
		set
		{
			if( value < 0 )
			{
				throw new ArgumentException(exceptionStr);
			}
			else
			{
				quantityOrdered = value;
			}
		}
	}

	#endregion
}