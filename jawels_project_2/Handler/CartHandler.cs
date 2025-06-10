using jawels_project_2.Factory;
using jawels_project_2.Models;
using jawels_project_2.Repository;
using System;
using System.Linq;

public class CartHandler
{
    public static void UpdateItemQuantity(int userId, int jewelId, int newQty)
    {
        if (!CartFactory.ValidateQuantity(newQty))
            throw new Exception("Invalid quantity");

        CartRepository.UpdateQuantity(userId, jewelId, newQty);
    }

    public static void RemoveItem(int userId, int jewelId)
    {
        CartRepository.RemoveItem(userId, jewelId);
    }


    public static void ClearUserCart(int userId)
    {
        CartRepository.ClearCart(userId);
    }

    public static void Checkout(int userId, String paymentMethod)
    {
        var cart = CartRepository.GetCartDisplayByUserID(userId); // returns List<CartDisplayDTO>
        TransactionRepository.InsertTransaction(userId, paymentMethod, cart);

        if (cart.Count == 0)
            throw new Exception("Cart is empty");

        TransactionRepository.InsertTransaction(userId, paymentMethod, cart);
        CartRepository.ClearCart(userId);
    }
    public void AddToCart(int userId, int jewelId, int quantity)
    {
        using (JawelsDatabaseEntities3 db = new JawelsDatabaseEntities3())
        {
            // Check if this jewel is already in the user's cart
            var existingCartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);

            if (existingCartItem != null)
            {
                // If already in cart, increase quantity
                existingCartItem.Quantity += quantity;
            }
            else
            {
                // If not, add new cart item
                Cart newItem = new Cart
                {
                    UserID = userId,
                    JewelID = jewelId,
                    Quantity = quantity
                };

                db.Carts.Add(newItem);
            }

            db.SaveChanges();
        }
    }
}
