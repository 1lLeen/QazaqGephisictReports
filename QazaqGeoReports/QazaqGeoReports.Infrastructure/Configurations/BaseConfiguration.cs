﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Infrastructure.Configurations;
public class BaseConfiguration<TModel> : IEntityTypeConfiguration<TModel> where TModel : BaseEntity
{
    public void Configure(EntityTypeBuilder<TModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }
    public static void InitDefaultDateColumns(EntityTypeBuilder<TModel> builder)
    {
        builder.Property(x => x.CreatedTime)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

        builder.Property(x => x.UpdatedTime)
            .IsRequired()
            .ValueGeneratedOnAddOrUpdate()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
    }
}
