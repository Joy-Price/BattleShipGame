using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
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
    /// Game logic is bound to this file until it is more clear how to access wpf elements outside of this class.
    /// ^after that - Can implement an interface for game flow.
    ///     public event EventHandler<EventArgs> StateChanged;
    /// </summary>
    public partial class MainWindow : Window
    {

        //ComboBox Options for Attack Coordinate selection
        public int[] Numbers { get; set; }
        public char[] Letters { get; set; }
        public static int TotalShipParts = 12; //INPUT TOTAL LENGTH OF ALL SHIPS
        Battleship Game = new Battleship((TotalShipParts));
        Coordinate Attack = new Coordinate(0,0);


        public MainWindow()
        {
            InitializeComponent();


            //Implement combobox selection to set Attack x and y values
            //Implement Try attack button
            Numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            DataContext = this;
            AttackPanel.Visibility = Visibility.Hidden;




            //place fleet
            //Implement PlaceFleet to take a list of Coordinates


            PlaceFleet(new Coordinate(2, 3),3,true);
            PlaceFleet(new Coordinate(0, 0), 3, true);
            PlaceFleet(new Coordinate(5, 5), 3, true);
            PlaceFleet(new Coordinate(4, 1), 3, true);

            PlaceFleet(new Coordinate(2, 3), 3, false);
            PlaceFleet(new Coordinate(0, 0), 3, false);
            PlaceFleet(new Coordinate(5, 5), 3, false);
            PlaceFleet(new Coordinate(4, 1), 3, false);

            //Add button to set this
            Game.Battling = true;
            

            //MainGame Flow
            while (Game.Battling)
            {
                AttackPanel.Visibility = Visibility.Visible;
                //PlayerOneAttack
                //Decision
                //ChangeTurn
                //PlayerTwo Attack
                //Decision
                Game.IsPlayerOne = true;
                //Listen for AttackCoords
                Game.TakeAttack(Attack,Game.IsPlayerOne);
                Game.CheckWinner(Game.IsPlayerOne);
                DisplayPlayerOneBoard(Game.PlayerOne); //if hit, change to 3 implement another color change for this method
                Game.IsPlayerOne = false;
                //Listen for AttackCoords
                Game.TakeAttack(Attack, Game.IsPlayerOne);
                Game.CheckWinner(Game.IsPlayerOne);
                DisplayPlayerTwoBoard(Game.PlayerTwo);
            }
                
 
           
            

        }



        void PlaceFleet(Coordinate ship, int length, bool IsPlayerOne)
        {
            Game.PlaceShip(ship, length, IsPlayerOne);

        }

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

        void DisplayPlayerTwoBoard(int[,] boardArray)
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
                        shape.Fill = Brushes.CornflowerBlue;
                        wrapPanel2.Children.Add(shape);


                    }
                    else if (boardArray[i, j] == 1)
                    {
                        Ellipse shape = new Ellipse();
                        shape.Width = 20;
                        shape.Height = 20;
                        shape.Fill = Brushes.CornflowerBlue; //Actual ship coordinates need to be hidden. This is still here for own reference.
                        wrapPanel2.Children.Add(shape);
                    }
                }
            }

        }

        private void CBRowSelection(object sender, EventArgs e)
        {
            Attack.Row = (int)CBrow.SelectedItem;
        }

        private void CBColumnSelection(object sender, EventArgs e)
        {
            //implement column selection with char rathre than int for full game experience.
            Attack.Col = (int)CBcolumn.SelectedItem;

        }
    }
}
