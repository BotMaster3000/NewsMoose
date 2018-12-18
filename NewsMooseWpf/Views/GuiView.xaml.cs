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
                //Daten Speicher
                //Daten Laden
                //ListBox Aktualisieren
            }
        }
    }
}
