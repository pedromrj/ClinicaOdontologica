using ClinicaOdontologica.modals.abstracts;

namespace ClinicaOdontologica.modals
{
    public class Paciente : Pessoa
    {
        private List<Atendimento> atendimentos;

        public Paciente(string cpf, string nome, string telefone, bool fidelidade) : base(cpf, nome, telefone, fidelidade)
        {
            this.atendimentos = new List<Atendimento>();
        }

        public void AddAtendimento(Atendimento atendimento)
        {
            this.atendimentos.Add(atendimento);
        }

        public List<Atendimento> ObterAtendimento()
        {
            return this.atendimentos;
        }
    }
}
