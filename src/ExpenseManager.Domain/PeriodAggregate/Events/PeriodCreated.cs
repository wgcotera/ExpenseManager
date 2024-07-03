using ExpenseManager.Domain.Common.Models;

namespace ExpenseManager.Domain.PeriodAggregate.Events;
public record PeriodCreated(Period Period) : IDomainEvent;