using jawels_project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace jawels_project_2.Factory
{
    public class CartFactory
    {
        public static int CalculateSubtotal(decimal price, int qty)
        {
            return (int)(price * qty);
        }

        public static int CalculateTotal(List<Cart> cartList)
        {
            return cartList.Sum(item => CalculateSubtotal(item.MsJewel.JewelPrice, item.Quantity));
        }

        public static bool ValidateQuantity(int quantity)
        {
            return quantity > 0;
        }
    }
}
