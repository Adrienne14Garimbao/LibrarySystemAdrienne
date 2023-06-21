using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LibrarySystemAdrienne.Controllers;

namespace LibrarySystemAdrienne.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LibrarySystemAdrienneControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
