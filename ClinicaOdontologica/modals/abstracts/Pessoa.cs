namespace ClinicaOdontologica.modals.abstracts;

public abstract class Pessoa
{
    public string Cpf { get; }
    public string Nome { get; }
    public string Telefone { get; }
    public bool Fidelidade { get; }

    public Pessoa(string cpf, string nome, string telefone, bool fidelidade)
    {
        this.Cpf = cpf;
        this.Nome = nome;
        this.Telefone = telefone;
        this.Fidelidade = fidelidade;
    }
}
