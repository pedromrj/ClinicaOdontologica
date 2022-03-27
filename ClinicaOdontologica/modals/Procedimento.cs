namespace ClinicaOdontologica.modals
{
    public class Procedimento
    {
        public int Codigo { get; set; }
        public string Nome { get; }
        public double Preco { get; }

        public Procedimento(string nome, double preco) 
        {
           this.Nome = nome;   
           this.Preco = preco;
        }
    }
}
