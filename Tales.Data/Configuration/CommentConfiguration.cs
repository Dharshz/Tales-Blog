using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Modal;

namespace Tales.Data.Configuration
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            HasKey(a => a.CommentId);
            Property(a => a.CommentId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(a => a.Name).IsRequired();
            Property(a => a.PostId).IsRequired();
            HasRequired(a => a.Post).WithMany(a => a.Comments).HasForeignKey(a => a.PostId).WillCascadeOnDelete(false);
        }
    }
}
