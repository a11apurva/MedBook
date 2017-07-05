using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
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
    /// 


    public sealed partial class upload_pic : Page
    {
        CoreApplicationView view;
        String ImagePath;


        public upload_pic()
        {
            this.InitializeComponent();
            
            view = CoreApplication.GetCurrentView();

            select();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            select();
        }

        private void select()
        {
            ImagePath = string.Empty;
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.ViewMode = PickerViewMode.Thumbnail;

            // Filter to include a sample subset of file types
            filePicker.FileTypeFilter.Clear();
            filePicker.FileTypeFilter.Add(".bmp");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.FileTypeFilter.Add(".jpeg");
            filePicker.FileTypeFilter.Add(".jpg");

            filePicker.PickSingleFileAndContinue();
            view.Activated += viewActivated;
        }

        private async void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
        {
            FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;

            if (args != null)
            {
                if (args.Files.Count == 0) return;

                view.Activated -= viewActivated;
                StorageFile storageFile = args.Files[0];
                var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                await bitmapImage.SetSourceAsync(stream);

             //   var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
                img.Source = bitmapImage;
            }
        }



        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(store));
        }

        private async void upload_Click(object sender, RoutedEventArgs e)
        {
            status.Visibility = Visibility.Visible;
            status.Text = "Beep...";
            await System.Threading.Tasks.Task.Delay(1100);
            status.Text = "Beep...Beep...";
            await System.Threading.Tasks.Task.Delay(1100);
            status.Text = "Beep...Beep...Blop...";
            await System.Threading.Tasks.Task.Delay(13000);
            status.Text = "Error...Please try again...";
            await System.Threading.Tasks.Task.Delay(1100);
            //Frame.Navigate(typeof(store));
        }



        private void title_GotFocus(object sender, RoutedEventArgs e)
        {
            title.Text = "";
        }

        private void description_GotFocus(object sender, RoutedEventArgs e)
        {
            description.Text = "";
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
