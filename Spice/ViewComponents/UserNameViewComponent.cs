using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spice.ViewComponents
{
    public class UserNameViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public UserNameViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var userFromDb = await db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == claims.Value);

            return View(userFromDb);
        }
    }
}
