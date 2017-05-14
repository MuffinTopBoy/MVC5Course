using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MVC5Course.Models.ViewModels
{
    public class SearchViewModul:IValidatableObject
    {
        public SearchViewModul()
        {
            this.Stock_S = 0;
            this.Stock_E = 0;
        }
        public string Name { get; set; }
        public int Stock_S { get; set; }
        public int Stock_E { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(this.Stock_S> this.Stock_E)
            {
                yield return new ValidationResult("產品數量錯誤",new string[] { "Stock_S", "Stock_E" });
            }
            //yield break;
        }
    }
}