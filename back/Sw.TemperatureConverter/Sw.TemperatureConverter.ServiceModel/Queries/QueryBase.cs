using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sw.TemperatureConverter.ServiceModel.Queries
{
    public abstract class QueryBase<TResult> : IRequest<TResult> where TResult : class
    {

    }
}
