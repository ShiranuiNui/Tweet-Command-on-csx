#! "netcoreapp2.0"

#r "nuget:NetStandard.Library,2.0.0"
#r "nuget:CoreTweet,0.8.1.394"
#r "nuget:Newtonsoft.Json,10.0.3"
using System.IO;
using CoreTweet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

string settingFile = File.ReadAllText("settings.json");
var jsonObject = JObject.Parse(settingFile);

using (var streamReader = new StreamReader(Console.OpenStandardInput()))
{   
    string statusString = streamReader.ReadToEnd();
    var token = new Tokens(Tokens.Create((string)jsonObject["TWITTER_APIKEY"], (string)jsonObject["TWITTER_APISECRET"], (string)jsonObject["TWITTER_ACCESSTOKEN"], (string)jsonObject["TWITTER_ACCESSSECRET"]));

    await token.Statuses.UpdateAsync(status => statusString);

    Console.WriteLine("Tweet Complete");
}