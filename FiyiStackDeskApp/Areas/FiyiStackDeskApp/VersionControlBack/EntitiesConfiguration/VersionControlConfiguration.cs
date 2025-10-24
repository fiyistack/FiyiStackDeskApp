using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.VersionControlBack.Entities;

/*
 * 
 * Coded by fiyistack.com
 * Copyright © 2025
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.VersionControlBack.EntitiesConfiguration
{
    public class VersionControlConfiguration : IEntityTypeConfiguration<VersionControl>
    {
        public void Configure(EntityTypeBuilder<VersionControl> entity)
        {
            try
            {
                //VersionControlId
                entity.HasKey(e => e.VersionControlId);
                entity.Property(e => e.VersionControlId)
                    .ValueGeneratedOnAdd();

                //DateTimeCreation
                entity.Property(e => e.DateTimeCreation)
                    .HasColumnType("datetime")
                    .IsRequired(true);

                //DateTimeLastModification
                entity.Property(e => e.DateTimeLastModification)
                    .HasColumnType("datetime")
                    .IsRequired(true);

                //UserCreationId
                entity.Property(e => e.UserCreationId)
                    .HasColumnType("int")
                    .IsRequired(true);

                //UserLastModificationId
                entity.Property(e => e.UserLastModificationId)
                    .HasColumnType("int")
                    .IsRequired(true);

                //VersionNumber
                entity.Property(e => e.VersionNumber)
                    .HasColumnType("numeric(18, 2)")
                    .IsRequired(true);

                
            }
            catch (Exception) { throw; }
        }
    }
}
