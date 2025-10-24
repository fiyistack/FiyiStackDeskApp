using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Entities;

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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.EntitiesConfiguration
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> entity)
        {
            try
            {
                //TableId
                entity.HasKey(e => e.TableId);
                entity.Property(e => e.TableId)
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

                //DataBaseId
                entity.Property(e => e.DataBaseId)
                    .HasColumnType("int")
                    .IsRequired(true);

                //Name
                entity.Property(e => e.Name)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);

                //Scheme
                entity.Property(e => e.Scheme)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);

                //Area
                entity.Property(e => e.Area)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);

                //Version
                entity.Property(e => e.Version)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);

                
            }
            catch (Exception) { throw; }
        }
    }
}
