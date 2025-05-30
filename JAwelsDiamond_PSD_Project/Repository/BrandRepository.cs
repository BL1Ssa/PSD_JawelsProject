using JAwelsDiamond_PSD_Project.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;

namespace JAwelsDiamond_PSD_Project.Repository
{
    public class BrandRepository
    {
        private JawelsdatabaseEntities2 db = new JawelsdatabaseEntities2();

        // CREATE - Insert new brand
        public void InsertBrand(MsBrand brand)
        {
            db.MsBrands.Add(brand);
            db.SaveChanges();
        }

        // READ - Get all brands
        public List<MsBrand> GetAllBrands()
        {
            return db.MsBrands.ToList();
        }

        // READ - Get brand by ID
        public MsBrand GetBrandById(int id)
        {
            return db.MsBrands.Find(id);
        }

        // UPDATE - Update brand by object
        public void UpdateBrand(MsBrand updatedBrand)
        {
            MsBrand existing = db.MsBrands.Find(updatedBrand.BrandID);
            if (existing != null)
            {
                existing.BrandName = updatedBrand.BrandName;
                existing.BrandCountry = updatedBrand.BrandCountry;
                existing.BrandClass = updatedBrand.BrandClass;
                db.SaveChanges();
            }
        }

        // DELETE - Delete brand by ID
        public void DeleteBrand(int id)
        {
            MsBrand brand = db.MsBrands.Find(id);
            if (brand != null)
            {
                db.MsBrands.Remove(brand);
                db.SaveChanges();
            }
        }
    }
}
