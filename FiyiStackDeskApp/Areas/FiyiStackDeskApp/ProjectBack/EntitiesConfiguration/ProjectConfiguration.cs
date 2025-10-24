using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Entities;

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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.EntitiesConfiguration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> entity)
        {
            try
            {
                //ProjectId
                entity.HasKey(e => e.ProjectId);
                entity.Property(e => e.ProjectId)
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

                //Name
                entity.Property(e => e.Name)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);

                //HistoryUser
                entity.Property(e => e.HistoryUser)
                    .HasColumnType("varchar(MAX)")
                    .IsRequired(false);

                //Path
                entity.Property(e => e.Path)
                    .HasColumnType("varchar(8000)")
                    .IsRequired(false);

                //ConfigurationTypeId
                entity.Property(e => e.ConfigurationTypeId)
                    .HasColumnType("int")
                    .IsRequired(true);
            }
            catch (Exception) { throw; }
        }
    }
}
