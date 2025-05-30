using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Factory;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JAwelsDiamond_PSD_Project.Repository
{
    public class JewelRepository
    {
        private readonly JawelsDatabaseEntities db = new JawelsDatabaseEntities();

        public bool AddJewel(MsJewel newJewel)
        {
            try
            {
                db.MsJewels.Add(newJewel);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Revisi
        public List<MsJewel> GetAllJewels()
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                
                return db.MsJewels
                        .Include("MsCategory")
                        .Include("MsBrand")
                        .ToList();
            }
        }

        //Revisi
        public MsJewel GetJewelById(int id)
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                
                return db.MsJewels
                        .Include("MsCategory")
                        .Include("MsBrand")
                        .FirstOrDefault(j => j.JewelID == id);
            }
        }

        public bool UpdateJewel(MsJewel updatedJewel)
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
        public bool DeleteJewel(int id)
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


        //Revisi
        public int GetLastId()
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                
                MsJewel lastJewel = db.MsJewels.OrderByDescending(j => j.JewelID).FirstOrDefault();
                return (lastJewel == null) ? 1 : lastJewel.JewelID + 1;
            }
        }
    }
}
