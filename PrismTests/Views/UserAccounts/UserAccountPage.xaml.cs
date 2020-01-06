using System;
using System.Collections.Generic;
using PrismTests.Helpers;
using Xamarin.Forms;

namespace PrismTests.Views
{
    public partial class UserAccountPage : ContentPage
    {
        public UserAccountPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
