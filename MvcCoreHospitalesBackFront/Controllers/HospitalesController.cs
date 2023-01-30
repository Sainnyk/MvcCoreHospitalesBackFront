using Microsoft.AspNetCore.Mvc;
using MvcCoreHospitalesBackFront.Models;
using MvcCoreHospitalesBackFront.Services;

namespace MvcCoreHospitalesBackFront.Controllers
{
    public class HospitalesController : Controller
    {
        private ServiceApiHospital service;
        public HospitalesController(ServiceApiHospital service)
        {
            this.service = service;
        }

        //Aquí tendremos una vista para el back
        public async Task<IActionResult> HospitalesBack()
        {
            List<Hospital> hospitales = await this.service.GetHospitalesAsync();

            return View(hospitales);
        }
        //Aquí dibujaremos un menú para ir al back o al front
        public IActionResult Index()
        {
            return View();
        }

        //Aquí tendremos una vista para el front
        public IActionResult HospitalesFront()
        {
            return View();
        }


    }
}
