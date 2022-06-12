//namespace COMPANY.Domain.Entities
//{
//    using COMPANY.Common.Helpers;
//    using System;
//    using System.Collections.Generic;

//    /// <summary>
//    /// a minimal version of the <see cref="User"/> entity,
//    /// with an <see cref="Id"/> and a <see cref="UserName"/>
//    /// </summary>
//    public partial class MinimalUser
//    {
//        /// <summary>
//        /// the id of the user how made the changes
//        /// </summary>
//        public Guid Id { get; set; }

//        /// <summary>
//        /// the user name of the user who made the changes
//        /// </summary>
//        public string UserName { get; set; }
//    }

//    /// <summary>
//    /// partial part for <see cref="MinimalUser"/>
//    /// </summary>
//    public partial class MinimalUser : IEquatable<MinimalUser>
//    {
//        /// <summary>
//        /// create an empty instant of the Minimal user
//        /// </summary>
//        public static readonly MinimalUser Empty = new MinimalUser(Guid.Empty, "");

//        /// <summary>
//        /// check if the current minimal user instant is an empty instant
//        /// </summary>
//        public bool IsEmpty => Id == Guid.Empty && UserName.IsValid();

//        /// <summary>
//        /// create a new instant of <see cref="MinimalUser"/>
//        /// </summary>
//        public MinimalUser() { }

//        /// <summary>
//        /// create a new instant of <see cref="MinimalUser"/>, with an <see cref="Id"/> and a <see cref="UserName"/>
//        /// </summary>
//        /// <param name="id">the id of the user</param>
//        /// <param name="userName">the user name of the user</param>
//        public MinimalUser(Guid id, string userName) : base()
//        {
//            Id = id;
//            UserName = userName;
//        }

//        /// <summary>
//        /// the string representation of the object
//        /// </summary>
//        /// <returns></returns>
//        public override string ToString() => $"{UserName}";

//        /// <summary>
//        /// check if the given object is equals the current instant
//        /// </summary>
//        /// <param name="obj">the object to check the equality for it</param>
//        /// <returns>true if equals, false if not</returns>
//        public override bool Equals(object obj) => Equals(obj as MinimalUser);

//        /// <summary>
//        /// check if the given object is equals the current instant
//        /// </summary>
//        /// <param name="obj">the object to check the equality for it</param>
//        /// <returns>true if equals, false if not</returns>
//        public bool Equals(MinimalUser other)
//            => other != null && Id.Equals(other.Id) && UserName == other.UserName;

//        /// <summary>
//        /// get the has value of the object
//        /// </summary>
//        /// <returns>the hash value</returns>
//        public override int GetHashCode()
//        {
//            unchecked
//            {
//                int hashCode = 434618873;
//                hashCode = hashCode * -1521134295 + Id.GetHashCode();
//                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
//                return hashCode;
//            }
//        }

//        public static bool operator ==(MinimalUser left, MinimalUser right) => EqualityComparer<MinimalUser>.Default.Equals(left, right);
//        public static bool operator !=(MinimalUser left, MinimalUser right) => !(left == right);

//        /// <summary>
//        /// get a <see cref="MinimalUser"/> instant from the user instant
//        /// </summary>
//        /// <param name="user">the <see cref="User"/> instant</param>
//        public static implicit operator MinimalUser(User user)
//            => user is null
//                ? Empty
//                : new MinimalUser(user.Id, user.UserName);
//    }
//}
