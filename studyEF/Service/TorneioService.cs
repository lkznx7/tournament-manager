namespace studyEF.Service;
using studyEF.Model;
using System;

public class TorneioService
{
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
            
        }else if (nomeJogo != null)
        {}
        else{}
    }
    public void AtualizarTorneio(){}
}