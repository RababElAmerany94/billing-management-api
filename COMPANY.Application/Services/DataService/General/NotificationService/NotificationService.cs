namespace COMPANY.Application.Services.DataService.General.NotificationService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.General.Notification;
    using COMPANY.Domain.Entities.Generals;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    [Inject(typeof(INotificationService), ServiceLifetime.Scoped)]
    public class NotificationService :
        BaseService<Notification, string, NotificationModel, NotificationPutModel, NotificationPutModel>,
        INotificationService
    {
        public NotificationService(
            IDataRequestBuilder<Notification> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        { }

        /// <summary>
        /// add set of notifications
        /// </summary>
        /// <param name="notifications">list of notifications</param>
        public async Task AddNotifications(IEnumerable<Notification> notifications)
            => await _dataAccess.AddRangeAsync(notifications);

        public async Task<Result> MarkAllAsSeen()
        {
            var notifications = await _dataAccess.GetAsync(e => e.UserId == _user.Id && !e.IsSeen);

            foreach (var notification in notifications)
                notification.IsSeen = true;

            _dataAccess.UpdateRange(notifications);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("edit with successfully");
        }

        public async Task<Result> MarkAsSeen(string notificationId)
        {
            var notification = await GetEntityByIdAsync(notificationId);
            notification.IsSeen = true;
            _dataAccess.Update(notification);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("edit with successfully");
        }

        protected override Expression<Func<Notification, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterOption)
            => base.BuildGetAsPagedPredicate(filterOption)
                .And(e => e.UserId == _user.Id);
    }
}
