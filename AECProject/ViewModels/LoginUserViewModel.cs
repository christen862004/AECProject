using System.ComponentModel.DataAnnotations;

namespace AECProject.ViewModels
{
    public class LoginUserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Passwrod { get; set; }

        public bool RememberMe { get; set; }
    }
}
