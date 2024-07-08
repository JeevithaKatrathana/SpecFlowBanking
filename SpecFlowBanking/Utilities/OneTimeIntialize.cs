using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBanking.Utilities
{
    public sealed class OneTimeIntialize
    {
        ExtentReports? extent;
        private static readonly object lockobj = new  ();
        private OneTimeIntialize() //parameterless constructor
        {
           
        }
       
    private static OneTimeIntialize? instance = null;
        public static OneTimeIntialize GetInstance() 
        {
            //get
            {
                lock (lockobj)
                    {
                        instance ??= new ();
                        return instance;
                    }
            }
        }

        public ExtentReports GetExtentReport()
        {
            string? path = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../")!.FullName + "\\Result\\Report\\htmlReport.html";
            var htmlReporter = new ExtentSparkReporter(path);

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            return extent;
        }
        
    }
}
