using jawels_project_2.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jawels_project_2.Factory
{
    public class JewelFactory
    {
        public static MsJewel Create(string name, string categoryId, string brandId, string price, string releaseYear)
        {
            return new MsJewel
            {
                JewelName = name,
                CategoryID = int.Parse(categoryId),
                BrandID = int.Parse(brandId),
                JewelPrice = int.Parse(price),
                JewelReleaseYear = int.Parse(releaseYear)
            };
        }

        public static MsJewel CreateJewel(string name, int categoryId, int brandId, int price, int year)
        {
            return new MsJewel
            {
                JewelName = name,
                CategoryID = categoryId,
                BrandID = brandId,
                JewelPrice = price,
                JewelReleaseYear = year
            };
        }
    }
}