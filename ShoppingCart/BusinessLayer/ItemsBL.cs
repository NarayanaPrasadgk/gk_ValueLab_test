using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ItemsBL : IItemsBL
    {

        private IItemsDAL _itemsDAL;

        /// <summary>
        /// Constructor with DI
        /// </summary>
        /// <param name="itemsDAL"></param>
        public ItemsBL(ItemsDAL itemsDAL)
        {
            _itemsDAL = itemsDAL;
        }

        public List<ItemsDataModel> GetAllItems()
        {
            return _itemsDAL.GetAllItems();
        }


        /// <summary>
        /// Calcualte the Total Amount for cart items
        /// </summary>
        /// <param name="cartItems"></param>
        /// <returns></returns>
        public List<ItemViewModel> CalculateTotalAmountForCartItems(List<ItemViewModel> cartItems)
        {
            decimal totalAmount = 0;
            int qtyReminder = 0;
            int qtyIndex = 0;


            if(cartItems.Count > 0)
            {
                foreach (var cartItem in cartItems)
                {
                    // get the data item based on item name for calculating the price and amount

                    var itemData = _itemsDAL.GetAllItems().Find(x => x.ItemName == cartItem.ItemName);

                    // if there is special price for item use it
                    if(itemData.SpecialPriceQuantity != null)
                    {
                        if(cartItem.Quantity == itemData.SpecialPriceQuantity)
                        {
                            cartItem.SpecialPrice = itemData.SpecialPrice.Value;
                            cartItem.Amount = (itemData.SpecialPrice.Value * cartItem.Quantity);
                            totalAmount += cartItem.Amount;
                        }
                        else if(cartItem.Quantity < itemData.SpecialPriceQuantity)
                        {
                            cartItem.UnitPrice = itemData.UnitPrice;
                            cartItem.SpecialPrice = itemData.SpecialPrice.Value;
                            cartItem.Amount = (itemData.SpecialPrice.Value * cartItem.Quantity);
                            totalAmount += cartItem.Amount;
                        }
                        else if(cartItem.Quantity > itemData.SpecialPriceQuantity)
                        {
                            qtyReminder = (cartItem.Quantity % itemData.SpecialPriceQuantity.Value);
                            qtyIndex = (cartItem.Quantity / itemData.SpecialPriceQuantity.Value);

                            cartItem.UnitPrice = itemData.UnitPrice;
                            cartItem.SpecialPrice = itemData.SpecialPrice.Value;
                            cartItem.Amount = (itemData.SpecialPrice.Value * qtyIndex) + (itemData.UnitPrice * qtyReminder);
                            totalAmount += cartItem.Amount;


                        }
                    }
                    else
                    {
                        cartItem.UnitPrice = itemData.UnitPrice;
                        cartItem.Amount = (itemData.UnitPrice * cartItem.Quantity);
                        totalAmount += cartItem.Amount;

                    }

                    cartItem.TotalBillAmount = totalAmount;
                }

               
            }

            return cartItems;
        }


    }
}
