
using jawels_project_2.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using jawels_project_2.Models;

namespace jawels_project_2.Repository
{
    public class JewelRepository
    {
        public List<MsCategory> GetCategories()
        {
            using (var db = new JawelsDatabaseEntities3())
            {
                return db.MsCategories.ToList();
            }
        }

        public List<MsBrand> GetBrands()
        {
            using (var db = new JawelsDatabaseEntities3())
            {
                return db.MsBrands.ToList();
            }
        }

        public bool AddJewel(string name, string categoryId, string brandId, string price, string releaseYear, out string errorMessage)
        {
            try
            {
                using (var db = new JawelsDatabaseEntities3())
                {
                    var jewel = JewelFactory.Create(name, categoryId, brandId, price, releaseYear);
                    db.MsJewels.Add(jewel);
                    db.SaveChanges();
                }
                errorMessage = null;
                return true;
            }
            catch (System.Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public List<MsJewel> GetAllJewels()
        {
            using (var db = new JawelsDatabaseEntities3())
            {
                return db.MsJewels.ToList();
            }
        }

        public MsJewel GetJewelById(int id)
        {
            using (var db = new JawelsDatabaseEntities3())
            {
                return db.MsJewels.FirstOrDefault(j => j.JewelID == id);
            }
        }

        public bool UpdateJewel(int jewelId, string name, int categoryId, int brandId, int price, int year, out string errorMessage)
        {
            errorMessage = "";
            using (var db = new JawelsDatabaseEntities3())
            {
                var jewel = db.MsJewels.FirstOrDefault(j => j.JewelID == jewelId);
                if (jewel == null)
                {
                    errorMessage = "Jewel not found.";
                    return false;
                }
                jewel.JewelName = name;
                jewel.CategoryID = categoryId;
                jewel.BrandID = brandId;
                jewel.JewelPrice = price;
                jewel.JewelReleaseYear = year;
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteJewel(int id)
        {
            using (var db = new JawelsDatabaseEntities3())
            {
                var jewel = db.MsJewels.Find(id);
                if (jewel != null)
                {
                    db.MsJewels.Remove(jewel);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public int getLastId()
        {
            using (var db = new JawelsDatabaseEntities3())
            {
                MsJewel lastJewel = (from j in db.MsJewels select j).LastOrDefault();
                if (lastJewel == null)
                {
                    return 1;
                }
                else
                {
                    return lastJewel.JewelID + 1;
                }
            }
        }
    }
}
