using System;
using System.Collections.Generic;
using System.Data;

namespace Repository.Framework
{
    public interface IService<TModel, TSingleSearch, TMultipleSearch>
        where TModel : IModel
        where TSingleSearch : ISingleSearch
        where TMultipleSearch : IMultipleSearch
    {
        IEnumerable<TModel> Find(TMultipleSearch search);
        TModel FindSingle(TSingleSearch search);
    }

    public interface IService<TModel, TKey, TSingleSearch, TMultipleSearch>
        where TKey : IKey
        where TModel : IModel<TKey>
        where TSingleSearch : ISingleSearch
        where TMultipleSearch : IMultipleSearch
    {
        void Delete(TKey key, IDbTransaction transaction);
        void Delete(IEnumerable<TKey> keys, IDbTransaction transaction);
        bool Exists(TKey key);
        IEnumerable<TKey> Exists(IEnumerable<TKey> keys);
        IEnumerable<TModel> Find(TMultipleSearch search);
        TModel FindSingle(TSingleSearch search);
        void Save(TModel model, IDbTransaction transaction);
        void Save(IEnumerable<TModel> models, IDbTransaction transaction);
    }
}
