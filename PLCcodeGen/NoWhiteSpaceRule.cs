using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Controls;

namespace PLCcodeGen
{
    class NoWhiteSpaceRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (((String)value).Contains(" "))
                return new ValidationResult(false,"Space characters are not allowed.");
            else
                return ValidationResult.ValidResult;
        }
    }
}
