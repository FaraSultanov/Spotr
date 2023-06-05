using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Shapes;

namespace FootShoop
{
    /// <summary>
    /// Логика взаимодействия для KorzinaWindow.xaml
    /// </summary>
    public partial class KorzinaWindow : Window
    {
        SportEntities1 entities = new SportEntities1();
        List<Tovar> Ordertovar = new List<Tovar>();
        public KorzinaWindow(List<Tovar> ordertovar)
        {
            InitializeComponent();
            Ordertovar = ordertovar;
            foreach(var adress in entities.PickPoint)
            {
                cmbPickPoint.Items.Add(adress);
            }
            dgKorzina.ItemsSource = Ordertovar;
            lblTotalPrice.Content = $"Общая стоимость:{Ordertovar.Sum(tovar => tovar.totalPrice)} руб.";
            lblDiscountPrice.Content = $"Размер скидки: {Ordertovar.Sum(tovar => tovar.PriceTovar) - Ordertovar.Sum(tovar => tovar.totalPrice)} руб.";
        }

        private void btnDeleteTovar_Click(object sender, RoutedEventArgs e)
        {
            var selectedTovar = dgKorzina.SelectedItem as Tovar;
            var rezult = MessageBox.Show("Вы точно хотите удалить товар из корзины?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(rezult == MessageBoxResult.Yes)
            {
                Ordertovar.Remove(selectedTovar);
                dgKorzina.ItemsSource = null;
                dgKorzina.ItemsSource = Ordertovar;
                lblTotalPrice.Content = $"Общая стоимость:{Ordertovar.Sum(tovar => tovar.totalPrice)} руб.";
                lblDiscountPrice.Content = $"Размер скидки: {Ordertovar.Sum(tovar => tovar.PriceTovar) - Ordertovar.Sum(tovar => tovar.totalPrice)} руб.";
            }
        }


        private void btnOrderAccess_Click_1(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            var selectedAdress = cmbPickPoint.SelectedItem as PickPoint;
            if (selectedAdress != null)
            {
                Orders newOrder = new Orders();
                entities.Orders.Add(newOrder);
                newOrder.DateOrder = DateTime.Now;
                newOrder.StatusOrder = "Новый";
                newOrder.CodeOrder = rnd.Next(100, 999);
                newOrder.Id_PickPoint = (cmbPickPoint.SelectedItem as PickPoint).Id_PickPoint;
                entities.SaveChanges();

                foreach (var tovars in Ordertovar)
                {
                    OrdersTovar newOrdersTovar = new OrdersTovar();
                    entities.OrdersTovar.Add(newOrdersTovar);
                    newOrdersTovar.Id_Order = newOrder.Id_Order;
                    newOrdersTovar.Id_Tovar = tovars.Id_Tovar;
                    entities.SaveChanges();
                }
                MessageBox.Show("Заказ успешно сформирован!", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                var window = new CheckWindow(Ordertovar,newOrder);
                window.ShowDialog();
             
            }
            else
            {
                MessageBox.Show("Укажите пункт выдачи", "ВНИМАНИЕ", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
