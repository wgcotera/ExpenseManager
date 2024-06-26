using ExpenseManager.Application.RecurringTransactionConfigurations.Commands;
using ExpenseManager.Contracts.RecurringTransactionConfiguration;
using ExpenseManager.Domain.Common.Enum;
using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate;
using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate.ValueObjects;

using Mapster;

namespace ExpenseManager.Api.Common.Mapping;

public class RecurringTransactionMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateRecurringTransactionConfigurationRequest Request, string UserId), 
                CreateRecurringTransactionConfigurationCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.TransactionType, src => TransactionType.FromName(src.Request.TransactionType))
            .Map(dest => dest.Frequency, src => Frequency.FromName(src.Request.Frequency))
            .Map(dest => dest, src => src.Request);
        
        config.NewConfig<RecurringTransactionConfiguration, RecurringTransactionConfigurationResponse>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.UserId, src => src.UserId.Value.ToString())
            .Map(dest => dest.TransactionType, src => src.TransactionType.Name)
            .Map(dest => dest.Frequency, src => src.Frequency.Name);


    }
}