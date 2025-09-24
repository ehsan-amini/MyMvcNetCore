﻿
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Security.Claims;
using MyMvcNetCore.Commen;
using MyMvcNetCore.DataLayer.Repository.IRepository;

namespace MyMvcNetCore.Web.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            //if (claim != null)
            //{
            //    if (HttpContext.Session.GetInt32(SD.SessionCart) == null)
            //        HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.CartRepository.GetAll(u => u.ApplicationUserId == claim.Value).Count());

            //    return View(HttpContext.Session.GetInt32(SD.SessionCart));
            //}
            //else
            //{
            //    HttpContext.Session.Clear();
            return View(0);
            //}


        }
    }
}
