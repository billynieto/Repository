using System;
using System.Collections.Generic;
using System.Data;

namespace Repository.Framework
{
    public interface IRepository<TModel, TSingleSearch, TMultipleSearch>
        where TModel : IModel
        where TSingleSearch : ISingleSearch
        where TMultipleSearch : IMultipleSearch
    {
        bool IsOpen { get; }
        ConnectionState State { get; }

        void Close();
        void Open();
        IEnumerable<TModel> Select(TMultipleSearch search);
        TModel Select(TSingleSearch search);
    }

    public interface IRepository<TModel, TKey, TSingleSearch, TMultipleSearch>
        where TKey : IKey
        where TModel : IModel<TKey>
        where TSingleSearch : ISingleSearch
        where TMultipleSearch : IMultipleSearch
    {
        bool IsOpen { get; }
        ConnectionState State { get; }

        void Close();
        void Delete(TKey id, IDbTransaction transaction);
        void Delete(IEnumerable<TKey> ids, IDbTransaction transaction);
        bool Exists(TKey id);
        IEnumerable<TKey> Exists(IEnumerable<TKey> ids);
        void Insert(TModel model, IDbTransaction transaction);
        void Insert(IEnumerable<TModel> models, IDbTransaction transaction);
        void Open();
        IEnumerable<TModel> Select(TMultipleSearch search);
        TModel Select(TSingleSearch search);
        IDbTransaction StartTransaction();
        void Update(TModel model, IDbTransaction transaction);
        void Update(IEnumerable<TModel> models, IDbTransaction transaction);
    }
}
