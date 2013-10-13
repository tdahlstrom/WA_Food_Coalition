using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers {
    public class FoodBankController : ApiController {
        private FoodCoalitionAppContext _db = new FoodCoalitionAppContext();
    }
}