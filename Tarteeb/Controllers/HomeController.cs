//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

using Microsoft.AspNetCore.Mvc;
using Tarteeb.Brokers.Storages;
using Tarteeb.Models.Tasks;
using Task = Tarteeb.Models.Tasks.Ticket;

namespace Tarteeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IStorageBroker storageBroker;

        public HomeController(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;
        
        [HttpGet]
        public ActionResult<string> GetMessage() => "Tarteeb is Working";

    }
}
