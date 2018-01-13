using Valit.AspNetCore.Tests.IntegrationApp.Models;

namespace Valit.AspNetCore.Tests.IntegrationApp.Validators
{
	public class UserModelValitator : IValitator<UserModel>
	{
		public IValitResult Validate(UserModel @object, IValitStrategy strategy = null)
            => ValitRules<UserModel>
                .Create()
                .WithStrategy(strategy)
                .Ensure(m => m.Id, _=>_
                    .IsNotEmpty()
                        .WithMessage(ErrorMessages.EmptyId))
                .Ensure(m => m.Email, _=>_
                    .Required()
                        .WithMessage(ErrorMessages.RequiredEmail)
                    .Email()
                        .WithMessage(ErrorMessages.InvalidEmail))
                .Ensure(m => m.Age, _=>_
                    .IsGreaterThanOrEqualTo(18)
                        .WithMessage(ErrorMessages.TooSmallAge))
                .For(@object)
                .Validate();
                        
	}
}