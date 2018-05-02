using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorDataAccess;

namespace BachelorApp
{
    public class Options
    {
        public static void Add(String name, int Low, int High)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<BachelorModel.Options> OptionsList = db.Model.ToList();
                    OptionsList.Add(new BachelorModel.Options() { ModelName = name, RangeOne = Low, RangeTwo = High });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void Change(int Id, String name, int Low, int High)
        {
            try
            {
                using (var db = new BachelorContext())
                {

                    List<BachelorModel.Options> OptionsList = db.Model.ToList();
                    foreach (BachelorModel.Options s in OptionsList)
                    {
                        if (s.ModelId == Id)
                        {
                            s.ModelName = name;
                            s.RangeOne = Low;
                            s.RangeTwo = High;
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

        public static void Delete( int Id)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<BachelorModel.Options> OptionsList = db.Model.ToList();
                    foreach(BachelorModel.Options s in OptionsList)
                    {
                        if(s.ModelId == Id)
                        {
                            OptionsList.Remove(s);
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

        public static List<BachelorModel.Options> Get()
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<BachelorModel.Options> returnvalue = db.Model.ToList();
                    return returnvalue;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
