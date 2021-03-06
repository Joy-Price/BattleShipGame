﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShipGame
{
    /// <summary>
    /// Questions:
    ///     []
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
          
          
            DisplayPlayerTwoBoard();

            
            int CarrierLength = 5;
            int BattleshipLength = 4;
            int DestroyerLength = 3;
            int SubmarineLength = 2; //3
            //int PatrolLength = ; //2



            
            Battleship test = new Battleship();
            test.PlaceShip(BattleshipLength);
            test.PlaceShip(CarrierLength);
            test.PlaceShip(DestroyerLength);
            test.PlaceShip(SubmarineLength);
            //test.PlaceShip(PatrolLength);
            DisplayPlayerOneBoard(test.PlayerOne);
        }

        //Create dynamic start game btn. Will disappear after game has started

        //public event EventHandler<EventArgs> StateChanged;

        void DisplayPlayerOneBoard(int[,] boardArray)
        {
            
                                        
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (boardArray[i, j] == 0)
                    {
                        Ellipse shape = new Ellipse();
                        shape.Width = 20;
                        shape.Height = 20;
                        shape.Fill = Brushes.Blue;
                        wrapPanel1.Children.Add(shape);


                    }
                    else if (boardArray[i, j] == 1)
                    {
                        Ellipse shape = new Ellipse();
                        shape.Width = 20;
                        shape.Height = 20;
                        shape.Fill = Brushes.Red;
                        wrapPanel1.Children.Add(shape);
                    }
                }
            }

        }
        void DisplayPlayerTwoBoard()
        {
            int[,] boardArray = new int[,] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                                        };
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (boardArray[i, j] == 0)
                    {
                        Ellipse shape = new Ellipse();
                        shape.Width = 20;
                        shape.Height = 20;
                        shape.Fill = Brushes.CornflowerBlue;
                        wrapPanel2.Children.Add(shape);


                    }
                    else if (boardArray[i, j] == 1)
                    {
                        Ellipse shape = new Ellipse();
                        shape.Width = 20;
                        shape.Height = 20;
                        shape.Fill = Brushes.Red;
                        wrapPanel2.Children.Add(shape);
                    }
                }
            }

        }

        
    }
}
