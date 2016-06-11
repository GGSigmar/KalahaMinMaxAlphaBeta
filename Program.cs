using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bantumi
{
    class Kalaha
    {
        private static void Main(string[] args)
        {

            int countingDepth = 6;
            var playground = new Board();
            playground.draw();

            while (true)
            {
                while (true)
                {
                    if (!playground.AskForMove(true)) // jezeli nie ma dodatkowego ruchu dla gracza
                    {
                        playground.draw();
                        break;
                    }
                    Console.WriteLine("\nDodatkowy ruch!\n");
                    playground.draw();
                }

                while (true)
                {
                    if (!playground.PlayerMove(false, playground.HeadQuarter(countingDepth))) // jezeli nie ma dodatkowego ruchu dla komputera
                    {
                        playground.draw();
                        break;
                    }
                    playground.draw();
                }
           
                if (playground.isOver()) break;
            }
            playground.FinishIt();
            playground.draw();
            
            Console.WriteLine("Wynik: " + playground.CalculateScore(true));
            Console.ReadKey();
        }
    }
}
