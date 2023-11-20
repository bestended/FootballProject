using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using mvcFutbol.Models;

namespace mvcFutbol.Controllers
{
    public class TakimlarController : Controller
    {
        HttpResponseMessage response;
        // GET: Takimlar
        public ActionResult Liste()
        {

            IEnumerable<Takimlarim> responseList;
            response=GlobalVariables.webapiclient.GetAsync("Takimlars").Result;
            responseList = response.Content.ReadAsAsync<IEnumerable<Takimlarim>>().Result;

            return View(responseList);
        }

        public ActionResult TakimlarEY(int id=0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                response=GlobalVariables.webapiclient.GetAsync("Takimlars/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Takimlarim>().Result);

            }


        }


        [HttpPost]
        public ActionResult TakimlarEY(Takimlarim takim)
        {
            if (takim.TakimId == 0)
            {
                response=GlobalVariables.webapiclient.PostAsJsonAsync("Takimlars", takim).Result;

            }
            else
            {
                response = GlobalVariables.webapiclient.PutAsJsonAsync("Takimlars/"+takim.TakimId,takim).Result
                                    ;
            }

           return RedirectToAction("Liste");
        }

        public ActionResult Sil(int id)
        {
            response=GlobalVariables.webapiclient.DeleteAsync("Takimlars/"+id.ToString()).Result;
            return RedirectToAction("Liste");

        }


    }

    

}