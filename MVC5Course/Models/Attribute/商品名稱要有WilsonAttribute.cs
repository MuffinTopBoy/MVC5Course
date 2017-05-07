﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.Attribute
{
    public class 商品名稱要有WilsonAttribute:DataTypeAttribute
    {
        public 商品名稱要有WilsonAttribute() :base (DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            string str = (string)value;

            return str.Contains("Wilson");
        }
    }
}