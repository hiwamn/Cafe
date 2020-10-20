using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Domain.Contract;
using Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Core.Contracts;
using Utility.Tools.General;
using Core.Entities.GlobalSettings;
using Core.Entities;
using Enums;
using Core.Entities.Dto;

namespace Infrastructure.EndPoint.Controllers
{
    public class DocumentController : SimpleController
    {
        private IUnitOfWork unit;
        private readonly IHostingEnvironment hosting;
        public string Location { get; set; }

        public DocumentController(IUnitOfWork _unit, IHostingEnvironment hosting)
        {
            unit = _unit;
            this.hosting = hosting;
        }
        [HttpGet]
        public async Task<IActionResult> GetDocument(Guid Id)
        {
            var doc = unit.Document.Get(Id);

            if (doc.DocumentType == DocumentType.Image.ToInt())
                return PhysicalFile(hosting.WebRootPath + "\\Documents\\" + Path.GetFileName(doc.Location), "image/jpeg");
            else if (doc.DocumentType == DocumentType.Video.ToInt())
                return PhysicalFile(hosting.WebRootPath + "\\Documents\\" + Path.GetFileName(doc.Location), "video/mp4");
            else if (doc.DocumentType == DocumentType.Document.ToInt())
                return PhysicalFile(hosting.WebRootPath + "\\Documents\\" + Path.GetFileName(doc.Location), "application/octet-stream");
            return null;
        }
        [HttpGet]
        public async Task<DocumentResultDto> GetDocumentAddress(Guid Id)
        {
            var doc = unit.Document.Get(Id);
            return new DocumentResultDto { Address = doc.Location};
        }


        [HttpPost]
        public string SendDocument([FromForm]DocumentType type)
        {
            var file = Request.Form.Files[0];
            Guid guid = SaveImage(file,type);
            return Agent.ToJson(new { Images = guid.ToString() , Location});
        }
        //[HttpPost]
        //public string SendImages()
        //{
        //    List<ImageDto> Images = new List<ImageDto>();
        //    Request.Form.Files.ToList().ForEach(p =>
        //    {
        //        var guid = SaveImage(p);
        //        Images.Add(new ImageDto { Id = guid,Name = p.Name});
        //    });
        //    return Agent.ToJson( Images );
        //}

        private Guid SaveImage(IFormFile file, DocumentType type)
        {
            string extension = Path.GetExtension(file.FileName);

            Guid guid = Guid.NewGuid();
            string fileName = guid.ToString() + extension;
            var HardLocation = hosting.WebRootPath + "/Documents" + $"/{fileName}";
            var HostLocation = AdminSettings.Root + "/Documents" + $"/{fileName}";

            Location = HostLocation;
            if (file.Length > 0)
            {
                //file = ImageHelper.ChangeImageAsync(file, hosting.WebRootPath + "/watermark.png").Result;
                using (var fileStream = new FileStream(HardLocation, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            Document img = new Document
            {
                Id = guid,
                Location = HostLocation,
                CreatedAt = DateTime.Now.ToUnix(),
                DocumentType = type.ToInt()
            };
            unit.Document.Add(img);
            unit.Complete();
            return guid;
        }
    }
}
