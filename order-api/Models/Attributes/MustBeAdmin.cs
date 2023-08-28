using System;

namespace order_api.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MustBeAdmin : Attribute
    { 

    }
}
