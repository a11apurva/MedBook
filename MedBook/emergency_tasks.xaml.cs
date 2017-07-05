using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
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
    public sealed partial class emergency_tasks : Page
    {
        public emergency_tasks()
        {
            this.InitializeComponent();
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

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;
            StorageFile ph23 = await roamingFolder.CreateFileAsync("session_set.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph23, "0");

            Frame.Navigate(typeof(MainPage));
        }

        private void blood_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BloodBank));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(call_doc));
        }

        private void message_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(message));
            Frame.Navigate(typeof(msg));
        
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(form));
        }




        private async void hospital_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Geolocator geolocator = new Geolocator();
                geolocator.DesiredAccuracyInMeters = 50;
                try
                {
                    Geoposition geoposition = await geolocator.GetGeopositionAsync(
                        maximumAge: TimeSpan.FromMinutes(5),
                        timeout: TimeSpan.FromSeconds(180));
                    string uriTolaunch = @"bingmaps:/cp=" + geoposition.Coordinate.Latitude.ToString("0.00") + "~" + geoposition.Coordinate.Longitude.ToString("0.00") + "vl=15&q=Hospital";
                    var uri = new Uri(uriTolaunch);
                    await Windows.System.Launcher.LaunchUriAsync(uri);
                }
                catch (UnauthorizedAccessException)
                { }
                string uriToLaunch = @"bingmaps:?cp=47.64~-122.13vl=20&q=Hospital";
                var uri1 = new Uri(uriToLaunch);
                await Windows.System.Launcher.LaunchUriAsync(uri1);
            }
            catch
            {
                Frame.Navigate(typeof(TaskCentre));
            }



        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(contacts1));
        }






    }
}
