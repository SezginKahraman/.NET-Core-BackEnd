using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; } //get sadece okunabilir demek //settrlar yazmak
        string Message { get; }

    }
}
