using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UI_try_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class view_rec : Page
    {
        public view_rec()
        {
            this.InitializeComponent();
            dance();
           // wait();
        }


        async void dance() {
            int n = 1;
            while(true)
            {
                await System.Threading.Tasks.Task.Delay(400);
                if (n == 1)
                    status3.Text = "Retrieving File Info... |";
                else if(n==2)
                    status3.Text = "Retrieving File Info... /";
                else if (n == 3)
                    status3.Text = "Retrieving File Info...--";
                else if (n == 4)
                    status3.Text = "Retrieving File Info...\\";
                else if (n == 5)
                    status3.Text = "Retrieving File Info... |";
                else if (n == 6)
                    status3.Text = "Retrieving File Info... /";
                else if (n == 7)
                    status3.Text = "Retrieving File Info...--";
                else if (n == 8)
                {
                    status3.Text = "Retrieving File Info... \\";
                    n = 0;
                }
                n++;

            }
            

        }

        async void wait()
        {
            await System.Threading.Tasks.Task.Delay(10000);
            status3.Text="Error. Please try again.";
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaskCentre));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(view_pic));
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;
            StorageFile ph23 = await roamingFolder.CreateFileAsync("session_set.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph23, "0");

            Frame.Navigate(typeof(MainPage));
        }

    }
}
