namespace MVC5Course.Models
{
    using MVC5Course.Models.DataTypes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(this.Price >1000 && this.Stock <10)
            {
                //yield return new ValidationResult("當Price>1000時，Stock不得<10", new string[] { "Price", "Stock" });
                yield return new ValidationResult("當Price>1000時，Stock不得<10");
            }
        }
    }

    public partial class ProductMetaData
    {
        [Required]
        [Display(Description ="商品ID", Name = "商品ID")]
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        [Display(Description ="商品名稱c",Name = "商品名稱d")]
        [身份證字號]
        public string ProductName { get; set; }
        [Display(Description ="價格")]
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
