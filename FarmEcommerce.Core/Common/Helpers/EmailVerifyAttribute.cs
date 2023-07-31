using Ecommerce.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagement.Core.Helpers
{
    /// <summary>
    /// Tried casting a string object bind to Gender, didn't work
    /// </summary>
    public class EmailVerifyAttribute : ValidationAttribute
    {
        private readonly UserManager<IBaseUserEntity> userManager;

        public EmailVerifyAttribute(UserManager<IBaseUserEntity> userManager)
        {
            this.userManager = userManager;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult($"{validationContext.DisplayName} cannot be null");
            }
            try
            {
                return userManager.Users.Any(x => x.Email == value.ToString()) ? new ValidationResult($"{validationContext.DisplayName} is already taken.") : ValidationResult.Success;
            }
            catch(Exception ex)
            {
                return new ValidationResult($"Error: {ex.Message}");
            }
        }
    }
}
