using Meeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Meeting.Controllers
{
    public class ToplantilarController : ApiController
    {
        ToplantiContext db = new ToplantiContext();

        [HttpGet]
        public List<Toplanti> Toplantilar()
        {
            List<Toplanti> toplanti = db.Toplantilar.ToList();
            return toplanti;
        }
    }
}
