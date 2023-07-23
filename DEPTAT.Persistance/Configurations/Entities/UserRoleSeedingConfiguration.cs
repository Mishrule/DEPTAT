using DEPTAT.Application.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Persistance.Configurations.Entities
{
	public class UserRoleSeedingConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			var hasher = new PasswordHasher<ApplicationUser>();
			builder.HasData(
				new ApplicationUser
				{
					Id = "a38e1209-6272-4bc7-9cc4-e24bacc41f1d",
					Email = "admin@localhost.com",
					NormalizedEmail = "ADMIN@LOCALHOST.COM",
					FirstName = "System",
					LastName = "Admin",
					UserName = "admin",
					NormalizedUserName = "ADMIN",
					PasswordHash = hasher.HashPassword(null, "Password@1")
				},
				new ApplicationUser
				{
					Id = "f2712948-06b5-411f-b0e6-24304dc31761",
					Email = "examiner@localhost.com",
					NormalizedEmail = "EXAMINER@LOCALHOST.COM",
					FirstName = "System",
					LastName = "examiner",
					UserName = "examiner",
					NormalizedUserName = "EXAMINER",
					PasswordHash = hasher.HashPassword(null, "Examiner@123")
				},
			new ApplicationUser
				{
					Id = "c63a3909-a67b-43e0-8c6b-6fa6ee1704c8",
					Email = "invigilator@localhost.com",
					NormalizedEmail = "INVIGILATOR@LOCALHOST.COM",
					FirstName = "System",
					LastName = "Invigilator",
					UserName = "Invigilator",
					NormalizedUserName = "INVIGILATOR",
					PasswordHash = hasher.HashPassword(null, "Invigilator@123")
				},
				new ApplicationUser
				{
					Id = "e5390aff-7fab-4634-b700-2abe65cf016d",
					Email = "account@localhost.com",
					NormalizedEmail = "ACCOUNT@LOCALHOST.COM",
					FirstName = "System",
					LastName = "account",
					UserName = "account",
					NormalizedUserName = "ACCOUNT",
					PasswordHash = hasher.HashPassword(null, "Account@123")
				}
			);
		}
	}
}
