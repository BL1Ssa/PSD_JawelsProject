using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using jawels_project_2.Repository;
using jawels_project_2.Models;

namespace jawels_project_2.Handler
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



        //Punya Martin
        private JawelsDatabaseEntities3 db = new JawelsDatabaseEntities3(); // ini benerin co z db nya di repo ga ada
        public List<MsJewel> GetAllJewels()
        {
            return db.MsJewels.ToList();
        }

        public MsJewel GetJewelDetails(int jewelId)
        {
            return db.MsJewels
                .Include("MsCategory")
                .Include("MsBrand")
                .FirstOrDefault(j => j.JewelID == jewelId);
        }

        public bool DeleteJewel(int jewelId)
        {
            var jewel = db.MsJewels.Find(jewelId);
            if (jewel != null)
            {
                db.MsJewels.Remove(jewel);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}