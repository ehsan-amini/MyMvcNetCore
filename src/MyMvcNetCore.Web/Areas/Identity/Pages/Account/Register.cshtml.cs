// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MyMvcNetCore.Commen;
using MyMvcNetCore.Commen.Constants;
using MyMvcNetCore.Entities;
using MyMvcNetCore.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.ViewModels;


namespace MyMvcNetCore.Web.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterModel(
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {



            [Display(Name = "Username")]
            [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
            [MinLength(4, ErrorMessage = AttributesErrorMessages.MinLengthMessage)]
            [MaxLength(30, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
            [PageRemote(
                PageName = "Register",
                PageHandler = "CheckUserName",
                HttpMethod = "Get",
                ErrorMessage = AttributesErrorMessages.RemoteMessage)]
            //[RegularExpression(@"^\w+$", ErrorMessage = "نام کاربری باید از حروف انگلیسی تشکیل شده باشد")]
            public string UserName { get; set; }

            [Display(Name = "Email")]
            [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
            [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$", ErrorMessage = AttributesErrorMessages.RegularExpressionMessage)]
            [PageRemote(
                  PageName = "Register",
                ErrorMessage = AttributesErrorMessages.RemoteMessage,
                HttpMethod = "Get",
                PageHandler = "CheckEmail"
            )]
            [MaxLength(100, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
            public string Email { get; set; }



            [Display(Name = "Firstname")]
            [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
            [MinLength(1, ErrorMessage = AttributesErrorMessages.MinLengthMessage)]
            [MaxLength(30, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
            public string FirstName { get; set; }

            [Display(Name = "Lastname")]
            [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
            [MinLength(1, ErrorMessage = AttributesErrorMessages.MinLengthMessage)]
            [MaxLength(30, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
            public string LastName { get; set; }


            [Display(Name = "Password")]
            [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
            [MinLength(6, ErrorMessage = AttributesErrorMessages.MinLengthMessage)]
            [MaxLength(50, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
            [DataType(DataType.Password)]
            public string Password { get; set; }


            [Display(Name = "Confirm Password")]
            [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
            [DataType(DataType.Password)]
            [Compare(nameof(Password), ErrorMessage = AttributesErrorMessages.CompareMessage)]
            public string ConfirmPassword { get; set; }




            [Display(Name = "Country")]
            [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
            [MinLength(2, ErrorMessage = AttributesErrorMessages.MinLengthMessage)]
            [MaxLength(30, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
            public string Country { get; set; }



            [Display(Name = "Address")]
            [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
            [MinLength(1, ErrorMessage = AttributesErrorMessages.MinLengthMessage)]
            [MaxLength(60, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
            public string StreetAddress { get; set; }


            [Display(Name = "City")]
            [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
            [MinLength(2, ErrorMessage = AttributesErrorMessages.MinLengthMessage)]
            [MaxLength(30, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
            public string City { get; set; }


            [Display(Name = "State")]
            [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
            [MinLength(2, ErrorMessage = AttributesErrorMessages.MinLengthMessage)]
            [MaxLength(30, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
            public string State { get; set; }



            [Display(Name = "PostalCode")]
            [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
            [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = AttributesErrorMessages.RegularExpressionMessage)]
            public string PostalCode { get; set; }



            [Display(Name = "PhoneNumber")]
            [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
            [RegularExpression(@"^([\+]?(?:00)?[0-9]{1,3}[\s.-]?[0-9]{1,12})([\s.-]?[0-9]{1,4}?)$", ErrorMessage = AttributesErrorMessages.RegularExpressionMessage)]
            public string PhoneNumber { get; set; }

            public string? Role { get; set; }

            [ValidateNever]
            public IEnumerable<SelectListItem> RoleList { get; set; }

            [ValidateNever]
            public IEnumerable<SelectListItem> CompanyList { get; set; }

            public int? CompanyId { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            Input = new()
            {
                RoleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                }),
                CompanyList = _unitOfWork.CompanyRepository.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.UserName, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.PhoneNumber = Input.PhoneNumber;
                user.Country = Input.Country;
                user.State = Input.State;
                user.City = Input.City;
                user.PostalCode = Input.PostalCode;
                user.Adress = Input.StreetAddress;
                user.CreatedDateTime = DateTime.Now;
                user.IsActive = true;






                if (Input.Role == SD.Role_Company)
                {
                    user.CompanyId = Input.CompanyId;
                }

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (!String.IsNullOrEmpty(Input.Role))
                        await _userManager.AddToRoleAsync(user, Input.Role);
                    else
                        await _userManager.AddToRoleAsync(user, SD.Role_Customer);

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        if (User.IsInRole(SD.Role_Admin))
                            TempData["success"] = "New User Created Successfully!";
                        else
                            await _signInManager.SignInAsync(user, isPersistent: false);

                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                //return Activator.CreateInstance<IdentityUser>();
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

        public JsonResult OnGetCheckUserName([FromQuery(Name = "Input.UserName")] string userName)
        {

            var user = _userManager.FindByNameAsync(userName);
            if (user.Result is null)
                return new JsonResult(true);
            else return new JsonResult(false);

        }

        public async Task<JsonResult> OnGetCheckEmail([FromQuery(Name = "Input.Email")] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return new JsonResult(true);
            else return new JsonResult(false);
        }


    }
}
