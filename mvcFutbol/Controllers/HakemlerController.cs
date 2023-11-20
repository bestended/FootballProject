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
    public class HakemlerController : Controller
    {
        HttpResponseMessage response;

        // GET: Hakemler
        public ActionResult Liste()
        {
            IEnumerable<Hakemim> responseList;
            response = GlobalVariables.webapiclient.GetAsync("Hakemlers").Result;
            responseList=response.Content.ReadAsAsync<IEnumerable<Hakemim>>().Result;

            return View(responseList);
        }

        [HttpGet]
        public ActionResult HakemEY(int id=0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                response = GlobalVariables.webapiclient.GetAsync("Hakemlers/"+ id.ToString()).Result;

                return View(response.Content.ReadAsAsync<Hakemim>().Result);
            }



        }

        [HttpPost]
        public ActionResult HakemEY(Hakemim hakem)
        {
            if (hakem.HakemId==0)
            {
                response = GlobalVariables.webapiclient.PostAsJsonAsync("Hakemlers/" , hakem).Result;

            }
            else
            {
                response = GlobalVariables.webapiclient.PutAsJsonAsync("Hakemlers/" + hakem.HakemId, hakem).Result;
            }


            return RedirectToAction("Liste");



        }


        public ActionResult Sil(int id)
        {
            response = GlobalVariables.webapiclient.DeleteAsync("Hakemlers/"+id.ToString()).Result;

            return RedirectToAction("Liste");

        }
    }
}