using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Capture;
using Windows.Devices.Sensors;
using Windows.Devices.Enumeration;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UI_try_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 


    public sealed partial class camera : Page
    {


        private MediaCapture _captureManager;
        private SimpleOrientationSensor _sensor;
        public camera()
        {
            this.InitializeComponent();
            //    this.NavigationCacheMode = NavigationCacheMode.Required;

            InitializeCamera();
            InitializeSensor();
        }

        private void InitializeSensor()
        {



            _sensor = SimpleOrientationSensor.GetDefault();
            if (_sensor != null)
            {
                _sensor.OrientationChanged += OrientationChanged;
            }
        }

        private async void InitializeCamera()
        {
            var videoDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            var rearCamera = videoDevices.First(item => item.EnclosureLocation != null &&
                                                        item.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Back);
            _captureManager = new MediaCapture();

            await _captureManager.InitializeAsync(new MediaCaptureInitializationSettings
            {
                VideoDeviceId = rearCamera.Id
            });

            _captureManager.SetPreviewRotation(VideoRotation.Clockwise90Degrees);
            capturePreview.Source = _captureManager;
            await _captureManager.StartPreviewAsync();
        }



        private async void TakePhotoClick(object sender, RoutedEventArgs e)
        {

            var imgFormat = ImageEncodingProperties.CreateJpeg();


            IReadOnlyList<StorageFolder> storageFolderList = await KnownFolders.PicturesLibrary.GetFoldersAsync();
            if (storageFolderList.Where(x => x.Name == "MedBook").Count() == 0)
            {
                StorageFolder folderCreationResult = await KnownFolders.PicturesLibrary.CreateFolderAsync("MedBook", CreationCollisionOption.ReplaceExisting);
                //     StorageFolder myfolder = KnownFolders.folderCreationResult;
                IStorageFile file = await folderCreationResult.CreateFileAsync(
                                "Photo.jpg", CreationCollisionOption.GenerateUniqueName);
                await _captureManager.CapturePhotoToStorageFileAsync(imgFormat, file);
                var photo = new BitmapImage(new Uri(file.Path));
            }
            else
            {

                StorageFolder folderCreationResult = await KnownFolders.PicturesLibrary.CreateFolderAsync("MedBook", CreationCollisionOption.OpenIfExists);
                StorageFolder myfolder = folderCreationResult;
                //   StorageFolder myfolder = storageFolderList.Where(x => x.Name == "MedBook");
                IStorageFile file = await myfolder.CreateFileAsync(
                                "Photo.jpg", CreationCollisionOption.GenerateUniqueName);
                await _captureManager.CapturePhotoToStorageFileAsync(imgFormat, file);
                var photo = new BitmapImage(new Uri(file.Path));
            }

            border1.Visibility = Visibility.Visible;
            status2.Visibility = Visibility.Visible;
            await System.Threading.Tasks.Task.Delay(1000);
            status2.Visibility = Visibility.Collapsed;
            border1.Visibility = Visibility.Collapsed;
         //   Frame.Navigate(typeof(save_pic));

        }


        void OrientationChanged(SimpleOrientationSensor sender, SimpleOrientationSensorOrientationChangedEventArgs args)
        {
            if (_captureManager == null)
                return;

            var orientation = args.Orientation;

            if (orientation == SimpleOrientation.Rotated90DegreesCounterclockwise ||
                orientation == SimpleOrientation.Rotated270DegreesCounterclockwise)
            {
                _captureManager.SetPreviewRotation(VideoRotation.None);
            }
            else
            {
                _captureManager.SetPreviewRotation(VideoRotation.Clockwise90Degrees);
            }
        }


        private void Home(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(store));
        }

    }
}