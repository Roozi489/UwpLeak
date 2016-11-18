using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LeakTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Frame ContentFrame;
        public static bool StopNavigating = true;

        public MainPage()
        {
            this.InitializeComponent();

            ContentFrame = MainContentFrame;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(FirstPage));
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= Page_Loaded;
            this.Unloaded -= Page_Unloaded;
            this.StopButton.Click -= StopButton_Click;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.StopNavigating = !MainPage.StopNavigating;
            ContentFrame.Navigate(typeof(FirstPage));
        }
    }
}
