using System.Threading.Tasks;
using RestSharp;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace PurrBnB.Models
{
  class ApiHelper
  {
    public static async Task<float> GeocodeLat(string apiKey, Dwelling dwelling)
    {
      RestClient client = new RestClient($"https://api.geoapify.com/v1/geocode/search?text={dwelling.DwellingStreetAddress}&apiKey={apiKey}&postcode={dwelling.DwellingZip}&city={dwelling.DwellingCity}&State={dwelling.DwellingState}");
      RestRequest request = new RestRequest(Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      var result1 = response.Content;
      var result = result1;
      JToken noResponse = "noResponse";
      //JToken latLong;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      //JToken LatLong = jsonResponse["features"][0]["geometry"]["coordinates"];
      float latFloat = JsonConvert.DeserializeObject<float>(jsonResponse["features"][0]["geometry"]["coordinates"][1].ToString());
 
      return latFloat;
    }

    public static async Task<float> GeocodeLong(string apiKey, Dwelling dwelling)
    {
      RestClient client = new RestClient($"https://api.geoapify.com/v1/geocode/search?text={dwelling.DwellingStreetAddress}&apiKey={apiKey}&postcode={dwelling.DwellingZip}&city={dwelling.DwellingCity}&State={dwelling.DwellingState}");
      RestRequest request = new RestRequest(Method.GET);
      var response = await client.ExecuteTaskAsync(request);

      var result1 = response.Content;
      var result = result1;
      JToken noResponse = "noResponse";
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      JToken Long = jsonResponse["features"][0]["geometry"]["coordinates"][1];
      float longFloat = JsonConvert.DeserializeObject<float>(jsonResponse["features"][0]["geometry"]["coordinates"][0].ToString());
      return longFloat;
    }
  }
}