using jawels_project_2.Models;
using System.Collections.Generic;
using System.Linq;
public static class CartRepository
{
    private static JawelsDatabaseEntities3 db = new JawelsDatabaseEntities3();

    public class CartDisplayDTO
    {
        public int UserID { get; set; }
        public int JewelID { get; set; }
        public string JewelName { get; set; }
        public string BrandName { get; set; }
        public decimal JewelPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal => JewelPrice * Quantity;
    }

    public static List<CartDisplayDTO> GetCartDisplayByUserID(int userId)
    {
        using (var db = new JawelsDatabaseEntities3())
        {
            var query = from cart in db.Carts
                        join jewel in db.MsJewels on cart.JewelID equals jewel.JewelID
                        join brand in db.MsBrands on jewel.BrandID equals brand.BrandID
                        where cart.UserID == userId
                        select new CartDisplayDTO
                        {
                            UserID = cart.UserID, // If there's no PK, use composite key instead
                            JewelID = jewel.JewelID,
                            JewelName = jewel.JewelName,
                            BrandName = brand.BrandName,
                            JewelPrice = jewel.JewelPrice,
                            Quantity = cart.Quantity
                        };

            return query.ToList();
        }
    }


    public static void UpdateQuantity(int userId, int jewelId, int newQty)
    {
        using (var db = new JawelsDatabaseEntities3())
        {
            var cartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (cartItem != null)
            {
                cartItem.Quantity = newQty;
                db.SaveChanges();
            }
        }
    }

    public static void RemoveItem(int userId, int jewelId)
    {
        using (var db = new JawelsDatabaseEntities3())
        {
            var cartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (cartItem != null)
            {
                db.Carts.Remove(cartItem);
                db.SaveChanges();
            }
        }
    }


    public static void ClearCart(int userId)
    {
        var items = db.Carts.Where(c => c.UserID == userId).ToList();
        db.Carts.RemoveRange(items);
        db.SaveChanges();
    }

    public static List<Cart> GetCartModelsByUserID(int userId)
    {
        using (var db = new JawelsDatabaseEntities3())
        {
            return db.Carts.Where(c => c.UserID == userId).ToList();
        }
    }

}
