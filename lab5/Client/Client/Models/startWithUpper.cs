using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class startWithUpper : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            
            // Ensure the first character is capitalized
            var firstChar = char.Parse(value.ToString().Substring(0,1));
            if (char.IsLower(firstChar))
            {
                return false;
            }
            return true;
        }
    }
}