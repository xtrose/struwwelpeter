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

namespace Struwwelpeter.Pages.Hans
{
    public partial class hans : PhoneApplicationPage
    {





        public hans()
        {
            InitializeComponent();

            lbl_text1.Text = "Wenn der Hans zur Schule ging,\nstets sein Blick am Himmel hing.\nNach den Dächern, Wolken, Schwalben\nschaut er aufwärts allenthalben:\nVor die eignen Füße dicht,\nja, da sah der Bursche nicht,\nalso dass ein jeder ruft:\n\"Seht den Hans Guck-in-die-Luft!\"";
            lbl_text2.Text = "Kam ein Hund daher gerannt;\nHänslein blickte unverwandt\nin die Luft.\nNiemand ruft:\n\"Hans gib acht, der Hund ist nah!\"\nWas geschah?\nBauz! Pardauz! - da liegen zwei!\nHund und Hänschen nebenbei.";
            lbl_text3.Text = "Einst ging er an Ufers Rand\nmit der Mappe in der Hand.\nNach dem blauen Himmel hoch\nsah er, wo die Schwalbe flog,\nalso dass er kerzengrad\nimmer mehr zum Flusse trat.\nUnd die Fischlein in der Reih\nsind erstaunt sehr, alle drei.";
            lbl_text4.Text = "Noch ein Schritt! und plumbs! - der Hans\nstürzt hinab kopfüber ganz!\nDie drei Fischlein sehr erschreckt,\nhaben sich sogleich versteckt.";
            lbl_text5.Text = "Doch zum Glück da kommen zwei\nMänner aus der Näh herbei,\nUnd die haben ihn mit Stangen\naus dem Wasser aufgefangen.";
            lbl_text6.Text = "Seht! Nun steht er triefend naß!\nEi! das ist ein schlechter Spaß!\nWasser läuft dem armen Wicht\naus dem Haaren ins Gesicht,\naus den Kleidern, von dem Armen;\nund es friert ihn zum Erbarmen.\nDoch die Fischlein alle drei,\nschwimmen hurtig gleich herbei;\nstrecken's Köpflein aus der Flut,\nlachen, daß man's hören tut,\nlachen fort noch lange Zeit;\nund die Mappe schwimmt schon weit.";
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