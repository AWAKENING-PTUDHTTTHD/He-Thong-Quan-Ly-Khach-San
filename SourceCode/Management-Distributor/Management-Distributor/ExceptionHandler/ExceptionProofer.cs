using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Management_Distributor.ExceptionHandler
{
    public static class ExceptionProofer
    {
        public static void LogToFile(string strPath, Exception ex)
        {
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now.ToString());
                sw.WriteLine("Error Message: " + ex.Message);
                //sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("Stack Trace: " + ex.InnerException);
                sw.WriteLine("===========End============= " + DateTime.Now.ToString());

            }
        }
 
                
    }
}