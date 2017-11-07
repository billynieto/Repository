using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Repository.Framework;

namespace Repository
{
    public abstract class ServiceBase<TModel, TKey, TSingleSearch, TMultipleSearch> : IService<TModel, TKey, TSingleSearch, TMultipleSearch>
        where TKey : IKey
        where TModel : IModel<TKey>
        where TSingleSearch : ISingleSearch
        where TMultipleSearch : IMultipleSearch
    {
        protected IRepository<TModel, TKey, TSingleSearch, TMultipleSearch> repository;

        public ServiceBase(IRepository<TModel, TKey, TSingleSearch, TMultipleSearch> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("Repository");

            this.repository = repository;
        }

        public virtual void Delete(TKey key, IDbTransaction transaction)
        {
            if (key == null)
                throw new ArgumentNullException("Key");

            Delete(new List<TKey>() { key }, transaction);
        }

        public virtual void Delete(IEnumerable<TKey> keys, IDbTransaction transaction)
        {
            if (keys == null)
                throw new ArgumentNullException("Keys");

            bool iOpenedTheConnection = false;
            bool iStartedTheTransaction = false;

            try
            {
                if (!this.repository.IsOpen)
                {
                    this.repository.Open();
                    
                    iOpenedTheConnection = true;

                    if (!this.repository.IsOpen)
                        throw new Exception("The Repository is not reporting being Opened after we opened it!");
                }

                if (transaction == null)
                {
                    transaction = this.repository.StartTransaction();

                    iStartedTheTransaction = true;
                }

                IEnumerable<TKey> savedKeys = new List<TKey>(Exists(keys, transaction));
                IEnumerable<TKey> notSavedKeys = keys.Where(_key => !savedKeys.Any(_savedKey => _savedKey.Equals(_key))).ToList();

                if (notSavedKeys.Count() > 0)
                {
                    string spacer = "; ";

                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (TKey key in notSavedKeys)
                        stringBuilder.Append(key.ToString()).Append(spacer);

                    string error = stringBuilder.Remove(stringBuilder.Length - spacer.Length, spacer.Length).ToString();

                    throw new KeyNotFoundException(error);
                }

                this.repository.Delete(keys, transaction);

                if (iStartedTheTransaction)
                    transaction.Commit();
            }
            catch (Exception ex)
            {
                if (iStartedTheTransaction)
                    transaction.Rollback();

                throw ex;
            }
            finally
            {
                if (iOpenedTheConnection)
                    this.repository.Close();

                if (iStartedTheTransaction)
                    transaction.Dispose();
            }
        }

        public virtual bool Exists(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key");

            bool iOpenedConnection = false;

            try
            {
                if (!this.repository.IsOpen)
                {
                    iOpenedConnection = true;

                    this.repository.Open();
                }

                return this.repository.Exists(key);
            }
            finally
            {
                if (iOpenedConnection)
                    this.repository.Close();
            }
        }

        public virtual bool Exists(TKey key, IDbTransaction transaction)
        {
            if (key == null)
                throw new ArgumentNullException("Key");

            bool iOpenedConnection = false;

            try
            {
                if (!this.repository.IsOpen)
                {
                    iOpenedConnection = true;

                    this.repository.Open();
                }

                return this.repository.Exists(key, transaction);
            }
            finally
            {
                if (iOpenedConnection)
                    this.repository.Close();
            }
        }

        public virtual IEnumerable<TKey> Exists(IEnumerable<TKey> keys)
        {
            if (keys == null)
                throw new ArgumentNullException("Keys");

            bool iOpenedConnection = false;

            try
            {
                if (!this.repository.IsOpen)
                {
                    iOpenedConnection = true;

                    this.repository.Open();
                }

                return this.repository.Exists(keys);
            }
            finally
            {
                if (iOpenedConnection)
                    this.repository.Close();
            }
        }

        public virtual IEnumerable<TKey> Exists(IEnumerable<TKey> keys, IDbTransaction transaction)
        {
            if (keys == null)
                throw new ArgumentNullException("Keys");

            bool iOpenedConnection = false;

            try
            {
                if (!this.repository.IsOpen)
                {
                    iOpenedConnection = true;

                    this.repository.Open();
                }

                return this.repository.Exists(keys, transaction);
            }
            finally
            {
                if (iOpenedConnection)
                    this.repository.Close();
            }
        }

        public virtual IEnumerable<TKey> ExtractKeys(IEnumerable<TModel> models)
        {
            if (models == null)
                throw new ArgumentNullException("Models");

            return models.Select(_model => _model.Key);
        }

        public virtual IEnumerable<TModel> ExtractModels(IEnumerable<TModel> models, IEnumerable<TKey> keys)
        {
            if (keys == null)
                throw new ArgumentNullException("Keys");
            if (models == null)
                throw new ArgumentNullException("Models");

            return models.Where(_model => keys.Any(_key => _key.Equals(_model.Key)));
        }

        public virtual IEnumerable<TModel> Find(TMultipleSearch search)
        {
            if (search == null)
                throw new ArgumentNullException("Search");
            search.Validate();

            bool iOpenedConnection = false;

            try
            {
                if (!this.repository.IsOpen)
                {
                    iOpenedConnection = true;

                    this.repository.Open();

                    if (!this.repository.IsOpen)
                        throw new Exception("The Repository is not reporting being Opened after we opened it!");
                }

                return this.repository.Select(search);
            }
            finally
            {
                if (iOpenedConnection)
                    this.repository.Close();
            }
        }

        public virtual IEnumerable<TModel> Find(TMultipleSearch search, IDbTransaction transaction)
        {
            if (search == null)
                throw new ArgumentNullException("Search");
            search.Validate();

            bool iOpenedConnection = false;

            try
            {
                if (!this.repository.IsOpen)
                {
                    iOpenedConnection = true;

                    this.repository.Open();

                    if (!this.repository.IsOpen)
                        throw new Exception("The Repository is not reporting being Opened after we opened it!");
                }

                return this.repository.Select(search, transaction);
            }
            finally
            {
                if (iOpenedConnection)
                    this.repository.Close();
            }
        }

        public virtual TModel FindSingle(TSingleSearch search)
        {
            if (search == null)
                throw new ArgumentNullException("Search");
            search.Validate();

            bool iOpenedConnection = false;

            try
            {
                if (!this.repository.IsOpen)
                {
                    iOpenedConnection = true;

                    this.repository.Open();

                    if (!this.repository.IsOpen)
                        throw new Exception("The Repository is not reporting being Opened after we opened it!");
                }

                return this.repository.Select(search);
            }
            finally
            {
                if (iOpenedConnection)
                    this.repository.Close();
            }
        }

        public virtual TModel FindSingle(TSingleSearch search, IDbTransaction transaction)
        {
            if (search == null)
                throw new ArgumentNullException("Search");
            search.Validate();

            bool iOpenedConnection = false;

            try
            {
                if (!this.repository.IsOpen)
                {
                    iOpenedConnection = true;

                    this.repository.Open();

                    if (!this.repository.IsOpen)
                        throw new Exception("The Repository is not reporting being Opened after we opened it!");
                }

                return this.repository.Select(search, transaction);
            }
            finally
            {
                if (iOpenedConnection)
                    this.repository.Close();
            }
        }

        public virtual void Save(TModel model, IDbTransaction transaction)
        {
            if (model == null)
                throw new ArgumentNullException("Model");

            bool iOpenedConnection = false;
            bool iOpenedTheTransaction = false;

            try
            {
                if (!this.repository.IsOpen)
                {
                    iOpenedConnection = true;

                    this.repository.Open();

                    if (!this.repository.IsOpen)
                        throw new Exception("The Repository is not reporting being Opened after we opened it!");
                }

                if (transaction == null)
                {
                    transaction = this.repository.StartTransaction();

                    iOpenedTheTransaction = true;
                }
                
                if (!Exists(model.Key, transaction))
                    this.repository.Insert(model, transaction);
                else
                    this.repository.Update(model, transaction);

                if (iOpenedTheTransaction)
                    transaction.Commit();
            }
            catch (Exception ex)
            {
                if (iOpenedTheTransaction)
                    transaction.Rollback();

                throw ex;
            }
            finally
            {
                if (iOpenedConnection)
                    this.repository.Close();

                if (iOpenedTheTransaction)
                    transaction.Dispose();
            }
        }

        public virtual void Save(IEnumerable<TModel> models, IDbTransaction transaction)
        {
            if (models == null)
                throw new ArgumentNullException("Models");
            foreach (TModel model in models)
                if (model == null)
                    throw new ArgumentNullException("Individual Model");
            foreach (TModel model in models)
                model.Validate();

            bool iOpenedConnection = false;
            bool iOpenedTheTransaction = false;

            try
            {
                if (!this.repository.IsOpen)
                {
                    iOpenedConnection = true;

                    this.repository.Open();

                    if (!this.repository.IsOpen)
                        throw new Exception("The Repository is not reporting being Opened after we opened it!");
                }

                if (transaction == null)
                {
                    transaction = this.repository.StartTransaction();

                    iOpenedTheTransaction = true;
                }

                IEnumerable<TKey> keys = ExtractKeys(models);

                IEnumerable<TKey> savedKeys = new List<TKey>(Exists(keys, transaction));
                IEnumerable<TKey> notSavedKeys = keys.Where(_key => !savedKeys.Any(_savedKey => _savedKey.Equals(_key))).ToList();

                if (notSavedKeys.Count() > 0)
                    this.repository.Insert(ExtractModels(models, notSavedKeys), transaction);

                if (savedKeys.Count() > 0)
                    this.repository.Update(ExtractModels(models, savedKeys), transaction);

                if (iOpenedTheTransaction)
                    transaction.Commit();
            }
            catch (Exception ex)
            {
                if (iOpenedTheTransaction)
                    transaction.Rollback();

                throw ex;
            }
            finally
            {
                if (iOpenedConnection)
                    this.repository.Close();

                if (iOpenedTheTransaction)
                    transaction.Dispose();
            }
        }
    }
}
