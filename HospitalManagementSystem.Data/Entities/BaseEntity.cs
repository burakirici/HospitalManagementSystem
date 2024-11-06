﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.Entities
{
    public class BaseEntity
    {
        
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }

    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasQueryFilter(x => x.IsDeleted == false);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedDate).IsRequired();
            // Bu veritabanı üzerinde yapılacak bütün sorgulamalarda ve diğer linq işlemlerinde geçerli olacak bir filtreleme yazdık.Böylelkle hiç bir zaman sofr delete atılmış verilerle uğraşmayacağız.
            builder.Property(x => x.UpdatedAt)
                   .IsRequired(false);
        }
    }
}
