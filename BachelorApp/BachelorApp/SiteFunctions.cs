using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorDataAccess;
using BachelorModel;

namespace BachelorApp
{
    public class SiteFunctions
    {
        public static void AddSite(String NewSite)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Site> Sites = db.Sites.ToList();
                    Sites.Add(new Site() { SiteName = NewSite });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void AddSiteNoGUI()
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    Console.WriteLine("Input new site name:");
                    String NewSite = Console.ReadLine();
                    List<Site> Sites = db.Sites.ToList();
               
                            Sites.Add(new Site() { SiteName = NewSite, SiteId = 2 });
                            db.SaveChanges();
                    
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static String GetSite(int SiteId)
        {
            try
            {

                using (var db = new BachelorContext())
                {
                    List<Site> Sites = db.Sites.ToList();
                    foreach (Site s in Sites)
                    {
                        if (s.SiteId == SiteId)
                        {
                            return s.SiteName;
                        }
                    }
                }
                return "Load error";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static String GetSiteNoGui()
        {
            try
            {

                using (var db = new BachelorContext())
                {
                    List<Site> Sites = db.Sites.ToList();
                    foreach (Site s in Sites)
                    {
                        Console.WriteLine("Site id: " + s.SiteId + " sitename: " + s.SiteName);
                        Console.ReadKey();
                    }
                }
                return "Load error";
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
