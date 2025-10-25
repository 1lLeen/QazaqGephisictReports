using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Interfaces.Repositories;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

    protected QazaqGeoReportContext _context;
    protected DbSet<User> _dbSet;
    public UserRepository(QazaqGeoReportContext context)
    {
        _context = context;
        _dbSet = _context.Set<User>();
    }
    public async Task<List<User>> GetAllAsync()
    {
        var res = await _dbSet.ToListAsync();
        return res;
    }
    public async Task<User> CreateAsync(User model)
    {
        model.CreatedTime = DateTime.UtcNow;
        model.UpdatedTime = DateTime.UtcNow;

        await _dbSet.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }
    public async Task<User> DeleteAsync(string id)
    {
        var model = await GetUserByIdAsync(id);
        _dbSet.Remove(model);
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<User> UpdateAsync(User model)
    {
        model.UpdatedTime = DateTime.UtcNow;
        var local = _context.Set<User>()
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

    public async Task<User> GetByFullNameAsync(string fullname) => await _dbSet.FirstOrDefaultAsync(x => x.FullName == fullname);
    
    public async Task<User> GetUserByIdAsync(string id) => await _dbSet.FirstOrDefaultAsync(x => x.Id.Contains(id));

    public async Task<User> GetUserByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<User> GetUserByFirstNameAsync(string firstName) => await _context.Users.FirstOrDefaultAsync(x => x.FirstName == firstName);

    public async Task<User> GetUserByLastNameAsync(string lastName) => await _context.Users.FirstOrDefaultAsync(x => x.LastName == lastName);

    public async Task<User> GetUserByMiddleNameAsync(string middleName) => await _context.Users.FirstOrDefaultAsync(x => x.MiddleName== middleName);

    public async Task<User> GetUserByPhoneAsync(string phone) => await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phone);

}
