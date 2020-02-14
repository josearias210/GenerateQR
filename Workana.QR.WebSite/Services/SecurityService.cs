using System;

namespace Workana.QR.WebSite.Services
{
    public class SecurityService
    {
        public static string Encrypt(string message)
        {
            string messageEncrypt = string.Empty;
            try
            {
                foreach (char letter in message.ToCharArray())
                {
                    if (letter == ' ')
                        messageEncrypt += " ";
                    else
                    {
                        int num = letter;
                        num += 2;
                        messageEncrypt += (char)num;
                    }
                }

            }
            catch (Exception)
            {
                messageEncrypt = "";
            }
            return messageEncrypt;
        }
    }
}
