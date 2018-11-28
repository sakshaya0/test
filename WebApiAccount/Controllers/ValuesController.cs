using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiAccount.Business_Logic;

namespace WebApiAccount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        AccountTransaction ac = new AccountTransaction();
        // GET api/values
        [HttpGet]
        public ActionResult<List<object>> Get()
        {
            return ac.GetAllAccountDetails();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<List<object>> Get(int id)
        {
            if (id == 2)
                return ac.GetActiveAccountDetails();
            else if (id == 3)
                return ac.GetWithMinimumBalnce();
            else if (id == 4)
                return ac.GetBalanceLessThan500();
            else
                return ac.GetActiveAccountDetails();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
