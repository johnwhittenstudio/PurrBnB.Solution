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
    public static async Task<string> Geocode(string apiKey, Dwelling dwelling)
    {
      RestClient client = new RestClient($"https://api.geoapify.com/v1/geocode/search?text={dwelling.DwellingStreetAddress}&apiKey=ed4defa185064c72860cbff688f2edd2&postcode={dwelling.DwellingZip}&city={dwelling.DwellingCity}&State={dwelling.DwellingState}");
      RestRequest request = new RestRequest(Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      //Console.WriteLine("Response Content: " + response.Content);
      var result1 = response.Content;
      var result = result1;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      foreach (var item in jsonResponse["features"])
      {
        JToken name = item["geometry"];
        Console.WriteLine("Name: " + name);
        Console.WriteLine("NameCoords: " + name["coordinates"] + name[0]);
        foreach (var nestedItem in item)
        {
          JToken nestedName = nestedItem["coordinates"];
          Console.WriteLine("Name: " + nestedName);
          Console.WriteLine("NestedItem" + nestedItem["coordinates"]);
        }
      }


      Console.WriteLine(" test response" + jsonResponse["features"]["geometry"]);
      // Console.WriteLine(jsonResponse["features"[0]]);
      var features = jsonResponse["features"];
      Console.WriteLine(features["geometry"]);
      Console.WriteLine(features[0]);

      // var id = jo["report"]["Id"].ToString();

      //Console.WriteLine(jsonResponse);
      var latlong = jsonResponse;
      //      List<Article> articleList = JsonConvert.DeserializeObject<List<Article>>(jsonResponse["results"].ToString());
      //List<Dwelling> jsonResponseString = JsonConvert.DeserializeObject<List<Dwelling>>(jsonResponse["results"].ToString());
      List<Dwelling> jsonResponseString = JsonConvert.DeserializeObject<List<Dwelling>>(jsonResponse["features"].ToString());
      Console.WriteLine("Json response features: " + jsonResponseString);

      // Console.WriteLine(typeof(response.Content));
      return response.Content;
      //return jsonResponseString;
    }
  }
}

// json.features[0].properties.lon
// json.features[0].properties.lat

//    public static List<Article> GetArticles(string apiKey)
    // {
    //   var apiCallTask = ApiHelper.ApiCall(apiKey);
    //   var result = apiCallTask.Result;

    //   JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
    //   List<Article> articleList = JsonConvert.DeserializeObject<List<Article>>(jsonResponse["results"].ToString());

    //   return articleList;
    // }

    //Response Content: {"type":"FeatureCollection","features":[{"type":"Feature","properties":{"datasource":{"sourcename":"openstreetmap","attribution":"c OpenStreetMap contributors","license":"Open Database License","url":"https://www.openstreetmap.org/copyright"},"housenumber":"2606","street":"Southeast 78th Avenue","suburb":"South Tabor","city":"Portland","county":"Multnomah County","state":"Oregon","postcode":"97206","country":"United States","country_code":"us","lon":-122.58261246071388,"lat":45.50427995,"state_code":"OR","formatted":"2606 Southeast 78th Avenue, Portland, OR 97206, United States of America","address_line1":"2606 Southeast 78th Avenue","address_line2":"Portland, OR 97206, United States of America","category":"building.residential","result_type":"building","rank":{"importance":0.5309999999999999,"popularity":3.760435288193569,"confidence":1,"confidence_city_level":1,"confidence_street_level":1,"match_type":"full_match"},"place_id":"518640c68549a55ec059a6a3d23e8cc04640f00102f90186a1ff1500000000c00203"},"geometry":{"type":"Point","coordinates":[-122.58261246071388,45.50427995]},"bbox":[-122.5827111,45.50421,-122.5824166,45.5043286]}],"query":{"text":"2606 SE 78th Ave","parsed":{"housenumber":"2606","street":"se 