using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewsMooseClassLibrary.ViewModels;
using NewsMooseClassLibrary.Models;


namespace NewsMooseWpf.Views
{
    /// <summary>
    /// Interaktionslogik für GuiView.xaml
    /// </summary>
    public partial class GuiView : UserControl
    {
        public GuiViewModel ViewModel { get; set; } = new GuiViewModel();

        public GuiView()
        {
            InitializeComponent();
        }


        private void CreateNewNewsPaper(object sender, RoutedEventArgs e)
        {
            if(NewsPaperName.Text != "")
            {
                ViewModel.CreateNewNewsPaper(NewsPaperName.Text);
                
                //ListBox Aktualisieren
            }
            
        }

        private void CreateNewPublisher(object sender, RoutedEventArgs e)
        {
            if (PublisherName.Text != "")
            {
                ViewModel.CreateNewPublisher(PublisherName.Text);
                PublisherListBox.ItemsSource = ViewModel.Publishers;
                PublisherListBox.Items.Refresh();
                PublisherListBox.SelectedIndex = PublisherListBox.Items.Count - 1;
                //Daten Speicher
                //Daten Laden
                //ListBox Aktualisieren
            }
        }

        private void PublisherListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Publisher publisher = (Publisher)e.AddedItems[0];
                PublisherName.Text = publisher.Name;

                UpdatePublisher.IsEnabled = true;
                NewsPaperGroup.IsEnabled = true;
                DeletePublisher.IsEnabled = true;
            }
            
        }

        private void DeletePublisher_Click(object sender, RoutedEventArgs e)
        {
            Publisher publisher = (Publisher)PublisherListBox.SelectedItem;
            ViewModel.DeletePublisher(publisher);
            PublisherListBox.ItemsSource = ViewModel.Publishers;
            PublisherListBox.Items.Refresh();
            PublisherName.Text = "";
            PublisherListBox.SelectedIndex = 0;

            if(ViewModel.Publishers.Count == 0)
            {
                UpdatePublisher.IsEnabled = false;
                DeletePublisher.IsEnabled = false;
                NewsPaperGroup.IsEnabled = false;
            }
            
        }

        private void UpdatePublisher_Click(object sender, RoutedEventArgs e)
        {
            Publisher publisher = (Publisher)PublisherListBox.SelectedItem;
            if (publisher != null)
            {
                ViewModel.UpdatePublisher(publisher,PublisherName.Text);
                PublisherListBox.Items.Refresh();
            }
        }
    }
}
