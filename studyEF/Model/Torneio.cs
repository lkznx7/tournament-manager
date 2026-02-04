namespace studyEF.Model;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Npgsql;
using studyEF.Data;

    public enum Status
    {
        Ativo,
        Finalizado,
        Lotado
    }
    [Table("torneios")]
    public class Torneio
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nome_jogo")]
        public string NomeJogo { get; set; }

        [Required]
        [Column("data_torneio")]
        public DateTime DataEvento { get; set; }

        [Required]
        [Column("status_torneio")]
        public Status StatusTorneio { get; set; }

        public ICollection<Inscricao> Inscricoes { get; set; }

        public Torneio( String nomeJogo, DateTime dataEvento)
        {
            
            this.Id = Guid.NewGuid();
            this.NomeJogo = nomeJogo;
            this.DataEvento = dataEvento;
            this.StatusTorneio = Status.Ativo;
            this.Inscricoes = new List<Inscricao>();
        }
        
    }
