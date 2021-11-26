using CertingTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace CertingTask.Controllers
{
    public class TranslateController : BaseApiController
    {
        [HttpPost("json")]
        [Consumes("application/xml")]
        public ActionResult Translate(Organization organization)
        {
            return Ok(organization);
        }

        //without deserializing to object

        //public ActionResult PostTranslate(XElement xmlObject)
        //{
        //    string jsonText = JsonConvert.SerializeXNode(xmlObject);
        //    JObject json = JObject.Parse(jsonText);
        //    var jsonObject = JsonConvert.SerializeObject(json);
        //    return new ContentResult { Content = jsonObject, ContentType = "application/json" };
        //}
    }
}
