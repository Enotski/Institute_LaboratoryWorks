//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laba_3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Products
    {
        public string Name { get; set; }
        public string MeasureUnit { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Sum { get; set; }
        public string DocId { get; set; }
    
        public Bills Bills { get; set; }
        public Invoices Invoices { get; set; }
        public Reciepts Reciepts { get; set; }
    }
}
