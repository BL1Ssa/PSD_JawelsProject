﻿using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JAwelsDiamond_PSD_Project.Repository;
using JAwelsDiamond_PSD_Project.Models;

namespace JAwelsDiamond_PSD_Project.Handler
{

    public class JewelHandler
    {
        private readonly JewelRepository repo;
        BrandRepository brandRepo = new BrandRepository();

        public JewelHandler()
        {
            repo = new JewelRepository();
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



        // Revisi "Punya Martin"
        public List<MsJewel> GetAllJewels()
        {
            return repo.GetAllJewels();
        }
        public List<MsCategory> getAllCategories()
        {
            return repo.GetCategories();
        }

        public MsJewel GetJewelDetails(int jewelId)
        {
            return repo.GetJewelById(jewelId);
        }

        public MsBrand getBrand(int id)
        {
            return brandRepo.GetBrandById(id);
        }

        public List<MsBrand> getAllBrands()
        {
            return repo.GetBrands();
        }

        public bool DeleteJewel(int jewelId)
        {
            return repo.DeleteJewel(jewelId);
        }

        public MsCategory GetCategory(int jewelId)
        {
            return repo.getCategoryById(jewelId);
        }

        
    }
}