using MyMvcNetCore.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyMvcNetCore.Web.Areas.Admin.Controllers;

[Authorize(Roles = IdentityRoleNames.Admin)]
public class BaseController : Controller
{

}
