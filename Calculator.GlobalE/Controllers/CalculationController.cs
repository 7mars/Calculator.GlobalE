using Calculator.GlobalE.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Calculator.GlobalE.Controllers
{
    public class CalculationController : ApiController
    {
        public IHttpActionResult Post([FromBody] string input)
        {
            var result = ExpressionBuilder.Construct(input).Calculate();
            return Ok(result);
        }
    }
}
