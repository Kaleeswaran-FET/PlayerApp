using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PlayerApp.Models.DBModel;
using PlayerApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayerApp.DBMethods
{
    public class CPlayerDet
    {
        private CDBOperation<PlayerDetail> InsertPlayerdet;

        public CPlayerDet(CDBOperation<PlayerDetail> InsertPlayerdet)
        {
            this.InsertPlayerdet = InsertPlayerdet;
        }

        public string InsertIntoPlayerDet(string FullName, string Email,string MobileNo, string PlayerUserName,string SocialCode, int Age, string FbLink, string idprof, string signature, string confrimlst,PlayerDetail playerDetail)
        {
            string dbError = string.Empty;
            using (GeneralDbContext _databaseContext = new GeneralDbContext())
            {
                try
                {
                    _databaseContext.Database.BeginTransaction();
                    _databaseContext.Database.OpenConnection();
                    playerDetail.FullName= FullName;
                    playerDetail.Email= Email;
                    playerDetail.MobileNo= MobileNo;
                    playerDetail.PlayerUserName= PlayerUserName;
                    playerDetail.SocialCode= SocialCode;
                    playerDetail.Age= Age;
                    playerDetail.FBprofilelink= FbLink;
                    playerDetail.IdProofs= idprof;
                    playerDetail.DigitalSignature= signature;
                    playerDetail.ConfirmList= confrimlst;
                    InsertPlayerdet.Insert(playerDetail);
                    _databaseContext.Database.CommitTransaction();
                    _databaseContext.Database.CloseConnection();
                    _databaseContext.Dispose();
                }

                catch(Exception ex)
                {
                    _databaseContext.Database.RollbackTransaction();
                    dbError = ex.GetBaseException().ToString() ;
                    _databaseContext.Database.CloseConnection();
                    _databaseContext.Dispose();
                }
                return dbError;
            }
        }

        public static List<PlayerDetailviewModel> GetPlayerLstById(int id)
        {
            List<PlayerDetailviewModel> PlayerLst = new List<PlayerDetailviewModel>();
            using (GeneralDbContext _databaseContext = new GeneralDbContext())
            {
                try
                {
                    _databaseContext.Database.OpenConnection();
                    PlayerLst = (from plst in _databaseContext.PlayerDetail
                                 where plst.Player_Id == id
                               select new PlayerDetailviewModel()
                               {
                                FullName=plst.FullName,
                                Email=plst.Email,
                                MobileNo=plst.MobileNo,
                                PlayerUserName=plst.PlayerUserName,
                                SocialCode=plst.SocialCode,
                                Age=plst.Age,
                                FBprofilelink=plst.FBprofilelink,
                                IdProofs=plst.IdProofs,
                                DigitalSignature=plst.DigitalSignature,
                                ConfirmList=plst.ConfirmList,
                               }).ToList();
                }
                catch (Exception ex) {
                    ex.GetBaseException();
                    _databaseContext.Database.CloseConnection();
                    _databaseContext.Dispose();
                }
            }

            return PlayerLst;
        }
    }
}
