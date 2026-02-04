namespace studyEF.Model;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Npgsql;
 
[Table("inscricoes")]
public class Inscricao
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [Column("participante_id")]
    public Guid ParticipanteId { get; set; }
    [Required]
    [Column("torneio_id")]
    public Guid TorneioId { get; set; }
    [Required]
    [Column("data_inscricao")]
    public DateTime DataInscricao { get; set; }
    [ForeignKey(nameof(ParticipanteId))]
    public Participante Participante { get; set; }
    [ForeignKey(nameof(TorneioId))]
    public Torneio Torneio { get; set; }
}