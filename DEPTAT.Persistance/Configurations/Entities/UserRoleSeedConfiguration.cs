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
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "37470a99-4000-4e22-bde2-970e3acd9a5c",
                    UserId = "a38e1209-6272-4bc7-9cc4-e24bacc41f1d" //--Admin
                },
                new IdentityUserRole<string>
                {
                    RoleId = "cda07e2d-3d8e-4a54-ac3e-0ac233dfb3b6", //--Examina
                    UserId = "f2712948-06b5-411f-b0e6-24304dc31761"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "561ebda5-541c-48b9-9e1a-e47e9e0ca044", //--Invigilator
                    UserId = "c63a3909-a67b-43e0-8c6b-6fa6ee1704c8"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "dabe93bd-b0d7-4031-91e8-81296292277d", //--Account
                    UserId = "e5390aff-7fab-4634-b700-2abe65cf016d"
                }
            );
        }
    }
}
