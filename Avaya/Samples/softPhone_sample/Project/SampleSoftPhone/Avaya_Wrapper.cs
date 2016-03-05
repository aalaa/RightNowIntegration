using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Nortel.CCT;

namespace SampleSoftPhone
{
    class Avaya_Wrapper
    {
        private Toolkit cctToolKit;
        private int lastError;

        public Avaya_Wrapper()
        {
            cctToolKit = new Toolkit();

            lastError = IProgErrors.E_SUCCESS;
        }

        public int login(String server, String user, String domain, String pwd)
        {
            // Validate parameters
            if (server == null || server == "" ||
                user == null || user == "" ||
                domain == null || domain == "" ||
                pwd == null || pwd == "")
            {
                IProgErrors.reportProdError(IProgErrors.E_INVALID_PARAM, String.Format(
                    "Parameter values provided: Server: {0}, User: {1}, Domain: {2}, Password: {3}",
                    server, user, domain, (pwd == null || pwd == "")? "Invalid Password" : "Valid Password"));
            }

            try
            {
                cctToolKit.Server = server;
                cctToolKit.Port = 29373;
                cctToolKit.Credentials = new CCTCredentials(user, domain, pwd);
                cctToolKit.Connect();

                lastError = IProgErrors.E_SUCCESS;
            }
            catch
            {
                IProgErrors.reportProdError(IProgErrors.E_LOGIN_FAILURE, "");

                lastError = IProgErrors.E_LOGIN_FAILURE;
            }

            return lastError;
        }
    }
}
