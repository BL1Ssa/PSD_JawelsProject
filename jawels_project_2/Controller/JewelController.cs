using jawels_project_2.Models;
using jawels_project_2.Handler;

using System.Collections.Generic;

namespace jawels_project_2.Controller
{
    public class JewelController
    {
        private JewelHandler handler = new JewelHandler();

        public MsJewel GetJewelById(int id)
        {
            return handler.GetJewelById(id);
        }

        public List<MsCategory> GetCategories()
        {
            return handler.GetCategories();
        }

        public List<MsBrand> GetBrands()
        {
            return handler.GetBrands();
        }

        public bool ValidateJewelName(string name)
        {
            var len = name?.Trim().Length ?? 0;
            return len >= 3 && len <= 25;
        }

        public bool ValidateReleaseYear(string yearStr)
        {
            int year;
            return int.TryParse(yearStr, out year) && year < System.DateTime.Now.Year;
        }

        public bool ValidatePrice(string priceStr)
        {
            int price;
            return int.TryParse(priceStr, out price) && price > 25;
        }

        public bool AddJewel(string name, string categoryId, string brandId, string price, string releaseYear, out string errorMessage)
        {
            return handler.AddJewel(name, categoryId, brandId, price, releaseYear, out errorMessage);
        }

        public bool UpdateJewel(int jewelId, string name, string categoryId, string brandId, string priceStr, string yearStr, out string errorMessage)
        {
            errorMessage = "";
            int price, year, catId, brandIdInt;
            if (!ValidateJewelName(name))
            {
                errorMessage = "Jewel Name must be 3-25 characters.";
                return false;
            }
            if (!int.TryParse(categoryId, out catId))
            {
                errorMessage = "Invalid category.";
                return false;
            }
            if (!int.TryParse(brandId, out brandIdInt))
            {
                errorMessage = "Invalid brand.";
                return false;
            }
            if (!ValidatePrice(priceStr))
            {
                errorMessage = "Price must be a number and more than $25.";
                return false;
            }
            if (!ValidateReleaseYear(yearStr))
            {
                errorMessage = "Invalid release year.";
                return false;
            }
            price = int.Parse(priceStr);
            year = int.Parse(yearStr);

            return handler.UpdateJewel(jewelId, name.Trim(), catId, brandIdInt, price, year, out errorMessage);
        }
    }
}