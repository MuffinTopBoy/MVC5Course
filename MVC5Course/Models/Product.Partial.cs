namespace MVC5Course.Models
{
    using Attribute;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product:IValidatableObject
    {
        public int 商品數量
        { get { return this.OrderLine.Count; } }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if(this.Price>2&&this.Stock>0)
            //{
            //    yield return new ValidationResult("商品太少少0000", new string[] { "stock","Order"});
            //}
            yield break;
        }
    }
    
    public partial class ProductMetaData
    {
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        [Required(ErrorMessage = "請輸入商品名稱")]
        [MinLength(3), MaxLength(30)]
        [商品名稱要有Wilson(ErrorMessage ="沒有Wilson")]
        [DisplayName("商品名稱")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "請輸入價格")]
        [Range(0, 9999, ErrorMessage = "超出範圍")]
        [DisplayFormat(DataFormatString ="{0:0}",ApplyFormatInEditMode =true)]
        [DisplayName("價格")]
        public Nullable<decimal> Price { get; set; }
        [Required]
        [DisplayName("是否上架")]
        public Nullable<bool> Active { get; set; }
        [Required]
        [DisplayName("庫存")]
        [Range(0, 9999, ErrorMessage = "超出範圍")]
        public Nullable<decimal> Stock { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
