using System.Collections.Generic;
using System.Windows;
using DMG.Entities;
using DMG.Logic;

namespace DMG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EnemiesLogic generator = new EnemiesLogic();
            BoardLogic boardLogic = new BoardLogic();
            Weapon weaponLogic = new Weapon();

            List<Weapon> weapons = weaponLogic.initializeWeapons();
            Enemy[,] board = boardLogic.generateBoard(generator.generateBoardEnemies());
        }
    }
}
