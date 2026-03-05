using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CraeteRole;

public sealed class CreateRoleCommadValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommadValidator()
    {
        RuleFor(p => p.Code).NotEmpty().WithMessage("Role kodu boş olamaz!");
        RuleFor(p => p.Code).NotNull().WithMessage("Role kodu boş olamaz!");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Role adı boş olamaz!");
        RuleFor(p => p.Name).NotNull().WithMessage("Role adı boş olamaz!");
    }
}
