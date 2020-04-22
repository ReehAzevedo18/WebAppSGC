using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Enity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EnitiyConfig
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder
               .HasMany(m => m.SubMenu)
               .WithOne() //o submenu tem apenas um unico menu
               .HasForeignKey(x => x.MenuId);
        }
    }
}
