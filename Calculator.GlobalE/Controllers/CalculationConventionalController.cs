using Calculator.GlobalE.LogicConv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Calculator.GlobalE.Controllers
{
    public class CalculationConventionalController : ApiController
    {
        public IHttpActionResult Post([FromBody] string input)
        {
            return Ok(new Calculation().Calculate(input));
        }
    }
}