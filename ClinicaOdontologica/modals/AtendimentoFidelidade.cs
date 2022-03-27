using ClinicaOdontologica.interfaces;
using ClinicaOdontologica.modals.abstracts;

namespace ClinicaOdontologica.modals
{
    public class AtendimentoFidelidade : Atendimento, IAtendimento
    {
        public const double DESCONTO = 0.02;

        public double ObterValorTotal()
        {   double valorDesconto = base.ObterValorTotal() * DESCONTO;
            return base.ObterValorTotal() - valorDesconto;
        }
    }
}
