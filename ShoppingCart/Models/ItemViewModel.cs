using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ItemViewModel
    {
        /// <summary>
        /// Item Name
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Unit Price
        /// </summary>
        public int UnitPrice { get; set; }

        /// <summary>
        /// Special Price
        /// </summary>
        public decimal? SpecialPrice { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Total Bill Amount
        /// </summary>
        public decimal TotalBillAmount { get; set; }
    }
}
