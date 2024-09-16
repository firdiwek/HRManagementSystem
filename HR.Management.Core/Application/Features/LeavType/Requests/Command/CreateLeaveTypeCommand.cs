// Application/Commands/CreateLeaveTypeCommand.cs
using MediatR;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int DefaultDays { get; set; }
}
