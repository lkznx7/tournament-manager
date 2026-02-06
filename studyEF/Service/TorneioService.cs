namespace studyEF.Service;
using studyEF.Model;
using studyEF.Data;
using System;

public class TorneioService
{
    private Banco _banco = new Banco();
    public Torneio CriarTorneio(string nomeJogo, DateTime dataEvento)
    {
        if (DateTime.Now <= dataEvento)
        {
            Torneio T1 = new Torneio(nomeJogo, dataEvento);
            return T1;
        }
        else
        {
            Console.WriteLine("A data do evento tem q ser igaul a data de hoje ou posterior");
            return null;
        };
    }

    public void ConsultarTorneio(Guid? id = null, string nomeJogo = null)
    {
        if (id != null)
        {
            _banco.ConsultaTorneioID(id.Value);
        }else if (nomeJogo != null)
        {
            _banco.ConsultaTorneioNomeJogo(nomeJogo);
        }
        else
        {
            string ND = "Nenhum Torneio foi encontrado";
        }
    }
    public void AtualizarTorneio(){}
}