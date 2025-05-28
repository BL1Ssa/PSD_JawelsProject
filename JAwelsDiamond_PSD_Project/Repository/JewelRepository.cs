using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JAwelsDiamond_PSD_Project.Repository
{
    public class JewelRepository
    {
        public List<MsCategory> GetCategories()
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                return db.MsCategories.ToList();
            }
        }

        public List<MsBrand> GetBrands()
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                return db.MsBrands.ToList();
            }
        }

        public bool AddJewel(string name, string categoryId, string brandId, string price, string releaseYear, out string errorMessage)
        {
            try
            {
                using (var db = new JawelsdatabaseEntities2())
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
            using (var db = new JawelsdatabaseEntities2())
            {
                return db.MsJewels.ToList();
            }
        }

        public MsJewel GetJewelById(int id)
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                return db.MsJewels.Find(id);
            }
        }

        public bool UpdateJewel(MsJewel updatedJewel)
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                MsJewel existing = db.MsJewels.Find(updatedJewel.JewelID);
                if (existing != null)
                {
                    existing.JewelName = updatedJewel.JewelName;
                    existing.JewelPrice = updatedJewel.JewelPrice;
                    existing.JewelReleaseYear = updatedJewel.JewelReleaseYear;
                    existing.BrandID = updatedJewel.BrandID;
                    existing.CategoryID = updatedJewel.CategoryID;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteJewel(int id)
        {
            using (var db = new JawelsdatabaseEntities2())
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
            using (var db = new JawelsdatabaseEntities2())
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
