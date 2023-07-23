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
	public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData(
				new IdentityRole
				{
					Id = "37470a99-4000-4e22-bde2-970e3acd9a5c",
					Name = "Admin",
					NormalizedName = "ADMIN"
				},
				new IdentityRole
				{
					Id = "cda07e2d-3d8e-4a54-ac3e-0ac233dfb3b6",
					Name = "Examiner",
					NormalizedName = "EXAMINER"
				},
				
				new IdentityRole
				{
					Id = "561ebda5-541c-48b9-9e1a-e47e9e0ca044",
					Name = "Invigilator",
					NormalizedName = "INVIGILATOR"
				},
				new IdentityRole
				{
					Id = "dabe93bd-b0d7-4031-91e8-81296292277d",
					Name = "Account",
					NormalizedName = "ACCOUNT"
				}
			);
		}
	}
}
