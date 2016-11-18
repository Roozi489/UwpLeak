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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LeakTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            this.InitializeComponent();
        }

        private void NavigateToFirstPage()
        {
            MainPage.ContentFrame.BackStack.Clear();
            MainPage.ContentFrame.Navigate(typeof(FirstPage));
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToFirstPage();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!MainPage.StopNavigating)
            {
                NavigateToFirstPage();
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            this.NavigateButton.Click -= NavigateButton_Click;
            this.Loaded -= Page_Loaded;
            this.Unloaded -= Page_Unloaded;
        }
    }
}
