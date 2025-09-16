using Microsoft.AspNetCore.Mvc.Rendering;
using MyMvcNetCore.Entities.Identity;

namespace MyMvcNetCore.Entities.ViewModels
{
    public class RoleManagementVM
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
    }
}
