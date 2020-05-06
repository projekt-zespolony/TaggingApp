using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tagging.Model;
using System.Web.Script.Serialization;

namespace Tagging.Services
{
    public class DataRequestService
    {
        private string _url = "http://www.projekt-zespolowy.pl/sensors/";

        public DataRequestService()
        {
        }

        public async Task<List<Sensors>> GetSensors(int hours)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(_url + hours.ToString()).Result.Content.ReadAsStringAsync().Result;

                var sensors = new JavaScriptSerializer().Deserialize<List<Sensors>>(result);

                return sensors;
            }
        }
    }
}
