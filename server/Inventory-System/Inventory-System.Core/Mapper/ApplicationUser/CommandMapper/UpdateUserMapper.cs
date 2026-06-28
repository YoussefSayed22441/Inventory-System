using Inventory_System.Core.Features.Users.Commands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Core.Mapper.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void UpdateUserMapper()
        {
            CreateMap<UpdateUserCommand, Infrastructure.Identity.ApplicationUser>();
        }
    }
}
