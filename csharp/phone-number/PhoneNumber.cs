using System;
using System.Linq;

namespace Exercism.PhoneNumber
{
    internal class PhoneNumber
    {
        private static readonly string _defaultPhoneNumber = "0000000000";

        public string Number
        {
            get;
            private set;
        }

        public string AreaCode
        {
            get
            {
                return Number.Remove(3);
            }
        }

        private string LocalNumber
        {
            get
            {
                return String.Format("{0}-{1}", Number.Substring(3, 3), Number.Substring(6));
            }
        }

        public PhoneNumber(string phoneNumber)
        {
            Number = NumberParser(phoneNumber);
        }

        public string ToString()
        {
            return String.Format("({0}) {1}", AreaCode, LocalNumber);
        }

        private string NumberParser(string phoneNumber)
        {
            var cleanNumber = new string(phoneNumber.ToCharArray().Where(c => char.IsDigit(c)).ToArray());

            // Check the number length
            if (cleanNumber.Length < 10)
            {
                cleanNumber = _defaultPhoneNumber;
            }
            // If the number is 11 (or more) digits and starts with a 1, strip off the 1
            else if (cleanNumber[0] == '1' && cleanNumber.Length > 10)
            {
                cleanNumber = cleanNumber.Remove(0, 1);
            }
            // If the number is more than 10 digits and didnt start with a 1 - default the number
            else if (cleanNumber.Length > 10)
            {
                cleanNumber = _defaultPhoneNumber;
            }

            return cleanNumber;
        }
    }
}