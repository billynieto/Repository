using System;
using System.Collections;

namespace Repository.Framework
{
    public interface IKey : IComparable
    {
        void Validate();
    }
}
