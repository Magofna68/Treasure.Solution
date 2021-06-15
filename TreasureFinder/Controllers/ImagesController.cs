using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using TreasureFinder.Models;


namespace TreasureFinder.Controllers
{

  [ApiController]
  [Route("api/items/{id}/[controller]")]
  public class ImagesController : ControllerBase
  {
    private readonly TreasureFinderContext _db;

    public ImagesController(TreasureFinderContext db)
    {
      _db = db;
    }
    [HttpPost]
    public async Task<IActionResult> Post(int id, List<IFormFile> images)
    {
      long size = images.Sum(i => i.Length);

      foreach (var formFile in images)
      {
        if (formFile.Length > 0)
        {
          var filePath = Path.GetTempFileName();
          using var stream = System.IO.File.Create(filePath);
          await formFile.CopyToAsync(stream);
        }
      }
      foreach (var i in images)
      {
        using var ms = new MemoryStream();
        i.CopyTo(ms);
        var fileBytes = ms.ToArray();
        var newImage = new Image();
        string s = Convert.ToBase64String(fileBytes);
        newImage.ImageString = s;
        newImage.ItemId = id;
        _db.Images.Add(newImage);
        await _db.SaveChangesAsync();
      }
      return Ok(new { count = images.Count, size });
    }
  }
}


// // POST: api/FileUploads
// [ResponseType(typeof(FileUpload))]
// public IHttpActionResult PostFileUpload()
// {
//     if (HttpContext.Current.Request.Files.AllKeys.Any())
//     {
//         // Get the uploaded image from the Files collection  
//         var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
//         if (httpPostedFile != null)
//         {
//             FileUpload imgupload = new FileUpload();
//             int length = httpPostedFile.ContentLength;
//             imgupload.imagedata = new byte[length]; //get imagedata  
//             httpPostedFile.InputStream.Read(imgupload.imagedata, 0, length);
//             imgupload.imagename = Path.GetFileName(httpPostedFile.FileName);
//             db.FileUploads.Add(imgupload);
//             db.SaveChanges();
//             // Make sure you provide Write permissions to destination folder
//             string sPath = @"C:\Users\xxxx\Documents\UploadedFiles";
//             var fileSavePath = Path.Combine(sPath, httpPostedFile.FileName);
//             // Save the uploaded file to "UploadedFiles" folder  
//             httpPostedFile.SaveAs(fileSavePath);
//             return Ok("Image Uploaded");
//         }
//     }
//     return Ok("Image is not Uploaded"); 
// }