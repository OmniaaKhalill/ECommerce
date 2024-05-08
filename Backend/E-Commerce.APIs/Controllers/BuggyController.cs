using E_Commerce.Repository.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly ProjectContext context;

        public BuggyController(ProjectContext context)
        {
            this.context = context;
        }

        //[HttpGet("notfound")]
        //public ActionResult GetNotFound()
        //{
           
        //}

        //[HttpGet("servererror")]
        //public ActionResult GetServerError()
        //{
           
        //}

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id) 
        {
            return Ok();
        }
    
}
}


  
       
