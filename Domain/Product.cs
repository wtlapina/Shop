using System;

namespace Domain
{
    public class Product
    {
        public Guid ProdId { get; set; }
        public string ProdName { get; set; }
        public Decimal ProdPrice { get; set; }
        public int ProdCategoryId { get; set; }
        
    }
}