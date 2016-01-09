using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AcklenAveJobApp.Entities;
using AcklenAveJobApp.Interfaces;
using AcklenAveJobApp.Context;
using Ninject.Infrastructure.Language;

namespace AcklenAveJobApp.Repositories
{
    public class SecretPayloadRepository : ISecretPayloadRepository
    {
        private readonly DataBaseContext _ctx;

        public SecretPayloadRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }

        public SecretPayload Get(long id)
        {
            return _ctx.Secrets.FirstOrDefault(x => x.Id == id);
        }

        public SecretPayload Create(SecretPayload itemToCreate)
        {
            var toReturn = _ctx.Secrets.Add(itemToCreate);
            _ctx.SaveChanges();
            return toReturn;
        }

        public IQueryable<SecretPayload> Query(Expression<Func<SecretPayload, SecretPayload>> expression)
        {
            return _ctx.Secrets.Select(expression);
        }

        public IQueryable<SecretPayload> Filter(Expression<Func<SecretPayload, bool>> expression)
        {
            return _ctx.Secrets.Where(expression);
        }

        public SecretPayload Update(SecretPayload itemToUpdate)
        {
            _ctx.Entry(itemToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return itemToUpdate;
        }

        public SecretPayload Delete(long id)
        {
            var toDelete = Get(id);
            _ctx.Secrets.Remove(toDelete);
            _ctx.SaveChanges();
            return toDelete;
        }

        public SecretPayload Delete(SecretPayload toDelete)
        {
            _ctx.Secrets.Remove(toDelete);
            _ctx.SaveChanges();
            return toDelete;
        }

        public IEnumerable<SecretPayload> GetAllPayloads()
        {
            return _ctx.Secrets.ToEnumerable();
        }
    }
}