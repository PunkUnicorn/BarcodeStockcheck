using RestSharp;
using System.Text.RegularExpressions;
//using System.Dynamic;
//using static System.Windows.Forms.Design.AxImporter;
//using System.Threading;
//using RestSharp;
//using RestSharp.Authenticators;

namespace BarcodeStocktake
{
    public static class ResponseUtil
    { 
        public static string? MakeBase64Thumbnail(string? imageUrl)
        {
            if (imageUrl is null)
                return null;

            // ...

            return null;
        }

        public static string? GetProp(dynamic obj, string key)
        {
            if (obj is not IDictionary<string, object>)
                return null;

            var dict = (IDictionary<string, object>)obj;
            if (dict.ContainsKey(key))
                return dict[key].ToString();

            foreach (var nestedParent in dict.Values.Where(value => value is object && value is not string).ToList())
            {
                var nest = GetProp(nestedParent, key);
                if (nest is not null)
                    return nest;
            }

            return null;
        }

        public static string? GetFirstArrayItem(dynamic obj, string key)
        {
            if (obj is not IDictionary<string, object>)
                return null;

            var dict = (IDictionary<string, object>) obj;
            if (dict.TryGetValue(key, out var val))
            { 
                var array = (IEnumerable<object>)val;
                if (array.Any())
                    return array.First().ToString();
            }
            return null;
        }


        public static string MakeJsonFile(string code, RestResponse response)
        {
            if (!Directory.Exists("json"))
                Directory.CreateDirectory("json");

            var jsonFilename = $@"json\{code}.json";
            File.WriteAllText(jsonFilename, response.Content);
            return jsonFilename;
        }

        public static string? SearchDescriptionForProperties(string key, string description)
        {
            var regex = new Regex($@"{key}\s?\s?\s?:\s?\s?\s?([a-z A-Z]*)[,|.]");

            return regex.IsMatch(description)
                ? regex.Match(description).Groups[1].Value
                : null;
        }
    }

}