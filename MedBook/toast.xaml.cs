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
using NotificationsExtensions.TileContent;
using NotificationsExtensions.ToastContent;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using Windows.Globalization.DateTimeFormatting;
using Windows.Phone.UI.Input;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace UI_try_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class toast : Page
    {

        String time;
        String date;

        int currendate;

        System.TimeSpan diff2;
        int Diff1 = 0, Diff2 = 0, Diff_total = 0;

        int Date_sec;
        public toast()
        {
            this.InitializeComponent();
            ScheduleButton.Click += ScheduleButton_Click;
            //          ScheduleButtonString.Click += ScheduleButton_Click;
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }


        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ScheduleButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {


            try
            {


                int dueTimeInSeconds = Diff_total;

                if (dueTimeInSeconds <= 0) throw new ArgumentException();

                String updateString = StringBox.Text;
                DateTime dueTime = DateTime.Now.AddSeconds(dueTimeInSeconds);

                Random rand = new Random();
                int idNumber = rand.Next(0, 10000000);

                ScheduleToast(updateString, dueTime, idNumber);

                noti.Visibility = Visibility.Visible;
                noti2.Text = "Done" ;

            }
            catch (Exception)
            {
                //         rootPage.NotifyUser("You must input a valid time in seconds.", NotifyType.ErrorMessage);
            }
        }

        void ScheduleToast(String updateString, DateTime dueTime, int idNumber)
        {

            IToastText02 toastContent = ToastContentFactory.CreateToastText02();
            toastContent.TextHeading.Text = updateString;
            toastContent.TextBodyWrap.Text = "Received: " + dueTime.ToLocalTime();

            ScheduledToastNotification toast;

            toast = new ScheduledToastNotification(toastContent.GetXml(), dueTime);
            toast.Id = "Toast" + idNumber;

            ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);

            noti.Text = "Toast ID: " + toast.Id;

        }

        void ScheduleTile(String updateString, DateTime dueTime, int idNumber)
        {
            // Set up the wide tile text
            ITileWide310x150Text09 tileContent = TileContentFactory.CreateTileWide310x150Text09();
            tileContent.TextHeading.Text = updateString;
            tileContent.TextBodyWrap.Text = "Received: " + dueTime.ToLocalTime();

            // Set up square tile text
            ITileSquare150x150Text04 squareContent = TileContentFactory.CreateTileSquare150x150Text04();
            squareContent.TextBodyWrap.Text = updateString;

            tileContent.Square150x150Content = squareContent;

            // Create the notification object
            ScheduledTileNotification futureTile = new ScheduledTileNotification(tileContent.GetXml(), dueTime);
            futureTile.Id = "Tile" + idNumber;

            TileUpdateManager.CreateTileUpdaterForApplication().AddToSchedule(futureTile);
            // rootPage.NotifyUser("Scheduled a tile with ID: " + futureTile.Id, NotifyType.StatusMessage);
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaskCentre));
        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ManageToast));
        }

        private void DatePicker_DateChanged(object sender, Windows.UI.Xaml.Controls.DatePickerValueChangedEventArgs e)
        {

            DateTimeFormatter dateFormatter = new DateTimeFormatter("shortdate");



            Date_sec = e.NewDate.Year;

            currendate = DateTime.Now.Day;
            date = currendate.ToString();

            System.TimeSpan diff1 = e.NewDate - DateTime.Now;

            Diff1 = (int)diff1.TotalSeconds;

            Diff_total = Diff1 + Diff2;

            // txt2.Text = "due sec:" + Diff_total.ToString()+"   "+ Diff_total;
            
        }

        private void TimePicker_TimeChanged(object sender, Windows.UI.Xaml.Controls.TimePickerValueChangedEventArgs e)
        {

            diff2 = e.NewTime.Subtract(DateTime.Now.TimeOfDay);

            Diff2 = (int)diff2.TotalSeconds;

            Diff_total = Diff1 + Diff2;

            time = e.NewTime.ToString().ToString();

            // txt2.Text = "due sec:" + Diff_total.ToString();
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;
            StorageFile ph23 = await roamingFolder.CreateFileAsync("session_set.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph23, "0");

            Frame.Navigate(typeof(MainPage));
        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(contacts1));
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(form));
        }
        
    }
}
