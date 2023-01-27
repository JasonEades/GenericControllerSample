using GenericControllerSample.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace GenericControllerSample.Controllers
{
    [GenericControllerRouteConvention]
    public class ODataController<T> : ODataController where T : class, new()
    {


        [HttpGet]
        [EnableQuery]
        public IQueryable<T> Get()
        {
            return (new List<T>()).AsQueryable();
        }

        [HttpGet]
        [EnableQuery]
        public SingleResult<T> Get([FromODataUri] Guid key)
        {

            return SingleResult.Create(Get());

        }

        [HttpPost]
        public ActionResult Post([FromBody] T entity)
        {
            return NoContent();
        }

        [HttpPatch]
        public ActionResult Patch([FromODataUri] Guid key, [FromBody] Delta<T> delta)
        {
            var test = delta;
            return NoContent();
        }

#if RELEASE
        [Authorize]
#endif
        [HttpDelete]
        public ActionResult Delete([FromODataUri] Guid key)
        {
            return NoContent();

        }
    }
}

