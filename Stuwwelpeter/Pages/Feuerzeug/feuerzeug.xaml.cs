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

namespace Struwwelpeter.Pages.Feuerzeug
{
    public partial class feuerzeug : PhoneApplicationPage
    {




        //Wird am Anfang der Seite geladen
        //-----------------------------------------------
        public feuerzeug()
        {
            InitializeComponent();

            lbl_text1.Text = "Paulinchen war allein zu Haus,\ndie Eltern waren beide aus.\nAls sie nun durch das Zimmer sprang\nmit leichtem Mut und Sing und Sang,\nda sah sie plötzlich vor sich stehn\nein Feuerzeug, nett anzusehn.\n\"Ei,\" sprach sie, \"ei, wie schön und fein!\nDas muß ein trefflich Spielzeug sein.\nIch zünde mir ein Hölzchen an,\nwie's oft die Mutter hat getan.\"\n\nUnd Minz und Maunz, die Katzen,\nerheben ihre Tatzen.\nSie drohen mit den Pfoten:\n\"Der Vater hat's verboten!\nMiau! Mio! Miau! Mio!\nLaß stehn! Sonst brennst Du lichterloh!\"";
            lbl_text2.Text = "Paulinchen hört die Katzen nicht!\nDas Hölzchen brennt gar hell und licht,\ndas flackert lustig, knistert laut,\ngrad wie ihr's auf dem Bilde schaut.\nPaulinchen aber freut sich sehr\nund sprang im Zimmer hin und her.\n\nDoch Minz und Maunz, die Katzen,\nerheben ihre Tatzen.\nSie drohen mit den Pfoten:\n\"Die Mutter hat's verboten!\nMiau! Mio! Miau! Mio!\nWirf's weg! Sonst brennst Du lichterloh!\"";
            lbl_text3.Text = "Doch weh! Die Flamme fasst das Kleid,\ndie Schürze brennt; es leuchtet weit.\nEs brennt die Hand, es brennt das Haar,\nes brennt das ganze Kind sogar.\n\nUnd Minz und Maunz, die schreien\ngar jämmerlich zu zweien:\n\"Herbei! Herbei! Wer hilft geschwind?\nIm Feuer steht das ganze Kind!\nMiau! Mio! Miau! Mio!\nZu Hilf! Das Kind brennt lichterloh!\"";
            lbl_text4.Text = "Verbrannt ist alles ganz und gar,\ndas arme Kind mit Haut und Haar;\nein Häuflein Asche bleibt allein\nund beide Schuh, so hübsch und fein.\n\nUnd Minz und Maunz, die kleinen,\ndie sitzen da und weinen:\n\"Miau! Mio! Miau! Mio!\nWo sind die armen Eltern? Wo?\"\nUnd ihre Tränen fließen\nwie's Bächlein auf den Wiesen.";
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