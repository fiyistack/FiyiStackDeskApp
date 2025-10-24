using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FiyiStackDeskApp.Areas.System.FailureBack.Entities;

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

namespace FiyiStackDeskApp.Areas.System.FailureBack.EntitiesConfiguration
{
    public class FailureConfiguration : IEntityTypeConfiguration<Failure>
    {
        public void Configure(EntityTypeBuilder<Failure> entity)
        {
            try
            {
                //FailureId
                entity.HasKey(e => e.FailureId);
                entity.Property(e => e.FailureId)
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

                //Message
                entity.Property(e => e.Message)
                    .HasColumnType("varchar(MAX)")
                    .IsRequired(false);

                //StackTrace
                entity.Property(e => e.StackTrace)
                    .HasColumnType("varchar(MAX)")
                    .IsRequired(false);

                //Source
                entity.Property(e => e.Source)
                    .HasColumnType("varchar(MAX)")
                    .IsRequired(false);

                
            }
            catch (Exception) { throw; }
        }
    }
}
