using Fridger.WindowsUniversalApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Fridger.WindowsUniversalApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {              
        private readonly HttpClient httpClient;

        public LoginPage()
        {
            this.InitializeComponent();
            this.httpClient = new HttpClient();
            //var contentViewModel = new RegisterFormContentViewModel();
            //this.DataContext = new MainPageViewModel(contentViewModel);
        }
        
        private async void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            var reg = (sender as Button).CommandParameter as LoginFormViewModel;
            this.NotificationTextBlock.Text = string.Empty;
            var url = "http://localhost:57647/" + "token";

            //TODO: data musd be passed as x-www-form-url-encoded
            var content = new StringContent("grant_type=password&username=" + reg.UserName + "&password=" + reg.Password, Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await this.httpClient.PostAsync(new Uri(url), content);
            var result = await response.Content.ReadAsStringAsync();

            this.NotificationTextBlock.Text = result;

        }
    }
}
