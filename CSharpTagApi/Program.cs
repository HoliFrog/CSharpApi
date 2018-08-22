using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTagApi
{


    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string url1 = "http://data.metromobilite.fr/api/linesNear/json?x=5.709360123&y=45.176494599999984&dist=400&details=true";
            string url11 = "http://data.metromobilite.fr/api/linesNear/json?x=5.728221&y=45.185692&dist=900&details=true";
            string url2 = "http://data.metromobilite.fr/api/routers/default/index/routes";
            ApiCom apiCom = new ApiCom();
            apiCom.doRequestNearYou(url11);
            //apiCom.doRequestLignes(url2);
        }
    }
}
