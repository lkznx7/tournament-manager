namespace studyEF.Data;

using Microsoft.EntityFrameworkCore;
using studyEF.Model;

public class Banco : DbContext
{
    public DbSet<Torneio> Torneios { get; set; }
    public DbSet<Participante> Participantes { get; set; }
    public DbSet<Inscricao> Inscricoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=db.iqagwrkgneakvtrtcvjm.supabase.co;" +
            "Database=postgres;" +
            "Username=postgres;" +
            "Password=GameFLowAPI2026.@;" +
            "SSL Mode=Require;" +
            "Trust Server Certificate=true"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inscricao>()
            .HasOne(i => i.Participante)
            .WithMany(p => p.Inscricoes)
            .HasForeignKey(i => i.ParticipanteId);

        modelBuilder.Entity<Inscricao>()
            .HasOne(i => i.Torneio)
            .WithMany(t => t.Inscricoes)
            .HasForeignKey(i => i.TorneioId);
    }

    public void AdicionarParticipante(Participante participante)
    {
        Participantes.Add(participante);
        SaveChanges();
    }

    public bool ParticipanteExiste(string email, string nick)
    {
        return Participantes.Any(p =>
            p.Email == email || p.NickName == nick);
    }

    public Participante BuscarParticipante(string dado)
    {
        return Participantes.FirstOrDefault(p =>
            p.Email == dado ||
            p.NickName == dado ||
            p.NomeCompleto == dado);
    }

    public Participante BuscarPorEmail(string email)
    {
        return Participantes.FirstOrDefault(p => p.Email == email);
    }

    public Participante BuscarPorNick(string nick)
    {
        return Participantes.FirstOrDefault(p => p.NickName == nick);
    }

    public Participante BuscarPorNome(string nome)
    {
        return Participantes.FirstOrDefault(p => p.NomeCompleto == nome);
    }

    public void Salvar()
    {
        SaveChanges();
    }

    public void ConsultaTorneio(Guid id) {}


}
