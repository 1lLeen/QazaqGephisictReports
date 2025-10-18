﻿using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Domain.Interfaces.Services;
public interface IAbstractService<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(int id);
}
