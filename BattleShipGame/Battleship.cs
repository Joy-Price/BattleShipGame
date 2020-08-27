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
            //choose random direction
            //Random r = new Random();
            //make list of true bools to choose from
            //List<bool> Directions = new List<bool>() {};
            //int NumTrue = Directions.Count(v => v == true) ;
            //MakeTrueList(Directions);
            

            //int number = r.Next(NumTrue);

            //how to make random direction generation?

            if (Left)
                { PlaceLeft(startCoord,length); }
            if (Right)
                { PlaceRight(startCoord, length); }
            if (Up)
                { PlaceUp(startCoord, length); }
            if (Down)
                { PlaceDown(startCoord, length); }

           
            //if (number == 0)
            //{ if (Up == true) { PlaceUp(startCoord, length); } }
            //else if (number == 1)
            //{ if (Down == true) { PlaceDown(startCoord, length); } }
            //else if (number == 2)
            //{ if (Right == true) { PlaceRight(startCoord, length); } }
            //else if (number == 3)
            //{ if (Left == true) { PlaceLeft(startCoord, length); } }

        }

        public void MakeTrueList(List<bool> BoolList)
        {
            foreach (bool direction in BoolList)
                { if (direction == false)
                { BoolList.Remove(direction); }
                 }
        }

        public void WhichDirection(Coordinate startCoord, int length)
        {
            for (int i = 0; i < length + 1; i++)
            {
                if (PlayerOne[startCoord.Row, startCoord.Col + i] == 0)
                { Right = true; }
                else if (PlayerOne[startCoord.Row + i, startCoord.Col] == 0)
                { Down = true; }
                else if (PlayerOne[startCoord.Row - i, startCoord.Col] == 0)
                { Up = true; }
                else if (PlayerOne[startCoord.Row, startCoord.Col-i] == 0)
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
    

