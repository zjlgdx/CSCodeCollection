using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClient.NorthwindServiceReference;
using System.Data.Services.Client;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NorthwindEntities db = new NorthwindEntities(
          new Uri("http://localhost:61320/NorthwindService.svc"));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void getCustomers(object sender, RoutedEventArgs e)
        {
            var source = new DataServiceCollection<Customer>(db.Customers);
            dg.ItemsSource = source;
        }
    }
}
