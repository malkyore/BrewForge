using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Beernet_Lib.Tools
{
    public class Auth
    {
        public static string getAPIAuthToken(string apiLink, string authEndpoint, Dictionary<string, string> values)
        {
            //string dataurl = "http://rest.unacceptable.beer:5123";

            var client = new RestClient("" + apiLink);
            string token = "";
            var request = new RestRequest(authEndpoint, Method.POST);

            // Json to post.
            string jsonToSend = Newtonsoft.Json.JsonConvert.SerializeObject(values);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                var response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    token = response.Content;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = "Unauthorized";
                }
                else
                {
                    token = "Unknown Error";
                }
            }
            catch (Exception error)
            {
                token = "exception";
            }
            return token;
        }

        public static string createNewUserAccount(string apiLink, string authEndpoint, Dictionary<string, string> values)
        {
            var client = new RestClient("" + apiLink);
            string creationResponse = "";
            var request = new RestRequest(authEndpoint, Method.POST);

            string jsonToSend = Newtonsoft.Json.JsonConvert.SerializeObject(values);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                var response = client.Execute(request);

                creationResponse = response.Content;
            }
            catch (Exception error)
            {
                creationResponse = error.Message;
            }
            return creationResponse;
        }
    }
}
