using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop2018.Core.ApplicationService;
using PetShop2018.Core.Entities;

namespace PetShop2018.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviousOwnerController : ControllerBase
    {
        private readonly IPreviousOwnerService _previousOwnerService;

        public PreviousOwnerController(IPreviousOwnerService previousOwnerService)
        {
            _previousOwnerService = previousOwnerService;
        }

        // GET: api/PreviousOwner
        [HttpGet]
        public IEnumerable<PreviousOwner> Get()
        {
            return _previousOwnerService.GetPreviousOwners();
        }

        // GET: api/PreviousOwner/5
        [HttpGet("{id}", Name = "Get")]
        public PreviousOwner Get(int id)
        {
            return _previousOwnerService.GetPreviousOwner(id);
        }

        // POST: api/PreviousOwner
        [HttpPost]
        public void Post([FromBody] PreviousOwner preOwner)
        {
            _previousOwnerService.CreatePreviousOwner(preOwner);
        }

        // PUT: api/PreviousOwner/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PreviousOwner preOwner)
        {
            _previousOwnerService.UpdatePreviousOwner(preOwner);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _previousOwnerService.DeletePreviousOwner(id);
        }
    }
}
