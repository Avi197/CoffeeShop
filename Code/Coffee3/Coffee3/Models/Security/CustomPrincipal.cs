using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Coffee3.Models.Entities;

namespace Coffee3.Models.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private adminaccount Account;
        public CustomPrincipal(adminaccount account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.username);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            bool kq = roles.Any(r => this.Account.roles.Contains(r));
            return kq;
        }
    }
}