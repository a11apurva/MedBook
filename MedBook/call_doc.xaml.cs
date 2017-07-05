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
using Windows.ApplicationModel.Calls;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UI_try_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class call_doc : Page
    {
        String ph11, ph12, ph13, ph21, ph22, ph23, ph31, ph32, ph33;

        public call_doc()
        {
            this.InitializeComponent();

            ReadData();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }



        private void doc1_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallManager.ShowPhoneCallUI(ph12, ph11);

        }

        private void doc2_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallManager.ShowPhoneCallUI(ph22, ph21);
        }

        private void doc3_Click(object sender, RoutedEventArgs e)
        {
            PhoneCallManager.ShowPhoneCallUI(ph32, ph31);
        }



        async void ReadData()
        {
            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;

            try
            {

                StorageFile file11 = await roamingFolder.GetFileAsync("doc1_name.txt");
                ph11 = await FileIO.ReadTextAsync(file11);
                txt_block_1.Text = ph11;

                StorageFile file12 = await roamingFolder.GetFileAsync("doc1_phone.txt");
                ph12 = await FileIO.ReadTextAsync(file12);


                StorageFile file13 = await roamingFolder.GetFileAsync("doc1_des.txt");
                ph13 = await FileIO.ReadTextAsync(file13);
                txt_block_12.Text = ph13;

                StorageFile file21 = await roamingFolder.GetFileAsync("doc2_name.txt");
                ph21 = await FileIO.ReadTextAsync(file21);
                txt_block_2.Text = ph21;

                StorageFile file22 = await roamingFolder.GetFileAsync("doc2_phone.txt");
                ph22 = await FileIO.ReadTextAsync(file22);

                StorageFile file23 = await roamingFolder.GetFileAsync("doc2_des.txt");
                ph23 = await FileIO.ReadTextAsync(file23);
                txt_block_22.Text = ph23;

                StorageFile file31 = await roamingFolder.GetFileAsync("doc3_name.txt");
                ph31 = await FileIO.ReadTextAsync(file31);
                txt_block_3.Text = ph31;

                StorageFile file32 = await roamingFolder.GetFileAsync("doc3_phone.txt");
                ph32 = await FileIO.ReadTextAsync(file32);


                StorageFile file33 = await roamingFolder.GetFileAsync("doc3_des.txt");
                ph33 = await FileIO.ReadTextAsync(file33);
                txt_block_32.Text = ph33;


            }
            catch (Exception)
            {

            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(emergency_tasks));
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {

            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;
            StorageFile ph23 = await roamingFolder.CreateFileAsync("session_set.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph23, "0");

            Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(form));
        }




    }
}
