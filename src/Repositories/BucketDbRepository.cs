using AlphabetUpdateServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlphabetUpdateServer.Repositories;

public class BucketDbRepository : IBucketRepository
{
    private readonly ApplicationDbContext _context;

    public BucketDbRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async ValueTask<BucketEntity?> FindBucketById(string bucketId)
    {
        return await _context.Buckets.FindAsync(bucketId);   
    }

    public async ValueTask<IEnumerable<BucketEntity>> GetAllBuckets()
    {
        return await _context.Buckets.ToListAsync();
    }
}