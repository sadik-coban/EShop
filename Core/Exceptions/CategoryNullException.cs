using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions;
public class CategoryNullException : ArgumentNullException
{
    public CategoryNullException(string paramName)
    : base(paramName, "Category cannot be null.")
    {
    }

    public CategoryNullException(string paramName, string message)
        : base(paramName, message)
    {
    }
}
