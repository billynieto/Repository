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
        bool Exists(TKey key, IDbTransaction transaction);
        IEnumerable<TKey> Exists(IEnumerable<TKey> keys);
        IEnumerable<TKey> Exists(IEnumerable<TKey> keys, IDbTransaction transaction);
        IEnumerable<TModel> Find(TMultipleSearch search);
        IEnumerable<TModel> Find(TMultipleSearch search, IDbTransaction transaction);
        TModel FindSingle(TSingleSearch search);
        TModel FindSingle(TSingleSearch search, IDbTransaction transaction);
        void Save(TModel model, IDbTransaction transaction);
        void Save(IEnumerable<TModel> models, IDbTransaction transaction);
    }
}
