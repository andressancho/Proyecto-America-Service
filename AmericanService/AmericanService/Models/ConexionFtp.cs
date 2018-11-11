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

        public List<string> updateDataBase()
        {
            //String result_information = String.Empty;
            //String result_cv = String.Empty;
            FtpWebRequest request_information = (FtpWebRequest)WebRequest.Create("ftp://files.000webhost.com:21/public_html/data_information.csv");
            //FtpWebRequest request_cv = (FtpWebRequest)WebRequest.Create("ftp://files.000webhost.com:21/public_html/data_cv.csv");

            request_information.Method = WebRequestMethods.Ftp.DownloadFile;
            request_information.Credentials = new NetworkCredential("americaservice", "ameser2018");

            FtpWebResponse response_information = (FtpWebResponse) request_information.GetResponse();

            Stream responseStream_information = response_information.GetResponseStream();
            StreamReader reader_information = new StreamReader(responseStream_information);
            

            List<string> information = new List<string>();

            //while (!reader_information.EndOfStream)
            //foreach(string line in reader_information)
            do
            {
                string line = reader_information.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (!String.IsNullOrWhiteSpace(line))
                {

                    information.Add(line.Replace("SI", "1").Replace("NO", "0"));
                }
            } while (!reader_information.EndOfStream);

            //result_information = reader_information.ReadToEnd();
            information.RemoveAt(0);
            return information;





        }
    }
}