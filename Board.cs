using System;
using System.Diagnostics;
using System.Linq;

namespace Bantumi
{
    public class Board
    {
        public Pot Player1BasePot;
        public Pot Player2BasePot;
        public Pot[] Player1Pots = new Pot[6];
        public Pot[] Player2Pots = new Pot[6];
        public const int startingBeans = 6;

        public Board()
        {
            Player1BasePot = new Pot(0);
            Player2BasePot = new Pot(0);

            for (int i = 0; i < 6; i++)
            {
                Player1Pots[i] = new Pot(startingBeans);
                Player2Pots[i] = new Pot(startingBeans);
            }
        }

        public Board(Board copy)
        {
            Player1BasePot = new Pot(copy.Player1BasePot.beanCount);
            Player2BasePot = new Pot(copy.Player2BasePot.beanCount);
            for (int i = 0; i < 6; i++)
            {
                Player1Pots[i] = new Pot(copy.Player1Pots[i].beanCount);
                Player2Pots[i] = new Pot(copy.Player2Pots[i].beanCount);
            }
        }

        public void draw()
        {

            Console.WriteLine("        /---------Gracz  2--------\\");
            Console.WriteLine("        |-------------------------|");

            Console.Write("        |/--\\");

            if (Player2Pots[5].beanCount < 10)
            {
                Console.Write("0" + Player2Pots[5].beanCount + "|");
            }
            else
            {
                Console.Write(Player2Pots[5].beanCount + "|");
            }

            if (Player2Pots[4].beanCount < 10)
            {
                Console.Write("0" + Player2Pots[4].beanCount + "|");
            }
            else
            {
                Console.Write(Player2Pots[4].beanCount + "|");
            }

            if (Player2Pots[3].beanCount < 10)
            {
                Console.Write("0" + Player2Pots[3].beanCount + "|");
            }
            else
            {
                Console.Write(Player2Pots[3].beanCount + "|");
            }

            if (Player2Pots[2].beanCount < 10)
            {
                Console.Write("0" + Player2Pots[2].beanCount + "|");
            }
            else
            {
                Console.Write(Player2Pots[2].beanCount + "|");
            }

            if (Player2Pots[1].beanCount < 10)
            {
                Console.Write("0" + Player2Pots[1].beanCount + "|");
            }
            else
            {
                Console.Write(Player2Pots[1].beanCount + "|");
            }

            if (Player2Pots[0].beanCount < 10)
            {
                Console.Write("0" + Player2Pots[0].beanCount);
            }
            else
            {
                Console.Write(Player2Pots[0].beanCount);
            }

            Console.Write("/--\\|\n");

            if(Player2BasePot.beanCount < 10)
            {
                Console.Write("        ||0");
                Console.Write(Player2BasePot.beanCount);
            }
            else
            {
                Console.Write("        ||");
                Console.Write(Player2BasePot.beanCount);
            }

            Console.Write("|-----------------|");

            if (Player1BasePot.beanCount < 10)
            {
                Console.Write("0");
                Console.Write(Player1BasePot.beanCount);
                Console.Write("||\n");
            }
            else
            {
                Console.Write(Player1BasePot.beanCount);
                Console.Write("||\n");
            }

            Console.Write("        |\\--/");

            if(Player1Pots[0].beanCount < 10)
            {
                Console.Write("0" + Player1Pots[0].beanCount + "|");
            }
            else
            {
                Console.Write(Player1Pots[0].beanCount + "|");
            }

            if (Player1Pots[1].beanCount < 10)
            {
                Console.Write("0" + Player1Pots[1].beanCount + "|");
            }
            else
            {
                Console.Write(Player1Pots[1].beanCount + "|");
            }

            if (Player1Pots[2].beanCount < 10)
            {
                Console.Write("0" + Player1Pots[2].beanCount + "|");
            }
            else
            {
                Console.Write(Player1Pots[2].beanCount + "|");
            }

            if (Player1Pots[3].beanCount < 10)
            {
                Console.Write("0" + Player1Pots[3].beanCount + "|");
            }
            else
            {
                Console.Write(Player1Pots[3].beanCount + "|");
            }

            if (Player1Pots[4].beanCount < 10)
            {
                Console.Write("0" + Player1Pots[4].beanCount + "|");
            }
            else
            {
                Console.Write(Player1Pots[4].beanCount + "|");
            }

            if (Player1Pots[5].beanCount < 10)
            {
                Console.Write("0" + Player1Pots[5].beanCount);
            }
            else
            {
                Console.Write(Player1Pots[5].beanCount);
            }

            Console.Write("\\--/|\n");

            Console.WriteLine("        |-------------------------|");
            Console.WriteLine("        \\---------Gracz  1--------/");

        }

        public bool isOver()
        {
            
            var sum1 = Player1Pots.Sum(pot => pot.beanCount);  // linq i delta expressions! yay, education!
            var sum2 = Player2Pots.Sum(pot => pot.beanCount);

            return sum1 == 0 | sum2 == 0;
        }

        // EVALUATION FUNCTIONS HERE

        public int CalculateScore(bool player)
        {
            if (player) return Player1BasePot.beanCount - Player2BasePot.beanCount;
            return Player2BasePot.beanCount - Player1BasePot.beanCount;

        }

        public int CalculateScoreSimple(bool player)
        {
            if (player) return Player1BasePot.beanCount;
            return Player2BasePot.beanCount;
        }

        public void FinishIt()
        {
            foreach (var pot in Player1Pots)
            {
                Player1BasePot.beanCount += pot.beanCount;
                pot.beanCount = 0;
            }
            foreach (var pot in Player2Pots)
            {
                Player2BasePot.beanCount += pot.beanCount;
                pot.beanCount = 0;
            }
        }

        public bool AskForMove(bool player) // ruch gracza
        {
            if (player) Console.WriteLine("\nGracz 1 - ");
            else Console.WriteLine("\nGracz 2 - ");

            Console.WriteLine("\nPodaj numer dołka z którego chcesz wyciągnąć kamyczki (1-6): ");

            var choice = int.Parse(Console.ReadLine());

            if (Player1Pots[choice - 1].beanCount == 0)
            {
                Console.WriteLine("\nNie mozesz wykonac wybrac dolka zawierajacego 0 kamyczkow!");
                return true;
            }
            
            return PlayerMove(player, choice); // zwraca czy jest dodatkowy ruch
        }

        public bool PlayerMove(bool player, int choice) // zwraca true jezeli ruch zezwala na dodatkowy ruch
        {
            choice--;
            int beanCount;
            if (player)
            {
                beanCount = Player1Pots[choice].beanCount;
                Player1Pots[choice].beanCount = 0;
            }
            else
            {
                beanCount = Player2Pots[choice].beanCount;
                Player2Pots[choice].beanCount = 0;
                choice += 7;
            }

            for (int i = 0; i < beanCount; i++)
            {
                choice++;//                                                                               P1
                if (choice < 6) Player1Pots[choice].beanCount++;  // 0 - 5 -> Player pots        /-\12|11|10|9 |8 |7 /-\
                else if (choice == 6) Player1BasePot.beanCount++;   //                           |13-----------------|6|
                else if (choice > 6 && choice < 13) Player2Pots[choice - 7].beanCount++;  //     \-/0 |1 |2 |3 |4 |5 \-/
                else if (choice == 13) Player2BasePot.beanCount++;//                                      P2
                else if (choice == 14)
                {
                    choice = 0;
                    Player1Pots[choice].beanCount++;
                }

            }

            if(player)
            {
                if(choice==6)
                {
                    return true; // dodatkowy ruch gracza
                }
            }

            if(!player)
            {
                if(choice==13)
                {
                    return true; // dodatkowy ruch ai
                }
            }

            if (choice < 6 && Player1Pots[choice].beanCount == 1) // taking beans if finishing in empty pot in P1 row
            {
                if (player)
                {
                    Player1BasePot.beanCount += Player2Pots[Math.Abs(choice - 5)].beanCount + 1;

                    Player1Pots[choice].beanCount = 0;
                    Player2Pots[Math.Abs(choice - 5)].beanCount = 0;
                }
            }

            if (choice > 6 && choice < 13 && Player2Pots[choice - 7].beanCount == 1) // taking beans if finishing in empty pot P2
            {
                if (!player)
                {
                    Player2BasePot.beanCount += Player1Pots[Math.Abs((choice - 7) - 5)].beanCount + 1;
                    Player2Pots[choice - 7].beanCount = 0;

                    Player1Pots[Math.Abs((choice - 7) - 5)].beanCount = 0;
                }
            }


            return false; // nie ma dodatkowego ruchu :(
        }

        // MIN-MAX HERE

        public int SeekAndDestroy(Board oldBoard, int depth, bool max, int move, int alpha, int beta)
        {
            Board board = new Board(oldBoard);
            bool exMove = false; // extra ruch, jak jest dodatkowy ruch, niech bedzie tego samego typu jak jeden wyzej

            if (board.PlayerMove(!max, move))
            {
                depth++;
                exMove = true; // daje true ze nastepny tez bedzie max nodem, tworzy sztuczna galaz max
            }

            if (depth == 0)
            {
                // MOGE WYBRAC TUTAJ RODZAJ EVALUATION FUNCTION
                var score = board.CalculateScore(false); // bez tego komp musial miec ujemny score zeby wygrac
                return score;
            }

            int best = 0;

            if (max)
            {
                best = int.MinValue;

                for (int i = 1; i < 7; i++)
                {
                    if (board.Player2Pots[i - 1].beanCount == 0)
                    {
                        continue;
                    }

                    var nodeScore = SeekAndDestroy(board, depth - 1, exMove, i, alpha, beta);

                    if (nodeScore > alpha)
                    {
                        alpha = nodeScore;
                    }

                    if (alpha >= beta)
                    {
                        return alpha;
                    }

                    best = Math.Max(best, nodeScore);
                }

            }

            if (!max)
            {
                best = int.MaxValue;

                for (int i = 1; i < 7; i++)
                {
                    if (board.Player1Pots[i - 1].beanCount == 0)
                    {
                        continue;
                    }

                    var nodeScore = SeekAndDestroy(board, depth - 1, true, i, alpha, beta);

                    if (nodeScore < beta)
                    {
                        beta = nodeScore;
                    }

                    if (alpha >= beta)
                    {
                        return beta;
                    }

                    best = Math.Min(best, nodeScore);
                }
            }


            return best;
        }

        public int HeadQuarter(int depth) // zwraca choice z najwyzszym scorem
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int choice = 0;
            int actualMax = int.MinValue;

            Console.Write("\n");

            for (int i = 1; i < 7; i++)
            {
                int nodeScore = SeekAndDestroy(this, depth, true, i, int.MinValue, int.MaxValue);
                
                Console.WriteLine(i + ":" + nodeScore);
                
                if (nodeScore >= actualMax)
                {
                    choice = i;
                    actualMax = nodeScore;
                }
            }
            
            Console.WriteLine("\nCPU choice:" + choice);

            stopwatch.Stop();
            Console.WriteLine("\nTime elapsed: {0}\n", stopwatch.Elapsed);

            return choice;
        }
    }
}