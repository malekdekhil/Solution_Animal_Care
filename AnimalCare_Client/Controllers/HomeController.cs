using AnimalCare_Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimalCare_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
 
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
          }

        public IActionResult Index()
        {

            //var ListUsersModel = new List<UserModel>();
            // using (var httpClient = new HttpClient())
            //{
            //    using (var response = await httpClient.GetAsync(URLBASE + "User"))
            //    {
            //        var responseAPI = await response.Content.ReadAsStringAsync();

            //        ListUsersModel = JsonConvert.DeserializeObject<List<UserModel>>(responseAPI);
            //    }
            //}
              return View();
        }
        //[HttpGet]
        //[Route("Home/Specialiste/{IdUser}")]
        // public IActionResult Specialiste([FromRoute] int IdUser)
        //{
        //     if (IdUser <= 0 )
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(IdUser);
        //}
        //[HttpGet]
        //[Route("Home/Reservation/{IdEvent}")]
        //public IActionResult Reservation([FromRoute] int IdEvent)
        //{
        //    if (IdEvent <= 0)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View(IdEvent);
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddEvent(EventModel eventModel)
        //{

        //    using (var client = new HttpClient())
        //    {
        //        var SendEvent = new EventModel() { Status = eventModel.Status, UserId_FK = eventModel.UserId_FK,DateEvent = eventModel.DateEvent,IdEvent=eventModel.IdEvent };
        //        string stringData = JsonConvert.SerializeObject(SendEvent);
        //        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/Json");
        //        var response = await client.PostAsync(URLBASE + "Event", contentData);
        //        var result = response.IsSuccessStatusCode;

        //        return NoContent();

        //    }
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
     
        }
        private string URLBASE
        {
            get { return configuration.GetSection("BaseURL").GetSection("URL").Value; }
        }
    }
}
