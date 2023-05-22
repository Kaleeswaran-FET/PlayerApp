using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayerApp.DBMethods;
using PlayerApp.Models.DBModel;
using PlayerApp.Models.ViewModel;
using System.Collections.Generic;

namespace PlayerApp.Controllers
{
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private CDBOperation<PlayerDetail> InsertPlayerdet;
        public PlayerController(CDBOperation<PlayerDetail> InsertPlayerdet)
        {
            this.InsertPlayerdet = InsertPlayerdet;
           
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Player/AddPlayerdet")]
        public string AddPlayer(string FullName,string Email,string MobileNo,string PlayerUserName,string SocialCode,int Age,string FbLink,string idprof,string signature,string confrimlst)
        {
            CPlayerDet cobjPlayerdet = new CPlayerDet(InsertPlayerdet);
            PlayerDetail playerDetail = new PlayerDetail();
            string dbError = string.Empty;
            dbError = cobjPlayerdet.InsertIntoPlayerDet(FullName,Email,MobileNo,PlayerUserName,SocialCode,Age,FbLink,idprof,signature,confrimlst,playerDetail);
            return dbError;

        }

        [Route("[action]")]
        [Route("api/Player/GetPlayerDet")]
        public List<PlayerDetailviewModel> GetPlayerLst(int id)
        {
            return CPlayerDet.GetPlayerLstById(id);
        }
    }
}
