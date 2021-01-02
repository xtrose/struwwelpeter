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

namespace Struwwelpeter.Pages.Jaeger
{
    public partial class jaeger : PhoneApplicationPage
    {





        public jaeger()
        {
            InitializeComponent();

            lbl_text1.Text = "Es zog der wilde Jägersmann\nsein grasgrün neues Röcklein an;\nnahm Ranzen, Pulverhorn und Flint\nund lief hinaus ins Feld geschwind.\n\nEr trug die Brille auf der Nas\nund wollte schießen tot der Has.\n\nDas Häschen sitzt im Blätterhaus,\nund lacht den wildern Jäger aus.";
            lbl_text2.Text = "Jetzt schien die Sonne gar zu sehr,\nda ward ihm sein Gewehr zu schwer.\nEr legte sich ins grüne Gras,\ndas alles sah der kleine Has.\nUnd als der Jäger schnarcht' und schlief,\nder Has ganz heimlich zu ihm lief\nund nahm die Flint und auch die Brill\nund schlich davon ganz leis und still.";
            lbl_text3.Text = "Die Brille hat has Häschen jetzt\nsich selber auf seine Nas gesetzt\nund schießen will's aus dem Gewehr.\nDer Jäger aber fürcht' sich sehr.\nEr läuft davon und springt und schreit:\n\"Zu Hilf, ihr Leut, zu Hilf, ihr Leut!\"\n\nDa kommt der wilde Jägersmann\nzuletzt beim tiefen Brünnchen an,\ner springt hinein. Die Not war groß;\nes schießt der Has die Flinte los.";
            lbl_text4.Text = "Des Jägers Frau am Fenster saß\nund trank aus ihrer Kaffeetass.\nDie schoss das Häschen ganz entzwei,\nda rief die Frau: \"O wei! O wei!\"\nDoch bei dem Brünnchen heimlich saß\ndes Häschens Kind, der kleine Has.\nDer hockte da im grünen Gras;\ndem floss der Kaffee auf die Nas'.\ner schrie: \"Wer hat mich da verbrannt?\",\nund hielt den Löffel in der Hand.";
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