using Search4Peeps.Services;
using System;
using System.Net;
using System.Web.Mvc;

namespace Search4Peeps.Controllers
{
    public class ImageController : Controller
    {
        private IPeepService peepService;

        public ImageController(IPeepService peepService)
        {
            this.peepService = peepService;
        }
        // GET: Image
        public ActionResult Show(int id)
        {
            try
            {
                byte[] imageData = peepService.GetPhoto(id);
                if (imageData != null && imageData.Length > 0)
                {
                    return new FileStreamResult(new System.IO.MemoryStream(imageData), "image/jpeg");
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError,
                    string.Format("{0}{1}",
                    ex.Message,
                    ex.InnerException == null ? string.Empty : string.Format(" - inner exception: {0}", ex.InnerException.Message)));
            }
            return null;
        }
    }
}