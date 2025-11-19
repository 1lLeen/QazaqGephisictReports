using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Application.Interfaces.Repositories;
using System.Linq.Expressions;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class AbstractRepository<TModel> : IAbstractRepository<TModel> where TModel : BaseEntity
{
    protected QazaqGeoReportContext _context;
    protected DbSet<TModel> _dbSet;
    public AbstractRepository(QazaqGeoReportContext context)
    {
        _context = context;
        _dbSet = _context.Set<TModel>();
    }
    public async Task<TModel> CreateAsync(TModel model)
    {
        model.CreatedTime = DateTime.UtcNow;
        model.UpdatedTime = DateTime.UtcNow;

        await _dbSet.AddAsync(model);    
        await _context.SaveChangesAsync();
        return model;
    }
    public async Task<TModel> DeleteAsync(int id)
    {
        var model = await GetByIdAsync(id);
        _dbSet.Remove(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<List<TModel>> GetAllAsync()
    {
        var res = await _dbSet.AsNoTracking().ToListAsync();
        return res;
    }

    public async Task<TModel?> GetAsync(Expression<Func<TModel, bool>> predicate)
    {
        return await _dbSet
        .AsNoTracking()
        .FirstOrDefaultAsync(predicate);
    }

    public async Task<TModel> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TModel> UpdateAsync(TModel model)
    {
        model.UpdatedTime = DateTime.UtcNow;
        var local = _context.Set<TModel>()
            .Local
            .FirstOrDefault(entry => entry.Id.Equals(model.Id));
        if (local != null)
        {
            _context.Entry(local).State = EntityState.Detached;
        }
        var entry = _context.Entry(model);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return model;

    }
}