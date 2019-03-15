using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface INestedService
    {
        IMyService ChildService { get; }
    }
}
