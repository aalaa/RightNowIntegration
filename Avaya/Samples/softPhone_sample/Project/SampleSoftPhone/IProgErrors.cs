using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleSoftPhone
{
    interface IProgErrors
    {
        public static int E_SUCCESS = 0;
        public static int E_INVALID_PARAM = 0x02;
        public static int E_LOGIN_FAILURE = 0x10;

        public static Dictionary<int, String> errorLookUp = new Dictionary<int, string>();

        private static String prodErrorMsg = "Error Code: {0}. Message: {1}. Extra Information: {3}";

        public static void initLookUp()
        {
            if (errorLookUp.Count > 0)
                return;

            errorLookUp[E_LOGIN_FAILURE] = "";
        }

        public static void reportProdError(int error, String extraInfo)
        {
            String msg = String.Format(prodErrorMsg, error, errorLookUp[error], extraInfo);
            Console.WriteLine(msg);
        }

        public static void reportDevError(int error, String extraInfo)
        {
        }
    }
}
