using System;
using System.Net;
using System.Net.Mail;

namespace CourierManagementAPI.Models.Shared
{
    public class Helper
    {
        public static string ParseError(string ErrorMsg)
        {
            string retorno = "";


            try
            {
                retorno = ErrorMsg;

                if (ErrorMsg.ToUpper().Contains("RAISEERROR"))
                {
                    int pos = 0;
                    int posFinal = 0;

                    pos = ErrorMsg.ToUpper().IndexOf("RAISEERROR", StringComparison.Ordinal);

                    pos += 9;
                    posFinal = ErrorMsg.ToUpper().IndexOf("/>");
                    retorno = ErrorMsg.Substring(pos + 2, posFinal - pos - 2);

                }

            }
            catch (Exception)
            {

                return ErrorMsg;
            }

            return retorno;

        }
    }
}
