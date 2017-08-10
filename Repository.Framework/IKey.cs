using System;

namespace Repository.Framework
{
    public interface IKey : IComparable
    {
        void Validate();
    }
}
