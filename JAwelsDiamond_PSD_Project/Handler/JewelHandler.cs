using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JAwelsDiamond_PSD_Project.Repository;
using JAwelsDiamond_PSD_Project.Models;

namespace JAwelsDiamond_PSD_Project.Handler
{
    public class JewelHandler
    {
        private JewelRepository repo = new JewelRepository();

        public MsJewel GetJewelById(int id)
        {
            return repo.GetJewelById(id);
        }

        public List<MsCategory> GetCategories()
        {
            return repo.GetCategories();
        }

        public List<MsBrand> GetBrands()
        {
            return repo.GetBrands();
        }

        public bool ValidateJewelName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= 3 && name.Length <= 25;
        }

        public bool ValidateReleaseYear(string yearStr)
        {
            int year;
            return int.TryParse(yearStr, out year) && year >= 1900 && year <= DateTime.Now.Year;
        }

        public bool AddJewel(string name, string categoryId, string brandId, string price, string releaseYear, out string errorMessage)
        {
            return repo.AddJewel(name, categoryId, brandId, price, releaseYear, out errorMessage);
        }

        public bool UpdateJewel(int jewelId, string name, int categoryId, int brandId, int price, int year, out string errorMessage)
        {
            return repo.UpdateJewel(jewelId, name, categoryId, brandId, price, year, out errorMessage);
        }

        public bool ValidatePrice(string priceStr)
        {
            int price;
            return int.TryParse(priceStr, out price) && price > 25;
        }
    }
}