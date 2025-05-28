using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JAwelsDiamond_PSD_Project.Repository
{
    public class JewelRepository
    {
        private readonly JawelsdatabaseEntities2 db = new JawelsdatabaseEntities2();

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

        public List<MsJewel> GetAllJewels()
        {
            return db.MsJewels.ToList();
        }

        public MsJewel GetJewelById(int id)
        {
            return db.MsJewels.Find(id);
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

        public int getLastId()
        {
            MsJewel lastJewel = (from j in db.MsJewels select j).LastOrDefault();
            if(lastJewel == null)
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
