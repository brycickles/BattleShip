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
                printBoard(theirBoard, 1);
                printBoard(myBoard, 2);
                placeShips();
                Console.WriteLine("Please enter X Coordinate (0 to 7) to attack");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter Y Coordinate (0 to 7) to attack");
                int y = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                

                if(roboHits >= 17)
                {       
                    gameWinner = "Player";
                    gameOngoing = false;
                } else if(playerHits >= 17)
                {
                    gameWinner = "Robot";
                    gameOngoing = false;

                }
                
            }

            Console.WriteLine("Congratulations, {0}, you've won the game!", gameWinner);
            

        }
        private static void attackEnemyBoard(Board myBoard, int playerHits, int x, int y)
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
        private static void attackMyBoard(Board theirBoard, int roboHits, int x, int y)
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
        private static void printBoard(Board board, int boardNumber)
        {
            Console.WriteLine("   BOARD {0}", boardNumber);
            //print the board to the console. Use X for the piece location, + for legal move, period for empty swuare
            Console.WriteLine("   0  1  2  3  4  5  6  7 ");
            for (int i = 0; i < theirBoard.size; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < theirBoard.size; j++)
                {
                    Cell c = theirBoard.theGrid[i, j];
                    {
                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine();//occurs once every 8 letters

            }
            Console.WriteLine("\n");
        }

        private static int shipCheck(string shipName)
        {
            int shipSize = 0;
            switch (shipName)
            {
                case "aircraft carrier":
                    shipSize = 5;
                    break;
                case "destroyer":
                    shipSize = 2;
                    break;
                case "submarine":
                    shipSize = 3;
                    break;
                case "battleship":
                    shipSize = 4;
                    break;
                case "cruiser":
                    shipSize = 3;
                    break;
            }

            return shipSize;
        }
        private static void placeShips()
        {
            List<string> shipList = new List<string>() { "aircraft carrier", "destroyer", "submarine", "battleship", "cruiser" };
            int shipSize = 0;
            int xcoord = 0;
            int ycoord = 0;

            foreach (string el in shipList)
            {

                for (int a = 0; a < shipSize; a++)
                {                    
                    shipSize = shipCheck(el);
                    Console.WriteLine("The {0} occupies {1} spaces.", el, shipSize);

                    Console.WriteLine("Enter x coordinate to place:");
                    xcoord = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter y coordinate to place:");
                    ycoord = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < myBoard.size; i++)
                    {
                        for (int j = 0; j < myBoard.size; j++)
                        {
                            Cell c = myBoard.theGrid[i, j];
                            Cell d = theirBoard.theGrid[i, j];
                            if (i == xcoord && j == ycoord)
                            {
                                c.CurrentlyOccupied = true;
                                Console.Write("[S]");
                            }
                            c.HasBeenHit = false;//outside the if so that every single space in the board has not been hit
                            d.HasBeenHit = false; //now every space on both boards has a hasbeenhit value of false
                        }
                    }
                    Console.Clear();

                }

            }




        }

    }
}
