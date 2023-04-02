using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealEstateClassLibary;

namespace RealEstateRestful.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class HouseController : Controller//Base
    {
        [HttpPost]
        public Boolean AddHouse([FromBody] House house)
        {
            return true;
        }
    }
}
