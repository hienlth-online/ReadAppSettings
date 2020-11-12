using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ReadAppSettings.Models;

namespace ReadAppSettings.Controllers
{
    public class DemoController : Controller
    {
        private readonly Payment _payment;
        public DemoController(IOptions<Payment> payment)
        {
            _payment = payment.Value;
        }

        public IActionResult DocConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            var appId = config["Payments:AppId"];
            var secrectKey = config["Payments:SecrectKey"];

            var paymentSection = config.GetSection("Payments");
            var appId2 = paymentSection["AppId"];

            var connectionString1 = config["ConnectionStrings:MSSQL"];
            var connectionString2 = config.GetConnectionString("MSSQL");


            return View();
        }
    }
}