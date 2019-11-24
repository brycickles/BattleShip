using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {
        static Board myBoard = new Board(8); //static - only one board allowed
        static Board theirBoard = new Board(8); //static - only one board allowed
        static void Main(string[] args)
        {
            int roboHits = 0;
            int playerHits = 0;
            string gameWinner = "";
            bool gameOngoing = true; ;

            while(gameOngoing == true){

                Console.WriteLine("Please enter X Coordinate (0 to 7) to attack");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter Y Coordinate (0 to 7) to attack");
                int y = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                printEnemyBoard(theirBoard, roboHits, x, y);
                printMyBoard(myBoard, playerHits, x, y);

                if(roboHits >= 17)
                {       
                    gameWinner = "Player Wins!";
                    gameOngoing = false;
                } else if(playerHits >= 17)
                {
                    gameWinner = "Robot Wins!";
                    gameOngoing = false;

                }
                
            }

            Console.WriteLine("Congratulations, {0}, you've won the game!");
            

        }
        private static void printMyBoard(Board myBoard, int playerHits, int x, int y)
        {
            Console.WriteLine("\n\n          MY BOARD");
            //print the board to the console. Use X for the piece location, + for legal move, period for empty swuare
            Console.WriteLine("   0  1  2  3  4  5  6  7 ");
            for (int i = 0; i < myBoard.size; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < myBoard.size; j++)
                {
                    Cell c = myBoard.theGrid[i, j];
                    if (c.CurrentlyOccupied == true && x == i && y == j)
                    {
                        Console.Write("[H]");
                        playerHits = playerHits + 1;
                        c.HasBeenHit = true;
                    }
                    else if (x == i && y == j)
                    {
                        Console.Write("[M]");
                        c.HasBeenHit = true;
                    }
                    else if (c.HasBeenHit == true && c.CurrentlyOccupied == true)
                    {
                        Console.Write("[H]");
                    }
                    else if (c.HasBeenHit == true && c.CurrentlyOccupied == false)
                    {
                        Console.Write("[M]");
                    }
                    else
                    {

                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine();//occurs once every 8 letters

            }

        }
        private static void printEnemyBoard(Board theirBoard, int roboHits, int x, int y)
        {
            Console.WriteLine("    KNOWN OPPONENTS BOARD");
            //print the board to the console. Use X for the piece location, + for legal move, period for empty swuare
            Console.WriteLine("   0  1  2  3  4  5  6  7 ");
            for (int i = 0; i < theirBoard.size; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < theirBoard.size; j++)
                {
                    Cell c = theirBoard.theGrid[i, j];
                    if (c.CurrentlyOccupied == true && x == i && y == j)
                    {
                        Console.Write("[H]");
                        roboHits = roboHits + 1;
                        c.HasBeenHit = true;
                    }
                    else if (x == i && y == j)
                    {
                        Console.Write("[M]");
                        c.HasBeenHit = true;
                    }
                    else if (c.HasBeenHit == true && c.CurrentlyOccupied == true)
                    {
                        Console.Write("[H]");
                    }
                    else if (c.HasBeenHit == true && c.CurrentlyOccupied == false)
                    {
                        Console.Write("[M]");
                    }
                    else
                    {

                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine();//occurs once every 8 letters

            }
        }


    }
}
