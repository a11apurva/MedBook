using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class BMI : Page
    {
        public BMI()
        {
            this.InitializeComponent();

            feet.Visibility = Visibility.Collapsed;
            inches.Visibility = Visibility.Collapsed;
            centi.Visibility = Visibility.Collapsed;

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private void cent_Checked(object sender, RoutedEventArgs e)
        {
            feet.Visibility = Visibility.Collapsed;
            inches.Visibility = Visibility.Collapsed;
            centi.Visibility = Visibility.Visible;
            feetinch.IsChecked = false;
        }

        private void feetinch_Checked(object sender, RoutedEventArgs e)
        {
            feet.Visibility = Visibility.Visible;
            inches.Visibility = Visibility.Visible;
            centi.Visibility = Visibility.Collapsed;
            cent.IsChecked = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            double bmi;

            double weight = Convert.ToDouble(wght.Text);
            double height;


            if (cent.IsChecked == true)
                height = Convert.ToDouble(centi.Text) / 100.0;
            else
                height = (Convert.ToDouble(feet.Text) * 12 + Convert.ToDouble(inches.Text)) * 0.0254;


            bmi = weight / (height * height);
            result.Text = "Result : Your BMI is: " + bmi.ToString();
            if ((bmi > 30) && (bmi <= 40))
                label4.Text = "Inference :You are obese";
            else if ((bmi > 25) && (bmi < 30))
                label4.Text = "Inference :You are overweight";
            else if ((bmi > 18.5) && (bmi <= 25))
                label4.Text = "Inference :You weight is normal";
            else if (bmi < 18.5)
                label4.Text = "Inference :You are underweight";
            else if (bmi > 40)
                label4.Text = "Inference :You are extremly obese";



        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(form));
        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(contacts1));
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder roamingFolder = Windows.Storage.ApplicationData.Current.RoamingFolder;
            StorageFile ph23 = await roamingFolder.CreateFileAsync("session_set.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(ph23, "0");

            Frame.Navigate(typeof(MainPage));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Health));
        }


    }
}
