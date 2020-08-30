using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleShipGame
{
    public enum CoordStatus
    {
        openSeas = 0,
        ship = 1,
        hit = 2

    }

    
    public class Coordinate
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Coordinate(int row, int column)
        {
            this.Row = row;
            this.Col = column;
            
        }
    }

    class Battleship
    {
        // REMEMBER INDEX IS FROM 0 -> 9   NOT 10
        public int[,] PlayerOne { get; set; }
        int[,] PlayerTwo { get; set; }


        public Battleship()
        {
            this.PlayerOne = new int[,]
                              {  { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0}   };
            this.PlayerTwo = new int[,]
                             {  { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0},
                                { 0,0,0,0,0,0,0,0,0,0}   };
            
        }


        public void PlaceShip(Coordinate start, int size)
        {
          
            Random r = new Random();
            if (r.Next() % 2 == 0)
            {
                GenerateHorizontalShip(size, start);
            }
            else
            { GenerateVerticalShip(size, start); }
        }

        public void GenerateHorizontalShip(int size, Coordinate Coord)
        {
            //check if coord is out of bounds
            int x = Coord.Col;
            int y = Coord.Row;
            if (x + size + 1 > 9) { MessageBox.Show("Please select another starting Coordinate other than:  " + y.ToString() + "," + x.ToString()); } //Edit message for game. Is also Duplicate code
           
            else if (CheckForShip(x, y, size, "vertical"))
            {
                for (int i = 0; i < size; i++)
                { PlayerOne[x, y + i] = 1; }
            }



        }

        public void GenerateVerticalShip(int size, Coordinate Coord)
        {
            //check if coord is out of bounds
            int x = Coord.Col;
            int y = Coord.Row;
            if (y + size + 1 > 9) { MessageBox.Show("Please select another starting Coordinate other than:  " + y.ToString() + "," + x.ToString()); } //Edit message for game. Is also Duplicate code

            if (CheckForShip(x, y, size, "vertical"))
            {
                for (int i = 0; i < size; i++)
                { PlayerOne[x + i, y] = 1; }
            }



        }


        public bool CheckForShip(int x, int y, int size, string direction)
        {

            if (direction == "vertical")
            {
                for (int i = 0; i < size + 1; i++)
                {
                    if (PlayerOne[x + 1, y] != 0)
                    {
                        return false;
                    }
                }
            }

            else if (direction == "horizontal")
            {
                for (int i = 0; i < size + 1; i++)
                {
                    if (PlayerOne[x, y + 1] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;

        }

    }
}
    

