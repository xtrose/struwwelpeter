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

namespace Struwwelpeter.Pages.Phillip
{
    public partial class philipp : PhoneApplicationPage
    {





        public philipp()
        {
            InitializeComponent();

            lbl_text1.Text = "\"Ob der Philipp heute still\nwohl bei Tische sitzen will?\"\nAlso sprach in ernstem Ton\nder Papa zu seinem Sohn,\nund die Mutter blickte stumm\nauf dem ganzen Tisch herum.\nDoch der Philipp hörte nicht,\nwas zu ihm der Vater spricht.\nEr gaukelt\nund schaukelt,\ner trappelt\nund zappelt\nauf dem Stuhle hin und her.\n\"Philipp, das missfällt mir sehr!\"";
            lbl_text2.Text = "Seht, ihr lieben Kinder, seht,\nwie's dem Philipp weiter geht!\nSchaut genau auf dieses Bild!\nSeht! Er schaukelt gar zu wild,\nbis der Stuhl nach hinten fällt;\nda ist nichts mehr, was ihn hält;\nnach dem Tischtuch greift er, schreit.\nDoch was hilfts? Zu gleicher Zeit\nfallen Teller, Flasch und Brot.\nVater ist in großer Not,\nund die Mutter blicket stumm\nauf dem ganzen Tisch herum.";
            lbl_text3.Text = "Nun ist der Philipp ganz versteckt,\nund der Tisch ist abgedeckt,\nwas der Vater essen wollt,\nunten auf der Erde rollt;\nSuppe, Brot und alle Bissen,\nalles ist herabgebissen;\nSuppenschüssel ist entzwei,\nund die Eltern stehn dabei.\nBeide sind gar zornig sehr,\nhaben nichts zu essen mehr.";
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