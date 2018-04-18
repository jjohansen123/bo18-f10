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
        public static void PrintHighest()
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<HighId> highest = db.HighestNode.ToList();
                    foreach (HighId s in highest)
                    {
                        Console.WriteLine("Highest ID in database: " + s.HighestId);
                        Console.ReadKey();
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static int GetHighest()
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<HighId> highest = db.HighestNode.ToList();
                    foreach (HighId s in highest)
                    {
                       return s.HighestId;
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