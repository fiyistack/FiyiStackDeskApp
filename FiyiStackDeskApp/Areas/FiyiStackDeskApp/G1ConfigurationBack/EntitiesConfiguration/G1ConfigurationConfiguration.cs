using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Entities;

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * 
 * Coded by fiyistack.com
 * Copyright © 2025
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.EntitiesConfiguration
{
    public class G1ConfigurationConfiguration : IEntityTypeConfiguration<G1Configuration>
    {
        public void Configure(EntityTypeBuilder<G1Configuration> entity)
        {
            try
            {
                //ConfigurationId
                entity.HasKey(e => e.G1ConfigurationId);
                entity.Property(e => e.G1ConfigurationId)
                    .ValueGeneratedOnAdd();

                //Active
                entity.Property(e => e.Active)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

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

                //ProjectId
                entity.Property(e => e.ProjectId)
                    .HasColumnType("int")
                    .IsRequired(true);

                //WantCSharp
                entity.Property(e => e.WantCSharp)
                    .HasColumnType("tinyint")
                    .IsRequired(true);


                //WantMSSQLServer
                entity.Property(e => e.WantMSSQLServer)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                //DeleteTable
                entity.Property(e => e.DeleteTable)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                //DeleteField
                entity.Property(e => e.DeleteField)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                //DeleteFiles
                entity.Property(e => e.DeleteFiles)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                //WantDTO
                entity.Property(e => e.WantDTO)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                //WantEntity
                entity.Property(e => e.WantEntity)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                //WantEntityConfiguration
                entity.Property(e => e.WantEntityConfiguration)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                //WantInterfaces
                entity.Property(e => e.WantInterfaces)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                //WantRepository
                entity.Property(e => e.WantRepository)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                //WantBlazorPages
                entity.Property(e => e.WantBlazorPages)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                //WantService
                entity.Property(e => e.WantService)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                
            }
            catch (Exception) { throw; }
        }
    }
}
