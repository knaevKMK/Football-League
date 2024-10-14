namespace Application.BoundedContexts.FootballMatches.Commands
{

    using FluentAssertions;
    using FluentValidation;

    public class CreateFootballMatchCommandValidator : AbstractValidator<CreateFootballMatchCommand>
    {
        public CreateFootballMatchCommandValidator()
        {
            RuleFor(cmd => cmd)
               .Must(cmd => cmd.HomeTeamId != cmd.GuestTeamId)
               .WithMessage("Home team ID and guest team ID must be different.");

            RuleFor(cmd => cmd.HomeTeamId)
               .NotEqual(Guid.Empty)
               .WithMessage("Home team ID must be a valid GUID.") ;

            RuleFor(cmd => (int)cmd.HomeTeamGoals)
               .InclusiveBetween(0, 255)
               .WithMessage("Home team goals must be a non-negative number.");

            RuleFor(cmd => cmd.GuestTeamId)
             .NotEqual(Guid.Empty)
             .WithMessage("Guest team ID must be a valid GUID.");
 
            RuleFor(cmd => (int)cmd.GuestTeamGoals)
             .InclusiveBetween(0, 255)
             .WithMessage("Guest team goals must be a non-negative number.");
        }
    }
}
