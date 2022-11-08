using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DemoWEBAPI.Personal_Res;
using static DemoWEBAPI.Personal_Req;
namespace DemoWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        [HttpPost]
        [Route("Personal")]
        public ActionResult<Personal_Res>Personal([FromBody] Personal_Req personal_Req)
        {

            string details = personal_Req.FirstName.Trim() + " " + personal_Req.LastName.Trim();
           
               string dob=personal_Req.Dob;
            
            Personal_Res res = new Personal_Res();
                 res.FullName = details;
           
            DateTime dateTime = Convert.ToDateTime(dob);
            var year = dateTime.Year;
            var presentyear = DateTime.Now.Year;
            var age = presentyear - year;
            res.Age = age.ToString();




            return Ok(res);
           

        }
    }
}
