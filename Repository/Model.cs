using System;
using System.Collections.Generic;

using Repository.Framework;

namespace Repository
{
    public abstract class Model : IModel
    {
        public Model()
        {
        }

        public virtual void Validate()
        {
        }
    }

    public abstract class Model<TKey> : IModel<TKey>
        where TKey : IKey
    {
        protected TKey key;

        public TKey Key { get { return this.key; } }

        public Model(TKey key)
        {
            this.key = key;
        }

        public virtual void Validate()
        {
        }
    }
}
