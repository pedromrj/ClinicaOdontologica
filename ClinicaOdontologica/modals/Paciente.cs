using ClinicaOdontologica.modals.abstracts;

namespace ClinicaOdontologica.modals
{
    public class Paciente : Pessoa
    {
        private List<Atendimento> atendimentos;

        public Paciente(string cpf, string nome, string telefone) : base(cpf, nome, telefone)
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
