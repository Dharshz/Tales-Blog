using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Model;

namespace Tales.Data.Configuration
{
    class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(a => a.Name).HasMaxLength(15);
            this.Property(a => a.TagId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

           
        }
    }
}
