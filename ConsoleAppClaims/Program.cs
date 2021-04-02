using ConsoleAppClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaimsConsoleUI ui = new ClaimsConsoleUI();
            ui.Run();
        }
    }
}
