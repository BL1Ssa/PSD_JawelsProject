using JAwelsDiamond_PSD_Project.Handler;
using JAwelsDiamond_PSD_Project.Models;
using System.Collections.Generic;

namespace JAwelsDiamond_PSD_Project.Controller
{
    public class JewelController
    {
        private JewelHandler handler = new JewelHandler();

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
            return handler.ValidateJewelName(name);
        }

        public bool ValidateReleaseYear(string yearStr)
        {
            return handler.ValidateReleaseYear(yearStr);
        }

        public bool AddJewel(string name, string categoryId, string brandId, string price, string releaseYear, out string errorMessage)
        {
            return handler.AddJewel(name, categoryId, brandId, price, releaseYear, out errorMessage);
        }
    }
}