using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Android1
{
    class ApiServices
    {
        private object jsonConvert;

        public async Task<HttpContent> RegisterAsync(string First_name, string Middle_name, string Last_Name, string Email, string Password, DateTime Birthday, string Address1, string Address2, string nTattoo, string Gender, string Phone_number)
        {
            var client = new HttpClient();

            var model = new Dictionary<string, string>(){
                { "first_name" , First_name},
                {"middle_name", Middle_name },
                {"last_name", Last_Name },
                {"email", Email},
                {"password", Password},
                {"birthday", Birthday.ToString().Substring(0,9)},
                {"tattoos", nTattoo},
                {"date_created", DateTime.Today.ToString().Substring(0,9)},
                {"gender", Gender},
                {"address1", Address1},
                {"address2", Address2},
                {"phone_number",Phone_number }


            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            // dummy
            var response = await client.PostAsync("http://199.250.202.220:3000/register", content);
             return response.RequestMessage.Content;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var client = new HttpClient();

            var response = await client.GetAsync("https://www.untitledtattoo.com/_functions/login");
            return response.StatusCode.ToString();
        }
    }
}
