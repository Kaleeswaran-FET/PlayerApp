using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlayerApp.Models.ViewModel
{
    public class PlayerDetailviewModel
    {
        public int Player_Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string PlayerUserName { get; set; }
        public string SocialCode { get; set; }
        public int Age { get; set; }
        public string FBprofilelink { get; set; }
        public string IdProofs { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string DigitalSignature { get; set; }
        public string ConfirmList { get; set; }
    }
}
