using System.ComponentModel.DataAnnotations;

namespace AECProject.ViewModels
{
    //recive less model prop
    //extra info confirm pasww
    //validation att
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
    }
}
