
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
using System.Threading.Tasks;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UI_try_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class form : Page
    {
        public form()
        {
            this.InitializeComponent();
            ReadData();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
        //form_data lstTask;
        private void textBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            write_data();

         //   await Inserttaskitem();

            Frame.Navigate(typeof(emergency_tasks));
        }




        private async void write_data()
        {
            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;

            StorageFile ph11 = await roamingFolder.CreateFileAsync("doc1_name.txt",
                CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph11, doc1_name.Text);

            StorageFile ph12 = await roamingFolder.CreateFileAsync("doc1_phone.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph12, doc1_ph.Text);

            StorageFile ph13 = await roamingFolder.CreateFileAsync("doc1_des.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph13, doc1_des.Text);

            StorageFile ph21 = await roamingFolder.CreateFileAsync("doc2_name.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph21, doc2_name.Text);

            StorageFile ph22 = await roamingFolder.CreateFileAsync("doc2_phone.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph22, doc2_ph.Text);

            StorageFile ph23 = await roamingFolder.CreateFileAsync("doc2_des.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph23, doc2_des.Text);

            StorageFile ph31 = await roamingFolder.CreateFileAsync("doc3_name.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph31, doc3_name.Text);

            StorageFile ph32 = await roamingFolder.CreateFileAsync("doc3_phone.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph32, doc3_ph.Text);

            StorageFile ph33 = await roamingFolder.CreateFileAsync("doc3_des.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph33, doc3_des.Text);

            status.Text = "contacts stored!"; 
        }


        async void ReadData()
        {
            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;

            try
            {
                String ph11, ph12, ph13, ph21, ph22, ph23, ph31, ph32, ph33;

                StorageFile file11 = await roamingFolder.GetFileAsync("doc1_name.txt");
                ph11 = await FileIO.ReadTextAsync(file11);
                doc1_name.Text = ph11;

                StorageFile file12 = await roamingFolder.GetFileAsync("doc1_phone.txt");
                ph12 = await FileIO.ReadTextAsync(file12);
                doc1_ph.Text = ph12;

                StorageFile file13 = await roamingFolder.GetFileAsync("doc1_des.txt");
                ph13 = await FileIO.ReadTextAsync(file13);
                doc1_des.Text = ph13;


                StorageFile file21 = await roamingFolder.GetFileAsync("doc2_name.txt");
                ph21 = await FileIO.ReadTextAsync(file21);
                doc2_name.Text = ph21;

                StorageFile file22 = await roamingFolder.GetFileAsync("doc2_phone.txt");
                ph22 = await FileIO.ReadTextAsync(file22);
                doc2_ph.Text = ph22;

                StorageFile file23 = await roamingFolder.GetFileAsync("doc2_des.txt");
                ph23 = await FileIO.ReadTextAsync(file23);
                doc2_des.Text = ph23;


                StorageFile file31 = await roamingFolder.GetFileAsync("doc3_name.txt");
                ph31 = await FileIO.ReadTextAsync(file31);
                doc3_name.Text = ph31;

                StorageFile file32 = await roamingFolder.GetFileAsync("doc3_phone.txt");
                ph32 = await FileIO.ReadTextAsync(file32);
                doc3_ph.Text = ph32;

                StorageFile file33 = await roamingFolder.GetFileAsync("doc3_des.txt");
                ph33 = await FileIO.ReadTextAsync(file33);
                doc3_des.Text = ph33;


            }
            catch (Exception)
            {

            }
        }


        private void doc1_name_GotFocus(object sender, RoutedEventArgs e)
        {
            doc1_name.Text = "";
        }

        private void doc1_ph_GotFocus(object sender, RoutedEventArgs e)
        {
            doc1_ph.Text = "";
        }

        private void doc1_des_GotFocus(object sender, RoutedEventArgs e)
        {
            doc1_des.Text = "";
        }

        private void doc2_name_GotFocus(object sender, RoutedEventArgs e)
        {
            doc2_name.Text = "";
        }

        private void doc2_ph_GotFocus(object sender, RoutedEventArgs e)
        {
            doc2_ph.Text = "";
        }

        private void doc2_des_GotFocus(object sender, RoutedEventArgs e)
        {
            doc2_des.Text = "";
        }

        private void doc3_name_GotFocus(object sender, RoutedEventArgs e)
        {
            doc3_name.Text = "";
        }

        private void doc3_ph_GotFocus(object sender, RoutedEventArgs e)
        {
            doc3_ph.Text = "";
        }

        private void doc3_des_GotFocus(object sender, RoutedEventArgs e)
        {
            doc3_des.Text = "";
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





