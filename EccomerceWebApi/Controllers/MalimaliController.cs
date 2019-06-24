using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EccomerceWebApi.Controllers
{
    public class MalimaliController : ApiController
    {
        private MaliMaliDbEntities Db = new MaliMaliDbEntities();
        [HttpGet]
        public IEnumerable<Fcm_Token_Table> GetTokens()
        {

            return Db.Fcm_Token_Table.ToList();

        }
        [HttpPost]
        public HttpResponseMessage Save_Fcm_Token([FromBody] Fcm_Token_Table fcm)
        {
            try
            {

                Db.Fcm_Token_Table.AddOrUpdate(x => x.Fcm_Token, fcm);
                Db.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, fcm);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        /*  [HttpGet]
          public void Send_Fcm(String title, String body)
          {
              try
              {
                  var client = new RestClient("https://fcm.googleapis.com/fcm/send");
                  var request = new RestRequest(Method.POST);
                 request.AddHeader("Content-Type", "Application/json");
                  request.AddHeader("Accept", "Application/json");
                  request.AddHeader("Authorization", "Key=AAAA6CqEHVo:APA91bG9EADASP-nnRrc0zu2IxLVVE4_vdH09pYBbuHrMquLDdSFj84BQrfFMkCYtT0aFungiCVuBf2UK4lzG-jycfl_r7x7XQ2YL-vU2Ichlf9pY6M_T6wYiN4q6eXUf0CI9KgPfrlB");
                  request.AddParameter(" Application/json", "{\"notification\":{\"title\": \""+title+"\", \"text\": \""+body + "\", \"badge\": \"1\", \"sound\": \"default\"}, \"data\":{\"foo\":\"bar\"}, \"priority\": \"High\", \"to\": \"/topics/News\"}", ParameterType.RequestBody);
                  IRestResponse response = client.Execute(request);
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.ToString());
              }



          }*/
        [HttpGet]
        public void get_token(String title, string body)
        {
            try
            {

                String b = Base64Encode("dYOZxlJ1MxbbDYG7U6XykENHgckvKEea:hCsxBctA1evwaH7w");
                var passclient = new RestClient("https://api.safaricom.co.ke/oauth/v1/generate?grant_type=client_credentials");
                var passrequest = new RestRequest(Method.GET);
                passrequest.AddHeader("Accept", "Application/json");
                passrequest.AddHeader("Content-Type", "Application/json");
                passrequest.AddHeader("Authorization", "Basic" + " " +b);

                IRestResponse response3 = passclient.Execute(passrequest);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        [HttpGet]
        public void lipanaMpesa(string ShortCode, string CommandID, string Amount, string Msisdn, string BillRefNumber) 
        
        {
            try
            {
                String URL = "https://api.safaricom.co.ke/mpesa/stkpush/v1/processrequest";
                var client = new RestClient(URL);
                var request = new RestRequest(Method.POST);
                request.AddHeader("accept", "Application/json");
                request.AddHeader("content-type", "Application/json");
                request.AddHeader("authorization", "Bearer VQ3eC3RGSprfePSTikAhU4iawWlx");
                //generate timestamp
                string passkey = "3cbc01cef50e4973dd84cefe5c1af943ac97ce4325658a26dd4d6cc8cdcc17ee";
                DateTime timenow = DateTime.Now;
                string transactiontype = "CustomerPayBillOnline";
                string callbackurl = "https://lociafrica.co.ke/";
                string timestamp = timenow.ToString("yyyyMMddHHmmss");
                string password = Base64Encode(ShortCode+passkey+timestamp);
                //string password = Base64Encode(ShortCode+:+passkey+":"+timestamp);
                 request.AddParameter(" Application/json", "{\"BusinessShortCode\": \"" + ShortCode+ "\",\"Password\": \"" + password + "\",\"Timestamp\": \"" + timestamp + "\",\"TransactionType\": \"CustomerPayBillOnline\",\"Amount\": \""+Amount+ "\",\"PartyA\": \"" + Msisdn + "\",\"PartyB\": \"" + ShortCode + "\",\"PhoneNumber\": \"" + Msisdn + "\",\"CallBackURL\": \"" + callbackurl + "\",\"AccountReference\": \"25170934\",\"TransactionDesc\": \"test\"}", ParameterType.RequestBody);
               
                IRestResponse response1 = client.Execute(request);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
            
    


       
    

