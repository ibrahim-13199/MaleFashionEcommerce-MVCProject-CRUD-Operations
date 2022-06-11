using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName  { get; set; }
    }
}
