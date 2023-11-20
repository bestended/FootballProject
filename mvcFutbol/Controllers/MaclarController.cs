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
    public class MaclarController : Controller
    {
        HttpResponseMessage response;
        // GET: Maclar
        public ActionResult Liste()
        {
            IEnumerable<Maclarim> responseList;
            response = GlobalVariables.webapiclient.GetAsync("Maclars").Result;
            responseList=response.Content.ReadAsAsync<IEnumerable<Maclarim>>().Result;

            return View(responseList);
        }

        [HttpGet]
        public ActionResult MaclarEY(int id=0)
        {

            if (id==0)
            {
                return View();
            }
            else
            {
                response = GlobalVariables.webapiclient.GetAsync("Maclars/" + id.ToString()).Result;

                return View(response.Content.ReadAsAsync<Maclarim>().Result);

            }




        }


        [HttpPost]
        public ActionResult MaclarEY(Maclarim maclar)
        {
            if (maclar.MacId == 0)
            {
                response=GlobalVariables.webapiclient.PostAsJsonAsync("Maclars/", maclar).Result;
                return RedirectToAction("Liste");

            }
            else
            {
                response = GlobalVariables.webapiclient.PutAsJsonAsync("Maclars/" + maclar.MacId, maclar).Result;


            }
            return RedirectToAction("Liste");

        }

        public ActionResult Sil(int id)
        {
            response=GlobalVariables.webapiclient.DeleteAsync("Maclars/"+id.ToString()).Result;

            return RedirectToAction("Liste");        }



    }
}