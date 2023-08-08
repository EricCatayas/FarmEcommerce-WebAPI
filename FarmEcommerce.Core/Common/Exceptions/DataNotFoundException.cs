using System;

namespace FarmEcommerce.Core.Common.Exceptions;

public class DataNotFoundException : Exception 
{
    public DataNotFoundException(int Id) : base($"No resource found with id {Id}")
    {
    }
    public DataNotFoundException(Type type, int Id) : base($"No {type.Name} found with id {Id}")
    {
    }
}

