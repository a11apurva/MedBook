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

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using Windows.Storage;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UI_try_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MediaLibrary1 : Page
    {
        public MediaLibrary1()
        {
            this.InitializeComponent();
           // view_images();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private async void view_images()
        {
            
            string accountName = "medupload";
            string accountKey = "ww5bbfVxAr9Iu0SaiZ4OAa12Gv2xUL9U/OlGzMhSrNl/UZcNMCkWSIAEeOb4/RWgMuQXW2spufNnQ8FD+Dl+QQ==";

            string container = "image1";

            BitmapImage bitmapToShow = new BitmapImage();
            InMemoryRandomAccessStream memstream = new InMemoryRandomAccessStream();

            StorageCredentials creds = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount acc = new CloudStorageAccount(creds, useHttps: true);
            CloudBlobClient cli = acc.CreateCloudBlobClient();
            CloudBlobContainer sampleContainer = cli.GetContainerReference(container);
            CloudBlockBlob blob = sampleContainer.GetBlockBlobReference("xbox.jpg");

         //   await blob.DownloadToStreamAsync(memstream.CloneStream());
         //   await blob.DownloadToStreamAsync(memstream);
          //  blob.DownloadToFileAsync(bitmapToShow);
            bitmapToShow.SetSource(memstream);

            img.Source = bitmapToShow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            view_images();
        }

    }
}

