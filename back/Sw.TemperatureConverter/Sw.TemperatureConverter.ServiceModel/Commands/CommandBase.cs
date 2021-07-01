using MediatR;

namespace Sw.TemperatureConverter.ServiceModel.Commands
{
    public class CommandBase<T> : IRequest<T> where T : class
    {
    }
}
