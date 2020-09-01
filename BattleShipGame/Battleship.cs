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

        public Coordinate(int column, int row)
        {
            this.Row = row;
            this.Col = column;
            
        }
    }

    class Battleship
    {
        public int[,] PlayerOne { get; set; }
        public int[,] PlayerTwo { get; set; }
        public bool IsPlayerOne { get; set; }
        public bool Battling { get; set; }
        public int ShipParts { get; set; }
        public int HitCounter;
       


        public Battleship(int NumberOfShipParts)
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

            this.ShipParts = NumberOfShipParts;
        }

        public void CheckWinner(bool IsPlayerOne)
        {
            if (IsPlayerOne)
                for (int i = 0; i < PlayerOne.Length; i++)
                {
                    for (int j = 0; j < PlayerOne.Length; j++)
                    {
                        if (PlayerOne[i, j] == 2)
                        {
                            HitCounter++;
                            if (HitCounter == ShipParts) 
                            { /*Reset Game and Declare Winner */
                                MessageBox.Show("Player One Won!");
                            }

                        }
                    }
                }
            
        }

        public void TakeAttack(Coordinate Coord, bool IsPlayerOne)
        {
            int xCoord = Coord.Col;
            int yCoord = Coord.Row;
            if (IsPlayerOne)
            {
                if (PlayerOne[xCoord, yCoord] == 1)
                { MessageBox.Show("Hit!"); PlayerOne[xCoord, yCoord] = 2; }
                else if (PlayerOne[xCoord, yCoord] == 0)
                { MessageBox.Show("Miss!"); }
            }
            else
            {
                if (PlayerTwo[xCoord, yCoord] == 1)
                { MessageBox.Show("Hit!"); PlayerOne[xCoord, yCoord] = 2; }
                else if (PlayerTwo[xCoord, yCoord] == 0)
                { MessageBox.Show("Miss!"); }
            }
            
                
           
            
        }

        public void PlaceShip(Coordinate start, int size, bool IsPlayerOne)
        {
          
            Random r = new Random();
            if (r.Next() % 2 == 0)
            {
                if (IsPlayerOne) { HorizontalShip(size, start, true); }
                else { HorizontalShip(size, start, false); }
            }
            else
            {
                if (IsPlayerOne) { VerticalShip(size, start, true); }
                else { VerticalShip(size, start, false); }
            }
        }

        public void HorizontalShip(int size, Coordinate Coord, bool IsPlayerOne)
        {
            //check if coord is out of bounds
            int x = Coord.Col;
            int y = Coord.Row;
            if (x + size + 1 > 9) { MessageBox.Show("Please select another starting Coordinate other than:  " + y.ToString() + "," + x.ToString()); } //Edit message for game. Is also Duplicate code

            if (CheckForShip(x, y, size, false, true))
            {
                for (int i = 0; i < size; i++)
                { PlayerOne[x, y + i] = 1; }
            }
            else if (CheckForShip(x, y, size, false, false))
            {
                for (int i = 0; i < size; i++)
                { PlayerTwo[x, y + i] = 1; }
            }



        }

        public void VerticalShip(int size, Coordinate Coord, bool IsPlayerOne)
        {
            //check if coord is out of bounds
            int x = Coord.Col;
            int y = Coord.Row;
            if (y + size + 1 > 9) { MessageBox.Show("Please select another starting Coordinate other than:  " + y.ToString() + "," + x.ToString()); } //Edit message for game. Is also Duplicate code

            if (CheckForShip(x, y, size, true,true))
            {
                for (int i = 0; i < size; i++)
                { PlayerOne[x + i, y] = 1; }
            }
            else if (CheckForShip(x, y, size, true, false))
            {
                for (int i = 0; i < size; i++)
                { PlayerTwo[x + i, y] = 1; }
            }



        }

        public bool CheckForShip(int x, int y, int size, bool IsVertical, bool IsPlayerOne)
        {

            if (IsVertical && IsPlayerOne)
            {
                for (int i = 0; i < size + 1; i++)
                {
                    if (PlayerOne[x + 1, y] != 0)
                    {
                        return false;
                    }
                }
            }
            else if (IsVertical && !IsPlayerOne)
            {
                for (int i = 0; i < size + 1; i++)
                {
                    if (PlayerOne[x + 1, y] != 0)
                    {
                        return false;
                    }
                }
            }
            else if (!IsVertical && IsPlayerOne)
            {
                for (int i = 0; i < size + 1; i++)
                {
                    if (PlayerOne[x, y + 1] != 0)
                    {
                        return false;
                    }
                }
            }
            else if (!IsVertical && !IsPlayerOne)
            {
                for (int i = 0; i < size + 1; i++)
                {
                    if (PlayerTwo[x, y + 1] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;

        }

    }
}
    

