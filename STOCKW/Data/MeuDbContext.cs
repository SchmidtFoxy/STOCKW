using Microsoft.EntityFrameworkCore;
using STOCKW.Models.Identidade;
using STOCKW.Models.Dominio;

namespace STOCKW.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options)
            : base(options)
        {
        }

        // DbSets para suas entidades
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<TipoMovimentacao> TiposMovimentacao { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Fisica> Fisicas { get; set; }
        public DbSet<Juridica> Juridicas { get; set; }
        public DbSet<Cidade> Cidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cidade>()
                .HasKey(c => c.ID_Cidade);

            modelBuilder.Entity<Item>()
                .HasKey(i => i.ID_Item);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.ID_Usuario);

            modelBuilder.Entity<Permissao>()
                .HasKey(p => p.ID_Permissao);

            modelBuilder.Entity<TipoMovimentacao>()
                .HasKey(t => t.ID_TipoMovimentacao);

            modelBuilder.Entity<Movimentacao>()
                .HasKey(m => m.ID_Movimentacao);

            modelBuilder.Entity<Pessoa>()
                .HasKey(p => p.ID_Pessoa);

            modelBuilder.Entity<Fisica>()
                .HasBaseType<Pessoa>();

            modelBuilder.Entity<Juridica>()
                .HasBaseType<Pessoa>();



            // Configurações adicionais de modelagem
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Permissao)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.ID_Permissao);

            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Item)
                .WithMany(i => i.Movimentacoes)
                .HasForeignKey(m => m.ID_Item);

            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Pessoa)
                .WithMany(p => p.Movimentacoes)
                .HasForeignKey(m => m.ID_Pessoa);

            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.TipoMovimentacao)
                .WithMany(t => t.Movimentacoes)
                .HasForeignKey(m => m.ID_TipoMovimentacao);

            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Usuario)
                .WithMany(u => u.Movimentacoes)
                .HasForeignKey(m => m.ID_Usuario);

            modelBuilder.Entity<Pessoa>()
                .HasOne(p => p.Cidade)
                .WithMany(c => c.Pessoas)
                .HasForeignKey(p => p.ID_Cidade);

           

            // Configurações para a classe Pessoa e suas subclasses
            modelBuilder.Entity<Fisica>().HasBaseType<Pessoa>();
            modelBuilder.Entity<Juridica>().HasBaseType<Pessoa>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
