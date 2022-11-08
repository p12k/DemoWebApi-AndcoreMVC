using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using static DemoWEBAPI.FileModel;

namespace DemoWEBAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        [HttpPost]
        [Route("getbase64")]
        public ActionResult<Base64Doc> GetBase64([FromBody] Doc doc)
        {
            if (Headers.GetRequestHeaders(Request))
            {

                byte[] buffer = Encoding.ASCII.GetBytes(doc.Alpha);//convert into byte Array //first byte pooja
                string Base64 = Convert.ToBase64String(buffer);//to base 64 string//    pooja=>'djsjdskjdls'
                Base64Doc base64Doc = new Base64Doc();//object create
                base64Doc.Base64 = Base64;

                return Ok(base64Doc);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("getaplha")]
        public ActionResult<Doc> GetAplha([FromBody]Base64Doc base64Doc)
        {
            if (Headers.GetRequestHeaders(Request))
            {
               
                byte[] buffer = Convert.FromBase64String(base64Doc.Base64);//convert into byte Array /
               
                
                String alpha = Encoding.ASCII.GetString(buffer, 0, buffer.Length);//to normal string
                Doc doc = new Doc();
                doc.Alpha = alpha;
                return Ok(doc);
            }
            else
            {
                return BadRequest();
            }
           
        }



        [HttpPost]
        [Route("getbase64name")]
        public  ActionResult<Base64>getbase64name([FromBody] Fileupload file)
        {
            // string base64 = JsonConvert.SerializeObject("file");
           
            byte[] buffer = Encoding.ASCII.GetBytes(file.Alpha);
            string base64 = Convert.ToBase64String(buffer);
            Base64 base641 = new Base64();
            base641.Data= base64;
            return Ok(base641);
        }


        [HttpPost]
        [Route("GetAlphanormal")]
        public ActionResult<Fileupload>GetAlphanormal([FromBody]Base64 base64)
        {
            byte[] buffer = Convert.FromBase64String(base64.Data);
            string alpha = Encoding.ASCII.GetString(buffer,0,buffer.Length);
            Fileupload fileupload=new Fileupload();
            fileupload.Alpha = alpha;
            return Ok(fileupload);
        }




        [HttpPost]
        [Route("getfullname")]
        public  ActionResult<Name>GetFullName([FromBody]Concatenate concatenate)
        {
            if (Headers.GetRequestHeaders(Request))
            {
                string name = concatenate.Firstname.Trim() + " " + concatenate.Lastname.Trim();
                Name name1 = new Name();
                name1.Fullname = name;
                return Ok(name1);
            }
            else
            {
                return BadRequest();
            }

           
        }
        [HttpPost]
        [Route("weeklydaysdate")]
        public ActionResult<Weekdate> WeeklyDaysDate([FromBody] Weekdays weekDays)
        {
if (Headers.GetRequestHeaders(Request)) {
                Weekdate weekdate = new Weekdate();

                string day = weekDays.Day.Trim().ToLower();
                switch (day)
                {
                    case "today":
                        string today = DateTime.Now.ToString("dd/MM/yyyy");
                        weekdate.Date = today;
                        break;
                    case "tommorow":
                        string tomorrow = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
                        weekdate.Date = tomorrow;
                        break;
                    case "yesterday":
                        string yesterday = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                        weekdate.Date = yesterday;
                        break;

                    default:
                        weekdate.Date = "Bad Request!!!";
                        break;

                       

                }
                return Ok(weekdate);
                
            }
            else
            {
                return BadRequest();
            }


        }

        //if(day=="today")
        //{
        //    string today = DateTime.Now.ToString("dd/MM/yyyy");
        //           weekdate.Date = today;
        //}
        //else if(day== "tommorow"){
        //    string tomorrow = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
        //          weekdate.Date = tomorrow;
        //}
        //else if(day== "yesterday")
        //{
        //    string yesterday = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
        //           weekdate.Date = yesterday;
        //}
        //else
        //{
        //  weekdate.Date ="Bad Request";    
        //}


        [HttpPost]
        [Route("Toreverseddata")]

        public ActionResult<Reverse_res> ToreverseData([FromBody] Reverse_req reverse_Req)
        {
            string req = reverse_Req.Toreverse;//get
            char[] chararray=   req.ToCharArray();

            char[] reversed = chararray.Reverse().ToArray();
            String s = new String(reversed);
            Reverse_res res= new Reverse_res();
            res.Reversed = s;//set
            return Ok(res);
        }
    }
}
