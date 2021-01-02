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

namespace Struwwelpeter.Pages.Friederich
{
    public partial class friederich : PhoneApplicationPage
    {





        //Wid am Anfang der Seite geladen
        //---------------------------------------------------------------------------------------------------------
        public friederich()
        {
            InitializeComponent();

            lbl_text1.Text = "Der Friederich, der Friederich,\ndas war ein arger Wüterich!\nEr fing die Fliegen in dem Haus\nund riß ihnen die Flügel aus.\nEr schlug die Stühl und Vögel tot,\nDie Katzen litten große Not.\nUnd höre nur, wie bös er war:\nEr peitschte, ach, sein Gretchen gar!";
            lbl_text2.Text = "Am Brunnen stand ein großer Hund,\ntrank Wasser dort mit seinem Mund.\nDa mit der Peitsch herzu sich schlich\nder bitterböse Friederich;\nund schlug den Hund, der heulte sehr\nund trat und schlug ihn immer mehr.\nDa biss der Hund ihn in das Bein,\nrecht tief bis in das Blut hinein.\nDer bitterböse Friederich,\nder schrie und weinte bitterlich.\nJedoch nach Hause lief der Hund\nund trug die Peitsche in dem Mund.";
            lbl_text3.Text = "Ins Bett muss Friedrich nun hinein, \nlitt vielen Schmerz an seinem Bein;\nund der Herr Doktor sitzt dabei\nund gibt ihm bitte Arzenei.\n\nDer Hund an Friedrichs Tischchen saß,\nwo er den großen Kuchen aß;\naß auch die gute Leberwurst\nund trank den Wein für seinen Durst.\nDie Peitsche hat er mitgebracht\nund nimmt sie sorglich sehr in acht.";//Werbung hinzufügen
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