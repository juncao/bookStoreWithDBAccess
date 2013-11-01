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
using System.Collections;
using System.Text;

/// <summary>
/// Summary description for ShoppingCart.
/// This adds OrderItem management to a shopping cart
/// implemented as a SortedList
/// </summary>
public class ShoppingCart : IEnumerable
{
	private SortedList theCart;

	public ShoppingCart() {
		theCart = new SortedList();
	} // end of Constructor

	
	public bool HasItems {
		get
        {
			bool hasItems = false;
			if( theCart.Count > 0 )
				hasItems = true;
			return hasItems;
		}
		set 
        {
			// ignore this is read only
		}
	} // end of HasItems


	public void addToCart(OrderItem item) 
    {
		theCart.Add(item.ProductID, item);
	}// AddToCaArt

    /// <summary>
    /// deletes item that is passed
    /// </summary>
    /// <param name="item"></param>
    public void deleteFromCart(OrderItem item)
    {
        theCart.Remove(item.ProductID);
    } // end deleteFromCart

    /// <summary>
    /// deletes the item with this id key
    /// </summary>
    /// <param name="id"></param>
    public void deleteFromCart(int id)
    {
        theCart.Remove(id);
    } // end deleteFromCart
    public OrderItem[] getCartContents()
    {
		
// need to create stuff
		OrderItem[] stuff = null;
		theCart.Values.CopyTo(stuff, 0);

		return (stuff);
	} // end getCartContents
	
	
	public bool keyExists(int ID) {
		
		return theCart.ContainsKey(ID);
	}// end keyExists

	public ICollection Values
	{
		get
		{
			return theCart.Values;
		}
	}

	#region IEnumerable Members

	public IEnumerator GetEnumerator()
	{
		return theCart.GetEnumerator();
	}

	#endregion

    public void replaceQuantity(int productID, int quantity)
    {
        int index = theCart.IndexOfKey(productID);
        ((OrderItem)theCart.GetByIndex(index)).QuantityOrdered = quantity;
    }

    public void addQuantity(int productID, int quantity)
    {
        int index = theCart.IndexOfKey(productID);
        ((OrderItem)theCart.GetByIndex(index)).QuantityOrdered += quantity;
    }
}