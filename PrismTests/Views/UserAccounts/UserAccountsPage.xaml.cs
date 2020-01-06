using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PrismTests.Views
{
    public partial class UserAccountsPage : ContentPage
    {
        public UserAccountsPage()
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
