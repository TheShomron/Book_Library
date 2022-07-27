using Data_Storage;
using Item_Type;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Book_Manage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Option_Page : Page
    {
        private IStorage<LibraryItem> db = new Storage();
        public Option_Page()
        {

            this.InitializeComponent();

            MainGrid.Width = 1280;
            MainGrid.Height =720;

            Rebot_Screens();

        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Adding_Item_Page), e);
        }
        private async void Remov_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Showing_Screen.SelectedItem == null)
            {

                var dialog1 = new MessageDialog($"Please Choose Item.");
                await dialog1.ShowAsync();
                return;
            }
            var chosen = Showing_Screen.SelectedItem as LibraryItem;

            ContentDialog pop = new ContentDialog
            {
                Title= "Remove Item",
                Content= $"Sure u Want To Remove: {chosen.Title}?",
                PrimaryButtonText = "yes",
                SecondaryButtonText = "no"
            };
            ContentDialogResult res = await pop.ShowAsync();
            if (res == ContentDialogResult.Primary)
            {
                db.Delete(chosen.Id);
                Rebot_Screens();
            }
        }

        private void Rebot_Screens()
        {
            Showing_Screen.ItemsSource =Data_Storage.DataMock.DataBase.LibraryItems.FindAll(x => x.IsBorrowed == false);
            BorrowScren_view.ItemsSource = Data_Storage.DataMock.DataBase.LibraryItems.FindAll(x => x.IsBorrowed == true);
        }
        private async void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Showing_Screen.SelectedItem == null)
            {

                var dialog1 = new MessageDialog($"Please Choose Item.");
                await dialog1.ShowAsync();
                return;
            }

            LibraryItem chosen = Showing_Screen.SelectedItem as LibraryItem;

            Frame.Navigate(typeof(Update_Page), chosen);
        }
        private void Sort_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Sort_ComboBox.SelectedIndex)
            {
                case 0:
                    {
                        Showing_Screen.ItemsSource =Data_Storage.DataMock.DataBase.LibraryItems.FindAll(x => x.IsBorrowed == false).OrderBy(x => x.Price);

                        break;
                    }
                case (1):
                    {
                        Showing_Screen.ItemsSource =Data_Storage.DataMock.DataBase.LibraryItems.FindAll(x => x.IsBorrowed == false).OrderBy(x => x.PublishDate);
                        break;
                    }
                case 2:
                    {
                        Showing_Screen.ItemsSource =Data_Storage.DataMock.DataBase.LibraryItems.FindAll(x => x.IsBorrowed == false).OrderBy(x => x.Title);
                        break;
                    }
                case 3:
                    {

                        Showing_Screen.ItemsSource =Data_Storage.DataMock.DataBase.LibraryItems.FindAll(x => x is Book && x.IsBorrowed == false);
                        break;
                    }
                case 4:
                    {

                        Showing_Screen.ItemsSource =Data_Storage.DataMock.DataBase.LibraryItems.FindAll(x => x is Journal && x.IsBorrowed == false);
                        break;
                    }

            }
        }
        private void Showing_Screen_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if(!(Showing_Screen.SelectedItem == null))
            {
                LibraryItem chosen = Showing_Screen.SelectedItem as LibraryItem;

                Frame.Navigate(typeof(Info_Page), chosen);
            }
          
        }
      
        private async void Borrow_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Showing_Screen.SelectedItem == null)
            {

                var dialog1 = new MessageDialog($"Please Choose Item.");
                await dialog1.ShowAsync();
                return;
            }


            LibraryItem chosen = Showing_Screen.SelectedItem as LibraryItem;
            if (chosen.IsBorrowed == false)
            {
                chosen.IsBorrowed = true;
              
                var dialog1 = new MessageDialog($"{chosen.Title} is now Borrowed.");
                await dialog1.ShowAsync();
                Rebot_Screens();


            }
            else
            {
                var dialog = new MessageDialog($"{chosen.Title} Is Already Borrowed...");
                await dialog.ShowAsync();
            }




        }

        private async void Buy_Btn_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (Showing_Screen.SelectedItem == null)
            {

                var dialog1 = new MessageDialog($"Please Choose Item.");
                await dialog1.ShowAsync();
                return;
            }
            var chosen = Showing_Screen.SelectedItem as LibraryItem;

            ContentDialog Buy = new ContentDialog
            {
                Title= "Purchasing",
                Content= $"Title: {chosen.Title}\nPrice:{chosen.Price:C}",
                PrimaryButtonText = "yes",
                SecondaryButtonText = "no"
            };
            ContentDialogResult ANS = await Buy.ShowAsync();
            if (ANS == ContentDialogResult.Primary)
            {
                chosen.Quantity--;
                if(chosen.Quantity == 0)
                    db.Delete(chosen.Id);

                Showing_Screen.ItemsSource =db.Get();
                Showing_Screen.ItemsSource =Data_Storage.DataMock.DataBase.LibraryItems.FindAll(x => x.IsBorrowed == false);
            }
        }

        private async void Return_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (BorrowScren_view.SelectedItem == null)
            {

                var dialog1 = new MessageDialog($"Please Choose Item.");
                await dialog1.ShowAsync();
                return;
            }


            LibraryItem chosen = BorrowScren_view.SelectedItem as LibraryItem;
            if (chosen.IsBorrowed == true)
            {
                chosen.IsBorrowed = false;
                var dialog1 = new MessageDialog($"{chosen.Title} is now Back In Stock.");
                await dialog1.ShowAsync();
                Rebot_Screens();


            }


        }

        private void BorrowScren_view_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (!(Showing_Screen.SelectedItem == null))
            {
                LibraryItem chosen = BorrowScren_view.SelectedItem as LibraryItem;

                Frame.Navigate(typeof(Info_Page), chosen);
            }
        }
    }
}
