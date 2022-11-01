using System.ComponentModel.DataAnnotations;

namespace NghiaVoBlog.Dto.User
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Displayname khong the bo trong")]
        public String DisplayName { get; set; }
        [Required(ErrorMessage = "Email khong the bo trong")]
        [EmailAddress]
        public String Email { get; set; }
        [Required(ErrorMessage = "So dien thoai khong the bo trong")]
        public String Phone { get; set; }
        [Required(ErrorMessage = "Ngay sinh khong the bo trong")]
        public DateTime DateOfBirth { get; set; }
        public String Address { get; set; }
    }
}