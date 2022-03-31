using ClinicaOdontologica.modals.abstracts;
using ClinicaOdontologica.modals;
using ClinicaOdontologica.exceptions;
using System.Text.RegularExpressions;

namespace ClinicaOdontologica.services
{

    public class Clinica
    {
        private List<Pessoa> pessoas;
        private List<Procedimento> procedimentos;

        public Clinica()
        {
            this.pessoas = new List<Pessoa>();
            this.procedimentos = new List<Procedimento>();
        }

        public void AddPaciente(Paciente paciente)
        {
            if (!Regex.IsMatch(paciente.Cpf, @"^[0-9]+$") || !Regex.IsMatch(paciente.Telefone, @"^[0-9]+$"))
            {
                throw new ParametroInvalidoException("Campo cpf ou telefone é invalido!");
                
            }
            this.pessoas.Add(paciente);
        }

        public void AddProcedimento(Procedimento procedimento)
        {
            procedimento.Codigo = procedimentos.Count;
            this.procedimentos.Add(procedimento);
        }

        public void AddAtendimento(String cpf, List<int> codigos)
        {
            Paciente paciente = ObterPaciente(cpf);
            Atendimento atendimento = new AtendimentoConvencional();

            codigos.ForEach(codigo =>
            {
                atendimento.AddProcedimento(ObterProcedimentos(codigo));
            });

            paciente.ObterAtendimento().Add(atendimento);
        }

        public Procedimento ObterProcedimentos(int codigo)
        {
            Procedimento? procedimento = this.procedimentos.Find(procedimento => procedimento.Codigo.Equals(codigo));
            if (procedimento == null)
            {
                throw new NaoEncontradoException("Não foi encontrado!");
            }

            return procedimento;
        }

        public List<Procedimento> ObterProcedimentos()
        {
            return this.procedimentos;
        }

        public List<Pessoa> ObterPaciente()
        {
            return this.pessoas;
        }

        public Paciente ObterPaciente(string cpf)
        {
            Pessoa? pessoa = this.pessoas.Find(pessoa => pessoa.Cpf.Equals(cpf));

            if (pessoa != null && typeof(Paciente).IsInstanceOfType(pessoa))
            {
                return (Paciente) pessoa;
            }

            if (pessoa == null)
            {
                throw new NaoEncontradoException("Pessoa não encontrada!");
            }

            throw new PacienteNaoEncontradoException("Paciente não encontrado!");
        }

    }
}
