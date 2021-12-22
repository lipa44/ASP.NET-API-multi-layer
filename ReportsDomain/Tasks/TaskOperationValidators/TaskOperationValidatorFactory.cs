using ReportsDomain.Tasks.TaskOperationValidators.Abstractions;
using ReportsDomain.Tools;

namespace ReportsDomain.Tasks.TaskOperationValidators;

public class TaskOperationValidatorFactory : ITaskOperationValidatorFactory
{
    public ITaskOperationValidator CreateValidator(ReportsTask reportsTask)
        => reportsTask.State switch
        {
            Enums.TaskStates.Open => new OpenTaskOperationValidator(),
            Enums.TaskStates.Active => new ActiveTaskOperationValidator(),
            Enums.TaskStates.Resolved => new ResolvedTaskOperationValidator(),
            _ => throw new ReportsException("Task state unrecognized")
        };
}