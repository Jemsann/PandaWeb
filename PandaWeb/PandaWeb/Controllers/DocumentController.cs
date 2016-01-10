using PandaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;

namespace PandaWeb.Controllers
{
    public class DocumentController : Controller
    {
        IRepository repository = new MyDBContextRepository();
        MyDBContext context = new MyDBContext();

        //upload documents. A course id must be provided.
        public ActionResult UploadDocuments(int id)
        {
			if (id == 0)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			return PartialView(repository.GetDocuments(id));
        }

        //upload management team protocols.
        public ActionResult UploadProtocols()
        {

            return PartialView();
        }

        // convert upload to byte array and save it in the database. The returns to the standard view.
        public ActionResult Save(FormCollection formCollection, int id = 0)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["Uploaded File"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    byte[] fileBytes = new byte[file.ContentLength];
                    file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    Documents doc = new Documents();
                    doc.Document = fileBytes;
                    doc.DocType = file.ContentType;
                    doc.FileName = file.FileName;
                    doc.Title = Path.GetFileName(file.FileName);
                    doc.CourseId = id;

                    context.Documents.Add(doc);
                    context.SaveChanges();

                    //http://scottlilly.com/how-to-upload-a-file-in-an-asp-net-mvc-4-page/

                }
            }
            return RedirectToAction("LG", "Education");
        }

        // convert upload to byte array and save it in the database. The returns to the standard view.
        public ActionResult SaveProtocol(FormCollection formCollection)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["Uploaded File"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    byte[] fileBytes = new byte[file.ContentLength];
                    file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                    Protocol protocols = new Protocol();

                    protocols.File = fileBytes;
                    protocols.Type = file.ContentType;
                    protocols.Name = Path.GetFileName(file.FileName);
                    protocols.FileName = file.FileName;
                    protocols.Added = DateTime.Now;
                    context.Protocols.Add(protocols);
                    context.SaveChanges();

                    //http://scottlilly.com/how-to-upload-a-file-in-an-asp-net-mvc-4-page/

                }
            }
            return RedirectToAction("LG", "Education");
        }

        //Download management team protocol.
		public ActionResult DownloadProtocol(int id)
		{
			byte[] docu = context.Protocols.Where(d => d.Id == id).Select(d => d.File).First();
			string content = context.Protocols.Where(d => d.Id == id).Select(d => d.Type).First();
			string title = context.Protocols.Where(d => d.Id == id).Select(d => d.Name).First();
			return File(docu, content, title);
		}

        // Shows documents with the option to dowload the from the database
		public PartialViewResult ShowDocuments(int id)
        {
            return PartialView(repository.GetSpecificDocuments(id));
        }

        //converts byte array back to the original file.
        public ActionResult DownloadFile(int id)
        {
            byte[] docu = context.Documents.Where(d => d.Id == id).Select(d =>d.Document).First();         
            string content = context.Documents.Where(d => d.Id == id).Select(d => d.DocType).First();
            string title = context.Documents.Where(d => d.Id == id).Select(d => d.Title).First();           
            return File(docu, content, title);
        }

      
    }
}