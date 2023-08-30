using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DependencyInjection.NumGenerator;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly INumGenerator numGenerator;
        private readonly INumGenerator2 numGenerator2;

        public WeatherForecastController(INumGenerator numGenerator, INumGenerator2 numGenerator2)
        {
            this.numGenerator = numGenerator;
            this.numGenerator2 = numGenerator2;
        }

        [HttpGet] 
        public String Get()
        {

            //int number= numGenerator.GetRandomNumber();
            //int number = numGenerator.RandomValue;
            int random1 = numGenerator.RandomValue;
            int random2 = numGenerator2.GetNumGeneratorRandomNumber();

            return $"NumGenerator.RandomValue : {random1}  ---  NumGenerator2.NumGenerator.RandomValue: {random2}";
            //Şu an burada ki return e göre scope kullanınca 2 sinde de aynı sayıları görüyorum çünkü request başına bir nesne üretiliyor.
            //fakat tranciesn kullanılsaydı request başına birdn fazla nesne üretileceği  için aynı nesneye 2 kere ulaşıldığında farklı yollarla bir kez daha instance oluşturulacaktı.
        }
    }
}
