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

using Microsoft.Advertising.Mobile.UI;
using Microsoft.Phone.Tasks;

namespace Struwwelpeter.Pages.Neger
{

    public partial class neger : PhoneApplicationPage
    {





        public neger()
        {
            InitializeComponent();

            lbl_text1.Text = "Es ging spazieren vor dem Tor\nein kohlpechrabenschwarzer Mohr.\nDie Sonne schien ihm aufs Gehirn,\nda nahm er seinen Sonnenschirm.\nDa kam der Ludwig hergerannt\nund trug sein Fähnchen in der Hand.\nDer Kaspar kam mit schnellem Schritt\nund brachte seine Bretzel mit.\nUnd auch der Wilhelm war nicht steif\nund brachte seinen runden Reif.\nDie schrien und lachten alle drei,\nals dort das Mohrchen ging vorbei,\nweil es so schwarz wie Tinte sei!";
            lbl_text2.Text = "Da kam der große Nikolas\nmit seinem großen Tintenfass.\nDer sprach: \"Ihr Kinder, hört mir zu\nund laßt den Mohren hübsch in Ruh!\nWas kann denn dieser Mohr dafür,\ndass er so weiß nicht ist, wie ihr?\"\nDie Buben aber folgten nicht,\nund lachten ihm ins Angesicht,\nund lachten ärger als zuvor\nüber den armen schwaren Mohr.";
            lbl_text3.Text = "Der Nikolas wurde bös und wild,\ndu siehst es hier auf diesem Bild!\nEr packte gleich die Buben fest\nbeim Arm, beim Kopf, bei Rock und West':\nden Wilhelm und den Ludewig,\nden Kaspar auch, der wehrte sich.\nEr tunkt' sie in die Tinte tief,\nwie auch der Kaspar \"Feuer\" rief.\nBis übern Kopf ins Tintenfass\ntunkt' sie der große Nikolas.";
            lbl_text4.Text = "Du siehst sie hier, wie schwarz sie sind,\nViel schwärzer als das Mohrenkind!\nDer Mohr voraus im Sonnenschein,\ndie Tintenbuben hintendrein;\nund hätten sie nicht so gelacht,hätt Niklas sie nicht schwarz gemacht.";
        }


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
                    adControl.ErrorOccurred += (o, d) =>
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

    }
    
}