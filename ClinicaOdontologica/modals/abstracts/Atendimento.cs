namespace ClinicaOdontologica.modals.abstracts
{
    public class Atendimento
    {
        protected List<Procedimento> procedimentos;

        public DateTime Data { get; }

        public Atendimento()
        {
            procedimentos = new List<Procedimento>();
            Data = DateTime.Now;
        }

        public void AddProcedimento(Procedimento procedimento)
        {
            this.procedimentos.Add(procedimento);
        }

        public List<Procedimento> GetProcedimentos()
        {
            return this.procedimentos;
        }

        public double GetValorTotal()
        {
            double valorTotal = 0;
            this.procedimentos.ForEach(p => valorTotal += p.Preco);
            return valorTotal;
        }
    }
}
