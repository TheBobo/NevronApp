using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NevronApp.Controllers
{
    public class HomeController : Controller
    {
        Random rnd = new Random();
        public ActionResult Index()

        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNumber()
        {
            List<int> numbers = GetSestion();

            int newNumber = rnd.Next(1001);
            numbers.Add(newNumber);

            SetSestion(numbers);
            return PartialView("_numbers"); ;
        }

        [HttpPost]
        public ActionResult SumNumber()
        {
            List<int> numbers = GetSestion();
            int? result =  GetSum(numbers);
            return Json(new { result = result });
        }

        [HttpPost]
        public ActionResult ClearNumbers()
        {
            ClearSestion();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        private int? GetSum(List<int> numbers )
        {
            int result = 0;
            if (numbers == null || numbers.Count ==0)
            {
                return null;
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                result += numbers[i];
            }
            return result;
        }

        private List<int> GetSestion()
        {
            List<int> numbers = (List<int>)Session["numbers"];
            if (numbers == null)
            {
                return new List<int>();
            }
            return numbers;
        }

        private void SetSestion(List<int> numbers)
        {
            Session["numbers"] = numbers;
        }

        private void ClearSestion()
        {
            Session.Clear() ;
        }
    }
}