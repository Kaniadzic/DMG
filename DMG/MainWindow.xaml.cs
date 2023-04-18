using System.Collections.Generic;
using System.Linq;
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
        private uint shootCounter = 0;

        List<Enemy> enemies = new List<Enemy>();

        private EnemiesLogic generator = new EnemiesLogic();
        private BoardLogic boardLogic = new BoardLogic();
        private DamageLogic damageLogic = new DamageLogic();

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            // generowanie przeciwników
            enemies = generator.generateBoardEnemies();
            ListView_Enemies.ItemsSource = enemies;

            // wypełnienie planszy buttonami
            boardLogic.populateBoard(Grid_GameBoard);
            boardLogic.populateBoardWithEnemies(enemies, Grid_GameBoard);

            // dodanie click eventów do buttonów planszy
            initializeBoardButtons();
        }

        /// <summary>
        /// Strzał
        /// </summary>
        /// <param name="sender"> Kliknięty button planszy </param>
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
                        dealDamageHitscan(Grid.GetColumn((UIElement)sender), Grid.GetRow((UIElement)sender), sender);
                        break;
                    case WeaponType.projectile:
                        dealDamageProjectile(Grid.GetColumn((UIElement)sender), Grid.GetRow((UIElement)sender), sender);
                        break;
                    default:
                        dealDamageArea(Grid.GetColumn((UIElement)sender), Grid.GetRow((UIElement)sender), sender);
                        break;
                }
            }

            if (enemies.Count == 0)
            {
                boardLogic.checkWinConditions(Grid_GameContainer);
            }
        }

        /// <summary>
        /// Strzał - hitscan
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="btn"> Kliknięty element planszy </param>
        private void dealDamageHitscan(int x, int y, object btn)
        {
            var target = enemies.Where(e => (e.x == x && e.y == y)).FirstOrDefault();
            short calculatedDamage = damageLogic.calculateDamage(selectedWeapon.minDamage, selectedWeapon.maxDamage);

            if (target != null)
            {
                if (target.armor > 0)
                {
                    target.armor -= (short)(calculatedDamage * damageLogic.calculatePenetration(selectedWeapon.penetration));
                }
                else
                {
                    if (target.hitpoints - calculatedDamage <= 0)
                    {
                        Grid_GameBoard.Children.Remove((UIElement)btn);

                        enemies.Remove(target);
                    }
                    else
                    {
                        target.hitpoints -= calculatedDamage;
                    }
                }


                ListView_Enemies.Items.Refresh();
            }
        }

        /// <summary>
        /// Strzał - projectile
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="btn"></param>
        private void dealDamageProjectile(int x, int y, object btn)
        {
            var target = enemies.Where(e => (e.x == x && e.y == y)).FirstOrDefault();
            short calculatedDamage = damageLogic.calculateDamage(selectedWeapon.minDamage, selectedWeapon.maxDamage);

            if (target != null && damageLogic.calculateHit(selectedWeapon.hitChance))
            {
                if (target.armor > 0)
                {
                    target.armor -= (short)(calculatedDamage * damageLogic.calculatePenetration(selectedWeapon.penetration));
                }
                else
                {
                    if (target.hitpoints - calculatedDamage <= 0)
                    {
                        Grid_GameBoard.Children.Remove((UIElement)btn);

                        enemies.Remove(target);
                    }
                    else
                    {
                        target.hitpoints -= calculatedDamage;
                    }
                }

                ListView_Enemies.Items.Refresh();
            }
        }

        /// <summary>
        /// Strzał - obszarowy
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="btn"></param>
        private void dealDamageArea(int x, int y, object btn)
        {
            IEnumerable<Enemy> targets = null;

            /// pattern wybuchu
            switch (selectedWeapon.type)
            {
                case WeaponType.area_explosive:
                    targets = enemies
                        .Where(e => (e.x >= x - 1 && e.x <= x + 1))
                        .Where(e => (e.y >= y - 1 && e.y <= y + 1));
                    break;
                case WeaponType.area_flame:
                    targets = enemies
                        .Where(e => (e.x >= x - 2 && e.x <= x + 2))
                        .Where(e => (e.y >= y - 1 && e.y <= y));
                    break;
                case WeaponType.area_rolling:
                    targets = enemies
                        .Where(e => (e.x == x))
                        .Where(e => (e.y >= y - 2 && e.y <= y + 2));
                    break;
                case WeaponType.area_shard:
                    targets = enemies
                        .Where(e => (e.x >= x - 2 && e.x <= x + 2))
                        .Where(e => (e.y >= y - 2 && e.y <= y + 2))
                        .Where((e, i) => i % 2 == 0);
                    break;
            }

            // zadanie dmg celom
            if (targets.Any())
            {
                short calculatedDamage = damageLogic.calculateDamage(selectedWeapon.minDamage, selectedWeapon.maxDamage);

                foreach (var target in targets)
                {
                    if (target.armor > 0)
                    {
                        target.armor -= (short)(calculatedDamage * damageLogic.calculatePenetration(selectedWeapon.penetration));
                    }
                    else
                    {
                        target.hitpoints -= calculatedDamage;
                    }
                }

                enemies.RemoveAll(e => e.hitpoints <= 0);
                ListView_Enemies.Items.Refresh();

                Grid_GameBoard.Children.Clear();
                boardLogic.populateBoard(Grid_GameBoard);
                boardLogic.populateBoardWithEnemies(enemies, Grid_GameBoard);
                initializeBoardButtons();
            }
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
        /// Zmiana broni
        /// </summary>
        /// <param name="weapon"> Nowa broń </param>
        private void weaponChange(Weapon weapon)
        {
            TextBlock_SelectedWeapon.Text = $"{weapon.name} DMG: {weapon.minDamage.ToString()}-{weapon.maxDamage.ToString()} Penetracja: {weapon.penetration.ToString()}";
        }

        #region on button click

        private void Button_Weapon_Gun_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Karabin", 15, 30, PenetrationValues.weak, WeaponType.hitscan, 100);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_Cannon_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Działko", 22, 45, PenetrationValues.medium, WeaponType.hitscan, 100);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_Flechettes_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Fleszetki", 10, 45, PenetrationValues.weak, WeaponType.projectile, 75);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_Rocket_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Rakieta", 30, 60, PenetrationValues.strong, WeaponType.projectile, 50);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_ExplosiveBomb_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Bomba burząca", 70, 100, PenetrationValues.strong, WeaponType.area_explosive, 75);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_ShardBomb_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Bomba odłamkowa", 25, 50, PenetrationValues.weak, WeaponType.area_shard, 90);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_FlameBomb_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Bomba zapalająca", 32, 64, PenetrationValues.weak, WeaponType.area_flame, 85);
            weaponChange(selectedWeapon);
        }

        private void Button_Weapon_RollingBomb_Click(object sender, RoutedEventArgs e)
        {
            selectedWeapon = new Weapon("Bomba tocząca", 88, 95, PenetrationValues.strong, WeaponType.area_rolling, 95);
            weaponChange(selectedWeapon);
        }

        #endregion
    }
}
