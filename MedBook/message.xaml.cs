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
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Core;
using Windows.ApplicationModel.Chat;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UI_try_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class message: Page
    {

        private Geolocator _geolocator = null;
        private CancellationTokenSource _cts = null;
        String Lat;
        String Longi;
        String ph1, ph2, ph3;
       
        public message()
        {

            this.InitializeComponent();

            text1.Visibility = Visibility.Collapsed;

        }







        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        async private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // GetGeolocationButton.IsEnabled = false;
            //    CancelGetGeolocationButton.IsEnabled = true;


            try
            {
                _geolocator = new Geolocator();
            }
            catch
            {
                text1.Text = "Please Switch On Location";
            }

#if WINDOWS_PHONE_APP
            // Desired Accuracy needs to be set
            // before polling for desired accuracy.
            _geolocator.DesiredAccuracyInMeters = 10;
#endif

            //      DesiredAccuracyInMeters.TextChanged += DesiredAccuracyInMeters_TextChanged;
            //       SetDesiredAccuracyInMeters.Click += SetDesiredAccuracyInMeters_Click;

            text1.Visibility = Visibility.Visible;
            text1.Text = "Finding Location...Please wait...";


            try
            {
                // Get cancellation token
                _cts = new CancellationTokenSource();
                CancellationToken token = _cts.Token;

                //  rootPage.NotifyUser("Waiting for update...", NotifyType.StatusMessage);

                // Carry out the operation
                Geoposition pos = await _geolocator.GetGeopositionAsync().AsTask(token);

                //  rootPage.NotifyUser("Updated", NotifyType.StatusMessage);

                //   DesiredAccuracyInMeters.IsEnabled = true;

                //   ScenarioOutput_Latitude.Text = pos.Coordinate.Point.Position.Latitude.ToString();
                Lat = pos.Coordinate.Point.Position.Latitude.ToString();
                //    ScenarioOutput_Longitude.Text = pos.Coordinate.Point.Position.Longitude.ToString();
                Longi = pos.Coordinate.Point.Position.Longitude.ToString();
                //   ScenarioOutput_Accuracy.Text = pos.Coordinate.Accuracy.ToString();
                //   ScenarioOutput_Source.Text = pos.Coordinate.PositionSource.ToString();

                if (pos.Coordinate.PositionSource == PositionSource.Satellite)
                {
                    // show labels and satellite data
                    // Label_PosPrecision.Visibility = Visibility.Visible;
                    //   ScenarioOutput_PosPrecision.Visibility = Visibility.Visible;
                    //    ScenarioOutput_PosPrecision.Text = pos.Coordinate.SatelliteData.PositionDilutionOfPrecision.ToString();
                    //    Label_HorzPrecision.Visibility = Visibility.Visible;
                    //    ScenarioOutput_HorzPrecision.Visibility = Visibility.Visible;
                    //    ScenarioOutput_HorzPrecision.Text = pos.Coordinate.SatelliteData.HorizontalDilutionOfPrecision.ToString();
                    //    Label_VertPrecision.Visibility = Visibility.Visible;
                    //    ScenarioOutput_VertPrecision.Visibility = Visibility.Visible;
                    //    ScenarioOutput_VertPrecision.Text = pos.Coordinate.SatelliteData.VerticalDilutionOfPrecision.ToString();
                }
                else
                {
                    // hide labels and satellite data
                    //  Label_PosPrecision.Visibility = Visibility.Collapsed;
                    //   ScenarioOutput_PosPrecision.Visibility = Visibility.Collapsed;
                    //    Label_HorzPrecision.Visibility = Visibility.Collapsed;
                    //    ScenarioOutput_HorzPrecision.Visibility = Visibility.Collapsed;
                    //    Label_VertPrecision.Visibility = Visibility.Collapsed;
                    //    ScenarioOutput_VertPrecision.Visibility = Visibility.Collapsed;
                }

                //  ScenarioOutput_DesiredAccuracyInMeters.Text = _geolocator.DesiredAccuracyInMeters.ToString();

            }
            catch (System.UnauthorizedAccessException)
            {
                // rootPage.NotifyUser("Disabled", NotifyType.StatusMessage);
                // text1.Text = "Please Switch On Location";
                //  ScenarioOutput_Latitude.Text = "No data";
                //  ScenarioOutput_Longitude.Text = "No data";
                //  ScenarioOutput_Accuracy.Text = "No data";
            }
            catch (TaskCanceledException)
            {
                // rootPage.NotifyUser("Canceled", NotifyType.StatusMessage);
            }
            catch 
            {   }
            finally
            {
                _cts = null;
            }

            //  GetGeolocationButton.IsEnabled = true;
            //  CancelGetGeolocationButton.IsEnabled = false;



            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;

            try
            {

                StorageFile file11 = await roamingFolder.GetFileAsync("frnd1_phone.txt");
                ph1 = await FileIO.ReadTextAsync(file11);


                StorageFile file12 = await roamingFolder.GetFileAsync("frnd2_phone.txt");
                ph2 = await FileIO.ReadTextAsync(file12);


                StorageFile file13 = await roamingFolder.GetFileAsync("frnd3_phone.txt");
                ph3 = await FileIO.ReadTextAsync(file13);

                var message = new ChatMessage();
                message.Recipients.Add(ph1);
                message.Recipients.Add(ph2);
                message.Recipients.Add(ph3);
                message.Body = "Emergency! Please help!\n" + "Latitude:" + Lat + " Longitude:" + Longi;
                await ChatMessageManager.ShowComposeSmsMessageAsync(message);
            }
            catch (Exception)
            {
                text1.Text = "NO contacts stored!";
            }


        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(emergency_tasks));
        }

        private void Button_Click_2(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(contacts1));
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
