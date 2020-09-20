using MRTwitter.Resources;
using System.Collections.Generic;

namespace MRTwitter.Validators
{
    public static class Validator
    {
        public static List<string> Text25LenghtValidator(string text)
        {
            List<string> errors = new List<string>();
            if (text.Length > 25)
            {
                errors.Add(GlobalResources.TextLenght25);
            }
            return errors;
        }
    }
}