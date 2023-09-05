using BusinessLayer;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ItemDALPassCase()
        {
            ItemsDAL itemsDAL = new ItemsDAL();

            List<ItemsDataModel> itemsList = new List<ItemsDataModel>();
            itemsList = itemsDAL.GetAllItems();

            Assert.AreEqual(itemsList.Count, 4);
        }

        [TestMethod]
        public void ItemDALFailCase()
        {
            ItemsDAL itemsDAL = new ItemsDAL();

            List<ItemsDataModel> itemsList = new List<ItemsDataModel>();
            itemsList = itemsDAL.GetAllItems();

            Assert.AreNotEqual(itemsList.Count, 3);
        }

        [TestMethod]
        public void ItemBLPassCase()
        {
            ItemsBL itemsBL = new ItemsBL(new ItemsDAL());

            List<ItemViewModel> billItems = new List<ItemViewModel>();

            List<ItemViewModel> cartItems = new List<ItemViewModel>();
            ItemViewModel item = new ItemViewModel();

            item.ItemName = "A";
            item.Quantity = 5;

            cartItems.Add(item);

            billItems = itemsBL.CalculateTotalAmountForCartItems(cartItems);

            Assert.AreEqual(billItems[0].TotalBillAmount, 230);
        }

        [TestMethod]
        public void ItemBLFailCase()
        {
            ItemsBL itemsBL = new ItemsBL(new ItemsDAL());

            List<ItemViewModel> billItems = new List<ItemViewModel>();

            List<ItemViewModel> cartItems = new List<ItemViewModel>();
            ItemViewModel item = new ItemViewModel();

            item.ItemName = "B";
            item.Quantity = 2;

            cartItems.Add(item);

            billItems = itemsBL.CalculateTotalAmountForCartItems(cartItems);

            Assert.AreNotEqual(billItems[0].TotalBillAmount, 60);
        }


    }
}
 