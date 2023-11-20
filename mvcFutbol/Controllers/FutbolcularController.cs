using mvcFutbol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
namespace mvcFutbol.Controllers
{
    public class FutbolcularController : Controller
    {
        HttpResponseMessage response;
        // GET: Futbolcular
        public ActionResult Liste()
        {

            IEnumerable<Futbolcum> responseList;
            response = GlobalVariables.webapiclient.GetAsync("Futbolculars").Result;
            responseList=response.Content.ReadAsAsync<IEnumerable<Futbolcum>>().Result;
            return View(responseList);

        }

        [HttpGet]
        public ActionResult FutbolcuEY(int id=0)
        {

            if (id == 0)
            {
                return View();
            }
            else
            {

                response = GlobalVariables.webapiclient.GetAsync("Futbolculars/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Futbolcum>().Result);
            }



        }



        [HttpPost]
        public ActionResult FutbolcuEY(Futbolcum futbolcu)
        {

            if (futbolcu.FormaNo == 0)
            {

                //post
                response = GlobalVariables.webapiclient.PostAsJsonAsync("Futbolculars/", futbolcu).Result;


            }
            else
            {
                //put
                response = GlobalVariables.webapiclient.PutAsJsonAsync("Futbolculars/"+ futbolcu.FormaNo, futbolcu).Result;

            }
            return RedirectToAction("Liste");

        }


        public ActionResult Sil(int id)
        {

            response = GlobalVariables.webapiclient.DeleteAsync("Futbolculars/"+id.ToString()).Result;
            return RedirectToAction("Liste");
        }



    }
}