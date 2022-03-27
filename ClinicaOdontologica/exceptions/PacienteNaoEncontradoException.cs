namespace ClinicaOdontologica.exceptions
{
    public class PacienteNaoEncontradoException : Exception
    {
        public PacienteNaoEncontradoException(string msg): base(msg) { }
    }
}
