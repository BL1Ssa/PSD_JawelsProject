using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsDiamond_PSD_Project.Factory
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
    }
}