﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContatoWeb.Controllers
{
    public class ContatoController : ApiController
    {
        public string Get()
        {
            return "Olá Mundo, integração contínua tá ok ;)";
        }
    }
}
