using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class AuctionDBCOntext : DbContext
{
    public AuctionDBCOntext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Auction> Auctions {get; set;}
}