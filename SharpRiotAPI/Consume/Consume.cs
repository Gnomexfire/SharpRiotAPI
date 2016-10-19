using SharpRiotAPI.APInterface;
using SharpRiotAPI.APIObjects;
/// Rafael fernandes motta http://bit.ly/2ektTHE
/// SharpRiotAPI.dll 
/// esta dll consome Riot API 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static SharpRiotAPI.APIEnums.APIEnums;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using System.Windows.Forms;
using SharpRiotAPI.APIEnums;
using System.Threading;
using System.Text.RegularExpressions;

/// <summary>
/// this class used for called methods Riot Api
/// </summary>
namespace SharpRiotAPI.Consume
{
    public class Consume : ISharRiotAPI
    {
        #region constructor
        /// <summary>
        /// inicia o construtor da classe
        /// </summary>
        /// <param name="key">chave de desenvolvedor riot</param>
        public Consume(string _key)
        {
            Key = "?api_key=" + _key;
            ApiPvpNet = ".api.pvp.net/api/lol/";
        }

        public SharpRiotApiClass ApiClass { get; set; }
        public string ApiPvpNet { get; set; }
        public string Key { get; set; }
        public SharpRiotApiRegions Region { get; set; }

        public object ConsumeApi(SharpRiotApiRegions _region, SharpRiotApiClass _class, string _s)
        {
            string _trueClass = string.Empty;
            object _object = new object();

            switch (_class)
            {
                #region  /v1.4/summoner/by-name/
                case SharpRiotApiClass.GetSummonerByName:
                    _trueClass = "/v1.4/summoner/by-name/";
                    break;
                #endregion

                #region league-v2.5
                case SharpRiotApiClass.GetSummonerStats:
                    _trueClass = "/v2.5/league/by-summoner/";
                    break;
                #endregion

            }
            var link = "https://" +
                        _region.ToString().ToLower() +
                        ApiPvpNet.ToLower() +
                        _region.ToString().ToLower() +
                        _trueClass.ToString().ToLower() +
                        _s +
                        Key;

            string html = string.Empty;
            try
            {
                using(WebClient client = new WebClient())
                {
                    html = client.DownloadString(new Uri(link));
                }
                JavaScriptSerializer jss = new JavaScriptSerializer();

                
                dynamic j = jss.Deserialize<dynamic>(html);
                switch (_class)
                {
                    #region  /v1.4/summoner/by-name/
                    case SharpRiotApiClass.GetSummonerByName:
                        SummonerName s = new SummonerName()
                        {
                            Id = Convert.ToInt32(j[_s.Replace(" ", "")]["id"]),
                            Name = (j[_s.Replace(" ", "")]["name"]),
                            SummornerLevel = Convert.ToInt32(j[_s.Replace(" ", "")]["summonerLevel"])
                        };
                        _object = s;
                    break;
                    #endregion

                    #region league-v2.5
                    case SharpRiotApiClass.GetSummonerStats:
                        SummonerStats st = new SummonerStats()
                        {
                        };
                    break;
                        #endregion
                }
            }
            catch (Exception ex)
            {
                html = ex.Message;
            }
            return _object;
        }
        #endregion
    }
}
