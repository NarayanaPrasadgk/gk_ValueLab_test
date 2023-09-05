using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IItemsDAL
    {

        /// <summary>
        /// Get all items from the DB
        /// </summary>
        /// <returns></returns>
        List<ItemsDataModel> GetAllItems();
    }
}
