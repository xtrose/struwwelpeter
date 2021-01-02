using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;





namespace Struwwelpeter.Pages
{





    public partial class Support : PhoneApplicationPage
    {





        //Wird am Anfang der Seite geladen
        //---------------------------------------------------------------------------------------------------------
        public Support()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------------------------------------------





        //Button Support
        //---------------------------------------------------------------------------------------------------------
        private void LinkXtrose(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var wb = new WebBrowserTask();
            wb.URL = "http://www.xtrose.com";
            wb.Show();
        }
        //---------------------------------------------------------------------------------------------------------





        //Button Support
        //---------------------------------------------------------------------------------------------------------
        private void BtnSupport(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EmailComposeTask emailcomposer = new EmailComposeTask();
            emailcomposer.To = "xtrose@hotmail.com";
            emailcomposer.Subject = "Battery Live Tile Editor";
            emailcomposer.Body = "";
            emailcomposer.Show();
        }
        //---------------------------------------------------------------------------------------------------------
    }
}