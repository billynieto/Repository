using System;

namespace Repository.Framework
{
    public interface IModel
    {
        void Validate();
    }

    public interface IModel<TKey>
        where TKey : IKey
    {
        TKey Key { get; }

        void Validate();
    }
}
