using ClinicaOdontologica.modals.abstracts;

namespace ClinicaOdontologica.modals
{
    public class Paciente : Pessoa
    {
        protected List<Atendimento> atendimentos;

        public bool Fidelidade { get; set; }

        public Paciente(string cpf, string nome, string telefone, bool fidelidade) : base(cpf, nome, telefone, fidelidade)
        {
            this.atendimentos = new List<Atendimento>();
        }

        public void AddAtendimento(Atendimento atendimento)
        {
            this.atendimentos.Add(atendimento);
        }

        public List<Atendimento> GetAtendimento()
        {
            return this.atendimentos;
        }
    }
}
