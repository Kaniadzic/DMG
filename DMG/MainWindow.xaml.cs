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
            GenerateEnemies generator = new GenerateEnemies();
            List<BoardEnemy> enemies = generator.generateBoardEnemies();
        }
    }
}
