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
            ViewModel.ShowNewsPaper();
            ViewModel.ShowPublishers();
        }


        private void CreateNewNewsPaper(object sender, RoutedEventArgs e)
        {
            if(NewsPaperName.Text != "")
            {
                ViewModel.CreateNewNewsPaper(NewsPaperName.Text);
                NewsPaperListBox.ItemsSource = ViewModel.NewsPapers;
                NewsPaperListBox.Items.Refresh();
                NewsPaperListBox.SelectedIndex = NewsPaperListBox.Items.Count -1;
                
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
                this.SetPublisherNewsPapers();
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
                this.SetNewsPapers();
            }
            
        }

        private void NewsPaperListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                NewsPaper newspaper = (NewsPaper)e.AddedItems[0];
                NewsPaperName.Text = newspaper.Name;

                UpdateNewsPaper.IsEnabled = true;
                DeleteNewsPaper.IsEnabled = true;
            }
        }

        private void UpdatePublisher_Click(object sender, RoutedEventArgs e)
        {
            Publisher publisher = (Publisher)PublisherListBox.SelectedItem;
            if (publisher != null)
            {
                ViewModel.UpdatePublisher(publisher, PublisherName.Text);
                PublisherListBox.Items.Refresh();
            }
        }

        private void UpdateNewsPaper_Click(object sender, RoutedEventArgs e)
        {
            NewsPaper newspaper = (NewsPaper)NewsPaperListBox.SelectedItem;
            if (newspaper != null)
            {
                ViewModel.UpdateNewsPaper(newspaper, NewsPaperName.Text);
                NewsPaperListBox.Items.Refresh();
                this.SetPublisherNewsPapers();
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
                ViewModel.NewsPapers.Clear();
                NewsPaperListBox.Items.Refresh();
                NewsPaperName.Text = "";
                NewsPaperGroup.IsEnabled = false;

            }
            
        }

        private void DeleteNewsPaper_Click(object sender, RoutedEventArgs e)
        {
            NewsPaper newspaper = (NewsPaper)NewsPaperListBox.SelectedItem;
            ViewModel.DeleteNewsPaper(newspaper);
            NewsPaperListBox.ItemsSource = ViewModel.NewsPapers;
            NewsPaperListBox.Items.Refresh();
            NewsPaperName.Text = "";
            NewsPaperListBox.SelectedIndex = 0;

            if (ViewModel.NewsPapers.Count == 0)
            {
                UpdateNewsPaper.IsEnabled = false;
                DeleteNewsPaper.IsEnabled = false;
            }
            this.SetPublisherNewsPapers();

        }

        private void SetPublisherNewsPapers()
        {
            Publisher selectedpublisher = (Publisher) PublisherListBox.SelectedItem;

            int publisherindex = ViewModel.Publishers.IndexOf(selectedpublisher);
            ViewModel.Publishers[publisherindex].NewsPapers = ViewModel.NewsPapers;
            

        }
        
        private void SetNewsPapers()
        {
            Publisher selectedpublisher = (Publisher)PublisherListBox.SelectedItem;
            int publisherindex = ViewModel.Publishers.IndexOf(selectedpublisher);

            ViewModel.NewsPapers = ViewModel.Publishers[publisherindex].NewsPapers;
            NewsPaperListBox.ItemsSource = ViewModel.Publishers[publisherindex].NewsPapers;
            NewsPaperName.Text = "";

        }

        

        
    }
}
