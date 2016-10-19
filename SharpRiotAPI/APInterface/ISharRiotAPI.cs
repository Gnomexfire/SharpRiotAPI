using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpRiotAPI.APIEnums;
using static SharpRiotAPI.APIEnums.APIEnums;

namespace SharpRiotAPI.APInterface
{
    public interface ISharRiotAPI
    {
        /// <summary>
        /// minha chave de desenvolvedor
        /// </summary>
        string Key { get; set; }
        /// <summary>
        /// url da Api riot
        /// </summary>
        string ApiPvpNet { get; set; }
        /// <summary>
        /// regiao a ser consultada
        /// </summary>
        SharpRiotApiRegions Region { get; set; }
        /// <summary>
        /// classe da api 
        /// </summary>
        SharpRiotApiClass ApiClass { get; set; }
        /// <summary>
        /// evento que consome a api 
        /// </summary>
        /// <param name="s">parametro de consumo da api</param>
        //Func<object> ConsumeApi(SharpRiotApiRegions _region , SharpRiotApiClass _class , string _s,out object _object);
        
        object ConsumeApi(SharpRiotApiRegions _region, SharpRiotApiClass _class, string _s);
    }
}
