namespace DemoWEBAPI
{
    public class Doc
    {
        public string Alpha { get; set; } = String.Empty;

    }
   


    public class Base64Doc
    {
        public string Base64 { get; set; }


    }

    public class Headers
    {
         public  static bool GetRequestHeaders(HttpRequest Request)
    {

        bool flag = false;
        bool username = Request.Headers.TryGetValue("UserName", out var UserName);
        bool password = Request.Headers.TryGetValue("Password", out var Password);

        if (username && password)
        {

            if (UserName == "Pooja" && Password == "Pooja@2022")
            {
                flag = true;
            }

        }
        return flag;
    }


       
    }

    public class Concatenate
    {
        public string Firstname { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;

    }
    public class Name
    {
        public string Fullname { get; set; } = String.Empty;

    }

       public class Weekdays//request
    {
        public string Day { get; set; } = String.Empty;
    }

    public class Weekdate//response
    {
        public string Date { get; set; }=string.Empty;
    }



    public class Reverse_req//request
    {
        public string Toreverse { get; set; } = String.Empty;
    }

    public class Reverse_res//response
    {
        public string Reversed { get; set; } = String.Empty;
    }

    //new- controller- details
//    Api name- Personal

//    request model-Personal_Req
//1)firstname
//2)lastname
//3)dob


//response model= Personal_Res
//1)FullName
//2)Age


}
