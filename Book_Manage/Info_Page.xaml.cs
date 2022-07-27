using Item_Type;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Book_Manage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Info_Page : Page
    {
        LibraryItem transfer;
        public Info_Page()
        {
            this.InitializeComponent();
            MainGrid.Width = 1280;
            MainGrid.Height =720;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            transfer = (LibraryItem)e.Parameter;
            base.OnNavigatedTo(e);

            Show_Item();

        }

        private void Show_Item()
        {
            Info_Box.Text += $"Title: {transfer.Title}\n\n " +
                $"ID: {transfer.Id}\nPublish Date: {(transfer.PublishDate):d}\nQuantity: {transfer.Quantity} | Price: {transfer.Price} \n";

            if (transfer is Book)
            {


                Info_Box.Text += $"Auther: {((Book)transfer):Auther} | Publisher: {((Book)transfer):Publisher}\nGenre: {((Book)transfer):Genre}" +
                    $"\n\n Summery:\n {((Book)transfer).Summary}";
            }
            else if (transfer is Journal)
            {
                Info_Box.Text +=  $"Editor: {((Journal)transfer):Editor} | Contributer: {((Journal)transfer):Contributer} | Frequency: {((Journal)transfer):Frequency}" +
                    $" \n\n Summery:\n{ ((Journal)transfer).Summary}";

            }
        }

        private void Return_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Option_Page), e);
        }
    }
}
