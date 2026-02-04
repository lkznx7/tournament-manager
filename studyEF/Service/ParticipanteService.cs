namespace studyEF.Service;

using studyEF.Data;
using studyEF.Model;

public class ParticipanteService
{
    private readonly Banco _banco;

    public ParticipanteService(Banco banco)
    {
        _banco = banco;
    }

    public bool CriarParticipante(string nome, string nick, string email)
    {
        if (_banco.ParticipanteExiste(email, nick))
            return false;

        var participante = new Participante(nome, nick, email);
        _banco.AdicionarParticipante(participante);

        return true;
    }

    public bool AtualizarParticipante(string dadoConsulta, int op, string novoDado)
    {
        Participante participante = op switch
        {
            1 => _banco.BuscarPorEmail(dadoConsulta),
            2 => _banco.BuscarPorNick(dadoConsulta),
            3 => _banco.BuscarPorNome(dadoConsulta),
            _ => null
        };

        if (participante == null)
            return false;

        if (op == 1) participante.Email = novoDado;
        if (op == 2) participante.NickName = novoDado;
        if (op == 3) participante.NomeCompleto = novoDado;

        _banco.Salvar();
        return true;
    }

    public Participante ConsultarParticipante(string dado)
    {
        return _banco.BuscarParticipante(dado);
    }
}