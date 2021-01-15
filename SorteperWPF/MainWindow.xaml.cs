using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

namespace SorteperWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameManager gameManager = new GameManager();

        public MainWindow()
        {
            gameManager.DealCards();

            InitializeComponent();

            UpdateCpuCardVisual();
            UpdatePlayerCardVisual();
        }

        /// <summary>
        /// Updates the visual of Player cards
        /// </summary>
        private void UpdatePlayerCardVisual()
        {
            PlayerPanel.Children.Clear();

            foreach (Card card in gameManager.SortedPlayerHand())
            {
                Image img = new Image();
                img.Height = 100;
                img.Margin = new Thickness(10, 0, 0, 0);
                img.Source = new BitmapImage(new Uri(@"\assets\" + card.imgName + ".png", UriKind.Relative));
                PlayerPanel.Children.Add(img);
            }
        }

        /// <summary>
        /// Updates the visual of CPU cards
        /// </summary>
        private void UpdateCpuCardVisual()
        {
            CPUPanel.Children.Clear();

            foreach (Card card in gameManager.SortedCPUHand())
            {
                Image img = new Image();
                img.Height = 100;
                img.Margin = new Thickness(10, 0, 0, 0);
                img.Source = new BitmapImage(new Uri(@"\assets\" + card.imgName + ".png", UriKind.Relative));
                img.MouseEnter += Image_MouseEnter;
                img.MouseLeave += Image_MouseLeave;
                img.MouseLeftButtonDown += Image_MouseLeftButtonDown;
                CPUPanel.Children.Add(img);

            }
        }

        /// <summary>
        /// Enlarges card on MouseEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = ((Image)sender);
            img.Height = img.ActualHeight * 1.1;

        }

        /// <summary>
        /// Resets cardsize on MouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Image img = ((Image)sender);
            img.Height /= 1.1;
        }

        /// <summary>
        /// Selects card on clicking the left mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseLeftButtonDown(Object sender, MouseEventArgs e)
        {
            Image image = (Image)sender;

            gameManager.PlayerTurn(gameManager.ImageToCard(image.Source.ToString()));

            UpdatePlayerCardVisual();

            gameManager.CpuTurn();
            UpdateCpuCardVisual();
        }

        /// <summary>
        /// Runs match methods on bother players' cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MatchButton_Click(object sender, RoutedEventArgs e)
        {
            gameManager.FindPlayerPairs();
            gameManager.FindCpuPairs();

            UpdatePlayerCardVisual();
            UpdateCpuCardVisual();
        }
    }
}
