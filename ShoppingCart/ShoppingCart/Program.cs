using BusinessLayer;
using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;

namespace ShoppingCart
{
    public class Program
    {
        List<ItemViewModel> cartItems = new List<ItemViewModel>();
        

        static void Main(string[] args)
        {
            Console.WriteLine("Shopping Kart!");
            Console.WriteLine("Available Items:");

            ItemsBL _itemsBL = new ItemsBL(new ItemsDAL());

            var avaibleItems = _itemsBL.GetAllItems();

            foreach (var item in avaibleItems)
            {
                Console.WriteLine($"Item Name || UnitPrice || Special Price Quantity || Special Price");
                Console.WriteLine($" {item.ItemName} || {item.UnitPrice} || {item.SpecialPriceQuantity} || {item.SpecialPrice}");
            }

            Console.WriteLine("Press + and enter to add new Item");
            Console.WriteLine("Press pp to Calculate and Print Invoice");

            Program p = new Program();
            do
            {

                while(!Console.KeyAvailable)
                {
                    string input = Console.ReadLine();

                    if(input == "+")
                    {
                        p.ValidateInput();
                    }
                    else if(input == "pp")
                    {
                        Console.WriteLine("Printing Invoice");

                        var invoiceItems = _itemsBL.CalculateTotalAmountForCartItems(p.cartItems);
                        decimal totalAmt = 0;
                        Console.WriteLine($"Item Name || Qunatity || Unit Price || Special Price  || Amount");
                        foreach (var item in invoiceItems)
                        {
                            totalAmt = item.TotalBillAmount;
                            Console.WriteLine($" {item.ItemName} || {item.Quantity} || {item.UnitPrice} || {item.SpecialPrice}  || {item.Amount}");

                        }
                        Console.WriteLine("Total Bill Amount = " + totalAmt);
                    }
                    else
                    {
                        p.ValidateInput();
                    }
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }


        public void ValidateInput()
        {
            Console.WriteLine("Enter Item Name, Quantity (Eg. A,4) and press enter.");

            // read the item name and qunatity
            string itemData = Console.ReadLine();

            if(itemData != null)
            {
                string[] item = itemData.Split(",");

                // check if the qunatity is a number or not
                int qty = 0;
                bool isNumber = int.TryParse(item[1], out qty);

                if(isNumber)
                {
                    AddEditCartItemsList(item[0].ToUpper(), qty);
                }
                else
                {
                    Console.WriteLine("Qunatity accepts number, please enter valid number");
                }

            }
            else
            {
                Console.WriteLine("Enter Item Name, Quantity (Eg. A,4) and press enter.");
            }


            Console.WriteLine("Press + and enter to add new Item, or press pp and enter to print invoice");
        }

        /// <summary>
        /// Add or edit the Items List
        /// </summary>
        public void AddEditCartItemsList(string itemName, int quantity)
        {
            var itemExists = cartItems.Find(x => x.ItemName == itemName);

            if(itemExists != null)
            {
                itemExists.Quantity += quantity;
            }
            else
            {
                ItemViewModel item = new ItemViewModel();

                item.ItemName = itemName;
                item.Quantity = quantity;

                cartItems.Add(item);

            }

        }

    }
}
