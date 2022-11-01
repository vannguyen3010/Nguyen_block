using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NghiaVoBlog.Models;

namespace NghiaVoBlog.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                var user =modelBuilder.Entity<User>();
                var article =modelBuilder.Entity<Article>();
                var category =modelBuilder.Entity<Category>();
                var tag =modelBuilder.Entity<Tag>();
                var comment =modelBuilder.Entity<Comment>();

            //tao bang tblUser
            user.ToTable("tblUser")
             //user co nhieu articles voi 1 thuoc tinh Author va khoa ngoai la AuthorId
            .HasMany<Article>(u => u.Articles).WithOne(a => a.Author).HasForeignKey(a => a.AuthorID);
            user.HasMany<Comment>(u => u.Comments).WithOne(c => c.Author).HasForeignKey(c => c.AuthorID);
            user .HasMany<Category>(u => u.Categories).WithOne(c => c.CreatedBy).HasForeignKey(c => c.CreatedById);


            article.ToTable("tblArticle");

            article.HasOne<User>(a => a.Author).WithMany(u => u.Articles).HasForeignKey(a => a.AuthorID).IsRequired().OnDelete(DeleteBehavior.NoAction);
            article.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryID);
            // article.HasMany<Tag>(a => a.Tags).WithMany(t => t.Articles).UsingEntity(at => at.ToTable("ArticleTag"));
            article.HasMany<Comment>(a => a.Comments).WithOne(c => c.Article).HasForeignKey(c => c.ArticleID);
            // article.HasMany<User>(a => a.Likers);
            
            category.ToTable("tblCategory");
            category.HasMany<Article>(c => c.Articles).WithOne(a => a.Category).HasForeignKey(c => c.CategoryID);
            category.HasOne<User>(c => c.CreatedBy).WithMany(u => u.Categories).HasForeignKey(c => c.CreatedById).IsRequired().OnDelete(DeleteBehavior.NoAction);

            tag.ToTable("TblTag");
            // tag.HasMany<Article>(t => t.Articles).WithMany(a => a.Tags).UsingEntity(at => at.ToTable("ArticleTag"));

            comment.ToTable("tblComment");
            comment.HasOne<User>(c => c.Author).WithMany(u => u.Comments).HasForeignKey(c => c.AuthorID).IsRequired().OnDelete(DeleteBehavior.NoAction);
            comment.HasOne<Article>( c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleID);

            modelBuilder.Entity<ArticleTag>(entity=>
            {
                entity.ToTable("tblArticleTag");
                entity.HasKey(j=> new { j.ArticleID,j.TagID});
                entity.HasOne(at => at.Article).WithMany(j => j.ArticleTags).HasForeignKey(j => j.ArticleID);
                entity.HasOne(at => at.Tag).WithMany(j=>j.ArticleTags).HasForeignKey(j=>j.TagID);
            });
            modelBuilder.Entity<ArticleLiker>(entity=>
            {
                entity.ToTable("ArticleLiker");
                entity.HasKey(j=> new { j.ArticleID,j.UserID});
                entity.HasOne(a => a.Article).WithMany(al => al.ArticleLikers).HasForeignKey(al => al.ArticleID);

                entity.HasOne(u => u.User).WithMany(al=>al.ArticleLikers).HasForeignKey(al=>al.UserID);
            });
        }
        
    }

}