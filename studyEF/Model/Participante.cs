namespace studyEF.Model;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Npgsql;

[Table("participantes")]
public class Participante
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(120)]
    [Column("nome_jogador")]
    public string NomeCompleto { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("nick_jogador")]
    public string NickName { get; set; }

    [Required]
    [MaxLength(150)]
    [EmailAddress]
    [Column("email_jogador")]
    public string Email { get; set; }
    [Required]
    [Column("status_jogador")]
    public bool StatusJogador { get; set; }
    public ICollection<Inscricao> Inscricoes { get; set; }
    public Participante(string nomeCompleto, string nickName, string email)
    {
        this.Id = Guid.NewGuid();
        this.NomeCompleto = NomeCompleto;
        this.NickName = NickName;
        this.Email = Email;
        this.StatusJogador = true;
        this.Inscricoes = new List<Inscricao>();
    }
}