using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SmartOrganizer.Timetable.DataAccess
{
	public class TimetableContextFactory : IDesignTimeDbContextFactory<TimetableContext>
	{
		//  private IConfiguration _configuration;
		public TimetableContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<TimetableContext>();
			// TODO: move connection string into configuration file
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TimetableDB;Trusted_Connection=True;");

			return new TimetableContext(optionsBuilder.Options);
		}
	}
}
