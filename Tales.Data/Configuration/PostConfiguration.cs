using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Modal;

namespace Tales.Data.Configuration
{
    class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            this.HasKey(a => a.PostId);
            this.Property(a => a.IsPublished).IsRequired();
            this.Property(a => a.PostId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(a => a.Description).IsRequired();
            this.Property(a => a.Title).IsRequired().HasMaxLength(250);
            this.Property(a => a.PublishedDate).IsRequired().HasColumnType("datetime");
            HasMany(a => a.Tags).WithMany(a => a.Posts)
                .Map(t => t.ToTable("PostTag").MapLeftKey("PostId").MapRightKey("TagId"));
                
        }
    }
}
