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
            if (OperatorsBuilder.RepositoryCache.Get(input) != null)
            {
                return Ok(OperatorsBuilder.RepositoryCache.Get(input));
            }

            string result;
            try
            {
                result = ExpressionBuilder.Construct(input).Calculate().ToString();
            }
            catch(Exception e)
            {
                result = e.Message;
            }

            OperatorsBuilder.RepositoryCache.Insert(input, result, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10));
            return Ok(result);
        }
    }
}
