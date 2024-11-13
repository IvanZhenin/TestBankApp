using BankDataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace BankDataBase.Data
{
	public class BankDataContext : DbContext
	{
		public BankDataContext(DbContextOptions<BankDataContext> options) : base(options)
		{
		}

		public DbSet<Bank> Banks { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Transaction> Transactions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Bank>().HasKey(b => b.Id);

			modelBuilder.Entity<Account>(account =>
			{
				account.HasKey(a => a.Id);

				account.HasOne(a => a.Bank)
					.WithMany(b => b.Accounts)
					.HasForeignKey(a => a.BankId);
			});

			modelBuilder.Entity<Transaction>(transaction =>
			{
				transaction.HasKey(t => t.Id);

				transaction.HasOne(t => t.SenderAccount)
					.WithMany(a => a.Transactions)
					.HasForeignKey(t => t.SenderId);

				transaction.HasOne(t => t.RecipientAccount)
					.WithMany(a => a.Transactions)
					.HasForeignKey(t => t.RecipientId);
			});
		}
	}
}