using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    class GenericValidationRules
    {
        public static bool ValidName(string name)
        {
            var isValid = true;

            foreach (var c in name)
            {
                if (Char.IsNumber(c))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
    }
}
