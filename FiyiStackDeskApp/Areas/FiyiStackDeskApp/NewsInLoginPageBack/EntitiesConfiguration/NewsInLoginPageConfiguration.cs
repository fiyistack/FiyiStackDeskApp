using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Entities;

/*
 * 
 * Coded by fiyistack.com
 * Copyright © 2025
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.EntitiesConfiguration
{
    public class NewsInLoginPageConfiguration : IEntityTypeConfiguration<NewsInLoginPage>
    {
        public void Configure(EntityTypeBuilder<NewsInLoginPage> entity)
        {
            try
            {
                //NewsInLoginPageId
                entity.HasKey(e => e.NewsInLoginPageId);
                entity.Property(e => e.NewsInLoginPageId)
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

                //New
                entity.Property(e => e.New)
                    .HasColumnType("varchar(MAX)")
                    .IsRequired(false);

                
            }
            catch (Exception) { throw; }
        }
    }
}
