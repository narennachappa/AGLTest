using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Http;
namespace AGLTest
{
    public partial class getUserData : System.Web.UI.Page
    {
        ErrorResponse response = new ErrorResponse();
        protected void Page_Load(object sender, EventArgs e)
        {
            //function to fetch JSON data from the AGL service URL
            List<pets> userDet = getAGLPeopleJSONData("Male", "Cat");
            BindPetList(userDet, "Male");

            userDet = getAGLPeopleJSONData("Female", "Cat");
            BindPetList(userDet, "Female");
        }

        /// <summary>
        /// function to fetch JSON data from the AGL service URL
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="petName"></param>
        /// <returns></returns>
        public List<pets> getAGLPeopleJSONData(string gender, string petName)
        {
            string url = "http://agl-developer-test.azurewebsites.net/people.json";
            List<UserDetails> userDet;
            List<pets> catListWithOwner;
            List<ErrorResponse> error;
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse ws = request.GetResponse();

                string jsonString = string.Empty;
                using (System.IO.StreamReader sreader = new System.IO.StreamReader(ws.GetResponseStream()))
                {
                    jsonString = sreader.ReadToEnd();
                }

                System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                //deserialize json string
                userDet = jsSerializer.Deserialize<List<UserDetails>>(jsonString);


                catListWithOwner = new List<pets>();
                pets obj;

                userDet = userDet.Where(s => s.gender == gender).ToList();

                foreach (var item in userDet)
                {
                    if (item.pets != null)
                    {
                        obj = new pets();
                        var c = item.pets.FirstOrDefault(x => x.type == petName);
                        obj.name = c.name.ToString();
                        catListWithOwner.Add(obj);
                    }

                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                }
                throw;
            }
            catch (Exception ex)
            {
                //response.AddErrors("Invalid Pet Type."+ ex.Message);
                //return error;
                throw;
            }
          

            return catListWithOwner;
        }

        /// <summary>
        /// Bind list to the repeater
        /// </summary>
        /// <param name="userDet"></param>
        /// <param name="gender"></param>
        public void BindPetList(List<pets> userDet, string gender)
        {
            switch (gender)
            {
                case "Male":
                    rptMalePets.DataSource = userDet;
                    rptMalePets.DataBind();
                    break;
                case "Female":
                    rptFemalePets.DataSource = userDet;
                    rptFemalePets.DataBind();
                    break;
                default:
                    break;
            }

        }
    }
}