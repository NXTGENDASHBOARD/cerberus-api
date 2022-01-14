using Cerberus.Dashboard.Application.Features.AccountFeatures.Commands;
using Cerberus.Dashboard.Application.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Dashboard.Application.Extensions.Account
{
    public static class AccountExtensions
    {


        #region ViewModel Extensions
        public static AccountResponseViewModel ToViewModelEntity(this Domain.Models.Account model, string token = null)
        {
            return new AccountResponseViewModel
            {
                Id = model.Id,
                Email = model.Email,
                FirstName = model.FirstName,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber,
                Token = token,
                IsActive = model.IsActive,
                StatusId = model.StatusId,
                OTP = model.OTPVerification,
                IsVerified = model.IsVerified,
            };
        }

        public static AccountDetailsResponseViewModel ToViewModelEntity(this Domain.Models.Account model)
        {
            return new AccountDetailsResponseViewModel
            {
                Id = model.Id,
                StaffNumber = model.StaffNumber,
                FirstName = model.FirstName,
                Surname = model.Surname,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Token = model.Token,
                IsActive = model.IsActive,
                IsVerified = model.IsVerified,
                StatusId = model.StatusId
            };
        }
        #endregion


        #region Entity Extensions

        public static Domain.Models.Account ToEntityCommand(this RegisterAccountCommand model)
        {
            return new Domain.Models.Account
            {
                StaffNumber = model.StaffNumber,
                FirstName = model.FirstName,
                Surname = model.Surname,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                CreatedDate = model.CreatedDate,
                CreateUserId = model.CreateUserId,
                IsThirdParty = model.IsThirdParty,
                ModifyDate = model.ModifyDate,
                ModifyUserId = model.ModifyUserId,
                ThirdPartyProvider = model.ThirdPartyProvider,
                PasswordHash = model.PasswordHash,
                IsVerified = model.IsVerified,
                OTPVerification = model.OTPVerification,
                IsActive = model.IsActive,
                StatusId = model.StatusId,
            };
        }

        #endregion

        #region Command Extensions
        public static RegisterAccountCommand ToCommandViewModel(this RegisterAccountViewModel model)
        {
            return new RegisterAccountCommand
            {
                StaffNumber = model.StaffNumber,
                FirstName = model.FirstName,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Password = model.Password,
                RoleName = model.RoleType,
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                CreateUserId = model.CreateUserId,
                ModifyDate = DateTime.UtcNow.ToLocalTime(),
                ModifyUserId = model.ModifyUserId,
                IsThirdParty = model.IsThirdParty,
                ThirdPartyProvider = model.ThirdPartyProvider,
                IsActive = model.IsActive,
                StatusId = model.StatusId,
            };
        }

        public static LoginAccountCommand ToCommandViewModel(this LoginAccountViewModel model)
        {
            return new LoginAccountCommand
            {
                StaffNumber = model.StaffNumber,
                Pin = model?.Pin
            };
        }
        #endregion

        #region Query Extensions 



        #endregion



    }
}
