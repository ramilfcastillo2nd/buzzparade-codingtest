using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buzzparade_codingtest.Controllers
{
    public class ProblemTwoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string s, string p)
        {
            ViewBag.Result = ProblemTwo(s, p);
            return View();
        }

        private string ProblemTwo(string s, string p)
        {
            List<int> result = new List<int>();
            if (s.Length < p.Length)
            {
                return string.Empty;
            }
            int[] pArr = new int[26];
            int[] sArr = new int[26];
            for (int i = 0; i < p.Length; i++)
            {
                pArr[p[i] - 'a']++;
                sArr[s[i] - 'a']++;
            }
            if (Enumerable.SequenceEqual(pArr, sArr))
            {
                result.Add(0);
            }
            for (int i = p.Length; i < s.Length; i++)
            {
                sArr[s[i] - 'a']++;
                sArr[s[i - p.Length] - 'a']--;
                if (Enumerable.SequenceEqual(pArr, sArr))
                {
                    result.Add(i - p.Length + 1);
                }
            }

            string resultStr = string.Join(",", result);

            return resultStr;
        }
    }
}