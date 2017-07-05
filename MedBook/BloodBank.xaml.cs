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
using System.IO;
using Windows.Storage;
using Windows.Devices.Geolocation;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Windows.ApplicationModel.Calls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UI_try_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BloodBank : Page
    {
        private Geolocator _geolocator = null;
        private CancellationTokenSource _cts = null;
        String Lat;
        String Longi;


        public BloodBank()
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
        

     

        private async void go2_Click(object sender, RoutedEventArgs e)
        {
            string _city = city.Text;
            string fileContent = "";
            string l1;
            string[] lines = new string[40]; int count = 0;
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///blood.txt"));
            var readFile = await Windows.Storage.FileIO.ReadLinesAsync(file);
            string[] l3 = new string[10];

            foreach (var line in readFile)
            {
                //  ans.Text = line;
                l1 = line;
                // string[] a=l1.Split(',');

                if (l1.Contains(_city))
                {
                    //  l2 = a[2];
                    //  ans.Text= l2 ;
                    // l3 = l1.Split(',');
                    //  l3[2]=l3[2].Replace("\"",string.Empty);
                    //  ans.Text = l3[2];
                    lines[count++] = l1;
                }
            }


            if (count==0)
                fileContent = "NO RESULTS. Please modify search parameter.";
            else
            foreach (string line in lines)
            {
                fileContent = fileContent + "$" + line;
            }


            listBox1.ItemsSource = fileContent.Split('$');
            callstat.Visibility = Visibility.Visible;
            callstat.Text = "Tap To Call";

        }

        private void listBox1_ItemClick(object sender, ItemClickEventArgs e)
        {
            string l = e.ClickedItem.ToString();
            //ans.Text = l;
           string[] line= new string[10];
            line = l.Split(',');
           // ans.Text = line[0];
            //ans.Text = l;
            line[2] = line[2].Replace("\"", string.Empty);
            PhoneCallManager.ShowPhoneCallUI(line[0], line[2]);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            go2.Visibility = Visibility.Visible;
            city.Visibility = Visibility.Visible;
                        
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            go2.Visibility = Visibility.Visible;
            city.Visibility = Visibility.Visible;            
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;
            StorageFile ph23 = await roamingFolder.CreateFileAsync("session_set.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph23, "0");

            Frame.Navigate(typeof(MainPage));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaskCentre));
        }


    }
}
