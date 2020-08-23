﻿using System;
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


        

        public void PlaceShip(int size)
        {
            Random r = new Random();
            if (r.Next() % 2 == 0)
            {
                GenerateHorizontalShip(size);
            }
            else
            { GenerateVerticalShip(size); }
        }

        public void GenerateHorizontalShip(int size)
        {

            Random random = new Random();
            int x = random.Next(9);
            int y = random.Next((9-size));
            
            //if (IsOkPlacement(size, x, y, "horizontal"))
            
                    for (int i = 0; i < size; i++)
                   { PlayerOne[x, y + i] = 1; }   
            


        }

        public void GenerateVerticalShip(int size)
        {
            Random random = new Random();
            int x = random.Next((9-size));
            int y = random.Next(9);
            
            //if (IsOkPlacement(size, x, y, "vertical"))
            
                for (int i = 0; i < size; i++)
                { PlayerOne[x + i, y] = 1; }
            
            
        }

        //bool IsOkPlacement(int size, int x, int y, string direction)
        //{

        //    if (direction == "horizontal")
        //    {

        //        for (int i = 0; i < size; i++)
        //        {
        //            if (PlayerOne[x, y + i] != 0)
        //            {
        //                return false;
        //            }
        //        }
        //    }

        //    else if (direction == "vertical")
        //    {

        //        for (int i = 0; i < size; i++)
        //        {
        //            if (PlayerOne[x + i, y] != 0)
        //            {
        //                return false;
        //            }
        //        }
        //    }

        //    return true;
        //}

    }
}
    

