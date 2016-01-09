using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AcklenAveJobApp.Entities;

namespace AcklenAveJobApp.Interfaces
{
    public interface ISecretPayloadRepository
    {
        SecretPayload Get(long id);
        SecretPayload Create(SecretPayload itemToCreate);
        IQueryable<SecretPayload> Query(Expression<Func<SecretPayload, SecretPayload>> expression);
        IQueryable<SecretPayload> Filter(Expression<Func<SecretPayload, bool>> expression);
        SecretPayload Update(SecretPayload itemToUpdate);
        SecretPayload Delete(long id);
        SecretPayload Delete(SecretPayload grade);
        IEnumerable<SecretPayload> GetAllPayloads();
    }
}
