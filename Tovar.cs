//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootShoop
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tovar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tovar()
        {
            this.OrdersTovar = new HashSet<OrdersTovar>();
        }
    
        public int Id_Tovar { get; set; }
        public string NameTovar { get; set; }
        public string DiscriptionTovar { get; set; }
        public string ManufacturerTovar { get; set; }
        public int PriceTovar { get; set; }
        public Nullable<int> DiscountTovar { get; set; }
        public Nullable<int> Count { get; set; }
        public string ImageTovar { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersTovar> OrdersTovar { get; set; }
    }
}
