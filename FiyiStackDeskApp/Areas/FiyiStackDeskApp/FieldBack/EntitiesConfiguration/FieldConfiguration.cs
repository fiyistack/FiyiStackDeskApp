using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Entities;

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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.EntitiesConfiguration
{
    public class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> entity)
        {
            try
            {
                //FieldId
                entity.HasKey(e => e.FieldId);
                entity.Property(e => e.FieldId)
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

                //TableId
                entity.Property(e => e.TableId)
                    .HasColumnType("int")
                    .IsRequired(true);

                //DataTypeId
                entity.Property(e => e.DataTypeId)
                    .HasColumnType("int")
                    .IsRequired(true);

                //Name
                entity.Property(e => e.Name)
                    .HasColumnType("varchar(100)")
                    .IsRequired(false);

                //Nullable
                entity.Property(e => e.Nullable)
                    .HasColumnType("tinyint")
                    .IsRequired(true);

                //HistoryUser
                entity.Property(e => e.HistoryUser)
                    .HasColumnType("varchar(MAX)")
                    .IsRequired(false);

                //Regex
                entity.Property(e => e.Regex)
                    .HasColumnType("varchar(MAX)")
                    .IsRequired(false);

                //MinValue
                entity.Property(e => e.MinValue)
                    .HasColumnType("varchar(MAX)")
                    .IsRequired(false);

                //MaxValue
                entity.Property(e => e.MaxValue)
                    .HasColumnType("varchar(MAX)")
                    .IsRequired(false);

                //ForeignTableName
                entity.Property(e => e.ForeignTableName)
                    .HasColumnType("varchar(MAX)")
                    .IsRequired(false);

                //ForeignColumnName
                entity.Property(e => e.ForeignColumnName)
                    .HasColumnType("varchar(MAX)")
                    .IsRequired(false);
            }
            catch (Exception) { throw; }
        }
    }
}
