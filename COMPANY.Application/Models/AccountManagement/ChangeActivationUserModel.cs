using System;
using System.Collections.Generic;
using System.Text;

namespace COMPANY.Application.Models.Account
{
    public class ChangeActivationUserModel
    {
        /// <summary>
        /// the id of user
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// is this user active
        /// </summary>
        public bool IsActive { get; set; }
    }
}
