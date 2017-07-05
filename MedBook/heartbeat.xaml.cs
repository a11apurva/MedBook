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
using Microsoft.Band;
using Microsoft.Band.Sensors;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UI_try_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class heartbeat : Page
    {
        public heartbeat()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private bool IsRunning = false;

        private async void ButtonRun_Click(object sender, RoutedEventArgs e)
        {
            if (IsRunning)
                return;
            else
                IsRunning = true;

            try
            {
                this.ButtonRun.IsEnabled = false;
                this.StatusMessage.Text = "";

                // Get the list of Microsoft Bands paired to the phone.
                IBandInfo[] pairedBands = await BandClientManager.Instance.GetBandsAsync();
                if (pairedBands.Length < 1)
                {
                    this.StatusMessage.Text = "Connect To Microsoft Band Please";
                    return;
                }

                // Connect to Microsoft Band.
                using (IBandClient bandClient = await BandClientManager.Instance.ConnectAsync(pairedBands[0]))
                {
                    if (bandClient.SensorManager.HeartRate.GetCurrentUserConsent() != UserConsent.Granted)
                    {
                        await bandClient.SensorManager.HeartRate.RequestUserConsentAsync();
                    }

                    int samplesReceivedHR = 0; // the number of HeartRate samples received
                    int samplesReceivedST = 0; // the number of SkinTemperature samples received
                    int samplesReceivedUV = 0; // the number of UV samples received


                    // Subscribe to HeartRate data.
                    bandClient.SensorManager.HeartRate.ReadingChanged += (s, args) =>
                    {
                        samplesReceivedHR++;
                        IBandHeartRateReading readings = args.SensorReading;
                        CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            this.txtHR.Text = readings.HeartRate.ToString() + " [" + readings.Quality.ToString() + "]";
                        });
                    };
                    await bandClient.SensorManager.HeartRate.StartReadingsAsync();




                    // Subscribe to SkinTemperature data.
                    bandClient.SensorManager.SkinTemperature.ReadingChanged += (s, args) =>
                    {
                        samplesReceivedST++;
                        IBandSkinTemperatureReading readings = args.SensorReading;
                        CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            this.txtSkinTemp.Text = readings.Temperature.ToString();
                        });
                    };
                    await bandClient.SensorManager.SkinTemperature.StartReadingsAsync();

                    // Subscribe to UV data.
                    bandClient.SensorManager.UV.ReadingChanged += (s, args) =>
                    {
                        samplesReceivedUV++;
                        IBandUVReading readings = args.SensorReading;
                        CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            this.txtUV.Text = readings.IndexLevel.ToString();
                        });
                    };
                    await bandClient.SensorManager.UV.StartReadingsAsync();

                    // Receive sensor data for a while
                    await Task.Delay(TimeSpan.FromSeconds(10));

                    // Stop the sensor subscriptions
                    await bandClient.SensorManager.Accelerometer.StopReadingsAsync();
                    await bandClient.SensorManager.Calories.StopReadingsAsync();
                    await bandClient.SensorManager.Contact.StopReadingsAsync();
                    await bandClient.SensorManager.Distance.StopReadingsAsync();
                    await bandClient.SensorManager.Gyroscope.StopReadingsAsync();
                    await bandClient.SensorManager.HeartRate.StopReadingsAsync();
                    await bandClient.SensorManager.Pedometer.StopReadingsAsync();
                    await bandClient.SensorManager.SkinTemperature.StopReadingsAsync();
                    await bandClient.SensorManager.UV.StopReadingsAsync();

                    this.StatusMessage.Text = string.Format("Done.\n {0} HeartRate samples received.\n {1} SkinTemperature samples received.\n {2} UV samples received.", samplesReceivedHR, samplesReceivedST, samplesReceivedUV);
                }
            }
            catch (Exception ex)
            {
                this.StatusMessage.Text = ex.ToString();
            }
            IsRunning = false;
            this.ButtonRun.IsEnabled = true;
        }

        private void Background_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            back_status.Text = "Feature To Be Added Soon!";
        }

        private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Health));
        }




    }
}
