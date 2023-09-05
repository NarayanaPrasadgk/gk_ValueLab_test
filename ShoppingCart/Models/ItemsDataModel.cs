using System;

namespace Models
{
    public class ItemsDataModel
    {
        /// <summary>
        /// Item Name
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Unit Price
        /// </summary>
        public int UnitPrice { get; set; }

        /// <summary>
        /// Special Price Qunatity
        /// </summary>
        public int? SpecialPriceQuantity { get; set; }

        /// <summary>
        /// Special Price
        /// </summary>
        public decimal? SpecialPrice { get; set; }
    }
}
