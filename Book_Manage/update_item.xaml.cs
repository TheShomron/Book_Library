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
    public sealed partial class Update_Page : Page
    {
        LibraryItem transfer;
        public Update_Page()
        {
            this.InitializeComponent();
            MainGrid.Width = 1280;
            MainGrid.Height =720;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            transfer = (LibraryItem)e.Parameter;
            base.OnNavigatedTo(e);

            if (transfer is Book)
            {
                Frequency_genre_ComboBox.ItemsSource = Book.BookGenres;
                Show_Book();
            }
            else if (transfer is Journal)
            {
                Journal_Adjustment();
                Show_Journal();

            }




        }

        private void Journal_Adjustment()
        {
            auther_editor_Block.Text = "Editor:";
            Publisher_Contributers_Block.Text = "Contributer:";
            Frequency_genre_Block.Text = "Frequency:";
            var _enumval = Enum.GetValues(typeof(JournalFrequency)).Cast<JournalFrequency>();
            Frequency_genre_ComboBox.ItemsSource = _enumval.ToList();
        }

        private void Show_Journal()
        {
            Title_TxtBox.Text =transfer.Title;
            Price_TxtBox.Text =transfer.Price.ToString();
            Published_Date_Box.Date = transfer.PublishDate;
            Quantity_TxtBox.Text=transfer.Quantity.ToString();
            Auther_Editor_TxtBox.Text= $"{((Journal)transfer):Editor}";
            Publisher_Contributers_TxtBox.Text= $"{((Journal)transfer):Contributer}";
            Frequency_genre_ComboBox.SelectedValuePath =  $"{((Journal)transfer):Frequency}";
            Summary_TxtBox.Text = ((Journal)transfer).Summary;
        }

        private void Show_Book()
        {
            Title_TxtBox.Text =transfer.Title;
            Price_TxtBox.Text =transfer.Price.ToString();
            Published_Date_Box.Date = transfer.PublishDate;
            Quantity_TxtBox.Text=transfer.Quantity.ToString();
            Auther_Editor_TxtBox.Text= $"{((Book)transfer):Auther}";
            Publisher_Contributers_TxtBox.Text= $"{((Book)transfer):Publisher}";
            Frequency_genre_ComboBox.SelectedValuePath = $"{((Book)transfer):Genre}";
            Summary_TxtBox.Text = ((Book)transfer).Summary;
        }


        private void update_Btn_Click(object sender, RoutedEventArgs e)
        {          
            Update_Item();
        }

        private void Update_Item()
        {
            transfer.Title = Title_TxtBox.Text;
            transfer.Price = double.Parse(Price_TxtBox.Text);
            transfer.PublishDate = DateTime.Parse(Published_Date_Box.Date.ToString());
            transfer.Quantity = int.Parse(Quantity_TxtBox.Text);

            if (transfer is Book)
            {
                ((Book)transfer).Author.Clear();
                ((Book)transfer).Publisher.Clear();
                ((Book)transfer).Genres.Clear();

                ((Book)transfer).Summary = Summary_TxtBox.Text;
                ((Book)transfer).Author.Add(Auther_Editor_TxtBox.Text);
                ((Book)transfer).Publisher.Add(Publisher_Contributers_TxtBox.Text);
                ((Book)transfer).Genres.Add(Frequency_genre_ComboBox.SelectedItem.ToString());
            }
            else if (transfer is Journal)
            {
                ((Journal)transfer).Editors.Clear();
                ((Journal)transfer).Contributers.Clear();
                ((Journal)transfer).Frequency.Clear();

                ((Journal)transfer).Summary = Summary_TxtBox.Text;
                ((Journal)transfer).Editors.Add(Auther_Editor_TxtBox.Text);
                ((Journal)transfer).Contributers.Add(Publisher_Contributers_TxtBox.Text);
                ((Journal)transfer).Frequency.Add(Frequency_genre_ComboBox.SelectedItem.ToString());

            }
        }


        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Option_Page), e);
        }


        //Btn reatrictions========================================================================================================== 
        private void Title_TxtBox_BeforeTextChanging_1(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => Char.IsNumber(c)) || args.NewText.Any(c => Char.IsSymbol(c));
        }

        private void Auther_Editor_TxtBox_BeforeTextChanging_1(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => Char.IsNumber(c)) || args.NewText.Any(c => Char.IsSymbol(c));
        }

        private void Price_TxtBox_BeforeTextChanging_1(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => Char.IsLetter(c)) ||  args.NewText.Any(c => Char.IsSeparator(c)) ||  args.NewText.Any(c => Char.IsSymbol(c)); 
         
        }

        private void Publisher_Contributers_TxtBox_BeforeTextChanging_1(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => Char.IsNumber(c)) || args.NewText.Any(c => Char.IsSymbol(c));
        }

        private void Quantity_TxtBox_BeforeTextChanging_1(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => Char.IsLetter(c)) ||  args.NewText.Any(c => Char.IsSeparator(c)) ||  args.NewText.Any(c => Char.IsSymbol(c));
        }


        //========================================================================================================================
    }
}
