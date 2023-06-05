using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootShoop
{
    public partial class Tovar
    {
        SportEntities1 entities = new SportEntities1();

        public int totalPrice
        {
            get
            {
                if(this.DiscountTovar > 0)
                {
                    int discount = (Convert.ToInt32(this.PriceTovar * this.DiscountTovar / 100));
                    return this.PriceTovar - discount;
                }
                else
                {
                    return this.PriceTovar;
                }
            }
            set
            {

            }
        }
    }
    public partial class PickPoint
    {
        public override string ToString()
        {
            return AdressPickPoint;
        }
    }
}
