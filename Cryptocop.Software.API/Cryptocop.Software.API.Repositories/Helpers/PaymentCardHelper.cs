using System.Linq;
using System;
using System.Text.RegularExpressions;
namespace Cryptocop.Software.API.Repositories.Helpers
{
    public class PaymentCardHelper
    {
        public static string MaskPaymentCard(string paymentCardNumber)
        {

            var cardNumber = paymentCardNumber;

            var lastDigits = cardNumber.Substring(cardNumber.Length - 4, 4);

            var requiredMask = new String('*', cardNumber.Length - lastDigits.Length);

            var maskedString = string.Concat(requiredMask, lastDigits);
            var maskedCardNumberWithSpaces = Regex.Replace(maskedString, ".{4}", "$0 ");
            return maskedCardNumberWithSpaces;
        }
    }
}