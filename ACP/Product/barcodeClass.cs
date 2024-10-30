using System;

namespace ACP
{
   public class barcodeClass
    {
        public string GenerateEan13()
        {
            Random random = new Random();
            string ean12 = "";
            for (int i = 0; i < 12; i++)
            {
                ean12 += random.Next(0, 9).ToString();
            }

            int sum = 0;
            for (int i = 0; i < ean12.Length; i++)
            {
                int digit = int.Parse(ean12[i].ToString());
                sum += (i % 2 == 0) ? digit * 1 : digit * 3;
            }

            int checkDigit = (10 - (sum % 10)) % 10;
            return ean12 + checkDigit.ToString();
        }
        public string GenerateEan8()
        {
            Random random = new Random();
            string ean8 = "";
            for (int i = 0; i < 8; i++)
            {
                ean8 += random.Next(0, 9).ToString();
            }

            int sum = 0;
            for (int i = 0; i < ean8.Length; i++)
            {
                int digit = int.Parse(ean8[i].ToString());
                sum += (i % 2 == 0) ? digit * 1 : digit * 3;
            }

            int checkDigit = (10 - (sum % 10)) % 10;
            return ean8 + checkDigit.ToString();
        }
        public string GenerateEan5()
        {
            Random random = new Random();
            string ean5 = "";
            for (int i = 0; i < 4; i++)
            {
                ean5 += random.Next(0, 5).ToString();
            }

            int sum = 0;
            for (int i = 0; i < ean5.Length; i++)
            {
                int digit = int.Parse(ean5[i].ToString());
                sum += (i % 2 == 0) ? digit * 1 : digit * 3;
            }

            int checkDigit = (10 - (sum % 10)) % 10;
            return ean5 + checkDigit.ToString();
        }
    }
}
