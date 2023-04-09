using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DMG.Entities;
using DMG.Enums;
using DMG.Logic;

namespace DMG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Weapon selectedWeapon = null;

        public MainWindow()
        {
            InitializeComponent();
            EnemiesLogic generator = new EnemiesLogic();
            BoardLogic boardLogic = new BoardLogic();
            Weapon weaponLogic = new Weapon();

            List<BoardEnemy> enemies = generator.generateBoardEnemies();
            ListView_Enemies.ItemsSource = enemies;

            Enemy[,] board = boardLogic.generateBoard(enemies);

            populateBoard();
            populateBoardWithEnemies(enemies);
        }

        private void populateBoardWithEnemies(List<BoardEnemy> enemies)
        {
            foreach(var enemy in enemies)
            {
                Button btn = new Button();
                btn.Content = enemy.enemy.symbol;
                btn.Height = 32;
                btn.Width = 32;
                btn.FontWeight = FontWeights.Bold;
                btn.Background = Brushes.Red;
                btn.BorderBrush = null;

                Grid_GameBoard.Children.Add(btn);

                Grid.SetRow(btn, enemy.coordinates.y);
                Grid.SetColumn(btn, enemy.coordinates.x);
            }
        }

        private void populateBoard(byte x = 9, byte y = 9)
        {
            for(int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Button btn = new Button();
                    btn.Content = "";
                    btn.Height = 32;
                    btn.Width = 32;
                    btn.BorderBrush = null;

                    Grid_GameBoard.Children.Add(btn);

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                }
            }
        }

        #region on button click

        private void Button_Weapon_Gun_Click(object sender, RoutedEventArgs e)
        {
            this.selectedWeapon = new Weapon("Karabin", DamageValues.weak, PenetrationValues.weak, WeaponType.hitscan, 100);
        }

        private void Button_Weapon_Cannon_Click(object sender, RoutedEventArgs e)
        {
            this.selectedWeapon = new Weapon("Działko", DamageValues.medium, PenetrationValues.medium, WeaponType.hitscan, 100);
        }

        private void Button_Weapon_Flechettes_Click(object sender, RoutedEventArgs e)
        {
            this.selectedWeapon = new Weapon("Fleszetki", DamageValues.weak, PenetrationValues.weak, WeaponType.hitscan, 75);
        }

        private void Button_Weapon_Rocket_Click(object sender, RoutedEventArgs e)
        {
            this.selectedWeapon = new Weapon("Rakieta", DamageValues.medium, PenetrationValues.strong, WeaponType.hitscan, 50);
        }

        private void Button_Weapon_ExplosiveBomb_Click(object sender, RoutedEventArgs e)
        {
            this.selectedWeapon = new Weapon("Bomba burząca", DamageValues.strong, PenetrationValues.strong, WeaponType.hitscan, 100);
        }

        private void Button_Weapon_ShardBomb_Click(object sender, RoutedEventArgs e)
        {
            this.selectedWeapon = new Weapon("Bomba tocząca", DamageValues.strong, PenetrationValues.strong, WeaponType.hitscan, 100);
        }

        private void Button_Weapon_FlameBomb_Click(object sender, RoutedEventArgs e)
        {
            this.selectedWeapon = new Weapon("Bomba odłamkowa", DamageValues.weak, PenetrationValues.weak, WeaponType.hitscan, 100);
        }

        private void Button_Weapon_RollingBomb_Click(object sender, RoutedEventArgs e)
        {
            this.selectedWeapon = new Weapon("Bomba zapalająca", DamageValues.medium, PenetrationValues.weak, WeaponType.hitscan, 100);
        }

        #endregion
    }
}
