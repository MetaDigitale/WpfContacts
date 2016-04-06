using System.Windows;
using System.Windows.Controls;
using WpfContacts.Pages;
using WpfContacts.ViewModels;

namespace WpfContacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ContattiViewModel _contattiViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _contattiViewModel = new ContattiViewModel();
            DataContext = _contattiViewModel;

            this.GridButton_Click(null, null);
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            this._contattiViewModel.CreateContatto();

            var contactDetails = new ContactDetails();
            this.NavigateTo(contactDetails);
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var contactDetails = new ContactDetails();
            this.NavigateTo(contactDetails);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this._contattiViewModel.SaveContatto();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            this._contattiViewModel.DeleteContatto();
        }

        private void GridButton_Click(object sender, RoutedEventArgs e)
        {
            var contactGrid = new ContactGrid();
            this.NavigateTo(contactGrid);
        }

        public void NavigateTo(UserControl pageToNavigate)
        {
            this.MainBody.Content = pageToNavigate;
        }
    }
}
