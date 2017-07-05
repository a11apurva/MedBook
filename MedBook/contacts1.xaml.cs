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
using Windows.Phone.PersonalInformation;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UI_try_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class contacts1 : Page
    {
        public contacts1()
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



        async void ReadData()
        {
            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;

            try
            {

                StorageFile file11 = await roamingFolder.GetFileAsync("frnd1_name.txt");
                String ph11 = await FileIO.ReadTextAsync(file11);
                txt11.Text = ph11;

                StorageFile file12 = await roamingFolder.GetFileAsync("frnd1_phone.txt");
                String ph12 = await FileIO.ReadTextAsync(file12);
                txt12.Text = ph12;

                StorageFile file21 = await roamingFolder.GetFileAsync("frnd2_name.txt");
                String ph21 = await FileIO.ReadTextAsync(file21);
                txt21.Text = ph21;

                StorageFile file22 = await roamingFolder.GetFileAsync("frnd2_phone.txt");
                string ph22 = await FileIO.ReadTextAsync(file22);
                txt22.Text = ph22;

                StorageFile file31 = await roamingFolder.GetFileAsync("frnd3_name.txt");
                String ph31 = await FileIO.ReadTextAsync(file31);
                txt31.Text = ph31;

                StorageFile file32 = await roamingFolder.GetFileAsync("frnd3_phone.txt");
                String ph32 = await FileIO.ReadTextAsync(file32);
                txt32.Text = ph32;
            }
            catch (Exception)
            {

            }
        }


        async private void Button_Click(object sender, RoutedEventArgs e)
        {


            /*
            var contactStore = await ContactStore.CreateOrOpenAsync(ContactStoreSystemAccessMode.ReadWrite, ContactStoreApplicationAccessMode.LimitedReadOnly);
            var createContactQuery = contactStore.CreateContactQuery();

            ContactInformation ci = new ContactInformation();
            ci.DisplayName = txt11.Text;

            StoredContact sc = new StoredContact(contactStore, ci);
            IDictionary<string, object> props = await sc.GetPropertiesAsync();
           // props.Add(KnownContactProperties.Email, "myemail@domcin.com");
            props.Add(KnownContactProperties.MobileTelephone, txt12.Text);
            // props.Add(KnownContactProperties.Notes, txt3.Text);
            
            await sc.SaveAsync();
            */




            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;

            StorageFile ph11 = await roamingFolder.CreateFileAsync("frnd1_name.txt",
                CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph11, txt11.Text);

            StorageFile ph12 = await roamingFolder.CreateFileAsync("frnd1_phone.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph12, txt12.Text);

            StorageFile ph21 = await roamingFolder.CreateFileAsync("frnd2_name.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph21, txt21.Text);

            StorageFile ph22 = await roamingFolder.CreateFileAsync("frnd2_phone.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph22, txt22.Text);

            StorageFile ph31 = await roamingFolder.CreateFileAsync("frnd3_name.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph31, txt31.Text);

            StorageFile ph32 = await roamingFolder.CreateFileAsync("frnd3_phone.txt",
            CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph32, txt32.Text);

            status.Text = "SUCCESS!";

        }



        private void txt1_GotFocus(object sender, RoutedEventArgs e)
        {
            txt11.Text = "";
        }

        private void txt2_GotFocus(object sender, RoutedEventArgs e)
        {
            txt12.Text = "";
        }

        private void txt21_GotFocus(object sender, RoutedEventArgs e)
        {
            txt21.Text = "";
        }

        private void txt22_GotFocus(object sender, RoutedEventArgs e)
        {
            txt22.Text = "";
        }

        private void txt31_GotFocus(object sender, RoutedEventArgs e)
        {
            txt31.Text = "";
        }

        private void txt32_GotFocus(object sender, RoutedEventArgs e)
        {
            txt32.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(emergency_tasks));
        }

    }
}
