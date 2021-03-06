using ClinicaOdontologica.exceptions;
using ClinicaOdontologica.services;
using ClinicaOdontologica.modals;
using ClinicaOdontologica.modals.abstracts;

namespace ClinicaOdontologica.view
{
    public class Janela
    {

        private Clinica servico; 

        public Janela()
        {
            this.servico = new Clinica();
        }

        public void Inicio()
        {
            int options = -1;
            do
            {
                try
                {
                    Menu();
                    options = int.Parse(Console.ReadLine());
                    FazerAcao(options);
                } catch (ComandoNaoEncontradoException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                } catch (FormatException ex)
                {
                    Console.WriteLine("Valor invalido para o comando!");
                    Console.ReadLine();
                }

            } while (options != 0);

        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("||||||Clinica Odontologica||||||");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar Paciente");
            Console.WriteLine("2. Adicionar Procedimento");
            Console.WriteLine("3. Adicionar Atendimento");
            Console.WriteLine("4. Obter informações dos atendimentos por CPF!");
        }

        public void FazerAcao(int action)
        {
            switch (action)
            {
                case 0:
                    break;
                case 1:
                    AddPaciente();
                    break;
                case 2:
                    AddProcedimento();
                    break;
                case 3:
                    AddAtendimento();
                    break;
                case 4:
                    ObterAtendimentos();
                    break;
                default:
                    throw new ComandoNaoEncontradoException("Comando não encontrado!");

            }
        }

        public void AddPaciente()
        {   
            try
            {
                Console.Clear();
                Console.WriteLine("||||||Adicionar Paciente||||||");
                Console.WriteLine("Qual o CPF do paciente apenas numeros: ");
                string? cpf = Console.ReadLine();
                Console.WriteLine("Qual o nome do paciente: ");
                string? nome = Console.ReadLine();
                Console.WriteLine("Qual o telefone do paciente: ");
                string? telefone = Console.ReadLine();
                servico.AddPaciente(new Paciente(cpf, nome, telefone));
                Console.WriteLine("Paciente adicionado com sucesso!");
                Console.ReadLine();
            } catch (ParametroInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                AddPaciente();
            } 
            
        }

        public void AddProcedimento()
        {
            Console.Clear();
            Console.WriteLine("||||||Adicionar Procedimentos||||||");
            Console.WriteLine("Qual o nome do procedimento: ");
            string nome = Console.ReadLine();
            double preco = ObterPreco();

            servico.AddProcedimento(new Procedimento(nome,preco));
            Console.WriteLine("Procedimento adicionado com sucesso!");
            Console.ReadLine();
        }

        public double ObterPreco()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Qual o preco do procedimento: ");
                    double preco = double.Parse(Console.ReadLine());
                    return preco;
                } catch (FormatException ex)
                {
                    Console.WriteLine("Comando Invalido!");
                    Console.ReadLine();
                }
            }
        }

        public string PreencherCpf()
        {
            while(true)
            {
                try
                {
                    Console.WriteLine("Qual é o CPF do paciente, que deseja criar um atendimento: ");
                    string cpf = Console.ReadLine();

                    Paciente paciente = servico.ObterPaciente(cpf);

                    return cpf;
                } catch (NaoEncontradoException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                } catch (PacienteNaoEncontradoException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }

            }
            
        }

        public void AddAtendimento()
        {
            Console.Clear();
            Console.WriteLine("||||||Adicionar Atendimento||||||");
            MostrarPaciente();
            string cpf = PreencherCpf();

            List<int> procedimentos = new List<int>();
            
            while( true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("||||||Adicionar Atendimento||||||");
                    MostrarProcedimentos();
                    Console.WriteLine("Digite o codigo do procedimento que deseja: ");
                    int codigo = int.Parse(Console.ReadLine());
                    
                    servico.ObterProcedimentos(codigo);

                    if (procedimentos.Contains(codigo))
                    {
                        Console.WriteLine("Não é possivel adicionar procedimentos duplicados!");
                    } else
                    {
                        procedimentos.Add(codigo);
                    }

                    Console.WriteLine("Gostaria de adicionar outro procedimento (1 - Sim ou 0 - Não): ");
                    int? proximo = int.Parse(Console.ReadLine());
                    if (proximo.Equals(0))
                    {
                        break;
                    }

                    if (proximo > 1 || proximo < 0)
                    {
                        throw new FormatException();
                    }
                } catch (FormatException ex)
                {
                    Console.WriteLine("Comando invalido ou codigo invalido!");
                    Console.ReadLine();

                } catch (NaoEncontradoException ex)
                {
                    Console.WriteLine("Procedimento não encontrado!");
                    Console.ReadLine();
                } 

            }

            servico.AddAtendimento(cpf, procedimentos);
            Console.WriteLine("Atendimento adicionado com sucesso!");
            Console.ReadLine();
        }

        public void MostrarPaciente()
        {
            List<Pessoa> pessoas = servico.ObterPaciente();
            Console.WriteLine("||||||Todos os pacientes||||||");
            Console.WriteLine("CPF | NOME | TELEFONE");
            pessoas.ForEach(pessoa =>
            {
                Console.WriteLine($"{pessoa.Cpf} | {pessoa.Nome} | {pessoa.Telefone}");
            });
        }

        public void MostrarProcedimentos()
        {
            List<Procedimento> procedimentos = servico.ObterProcedimentos();
            Console.WriteLine("||||||Todos os Procedimentos||||||");
            Console.WriteLine("CODIGO | NOME | PRECO");
            procedimentos.ForEach(procedimento =>
            {
                Console.WriteLine($"{procedimento.Codigo} | {procedimento.Nome} | {procedimento.Preco}");
            });
        }

        public void ObterAtendimentos()
        {   
            Console.Clear();
            Console.WriteLine("||||||Obter os Atendimentos por CPF||||||");
            MostrarPaciente();
            
            while(true)
            {
                try
                {

                    Console.WriteLine("Qual CPF gostaria de pesquisar: ");
                    string? cpf = Console.ReadLine();

                    Paciente pessoa = servico.ObterPaciente(cpf);

                    Console.Clear();

                    Console.WriteLine($"Lista de atendimento para o CPF: {cpf}");

                    pessoa.ObterAtendimento().ForEach(atendimento =>
                    {
                        MostrarAtendimento(atendimento);
                    });

                    Console.WriteLine("Todos os Atendimento foram listados!");
                    Console.ReadLine();
                    break;
                }
                catch (NaoEncontradoException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                catch (PacienteNaoEncontradoException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }

        }

        public void MostrarAtendimento(Atendimento atendimento)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Data do atendimento | Código | Nome | Preço");
            atendimento.ObterProcedimentos().ForEach(procedimento =>
            {

                Console.WriteLine($"{procedimento.Data} | {procedimento.Codigo} | {procedimento.Nome} | {procedimento.Preco}");
            });

            Console.WriteLine($"Total: {atendimento.ObterValorTotal()}");
            Console.WriteLine("-------------------------------------------");

        }

    }
}
