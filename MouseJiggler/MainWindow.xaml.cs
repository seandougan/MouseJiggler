using System;
using System.Collections.Generic;
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
using MouseJiggler;

namespace MouseJiggler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Jiggling");
           await MouseJiggler();
        } 
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Stop Jiggling");
            return;
        }

        private async Task MouseJiggler()
        {
            int offsetX = 1;
            int offsetY = 1;
            Point currentPosition = Mouse.GetPosition(this); 
            int newX = (int)currentPosition.X + offsetX;
            int newY = (int)currentPosition.Y + offsetY;
            
            while (CheckBoxJiggle.IsChecked == true)
            {
               var cursorMoved = NativeMethods.SetCursorPosition(newX, newY);
                await  Task.Delay(2500);
                offsetX = offsetX * -1;
                offsetY = offsetY * -1;
                 newX = (int)currentPosition.X + offsetX;
                 newY = (int)currentPosition.Y + offsetY;
            }
        }
    }
}