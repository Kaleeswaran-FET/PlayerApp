using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlayerApp.Models.DBModel
{
    public class PlayerDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Player_Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(15)]
        public string MobileNo { get; set; }

        [StringLength(20)]
        public string PlayerUserName { get; set; }

        [StringLength(20)]
        public string SocialCode { get; set; }

        public int Age { get; set; }

        [StringLength(80)]
        public string FBprofilelink { get; set; }

        public string IdProofs { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string DigitalSignature { get; set; }
        public string ConfirmList { get; set; }

    }
}
