﻿using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JAwelsDiamond_PSD_Project.Repository
{
    public class JewelRepository
    {
        JawelsdatabaseEntities2 db = new JawelsdatabaseEntities2();
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

        //Revisi
        public List<MsJewel> GetAllJewels()
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                return db.MsJewels.ToList();
            }
        }

        //Revisi
        public MsJewel GetJewelById(int id)
        {
            using (var db = new JawelsdatabaseEntities2())
            {
                return db.MsJewels.FirstOrDefault(j => j.JewelID == id);
            }
            using (var db = new JawelsdatabaseEntities2())
            {
                
                return db.MsJewels
                        .Include("MsCategory")
                        .Include("MsBrand")
                        .FirstOrDefault(j => j.JewelID == id);
            }
        }

        public bool UpdateJewel(int jewelId, string name, int categoryId, int brandId, int price, int year, out string errorMessage)
        {
            errorMessage = "";
            using (var db = new JawelsdatabaseEntities2())
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

        public MsCategory getCategoryById(int id)
        {
            MsCategory cat = db.MsCategories.Find(id);
            return cat;
        }
    }
}
