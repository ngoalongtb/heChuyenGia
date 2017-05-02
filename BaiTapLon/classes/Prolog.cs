using BaiTapLon.classes;
using NUnit.Framework;
using SbsSW.SwiPlCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaiTapLon
{
    public class Prolog
    {
        private static Prolog instance;

        public static Prolog Instance
        {
            get { if (instance == null) instance = new Prolog(); return Prolog.instance; }
            private set { Prolog.instance = value; }
        }
        private Prolog() {
            Environment.SetEnvironmentVariable("SWI_HOME_DIR", @"C:\Program Files (x86)\swipl");
            String[] empty_param = { "" };
            PlEngine.Initialize(empty_param);
        }

        //Load prolog file from hard disk
        public void Load_file(string s)
        {
            s = s.Replace("\\", "//");
            s = "consult('" + s + "')";
            string query = s.Replace("\\", "//");
            try
            {
                PlQuery q = new PlQuery(query);
                Assert.IsTrue(q.NextSolution());
            }
            catch (SbsSW.SwiPlCs.Exceptions.PlException e)
            {

            }
        }

        // Prosessing a query
        public string GetQuestion(string s)
        {
            s.Trim();
            string result = "";
            try
            {
                PlQuery q = new PlQuery(s);
                int i = 0;
                foreach (PlQueryVariables v in q.SolutionVariables)
                {
                    i++;
                    if (i >= 10) break;
                    result += v["X"].ToString() ;

                }
                return result;
            }
            catch (SbsSW.SwiPlCs.Exceptions.PlException ex)
            {
                return "Error query: " + ex.Message;
            }
        }

        public List<Option> GetOptions(string s)
        {
            List<Option> listResult = new List<Option>();
            try
            {
                PlQuery q = new PlQuery(s);
                int i = 0;
                foreach (PlQueryVariables v in q.SolutionVariables)
                {
                    i++;
                    if (i >= 10) break;
                    Option item = new Option();
                    item.Index = v["Index"].ToString();
                    item.Content = v["Content"].ToString();
                    listResult.Add(item);
                }
                return listResult;   
            }
            catch (SbsSW.SwiPlCs.Exceptions.PlException ex)
            {
                return null; 
            }
        }

        public List<string> GetAnswers(string s)
        {
            List<string> listResult = new List<string>();
            try
            {
                PlQuery q = new PlQuery(s);
                int i = 0;
                foreach (PlQueryVariables v in q.SolutionVariables)
                {
                    i++;
                    if (i >= 10) break;

                    string item = v["X"].ToString();
                    listResult.Add(item);
                }
                return listResult;
            }
            catch (SbsSW.SwiPlCs.Exceptions.PlException ex)
            {
                return null;
            }
        }

    }
}
