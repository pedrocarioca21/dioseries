using System;

namespace dioseries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = MenuOpcoes();

            while(opcao != "X"){
                switch(opcao){
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        ConsultarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Digite um número válido, imbecil.");
                }

                opcao = MenuOpcoes();
            }
        }

        public static void ListarSeries(){
            Console.Clear();
            Console.WriteLine("Listagem de séries:");
            var lista = repositorio.Lista();
            bool vazio = true;

            if(lista.Count == 0){
                Console.WriteLine("Lista vazia!");
                return;
            }

            foreach(var serie in lista){
                if(serie.retornaStatus()){
                Console.WriteLine("ID #{0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                vazio = false;
                }
            }

            if(vazio){
                Console.WriteLine("Lista vazia!");
            }

        }

        public static void InserirSerie(){
            Console.Clear();
            Console.WriteLine("Inserindo nova série.");
            Console.WriteLine("Insira o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Insira a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine("Insira a ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Escolha o gênero da série: ");
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Escolha a plataforma de streaming da série: ");
            foreach(int i in Enum.GetValues(typeof(Plataforma))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Plataforma), i));
            }
            int entradaPlataforma = int.Parse(Console.ReadLine());
            
            Serie nova = new Serie(repositorio.proximoId(), (Genero)entradaGenero, (Plataforma)entradaPlataforma, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.insere(nova);
        }

        public static void AtualizarSerie(){
            Console.WriteLine("Insira o ID da série que será atualizada: ");
            int entradaID = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o NOVO título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Insira a NOVA descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine("Insira o NOVO ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Escolha o NOVO o gênero da série: ");
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Escolha a plataforma de streaming da série: ");
            foreach(int i in Enum.GetValues(typeof(Plataforma))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Plataforma), i));
            }
            int entradaPlataforma = int.Parse(Console.ReadLine());
            
            Serie atualizada = new Serie(entradaID, (Genero)entradaGenero, (Plataforma)entradaPlataforma, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.atualiza(entradaID, atualizada);

        }

        public static void ExcluirSerie(){
            Console.WriteLine();
            Console.WriteLine("Insira o ID da série que será excluída: ");
            int entradaID = int.Parse(Console.ReadLine());
            repositorio.excluir(entradaID);
        }

        public static void ConsultarSerie(){
            Console.WriteLine();
            Console.WriteLine("Insira o ID da série que deseja consultar: ");
            int entradaID = int.Parse(Console.ReadLine());
            Console.WriteLine(repositorio.RetornaPorId(entradaID).ToString());
        }



        private static string MenuOpcoes(){
            Console.WriteLine();
            Console.WriteLine("PobreFlix - Os séries que os pobres gostam...");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir séries");
            Console.WriteLine("3 - Atualizar info do séries");
            Console.WriteLine("4 - Remover séries");
            Console.WriteLine("5 - Consultar séries");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
