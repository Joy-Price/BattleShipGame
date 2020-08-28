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
        bool Up;
        bool Down;
        bool Right;
        bool Left;


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

        



        public void PlaceShip(Coordinate startCoord, int length)
        {



            //which direction is possible
            WhichDirection(startCoord, length);

            //how to make random direction generation?

            if (Down)
            { PlaceDown(startCoord, length); }
            else if (Left)
                { PlaceLeft(startCoord,length); }
            else if (Right)
                { PlaceRight(startCoord, length); }
            else if (Up)
                { PlaceUp(startCoord, length); }
            
            else { Console.WriteLine("Placement not possible with coordinates. Try again"); }

           
        }

        public void WhichDirection(Coordinate startCoord, int length)
        {
            int ship = length + 1;
            if (startCoord.Row + ship > 9 || startCoord.Row - ship < 0 || startCoord.Col + ship > 9 || startCoord.Col - ship < 0)
            { Console.WriteLine(startCoord + "is not a valid Coordinate to place. Choose another Coordinate"); }
            for (int i = 0; i < length + 1; i++)

            {
                //BUG: while iterating, this will skip over a direction that is already true when it needs to be set to false 
                if ( ((startCoord.Col + i) < 10) && PlayerOne[startCoord.Row, startCoord.Col + i] == 0)
                { Right = true; }
                if (((startCoord.Row + i) < 10) && PlayerOne[startCoord.Row + i, startCoord.Col] == 0)
                { Down = true; }
                if (((startCoord.Row - i) >= 0) && PlayerOne[startCoord.Row - i, startCoord.Col] == 0)
                { Up = true; }
                if (((startCoord.Col - i) >= 0) && PlayerOne[startCoord.Row, startCoord.Col-i] == 0)
                { Left = true; }
            }
        }

        

        public void PlaceUp(Coordinate start, int length)
        {
            int x = start.Col;
            int y = start.Row;
            for (int i = 0; i < length; i++)
            { PlayerOne[x - i, y] = 1; }
        }
        public void PlaceDown(Coordinate start, int length)
        {
            int x = start.Col;
            int y = start.Row;
            
            for (int i = 0; i < length; i++)
            { PlayerOne[x + i, y] = 1; }
        }
        public void PlaceRight(Coordinate start, int length)
        {
            int x = start.Col;
            int y = start.Row;
            for (int i = 0; i < length; i++)
            { PlayerOne[x, y + i] = 1; }
        }
        public void PlaceLeft(Coordinate start, int length)
        {
            int x = start.Col;
            int y = start.Row;
            for (int i = 0; i < length; i++)
            { PlayerOne[x, y-i] = 1; }
        }


    }
}
    

