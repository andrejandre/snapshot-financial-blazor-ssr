using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Text.Json;

namespace SnapshotFinancial.Data;

public enum RecordType
{
    Asset,
    Liability
}

public class NetworthRecord
{
    public int Id { get; set; }
    public RecordType Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Status { get; set; } = "Active";
    public decimal Amount { get; set; }
    public string? Notes { get; set; }
}

public class NetworthService
{
    private readonly NetworthDbContext _dbContext;

    public NetworthService(NetworthDbContext dbContext)
    {
        _dbContext = dbContext;

        // Ensure database is created
        _dbContext.Database.EnsureCreated();
    }

    public async Task<List<NetworthRecord>> GetAllRecordsAsync()
    {
        return await _dbContext.NetworthRecords.ToListAsync();
    }

    public async Task<(List<NetworthRecord>, int)> GetPaginatedRecordsAsync(int page, int pageSize, string sortColumn, bool isAscending)
    {
        var query = _dbContext.NetworthRecords.AsQueryable();

        // Apply sorting
        if (!string.IsNullOrEmpty(sortColumn))
        {
            query = isAscending ? query.OrderBy(e => EF.Property<object>(e, sortColumn)) :
                                  query.OrderByDescending(e => EF.Property<object>(e, sortColumn));
        }

        int totalRecords = await query.CountAsync(); // Get total record count

        var records = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (records, totalRecords);
    }


    public async Task AddRecordAsync(NetworthRecord newRecord)
    {
        newRecord.Id = 0; // Let SQLite auto-generate ID
        await _dbContext.NetworthRecords.AddAsync(newRecord);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRecordAsync(int id)
    {
        var record = await _dbContext.NetworthRecords.FindAsync(id);
        if (record != null)
        {
            _dbContext.NetworthRecords.Remove(record);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateRecordAsync(NetworthRecord updatedRecord)
    {
        var existingRecord = _dbContext.NetworthRecords.Find(updatedRecord.Id);

        if (existingRecord == null)
        {
            throw new InvalidOperationException("Record not found in database.");
        }

        _dbContext.Entry(existingRecord).CurrentValues.SetValues(updatedRecord);

        await _dbContext.SaveChangesAsync();
    }

}