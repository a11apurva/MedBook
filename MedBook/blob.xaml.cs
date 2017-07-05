using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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


using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Popups;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Activation;




// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UI_try_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class blob : Page
    {
        CoreApplicationView view;
      //  String ImagePath;
        public blob()
        {
            this.InitializeComponent();
            view = CoreApplication.GetCurrentView();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.ViewMode = PickerViewMode.Thumbnail;


            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            openPicker.PickSingleFileAndContinue();
            view.Activated += viewActivated;
        }

        private async void viewActivated(CoreApplicationView sender, IActivatedEventArgs args1)
        {
            FileOpenPickerContinuationEventArgs args = args1 as FileOpenPickerContinuationEventArgs;

            if (args != null)
            {
                if (args.Files.Count == 0) return;

                view.Activated -= viewActivated;
                StorageFile file = args.Files[0];


                string accountName = "medupload";
                string accountKey = "ww5bbfVxAr9Iu0SaiZ4OAa12Gv2xUL9U/OlGzMhSrNl/UZcNMCkWSIAEeOb4/RWgMuQXW2spufNnQ8FD+Dl+QQ==";
                try
                {
                    StorageCredentials creds = new StorageCredentials(accountName, accountKey);
                    CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
                    CloudBlobClient client = account.CreateCloudBlobClient();
                    CloudBlobContainer sampleContainer = client.GetContainerReference("image1");
                    await sampleContainer.CreateIfNotExistsAsync();

                    CloudBlockBlob blob = sampleContainer.GetBlockBlobReference(file.Name);
                    ProgressRing1.IsActive = true;
                    await blob.UploadFromFileAsync(file);
                    ProgressRing1.IsActive = false;
                    ImageSource imgSource = new BitmapImage(blob.Uri);
                    Image1.Source = imgSource;
                }
                catch (Exception ex)
                {
                    MessageDialog dialog = new MessageDialog(ex.ToString());
                    //dialog.ShowAsync();
                }
                
            }
        }

        private async void UploadFile(StorageFile file)
        {
            string accountName = "medupload";
            string accountKey = "ww5bbfVxAr9Iu0SaiZ4OAa12Gv2xUL9U/OlGzMhSrNl/UZcNMCkWSIAEeOb4/RWgMuQXW2spufNnQ8FD+Dl+QQ==";
            try
            {
                StorageCredentials creds = new StorageCredentials(accountName, accountKey);
                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);
                CloudBlobClient client = account.CreateCloudBlobClient();
                CloudBlobContainer sampleContainer = client.GetContainerReference("image1");
                await sampleContainer.CreateIfNotExistsAsync();

                CloudBlockBlob blob = sampleContainer.GetBlockBlobReference(file.Name);
                ProgressRing1.IsActive = true;
                await blob.UploadFromFileAsync(file);
                ProgressRing1.IsActive = false;
                ImageSource imgSource = new BitmapImage(blob.Uri);
                Image1.Source = imgSource;
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.ToString());
                //dialog.ShowAsync();
            }
        }

        private void done_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaskCentre));
        }



    }
}
