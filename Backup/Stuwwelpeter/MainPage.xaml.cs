using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Advertising.Mobile.Resources;

using Microsoft.Advertising.Mobile.UI;
using Microsoft.Phone.Tasks;


namespace Struwwelpeter
{

    public partial class MainPage : PhoneApplicationPage
    {

        


        // Konstruktor
        //---------------------------------------------------------------------------------------------------------
        public MainPage()
        {
            //Komponenten laden
            InitializeComponent();
        }
        //---------------------------------------------------------------------------------------------------------





        //Wir am Anfang der Seite ausgeführt
        //---------------------------------------------------------------------------------------------------------
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {            
            //xAdImage verstecken
            xAdImage.Visibility = System.Windows.Visibility.Collapsed;

            //Prüfen ob Free Version
            if ((Application.Current as App).IsTrial)
            {
                //Werbung hinzufügen
                if (!string.IsNullOrEmpty(APPLICATION_ID) && !string.IsNullOrEmpty(AD_UNIT_ID))
                {
                    //AdControl
                    AdControl adControl = new AdControl(APPLICATION_ID, AD_UNIT_ID, true);
                    //Bei Fehlern
                    adControl.ErrorOccurred += (o,d) =>
                        {
                            adControl.Visibility = System.Windows.Visibility.Collapsed;
                            adControl_ErrorOccurred();
                        };


                    // Make the AdControl size large enough that it can contain the image
                    adControl.Width = 480;
                    adControl.Height = 80;
                    adControl.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                    LayoutRoot.Children.Add(adControl);                 
                }
            }
            //Bei Kaufversion
            else
            {
                //Content Panel vergrößern
                ContentPanel.Height = 800;
            }
        }
        //---------------------------------------------------------------------------------------------------------





        //Bei Fehlern in der Werbung
        //---------------------------------------------------------------------------------------------------------
        //Variabeln
        private AdControl adControl;
        private const string APPLICATION_ID = "7da3f9ae-9b8e-4083-911f-0321a4dd8104";
        private const string AD_UNIT_ID = "110773";
        string xAdLink;

        //Bei Fehlern
        private void adControl_ErrorOccurred()
        {
            //Eigene Werbung laden
            Random rand = new Random();
            int xAdID = rand.Next(1, 3);
            if (xAdID == 3)
            {
                xAdID = 2;
            }
            if (xAdID == 1)
            {
                xAdLink = "http://www.windowsphone.com/de-de/store/app/8-1-sperrbildschirm/baf10362-4166-4d1d-bf16-39a57e54dbac";
            }
            else if (xAdID == 2)
            {
                xAdLink = "http://www.windowsphone.com/de-de/store/app/battery-live-tile-editor/83ba3afc-06d9-4296-a3b1-7abd46090e79";
            }

            //Eigene Werbung anzeigen
            Uri uri = new Uri("Images/xAd/" + xAdID + ".png", UriKind.Relative);
            ImageSource img = new System.Windows.Media.Imaging.BitmapImage(uri);
            xAdImage.SetValue(Image.SourceProperty, img);
            xAdImage.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            xAdImage.Visibility = System.Windows.Visibility.Visible;
        }

        //Wenn eigene Werbung geklickt wird
        private void xAdImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var wb = new WebBrowserTask();
            wb.URL = xAdLink;
            wb.Show();
        }
        //---------------------------------------------------------------------------------------------------------





        //Button Struwwelpeter
        //---------------------------------------------------------------------------------------------------------
        private void btn_struwwelpeter(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Struwwelpeter/struwwelpeter.xaml", UriKind.Relative));
        }
        //---------------------------------------------------------------------------------------------------------


        //Button Friderich
        //---------------------------------------------------------------------------------------------------------
        private void btn_friderich(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Friederich/friederich.xaml", UriKind.Relative));
        }
        //---------------------------------------------------------------------------------------------------------


        //Button Feuerzeug
        //---------------------------------------------------------------------------------------------------------
        private void btn_feuerzeug(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Feuerzeug/Feuerzeug.xaml", UriKind.Relative));
        }
        //---------------------------------------------------------------------------------------------------------


        //Button Neger
        //---------------------------------------------------------------------------------------------------------
        private void btn_neger(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Neger/neger.xaml", UriKind.Relative));
        }
        //---------------------------------------------------------------------------------------------------------


        //Button Jäger
        //---------------------------------------------------------------------------------------------------------
        private void btn_jaeger(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Jaeger/jaeger.xaml", UriKind.Relative));
        }
        //---------------------------------------------------------------------------------------------------------


        //Button Konrad
        //---------------------------------------------------------------------------------------------------------
        private void btn_konrad(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Konrad/konrad.xaml", UriKind.Relative));
        }
        //---------------------------------------------------------------------------------------------------------



        //Button Kaspar
        //---------------------------------------------------------------------------------------------------------
        private void btn_kaspar(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Kaspar/kaspar.xaml", UriKind.Relative));
        }
        //---------------------------------------------------------------------------------------------------------


        //Button Phillip
        //---------------------------------------------------------------------------------------------------------
        private void btn_phillip(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Philipp/philipp.xaml", UriKind.Relative));
        }
        //---------------------------------------------------------------------------------------------------------


        //Button Hans
        //---------------------------------------------------------------------------------------------------------
        private void btn_hans(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Hans/hans.xaml", UriKind.Relative));
        }
        //---------------------------------------------------------------------------------------------------------


        //Button Robert
        //---------------------------------------------------------------------------------------------------------
        private void btn_robert(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Robert/robert.xaml", UriKind.Relative));
        }
        //---------------------------------------------------------------------------------------------------------



        //Button Vorwort
        //---------------------------------------------------------------------------------------------------------
        private void btn_vorwort(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Vorwort/vorwort.xaml", UriKind.Relative));
        }
        //---------------------------------------------------------------------------------------------------------





        //Button Zum Kaufen
        //---------------------------------------------------------------------------------------------------------
        MarketplaceDetailTask _marketPlaceDetailTask = new MarketplaceDetailTask();
        private void BtnBuy(object sender, RoutedEventArgs e)
        {
            _marketPlaceDetailTask.Show();
        }
        //---------------------------------------------------------------------------------------------------------


        //Button für andere Apps
        //---------------------------------------------------------------------------------------------------------
        private void BtnOther(object sender, RoutedEventArgs e)
        {
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();
            marketplaceSearchTask.SearchTerms = "xtrose";
            marketplaceSearchTask.Show();
        }
        //---------------------------------------------------------------------------------------------------------


        //Button Like
        //---------------------------------------------------------------------------------------------------------
        private void BtnFacebook(object sender, RoutedEventArgs e)
        {
            var wb = new WebBrowserTask();
            wb.URL = "https://www.facebook.com/xtrose.xtrose";
            wb.Show();
        }
        //---------------------------------------------------------------------------------------------------------


        //Button Rate
        //---------------------------------------------------------------------------------------------------------
        private void BtnRate(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask review = new MarketplaceReviewTask();
            review.Show();
        }
        //---------------------------------------------------------------------------------------------------------


        //Button Support
        //---------------------------------------------------------------------------------------------------------
        private void BtnSupport(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Support.xaml", UriKind.Relative));
            /*
            EmailComposeTask emailcomposer = new EmailComposeTask();
            emailcomposer.To = "xtrose@hotmail.com";
            emailcomposer.Subject = "Struwwelpeter Windows Phone";
            emailcomposer.Body = "";
            emailcomposer.Show();
             */
        }
        //---------------------------------------------------------------------------------------------------------
        
    }
}