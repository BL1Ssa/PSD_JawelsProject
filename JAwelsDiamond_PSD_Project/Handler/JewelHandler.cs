using JAwelsDiamond_PSD_Project.Models;
using JAwelsDiamond_PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsDiamond_PSD_Project.Handler
{

    public class JewelHandler
    {
        private readonly JewelRepository repo;
        private readonly JawelsDatabaseEntities db;

        public JewelHandler()
        {
            repo = new JewelRepository();
            db = new JawelsDatabaseEntities();
        }

        public List<MsJewel> GetAllJewels()
        {
            return db.MsJewels.ToList();
        }

        public MsJewel GetJewelDetails(int jewelId)
        {
            return db.MsJewels
                .Include("MsJewelCategory")
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