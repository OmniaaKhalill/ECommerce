using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.APIs.DTO;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {


        [HttpPost]
        public ActionResult<UploadFileResult> uploade(IFormFile File)
        {
            //save file with new name in images
            var extention = Path.GetExtension(File.FileName);
            var newFileName = $"{Guid.NewGuid()}{extention}";
            var FullFilePath = Environment.CurrentDirectory + "/Images/" + newFileName;
            var stream = new FileStream(FullFilePath, FileMode.Create);
            File.CopyTo(stream);
            //genrate the url
            var url = $"{Request.Scheme}://{Request.Host}/Images/{newFileName}";
            return new UploadFileResult(true, "success", url);
        }
    }
}
