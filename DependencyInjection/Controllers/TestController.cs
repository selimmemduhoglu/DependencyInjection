using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using static DependencyInjection.NumGenerator;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        public INumGenerator NumGenerator { get; }
        public TestController(INumGenerator numGenerator)
        {
            NumGenerator = numGenerator;
        }


        [HttpGet]
        public String Get()
        {
            return NumGenerator.RandomValue.ToString();


        }
    }
}
