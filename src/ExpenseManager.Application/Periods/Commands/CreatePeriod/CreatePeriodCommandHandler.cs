using ErrorOr;

using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.PeriodAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;
using ExpenseManager.Domain.Common.DomainErrors;

using MediatR;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;

namespace ExpenseManager.Application.Periods.Commands.CreatePeriod;
public class CreatePeriodCommandHandler : IRequestHandler<CreatePeriodCommand, ErrorOr<Period>>
{
    private readonly IPeriodRepository _periodRepository;
    private readonly IUserRepository _userRepository;

    public CreatePeriodCommandHandler(IPeriodRepository periodRepository, IUserRepository userRepository)
    {
        _periodRepository = periodRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Period>> Handle(CreatePeriodCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var user = _userRepository.GetUserById(UserId.Create(command.UserId));
        if (user is null)
        {
            return Errors.User.NotFound;
        }

        Period period = Period.Create(
            userId: UserId.Create(command.UserId),
            startDate: command.StartDate,
            endDate: command.EndDate
        );

        // Persist the period
        _periodRepository.Add(period);

        // Update the user with the new period
        user.AddPeriodId((PeriodId)period.Id);
        _userRepository.UpdateUser(user);

        // Return the period
        return period;
    }
}