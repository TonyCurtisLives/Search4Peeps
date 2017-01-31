using System;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using Search4Peeps.Services;

namespace Search4Peeps.Controllers
{
    public class HomeController : Controller
    {
        private IPeepService peepService;

        public HomeController(IPeepService peepService)
        {
            this.peepService = peepService;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowPeeps()
        {
            string delay = Request.Form["chkDelay"];
            if (delay != "false")
            {
                System.Threading.Thread.Sleep(5000);
            }
            JsonResult jsonPeeps;

            try
            {
                string name = Request.Form["txtName"];

                var peeps = peepService.GetPeeps(name).OrderBy(p => p.FirstName).Select(p => new
                {
                    PeepID = p.PeepID
                    , Name = string.Format("{0} {1} {2}"
                        , p.FirstName
                        , p.MiddleName
                        , p.LastName)
                    , Address = string.Format("{0}{1}{2}{1}{3}, {4}, {5}{1}{6}"
                        , p.Address.Line1
                        , "<br/>"
                        , p.Address.Line2
                        , p.Address.City
                        , p.Address.StateOrProvince
                        , p.Address.PostalCode
                        , p.Address.Country)
                    , Photo = p.Photo.PhotoID.ToString()
                    , Age = p.Age
                    , Interests = p.Interests
                    , FavoriteColor = p.FavoriteColor
                    , HasShrubbery = p.HasShrubbery
                    , SwallowIQ = p.SwallowIQ
                    , Nationality = p.Nationality
                }).ToList();

                jsonPeeps = Json(peeps, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError,
                    string.Format("{0}{1}",
                    ex.Message,
                    ex.InnerException == null ? string.Empty : string.Format(" - inner exception: {0}", ex.InnerException.Message)));
            }

            return jsonPeeps;
        }
    }
}