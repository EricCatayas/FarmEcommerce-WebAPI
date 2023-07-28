using System;

namespace FarmEcommerce.Core.Common.Exceptions;

public class DataNotFoundException<T> : Exception
{
    public DataNotFoundException(int Id) : base($"No {nameof(T)} found with id {Id}")
    {
    }
}
