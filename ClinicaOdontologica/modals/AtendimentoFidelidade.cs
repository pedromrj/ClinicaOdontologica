using ClinicaOdontologica.interfaces;
using ClinicaOdontologica.modals.abstracts;

namespace ClinicaOdontologica.modals
{
    public class AtendimentoFidelidade : Atendimento, IAtendimento
    {
        public const double DESCONTO = 0.02;

        public double GetValorTotal()
        {   double valorDesconto = base.GetValorTotal() * DESCONTO;
            return base.GetValorTotal() - valorDesconto;
        }
    }
}
