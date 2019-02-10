/*
using Domain.Generals;
using Domain.Identity;
using FluentValidation;
using Framework.NetStd.Validators;

public class UserValidator : ValidatorGeneric<User>
{
    public UserValidator()
    {
        ValidateName();
        ValidateEmail();
        ValidateLogin();
        ValidatePassword();

     }


    protected void ValidateName()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Please ensure you have entered the Name")
            .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
    }


    protected void ValidateEmail()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress();
    }

    protected void ValidateLogin()
    {
        RuleFor(c => c.Login)
            .NotEmpty().WithMessage("Please ensure you have entered the login");
    }

    protected void ValidatePassword()
    {
        RuleFor(c => c.Password)
            .NotEmpty().WithMessage("Please ensure you have entered the Passord")
            .MinimumLength(6).WithMessage("The Password must have mminimum 6 characters");
    }


}
*/