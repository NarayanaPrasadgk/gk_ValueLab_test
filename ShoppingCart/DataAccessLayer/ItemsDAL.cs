using Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class ItemsDAL : IItemsDAL
    {
        /// <summary>
        /// Get all the items from the DB
        /// </summary>
        /// <returns></returns>
        public List<ItemsDataModel> GetAllItems()
        {
            List<ItemsDataModel> itemsList = new List<ItemsDataModel>()
            {
                new ItemsDataModel() { ItemName = "A", UnitPrice = 50, SpecialPriceQuantity = 3, SpecialPrice = 130},
                new ItemsDataModel() { ItemName = "B", UnitPrice = 30, SpecialPriceQuantity = 2, SpecialPrice = 45},
                new ItemsDataModel() { ItemName = "C", UnitPrice = 20, SpecialPriceQuantity = null, SpecialPrice = null},
                new ItemsDataModel() { ItemName = "D", UnitPrice = 15, SpecialPriceQuantity = null, SpecialPrice = null}
            };
            
            return itemsList;


        }

    }
}
