
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
    public sealed partial class form_info : Page
    {
        public form_info()
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
        //form_data lstTask;
        private void textBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            write_data();

         //   await Inserttaskitem();

            Frame.Navigate(typeof(MainPage));
        }




        private async void write_data()
        {
            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;

            StorageFile ph11 = await roamingFolder.CreateFileAsync("user_name.txt",
                CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph11, user_name1.Text);

            StorageFile ph12 = await roamingFolder.CreateFileAsync("user_name2.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph12, user_name2.Text);

            StorageFile ph13 = await roamingFolder.CreateFileAsync("user_age.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph13, user_age.Text);

            StorageFile ph21 = await roamingFolder.CreateFileAsync("user_sex.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph21, user_sex.Text);

            StorageFile ph22 = await roamingFolder.CreateFileAsync("user_bloodgp.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph22, user_bloodgp.Text);

            StorageFile ph23 = await roamingFolder.CreateFileAsync("user_pass.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph23, user_pass.Text);

            status.Text = "STORED"; 
            
        }


       


        private void doc1_name_GotFocus(object sender, RoutedEventArgs e)
        {
            user_name1.Text = "";
        }

        private void doc1_ph_GotFocus(object sender, RoutedEventArgs e)
        {
            user_name2.Text = "";
        }

        private void doc1_des_GotFocus(object sender, RoutedEventArgs e)
        {
            user_age.Text = "";
        }

        private void doc2_name_GotFocus(object sender, RoutedEventArgs e)
        {
            user_sex.Text = "";
        }

        private void doc2_ph_GotFocus(object sender, RoutedEventArgs e)
        {
            user_bloodgp.Text = "";
        }


        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void user_pass_GotFocus(object sender, RoutedEventArgs e)
        {
            user_pass.Text = "";
        }



    }
}





