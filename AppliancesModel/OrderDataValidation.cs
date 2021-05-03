using System.Text.RegularExpressions;

namespace AppliancesModel.Models
{
    public static class OrderDataValidation
    {
        public static bool IsTelephoneNumberValid(string number)
        {
            if (Regex.IsMatch(number, @"(\+38)?0((\(\d{2}\)|\d{2})\s?\d{3}\s\d{2}\s\d{2}|\d{9})"))
                return true;
            else return false;

        }

        public static bool IsAddressValid(string address)
        {
            if (Regex.IsMatch(address, @"(улица\s|ул\.\s?)[А-Я][а-я]{2,}(,\sд\.\s?\d{1,5},\s?кв\.\s?\d{1,3}|\.?,?\s?(д\.\s?|дом\s)?\d{1,3}(,\s?(кв\.|квартира\s)\d{1,3})?)"))
                return true;
            else return false;
        }
    }
}
