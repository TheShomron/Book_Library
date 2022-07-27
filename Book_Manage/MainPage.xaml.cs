using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Book_Manage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


            MainGrid.Width = 1280;
            MainGrid.Height =720;







        }

        private async void start_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (UserName_Box.Text.ToLower()== "admin" && Password_Box.Password == "1234")
                this.Frame.Navigate(typeof(Option_Page), e);
            else
            {
                var dialog = new MessageDialog($"try 1234");
                await dialog.ShowAsync();
            }
        }
    }
}
