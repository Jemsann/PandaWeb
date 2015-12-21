using PandaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace PandaWeb.Controllers
{
    public class DocumentController : Controller
    {
        IRepository repository = new MyDBContextRepository();
        MyDBContext context = new MyDBContext();

        public ActionResult UploadDocuments(int id)
        {     
            return PartialView(repository.GetDocuments(id));
        }

        public ActionResult UploadProtocols()
        {
            return PartialView();
        }

        public ActionResult Save(FormCollection formCollection, int id = 0)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["Uploaded File"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    //string fileName = file.FileName;
                    //string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                    //string fileNames = Path.GetFileName(Request.Files["file"].FileName);
                    Documents doc = new Documents();
                    doc.Document = fileBytes;
                    doc.DocType = file.ContentType;
                    doc.FileName = file.FileName;
                    doc.CourseId = id;
                    context.Documents.Add(doc);
                    context.SaveChanges();

                    //http://scottlilly.com/how-to-upload-a-file-in-an-asp-net-mvc-4-page/

                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SaveProtocol(FormCollection formCollection)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["Uploaded File"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    //string fileName = file.FileName;
                    //string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                    //string fileNames = Path.GetFileName(Request.Files["file"].FileName);
                    Protocol protocols = new Protocol();

                    protocols.File = fileBytes;
                    protocols.Type = file.ContentType;
                    protocols.Name = file.FileName;
                                       
                    context.Protocols.Add(protocols);
                    context.SaveChanges();

                    //http://scottlilly.com/how-to-upload-a-file-in-an-asp-net-mvc-4-page/

                }
            }
            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult ShowDocuments()
        {
            //ska anpassas för att endast visa dokument för den som är inloggad
            var doc = (from e in context.Documents
                       select e);
            return PartialView(doc);
        }

        public ActionResult DownloadFile(int id)
        {
            var doc = (from e in context.Documents where e.Id == id select e.Document);
            //var docu = (context.Documents.Where(p => p.Id == id).Select(p => p));
            var docu = context.Documents.Single(p => p.Id == id);
            //var docu2 = context.Documents.Where(p => p.Id == id).Select(p => p.DocType).ToString();
            return File(docu.Document, docu.DocType);
        }
    }
}