 using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanService.Models
{
    public class ConexionFtp
    {
        public ConexionFtp(){}

        public void updateDataBase()
        {
            String result = String.Empty;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://files.000webhost.com:21/public_html/data.csv");

            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential("americaservice", "ameser2018");

            FtpWebResponse response = (FtpWebResponse) request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            result = reader.ReadToEnd();
            System.Diagnostics.Debug.WriteLine(result);



        }
    }
}