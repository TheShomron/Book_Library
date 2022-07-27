using Data_Storage;
using Item_Type;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Adding_Item_Page : Page
    {
        private IStorage<LibraryItem> db = new Storage();


        public Adding_Item_Page()
        {

            this.InitializeComponent();




            Frequency_genre_ComboBox.ItemsSource = Book.BookGenres;
        }

        private void Item_Switch_Toggled(object sender, RoutedEventArgs e)
        {

            ToggleSwitch Item_Switch = sender as ToggleSwitch;

            if (Item_Switch != null)
            {
                if (Item_Switch.IsOn == true)
                {
                    Add_Item.Content = "Add\nJournal";
                    Clear_TxtBoxes();
                    Journal_Adjustment();
                }
                else
                {
                    Add_Item.Content = "Add\nBook";
                    Clear_TxtBoxes();

                    Book_Adjustment();
                }
            }
        }

        private void Book_Adjustment()
        {


            auther_editor_Block.Text = "Auther:";
            Publisher_Contributers_Block.Text = "Publisher:";
            Frequency_genre_Block.Text = "Genre:";
            Frequency_genre_ComboBox.ItemsSource = Book.BookGenres;



        }

        private void Journal_Adjustment()
        {
            auther_editor_Block.Text = "Editor:";
            Publisher_Contributers_Block.Text = "Contributer:";
            Frequency_genre_Block.Text = "Frequency:";

            var _enumval = Enum.GetValues(typeof(JournalFrequency)).Cast<JournalFrequency>();
            Frequency_genre_ComboBox.ItemsSource = _enumval.ToList();
        }

        private void Clear_TxtBoxes()
        {
            Title_TxtBox.Text =String.Empty;
            Price_TxtBox.Text =String.Empty;
            Quantity_TxtBox.Text=String.Empty;
            Summary_TxtBox.Text=String.Empty;
            Auther_Editor_TxtBox.Text=String.Empty;
            Publisher_Contributers_TxtBox.Text=String.Empty;
        }

        private async void Add_Item_Click(object sender, RoutedEventArgs e)
        {
            string s = "Item Added. ";
            try
            {
                db.Add(Creat_Item());
            }
            catch(Exception ex)
            {



                s = $"{ex.Message}";
                       
                        
                  
              
                    
                
                

            }
                await worked_pop(s);

           


        }

        private static async System.Threading.Tasks.Task worked_pop(string s)
        {
            ContentDialog pop = new ContentDialog
            {
                Title= "system",
                Content= s ,
                PrimaryButtonText = "Close",

            };
            await pop.ShowAsync();
        }


        private LibraryItem Creat_Item()
        {

            string title = Title_TxtBox.Text;
            double price = double.Parse(Price_TxtBox.Text);
            DateTime Published = DateTime.Parse(Published_Date_Box.Date.ToString());
            int qauntity = int.Parse(Quantity_TxtBox.Text);


            if (Item_Switch.IsOn == true)
            {
                var tempJournal = new Journal(title, Published, price, qauntity);
                tempJournal.Editors.Add(Auther_Editor_TxtBox.Text);
                tempJournal.Contributers.Add(Publisher_Contributers_TxtBox.Text);
                tempJournal.Frequency.Add(Frequency_genre_ComboBox.SelectedItem.ToString());
                tempJournal.Summary = Summary_TxtBox.Text;
                return tempJournal;
            }
            else
            {
                var tempbook = new Book(title, Published, price, qauntity);
                tempbook.Author.Add(Auther_Editor_TxtBox.Text);
                tempbook.Publisher.Add(Publisher_Contributers_TxtBox.Text);
                tempbook.Genres.Add(Frequency_genre_ComboBox.SelectedItem.ToString());
                tempbook.Summary = Summary_TxtBox.Text;

                return tempbook;

            }


        }

        private void Return_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Option_Page), e);
        }



        //Btn reatrictions==========================================================================================================
        private void Title_TxtBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => Char.IsNumber(c)) || args.NewText.Any(c => Char.IsSymbol(c));
        }

        private void Auther_Editor_TxtBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => Char.IsNumber(c)) || args.NewText.Any(c => Char.IsSymbol(c));
        }

        private void Publisher_Contributers_TxtBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => Char.IsNumber(c)) || args.NewText.Any(c => Char.IsSymbol(c));
        }

        private void Price_TxtBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => Char.IsLetter(c)) ||  args.NewText.Any(c => Char.IsSeparator(c)) ||  args.NewText.Any(c => Char.IsSymbol(c));
        }

        private void Quantity_TxtBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => Char.IsLetter(c)) ||  args.NewText.Any(c => Char.IsSeparator(c)) ||  args.NewText.Any(c => Char.IsSymbol(c));
        }
        //=================================================================================================================================
    }
}
