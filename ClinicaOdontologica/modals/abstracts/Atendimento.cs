namespace ClinicaOdontologica.modals.abstracts
{
    public abstract class Atendimento
    {
        protected List<Procedimento> procedimentos;

        public Atendimento()
        {
            procedimentos = new List<Procedimento>();
        }

        public void AddProcedimento(Procedimento procedimento)
        {
            this.procedimentos.Add(procedimento);
        }

        public List<Procedimento> ObterProcedimentos()
        {
            return this.procedimentos;
        }

        public double ObterValorTotal()
        {
            double valorTotal = 0;
            this.procedimentos.ForEach(p => valorTotal += p.Preco);
            return valorTotal;
        }
    }
}
