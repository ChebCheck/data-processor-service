using DataProcessor.Entities;
using DataProcessor.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataProcessor.Repositories;

public class ModulelStatusRepository : IRepository<ModuleStatusEntity>
{
    private readonly ApplicationContext _context;
    private readonly DbSet<ModuleStatusEntity> _set;

    public ModulelStatusRepository(ApplicationContext context)
    {
        _context = context;
        _set = context.ModuleStates;
    }

    public async Task<ModuleStatusEntity> Create(ModuleStatusEntity entity)
    {
        var ent = await Get(entity.ModuleCategoryID);
        if(ent == null)
        {
            _set.Add(entity);
            await _context.SaveChangesAsync();
        }
        else
        {
            await Update(entity);
        }
        
        return entity;
    }

    public async Task Delete(string id)
    {
        var entity = await Get(id);
        if (entity != null)
        {
            _set.Remove(entity);
            await _context.SaveChangesAsync();
        }        
    }

    public async Task<ModuleStatusEntity?> Get(string id)
    {
        return await _set.FirstOrDefaultAsync(e => e.ModuleCategoryID == id);
    }

    public async Task<IEnumerable<ModuleStatusEntity>> GetAll()
    {
        return await _set.ToListAsync();
    }

    public async Task<ModuleStatusEntity> Update(ModuleStatusEntity entity)
    {
        var ent = await Get(entity.ModuleCategoryID);
        
        if (ent == null)
            throw new Exception();
        
        ent.ModuleState = entity.ModuleState;

        await _context.SaveChangesAsync();
        return entity;
    }
}
