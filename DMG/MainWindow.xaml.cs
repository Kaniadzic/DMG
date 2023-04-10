﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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
        #region Pola

        private Weapon selectedWeapon = null;
        private WindDirection windDirection = WindLogic.randomizeWindDirection();
        private uint shootCounter = 0;

        List<BoardEnemy> enemies = new List<BoardEnemy>();
        //private Enemy[,] board;

        private EnemiesLogic generator = new EnemiesLogic();
        private BoardLogic boardLogic = new BoardLogic();
        //private Weapon weaponLogic = new Weapon();

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            
            TextBlock_WindDirection.Text = windDirection.ToString();

            enemies = generator.generateBoardEnemies();
            ListView_Enemies.ItemsSource = enemies;

            //board = boardLogic.generateBoard(enemies);

            boardLogic.populateBoard(Grid_GameBoard);
            boardLogic.populateBoardWithEnemies(enemies, Grid_GameBoard);

            initializeBoardButtons();
        }

        /// <summary>
        /// Strzał
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shoot(object sender, RoutedEventArgs e)
        {
            if (selectedWeapon == null) {
                MessageBox.Show("Przed oddaniem strzału wybierz broń!");
            }
            else
            {
                shootCounter += 1;
                TextBlock_ShootCounter.Text = shootCounter.ToString();

                switch (selectedWeapon.type)
                {
                    case WeaponType.hitscan:
                        dealDamageHitscan(Grid.GetColumn((UIElement)sender), Grid.GetRow((UIElement)sender));
                        break;
                    case WeaponType.projectile:

                        break;
                    case WeaponType.area:

                        break;
                }

                
            }
        }

        private void dealDamageHitscan(int x, int y)
        {
            foreach(var enemy in enemies)
            {
                enemy.enemy.hitpoints -= 5;
            }

            ListView_Enemies.Items.Refresh();
        }

        /// <summary>
        /// Dodanie eventu click do planszy
        /// </summary>
        private void initializeBoardButtons()
        {
            foreach (Button btn in Grid_GameBoard.Children)
            {
                btn.Click += new RoutedEventHandler(this.shoot);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weapon"> Nowa broń </param>
        private void weaponChange(Weapon weapon)
        {
            TextBlock_SelectedWeapon.Text = $"{weapon.name} DMG: {weapon.damage.ToString()} Penetracja: {weapon.penetration.ToString()}";
        }

        #region on button click

        private void Button_Weapon_Gun_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Karabin", DamageValues.weak, PenetrationValues.weak, WeaponType.hitscan, 100);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_Cannon_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Działko", DamageValues.medium, PenetrationValues.medium, WeaponType.hitscan, 100);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_Flechettes_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Fleszetki", DamageValues.weak, PenetrationValues.weak, WeaponType.hitscan, 75);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_Rocket_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Rakieta", DamageValues.medium, PenetrationValues.strong, WeaponType.hitscan, 50);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_ExplosiveBomb_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Bomba burząca", DamageValues.strong, PenetrationValues.strong, WeaponType.hitscan, 100);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_ShardBomb_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Bomba odłamkowa", DamageValues.weak, PenetrationValues.weak, WeaponType.hitscan, 100);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_FlameBomb_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Bomba zapalająca", DamageValues.medium, PenetrationValues.weak, WeaponType.hitscan, 100);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_RollingBomb_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Bomba tocząca", DamageValues.strong, PenetrationValues.strong, WeaponType.hitscan, 100);
            weaponChange(selectedWeapon);
        }

        #endregion
    }
}
