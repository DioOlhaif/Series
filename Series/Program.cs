using System;


namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X") {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizaSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizaSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                        
                        
                }
                OpcaoUsuario = ObterOpcaoUsuario();
            
            }



        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            
            var lista = repositorio.Lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma séria encontrada");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("#ID{0} - {1} - {2}", serie.RetornaId(), serie.RetornaTitulo(), excluido?"Excluido":"");
            }
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova Série");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#ID{0}; - {1}", i , Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o Gênero entra as Opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série" );
            string entradaTitulo = Console.ReadLine();


            Console.WriteLine("Digite o Ano de início da série");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Serie");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero:
              (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno,
              descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

        }

        public static void AtualizaSerie()
        {
            Console.WriteLine("Digite o ID da Série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))) {

                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o Gênero entra as Opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série");
            string entradaTitulo = Console.ReadLine();
            
            Console.WriteLine("Digite a Descrição da Serie");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Digite o Ano de início da série");
            int entradaAno = int.Parse(Console.ReadLine());

            Serie atualizaSerie = new Serie(id: indiceSerie, genero:
                (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno,
                descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        public static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da Série");
            int indiceSerie = int.Parse(Console.ReadLine());


            repositorio.Exclui(indiceSerie);
            }
        public static void VisualizaSerie()
        {
            Console.WriteLine("Digite o ID da Série");
            int indiceSerie = int.Parse(Console.ReadLine());


            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario()

        {
            Console.WriteLine("");
            Console.WriteLine("Dio Series ao seu dispor!");
            Console.WriteLine("Informe a Opção Desejada");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir nova Série");
            Console.WriteLine("3- Atualizar Serie");
            Console.WriteLine("4- Excluir Séries");
            Console.WriteLine("5- Visualizar Séries");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;


        }

    }
}
