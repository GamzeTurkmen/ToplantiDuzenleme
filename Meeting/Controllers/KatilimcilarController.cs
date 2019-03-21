using Meeting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Meeting.Controllers
{
    public class KatilimcilarController : ApiController
    {
        //db tanımlama
        ToplantiContext db = new ToplantiContext();
    
        [HttpGet]
        public List<Katilimci> Katilimcilar()
        {
            //Listelemek için
            List<Katilimci> katilimci = db.Katilimcilar.ToList();
            return katilimci;
        }   

    }
}
