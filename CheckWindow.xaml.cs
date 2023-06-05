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
using System.Windows.Shapes;

namespace FootShoop
{
    /// <summary>
    /// Логика взаимодействия для CheckWindow.xaml
    /// </summary>
    public partial class CheckWindow : Window
    {
        List<Tovar> Ordertovar = new List<Tovar>();
        SportEntities1 entities = new SportEntities1();
        public CheckWindow(List<Tovar> ordertovar,Orders order)
        {
            InitializeComponent();
            
            Ordertovar = ordertovar;
            

            txbxChekInfo.Text = $"Заказ № {order.Id_Order} от {order.DateOrder.ToShortDateString()}";
            foreach (var tovar in Ordertovar)
            {
                txbxChekInfo.Text += $"\n{tovar.NameTovar} ------------- {tovar.totalPrice}";
            }
            txbxChekInfo.Text += $"\n\nОбщая стоимость: {Ordertovar.Sum(tovar => tovar.totalPrice)} руб.";
            txbxChekInfo.Text += $"\n Размер скидки: {Ordertovar.Sum(tovar => tovar.PriceTovar) - Ordertovar.Sum(tovar => tovar.totalPrice)} руб.";
            txbxChekInfo.Text += $"\n Пункт выдачи: {order.PickPoint.AdressPickPoint}";
            txbxChekInfo.Text += $"\n Код получения: {order.CodeOrder}";
            if(Ordertovar.Min(tovar => tovar.Count) > 3)
            {
                txbxChekInfo.Text += $"\n Срок доставки - 3 дня";
            }
            else
            {
                txbxChekInfo.Text += $"\n Срок доставки - 6 дней";
            }
         }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog saveFileDialog = new PrintDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                IDocumentPaginatorSource ipd = CheckOrder;
                saveFileDialog.PrintDocument(ipd.DocumentPaginator, "Flow Document");
            }
        }
    }
}
