using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ApiRestful.Business.Interfaces
{
    public interface IUser
    {
        public string Name { get; }

        Guid GetUserId();

        string GetUserEmail();

        bool IsAuthenticated();

        bool IsInRole(string Role);

        IEnumerable<Claim> GetClaimsIdentity();
    }
}
