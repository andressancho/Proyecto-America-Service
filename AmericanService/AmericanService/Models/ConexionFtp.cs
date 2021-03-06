﻿ using System;
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
            
            //--------------------- Download information from FTP server 000Webhost

            FtpWebRequest request_information = (FtpWebRequest)WebRequest.Create("ftp://files.000webhost.com:21/public_html/data_information.csv");
            //FtpWebRequest request_cv = (FtpWebRequest)WebRequest.Create("ftp://files.000webhost.com:21/public_html/data_cv.csv");

            request_information.Method = WebRequestMethods.Ftp.DownloadFile;
            request_information.Credentials = new NetworkCredential("americaservice", "ameser2018");

            FtpWebResponse response_information = (FtpWebResponse) request_information.GetResponse();

            Stream responseStream_information = response_information.GetResponseStream();
            StreamReader reader_information = new StreamReader(responseStream_information);
            

            List<string> information = new List<string>();

            
            string[] lines = reader_information.ReadToEnd().Split('\n');
            foreach (string line in lines)
            {

                if (!String.IsNullOrWhiteSpace(line))
                {

                    information.Add(line.Replace("SI", "True").Replace("NO", "False"));
                }
            }

            if (information.Count != 0)
            {
                information.RemoveAt(0);
                //--------------------- Upload information to FTP server 000Webhost

                FtpWebRequest request_upload = (FtpWebRequest)WebRequest.Create("ftp://files.000webhost.com:21/public_html/data_information.csv");

                request_upload.Method = WebRequestMethods.Ftp.UploadFile;
                request_upload.Credentials = new NetworkCredential("americaservice", "ameser2018");

                Stream ftp_stream = request_upload.GetRequestStream();
                byte[] buffer = new byte[] { };
                ftp_stream.Write(buffer, 0, 0);
                ftp_stream.Close();
            }

            return information;





        }
    }
}