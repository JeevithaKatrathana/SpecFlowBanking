using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Shapes;
using  System.Collections;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SpecFlowBanking.Utilities
{
    public class DBFunctions
    {
        public void ReadCSVDataIntoDataTable(string csvFileName)
        {
            string filePath = csvFileName;
            string[]? headers;
            string? Firstline, line;
           
            ArrayList My_arraylist = new ArrayList();
            using (StreamReader sr = new StreamReader(filePath))
            {
               
                Firstline = sr.ReadLine();
                headers = Firstline!.Split(',');

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string[] rows = line!.Split(',');
                    Dictionary<string, string> dict = new ();
                    for (int i = 0; i < rows!.Length; i++)
                    {
                        dict.Add(headers[i], rows[i]);
                    }
                    My_arraylist.Add(dict);
                }
            }
            foreach (var elements in My_arraylist)
            {
               
               Dictionary<string,string>? childdict = elements as  Dictionary<string,string>;
                foreach (KeyValuePair<string, string> item in childdict!)
                {
                    Console.WriteLine(item.Key + " :  "+ item.Value);
                   
                }
                Console.WriteLine(" *************************************************** ");
            }
           
        }
       
    }
}
