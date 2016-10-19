using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRiotAPI.APIEnums
{
    public class APIEnums
    {
        public enum SharpRiotApiClass
        {
            //Stats_v_1_3,
            #region summoner-v1.4 [BR, EUNE, EUW, JP, KR, LAN, LAS, NA, OCE, RU, TR]
            GetSummonerByName, // consulta por nome
                               //GetSummonerById, // consulta por id 
                               //GetSummonerMasteries , // retorna masteries
                               //SummonerByIdGetName , // retorna lista de nomes por id
                               //SummonerByIdGetRunes , // retorna runes por id
            #endregion
            #region league-v2.5
            GetSummonerStats, // retorna os status do player
            #endregion

        }
        public enum SharpRiotApiRegions
        {
            BR,
            EUNE,
            EUW,
            JP,
            KR,
            LAN,
            LAS,
            NA,
            OCE,
            RU,
            TR
        }
    }
}
