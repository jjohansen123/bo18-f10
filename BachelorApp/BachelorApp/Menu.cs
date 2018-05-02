using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorApp
{
    class MenuNogui
    {
        public static void Menu()
        {
            Console.WriteLine("Options:\n[1]: Add node to system\n[2]: View Nodes\n[3]: Edit node\n[4]: View highest node ID\n[5]: Delete node(and all its children)\n[6]: Temporary SQL fix\n[7]: Add sites\n[8]: View sites\n[Anything else] Exit");
            ConsoleKey ButtonPressed = Console.ReadKey().Key;
            Console.Clear();
            if (ButtonPressed == ConsoleKey.D1 || ButtonPressed == ConsoleKey.NumPad1 || ButtonPressed == ConsoleKey.End)
            {
                BachelorApp.Register.RegisterNode();
            }
            else if (ButtonPressed == ConsoleKey.D2 || ButtonPressed == ConsoleKey.NumPad2 || ButtonPressed == ConsoleKey.DownArrow)
            {
                BachelorApp.View.ViewNodes();
            }
            else if (ButtonPressed == ConsoleKey.D3 || ButtonPressed == ConsoleKey.NumPad3 || ButtonPressed == ConsoleKey.PageDown)
            {
                BachelorApp.Updatenode.UpdateNode();
            }
            else if (ButtonPressed == ConsoleKey.D4 || ButtonPressed == ConsoleKey.NumPad3 || ButtonPressed == ConsoleKey.PageDown)
            {
                BachelorApp.Highestnode.PrintHighest();
                Menu();
            }

            else if (ButtonPressed == ConsoleKey.D5 || ButtonPressed == ConsoleKey.NumPad4 || ButtonPressed == ConsoleKey.PageDown)
            {
                BachelorApp.Deletenode.DeleteNode();
                BachelorApp.Refreshall.RefeshAll();
                Menu();
            }
            else if (ButtonPressed == ConsoleKey.D6 || ButtonPressed == ConsoleKey.NumPad4 || ButtonPressed == ConsoleKey.PageDown)
            {
              //  BachelorApp.SQLFIX.Sqlfix();
                Menu();
            }
            else if (ButtonPressed == ConsoleKey.D7 || ButtonPressed == ConsoleKey.NumPad3 || ButtonPressed == ConsoleKey.PageDown)
            {
                SiteFunctions.RegisterNode();
                Menu();
            }
            else if (ButtonPressed == ConsoleKey.D8 || ButtonPressed == ConsoleKey.NumPad2 || ButtonPressed == ConsoleKey.DownArrow)
            {
                SiteFunctions.GetSiteNoGui();
                Menu();
            }
            else
            {
                Console.WriteLine("Exiting");
                Console.ReadKey();
            }
        }
    }
}
