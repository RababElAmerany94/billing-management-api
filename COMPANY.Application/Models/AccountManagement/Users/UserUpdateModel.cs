namespace COMPANY.Application.Models
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a model that defines the update requirements
    /// </summary>
    public class UserUpdateModel : UserCreateModel, IEntityUpdateModel<User>
    {
        /// <summary>
        /// update the user from the current model 
        /// </summary>
        /// <param name="user"></param>
        public void Update(User user)
        {
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Email = Email;
            user.PhoneNumber = PhoneNumber;
            user.UserName = UserName;
            user.RegistrationNumber = RegistrationNumber;
            user.IsActive = IsActive;
            user.RoleId = RoleId;
        }
    }
}
