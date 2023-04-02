using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;
using RealEstateClassLibary;

namespace RealEstateRestful.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class HomeController : Controller//Base
    {
        [HttpPost]
        public Boolean AddHouse([FromBody]House house)
        {

            return true;
        }
        /*[HttpGet]           //default route: http://localhost:51214/services/carservice/car
        [HttpGet("GetCar")] //route: services/carservice/car/getcar
        public string Get()
        {
            return "Web API - Http Get executed";
        }

        //order doesn't matter and not case sensitive
        [HttpGet("GetCarByMake")]   //route: services/carservice/car/getcarbymake?make=theMake     	
        public string GetCarByMake(String make, String salesPersonId)
        {
            return "Web API - Http GetCarByMake executed! Make = " + make;
        }

        //order matter and case sensitive
        [HttpGet("GetCarByMake/{make}/{salesPersonId}")]    //route: services/carservice/car/getcarbymake/theMake/theSalesId
        public string GetCarByMakeAndSalesId(String make, String salesPersonId)
        {
            return "GetCarByMakeAndSalesId executed";
        }

        [Produces("application/json")]
        [HttpPost]              //default route: services/carservice/car
        [HttpPost("StoreCar/")] //route: services/carservice/car/storecar/
        public String Post()
        {
            return "post executed";
        }

        [HttpPost("SaveCar/")]
        public String SaveCar([FromBody] Car theCar) //serializing
        {
            return "SaveCar is executed";
        }*/
    }
}
