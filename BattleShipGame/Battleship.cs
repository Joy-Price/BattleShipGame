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

    public enum Direction
    {
        PosX = 0,  //Col
        PosY = 1,  //Row
        NegX = 2,
        NegY = 3
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
        public Direction Direction { get; set; }


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
            Direction Direction = this.Direction;
        }

        



        public void PlaceShip(Coordinate startCoord, int length)
        {
            
            Coordinate start = startCoord;
            int x = start.Col;
            int y = start.Row;

            //which direction is possible
            WhichDirection(start, length);
            //choose random direction

        }

        public void WhichDirection(Coordinate startCoord, int length)
        {
            for (int i = 0; i < length + 1; i++)
            {
                if (PlayerOne[startCoord.Row, startCoord.Col + i] == 0)
                { Direction = Direction.PosX; }
                else if (PlayerOne[startCoord.Row + i, startCoord.Col] == 0)
                { Direction = Direction.NegY; }
                else if (PlayerOne[startCoord.Row - i, startCoord.Col] == 0)
                { Direction = Direction.PosY; }
                else if (PlayerOne[startCoord.Row, startCoord.Col-i] == 0)
                { Direction = Direction.NegX; }
            }
        }
        

       
    }
}
    

