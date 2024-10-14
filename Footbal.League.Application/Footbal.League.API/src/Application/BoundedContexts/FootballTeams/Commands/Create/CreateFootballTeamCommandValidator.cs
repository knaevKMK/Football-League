namespace Application.BoundedContexts.FootballTeams.Commands.Create
{

    using FluentValidation;

    public class CreateFootballTeamCommandValidator : AbstractValidator<CreateFootballTeamCommand>
    {
        public CreateFootballTeamCommandValidator()
        {
            RuleFor(cmd => cmd.Name)
              .NotEmpty()
              .WithMessage("Team Name required");
        }
    }
}
