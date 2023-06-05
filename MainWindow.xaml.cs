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

namespace FootShoop
{
    
    public partial class MainWindow : Window
    {
        SportEntities1 entities = new SportEntities1();
        List<Tovar> OrderTovar = new List<Tovar>();
        public MainWindow()
        {
            InitializeComponent();
            dtTovars.ItemsSource = entities.Tovar.ToList();
            btnKorzina.Visibility = Visibility.Hidden;
            
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedTovar = dtTovars.SelectedItem as Tovar;
            if(selectedTovar != null)
            {
                OrderTovar.Add(selectedTovar);
                btnKorzina.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Выберите товар", "ВНИМАНИЕ",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnKorzina_Click(object sender, RoutedEventArgs e)
        {
            var window = new KorzinaWindow(OrderTovar);
            window.ShowDialog();
        }
    }
}
