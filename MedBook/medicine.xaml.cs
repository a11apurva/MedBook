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
using Newtonsoft.Json;
using System.Net.Http;
using Windows.Storage;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UI_try_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class medicine : Page
    {
        public medicine()
        {
            this.InitializeComponent();
        }

        async private void search_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            block1.Visibility = Visibility.Visible;
            block1.Text = "Processing...";


            try
            {
                HttpClient http = new HttpClient();

                //  string venueid = "4d6a304b9bd6a143bd1e6adf";
                // string clientID = "E4AKIOYSWX1RFAQTNGOQ3FCDLLWZCHCT1ZEFBSLDUGBP05SN";
                // string secretKey = "QB3YRIV1JXCIF0C5A1WA2YKEKYN443XY30TZR0SA4OE3YGNH";
                // string version = "20130920";

                string medicine = txt1.Text;
                string api_Key = "6df2a5e1693d8085bfeadd1fdae9fe";



                var response = await http.GetStringAsync("http://oaayush-aayush.rhcloud.com/api/medicine_suggestions/?id=" + medicine + "&key=" + api_Key + "&limit=10");

                var FSfeed = JsonConvert.DeserializeObject<Rootobject>(response);

                Reviews.Visibility = Visibility.Visible;
                Reviews.ItemsSource = FSfeed.response.suggestions;
                block1.Text = "Click To Find Alternative Medicines";
            }
            catch
            {
                block1.Text = "Network error!";
            }
        }

        async private void Reviews_ItemClick(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
        {



            try
            {
                Suggestion item = e.ClickedItem as Suggestion;
                string selected_med = item.suggestion.ToString();
                block1.Text = selected_med;
                string api_Key = "6df2a5e1693d8085bfeadd1fdae9fe";

                block1.Text = "Processing...";

                HttpClient http = new HttpClient();
                var response = await http.GetStringAsync("http://oaayush-aayush.rhcloud.com/api/medicine_alternatives/?id=" + selected_med + "&key=" + api_Key + "&limit=10");

                var FSfeed = JsonConvert.DeserializeObject<Rootobject>(response);

                Reviews.ItemsSource = FSfeed.response.medicine_alternatives;

                back.Visibility = Visibility.Visible;
                block1.Text = "Alternatives:";
                txt1.Visibility = Visibility.Collapsed;
                search.Visibility = Visibility.Collapsed;
                Reviews.IsItemClickEnabled = false;
            }
            catch
            {
                block1.Text = "Net not Connected!";
            }
        }

        private void back_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            txt1.Visibility = Visibility.Visible;
            search.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Collapsed;
            Reviews.Visibility = Visibility.Collapsed;
            Reviews.IsItemClickEnabled = true;
            block1.Visibility = Visibility.Collapsed;

        }

        private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Health));
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;
            StorageFile ph23 = await roamingFolder.CreateFileAsync("session_set.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph23, "0");

            Frame.Navigate(typeof(MainPage));
        }

        private void txt1_GotFocus(object sender, RoutedEventArgs e)
        {
            txt1.Text = "";
        }
    }
}
