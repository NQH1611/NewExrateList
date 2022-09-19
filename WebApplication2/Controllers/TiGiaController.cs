using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using WebApplication2.Models;
using System.Dynamic;

namespace WebApplication2.Controllers
{

    public class TiGiaController : Controller
    {
        public IActionResult Index()
        {
            string siteContent = string.Empty;

            // link XML của Vietcombank
            string url = "https://portal.vietcombank.com.vn/Usercontrols/TVPortal.TyGia/pXML.aspx";

            //dùng HTTPWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            //lấy đối tượng Response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //gọi hàm GetResponseStream() để trả về đối tượng Stream
            Stream responseStream = response.GetResponseStream();
            //convert từ XML qua C# model:
            XmlSerializer serializer = new XmlSerializer(typeof(ExrateList));
            dynamic mymodel = new ExpandoObject();
            mymodel.Exrate = get

            ExrateList exrateList = (ExrateList)serializer.Deserialize(responseStream);
            Exrate exrate = (Exrate)serializer.Deserialize(responseStream);
            return View(exrate);
            //lấy danh sách Extrates truyền qua cho View
            return View(exrateList.Exrates);
        }
    }
}
