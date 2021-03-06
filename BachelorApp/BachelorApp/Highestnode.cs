﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorModel;
using System.Data.Sql;
using BachelorDataAccess;

namespace BachelorApp
{
    public class Highestnode
    {
        /// <summary>
        /// Increments the highest value in the database.
        /// </summary>
        
        public static void SetHighest(int Site)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<HighId> highest = db.HighestNode.ToList();
                    foreach (HighId s in highest)
                    {
                        if (s.SiteId == Site)
                        {
                            s.HighestId++;
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets the highest ID in the given site. This is to generate a button with the correct name.
        /// </summary>
    
        public static int GetHighest(int SiteId)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<HighId> highest = db.HighestNode.ToList();
                    foreach (HighId s in highest)
                    {
                        if (s.SiteId == SiteId)
                        { 
                            return s.HighestId;
                        }
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }   
        }
    }
}
