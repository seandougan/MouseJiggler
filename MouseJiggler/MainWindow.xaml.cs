using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
        /// <summary>
        /// This is a decorator that keeps track of the initial 
        /// </summary>
        private async Task MouseJiggler()
        {
            double offsetX = 1;
            double offsetY = 1;
            Point currentPosition = NativeMethods.GetCursorPosition();

            double newX = currentPosition.X + offsetX;
            double newY = currentPosition.Y + offsetY;
            
            while (CheckBoxJiggle.IsChecked == true)
            {
               var cursorMoved = NativeMethods.SetCursorPosition((int)newX, (int)newY);
               
                await  Task.Delay(2500);
                
                offsetX = offsetX * -1;
                offsetY = offsetY * -1;
                
                 newX =currentPosition.X + offsetX;
                 newY = currentPosition.Y + offsetY;
            }
        }
    }
}