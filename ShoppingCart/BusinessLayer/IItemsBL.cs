using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IItemsBL
    {
        /// <summary>
        /// Get all items from the DB
        /// </summary>
        /// <returns></returns>
        List<ItemsDataModel> GetAllItems();

        /// <summary>
        /// Calcualte the Total Amount for cart items
        /// </summary>
        /// <param name="cartItems"></param>
        /// <returns></returns>
        List<ItemViewModel> CalculateTotalAmountForCartItems(List<ItemViewModel> cartItems);
    }
}
