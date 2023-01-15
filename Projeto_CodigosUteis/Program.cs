using System.Text.Json;
using System.Text.Json.Serialization;
using testando_namespace;

#region TopLevelStatements
// //Writeline
// Console.WriteLine("Console: Hello, World!");

// //Statements
// int i;
// int i2 = i = 10;
// int i3 = i2--;
// i = i2 == 42 ? 10 : 20; //operador ternário
// Console.WriteLine($"Statements: {i2}");

// //Tipagem estática
//     //C# é uma linguagem de tipagem estática
//         //i = i2 == 42 ? 10 : "teste"; //essa expressão não é permitida
//     // System.//checagem  dp que o namespace system nos oferece
//     // <Aviso> TIPOS ESTÁTICOS NÃO PERMITEM CRIAÇÃO DE OBJETOS, TIPOS ESTÁTICOS SÓ CONTÉM FUNCIONALIDADES </Aviso>
//         // <Aviso> TODOS MEMBROS DO TIPO ESTÁTICO TAMBÉM PRECISAM SER ESTÁTICOS </Aviso>
//         //Membros do tipo estático podem ser utilizados chamando pelo .
//             //Exemplo
//             //string. membros estáticos da classe string

// //Um programa simples de interação com Console
// Console.Write("Digite seu nome: ");
// string name = Console.ReadLine();
// System.Console.WriteLine($"Olá {name}");
// System.Console.WriteLine("Digite o ano do seu nascimento: ");
// int year = int.Parse(Console.ReadLine());
// int age = 2022 - year;
// System.Console.WriteLine($"Você tem {age} anos.");

// //Condicionais
// if(age >= 18) System.Console.WriteLine("Você é maior da idade.");
// else System.Console.WriteLine("Você é menor de idade");
#endregion

class Test
{
    public int x;
}

class Program{
    static async Task Main(string[] argumentos)//esse método precisa ser statico e precisa ter a primeira letra maiúscula
    {
        #region Arrays
        string[] nomes = {  "Levi", "Maria" };
        int j = new int();
        #endregion

        #region ArgumentosNaExecucao
        //Chamar um argumento do main: use dotnet run -- texto
        //System.Console.WriteLine(argumentos[0]);
        #endregion

        #region Strings
        //comparação independente de case
        if(string.Equals(nomes[0], "Levi", StringComparison.OrdinalIgnoreCase))
            System.Console.WriteLine("Nomes iguais");

        //compara o final ou início da string
        System.Console.WriteLine($"Nomes terminam com 'vi' ? " + nomes[0].EndsWith("vi"));//aspas duplas se for mais de um caractere
        System.Console.WriteLine($"Nomes termina com 'i' ? " + nomes[0].EndsWith('i'));//aspas simples se for somente um caractere
        System.Console.WriteLine($"Nomes começa com 'Levi' ? " + nomes[0].StartsWith("Levi"));
        //pesquisa se contém
        System.Console.WriteLine($"Nomes contém 'L' ? " + nomes[0].Contains('L'));
        System.Console.WriteLine($"Nomes contém 'Le' ? " + nomes[0].Contains("Le"));
        System.Console.WriteLine($"Indice de 'Le' no array de nomes " + nomes[0].IndexOf("Le"));//retorna o indice do trecho que especificarmos
        //checa nulo, vazio ou white space
        System.Console.WriteLine($"Nomes é nulo ou vazio ? {string.IsNullOrEmpty(nomes[0])}");
        System.Console.WriteLine($"Nomes é nulo ou contém espaço em branco ? {string.IsNullOrWhiteSpace(nomes[0])}");
        //junção dos itens do array de string
        System.Console.WriteLine($"Separando nomes na string nomes com espaço {string.Join(' ',nomes)}");
        //pega o tamanho da string
        System.Console.WriteLine($"Tamanho da string nome {nomes[0].Length}");
        #endregion

        #region Int
        int i = 0;
        //converte a string 42 em int e deixa o valor de saída em i usando o modificador de saida out
        int.TryParse("42", out i);
        System.Console.WriteLine(i);
        int.TryParse("7", out int saida);
        #endregion

        #region Laço, loops
        int indice = 0;
        for (indice = 0; indice < nomes.Length; indice++)
        {
            System.Console.WriteLine(nomes[indice]);
        }

        foreach (string nome in nomes)
        {
            System.Console.WriteLine(nome);
        }

        #endregion

        #region Conversões explícitas e implícitas
            int k = 10;
            long l = 10;
            l=i;        //conversão implícita de inteiro para long, pois long é maior
            //i=l;      //tentando converter long para int, como long é maior que int, dispara um erro
            i = (int)l; //conversão explícita de int para long, caso o valor n for maior que limite OK
            l = 203109421924123;
            //caso o valor do long for maior que o limite do int, ele vai cortar o valor
            i = (int)l; 
            System.Console.WriteLine($"i: {i}");
            //.ToString converte a representação do objeto para seu equivalente em string
            System.Console.WriteLine(l.ToString());
        #endregion

        #region Tipos de referência e tipos de valor
            //classes são tipos de referência
            Test test1 = new Test();
            test1.x = 10;
            Test test2 = test1;//cópia por referência desse objeto test1, não criamos um objeto novo
            test2.x = 20;
            test2 = new Test();
            //strings são tipos de referência

            //char e bool são tipos de valor
            int inteiro_valor = 10;
            int outro_inteiro_valor = inteiro_valor;//atribuição por tipo de valor, cria um objeto novo

        #endregion,

        #region Tipos anuláveis
        //para anular tipos de referência utilize a palavra null
        Test test3 = new Test();
        test3 = null;
        //string? string_nula = null;
        //System.Console.WriteLine(string_nula.Length);//dispara uma exceção de null

        //para anular tipos de valor utilize o palavra ? para dizer que é anulável
        int? valor_anulavel = null;
        if(valor_anulavel==null)
            System.Console.WriteLine($"Tipo anulável {valor_anulavel}");
        //tipos de valor anuláveis possuem métodos para checagem de valor
        System.Console.WriteLine(valor_anulavel.HasValue);//retorna booleano caso possua um valor
        valor_anulavel = 2;
        System.Console.WriteLine(valor_anulavel.Value);//retorna o valor inteiro
        valor_anulavel = null;
        System.Console.WriteLine(valor_anulavel.GetValueOrDefault());//retorna o valor ou o default (para ints é 0)
        System.Console.WriteLine(valor_anulavel.GetValueOrDefault(2));//define um valor default para caso inteiro nulo
        #endregion

        #region Tratamento de exceções
        //referencia nula
        try{
            string? string_nula2 = null;
            System.Console.WriteLine(string_nula2.Length);
        }catch(NullReferenceException excecao){
            System.Console.WriteLine($"\n Exceção 1: {excecao}");
        }
        //fora de indice
        int[] inteiros = {0,1};
        try{
            System.Console.WriteLine(inteiros[2]);
        }catch(IndexOutOfRangeException excecao){
            System.Console.WriteLine($"\n Exceção 2: {excecao}");
        }catch(Exception outra_excecao){
            System.Console.WriteLine($"\n Exceção 3: {outra_excecao}");
        }
        // }catch{ //poder deixar só catch também se for pra exceções gerais
        // }
        #endregion

        #region Classes e campos (fields)
        ILogger logger = new FileLogger("outro-log.txt");//instanciando a classe concreta e não a interface
        BankAccount conta1 = new BankAccount("Joao",100,logger);
        BankAccount conta2 = new BankAccount("Maria",100,logger);

        conta1.Deposit(-100);
        conta2.Deposit(100);
        System.Console.WriteLine(conta2.Balance);
        //ILogger logger = new ILogger()://Não é possível criar instancia do tipo abstrato interface
        #endregion

        #region Tipos genéricos
        //LISTAS de qualquer tipo, por exemplo, contas
        //podem ser inicializadas assim
        List<BankAccount> contas = new List<BankAccount>
        {
            conta1,
            conta2
        };
        //itens podem ser adicionados ou removidos
        //contas.Add(conta1);
        //contas.Add(conta2);
        contas.Remove(conta1);
        foreach(BankAccount conta in contas){
            System.Console.WriteLine(conta.Balance);
        }
        //ou podem ser inicializadas assim
        //LISTA de inteiro exemplo
        List<int> numeros = new List<int>(){1,4,8,10};
        foreach(int numero in numeros){
            System.Console.WriteLine(numero);
        }

        //criar tipos genéricos
        //generico pra int
        DataStore<int> store_int = new DataStore<int>();
        store_int.Value = 42;
        System.Console.WriteLine(store_int.Value);

        //generico pra string
        DataStore<string> store_str = new DataStore<string>();
        store_str.Value = "teste";
        System.Console.WriteLine(store_str);
        //chamar método
        System.Console.WriteLine(store_str.Value.Length);
        #endregion

        #region Uso da palavra var
        //a variável vai ser do tipo da expressão da direita
        var novo_logger = new FileLogger("novo_log.txt");
        var data_store = new DataStore<string>();
        data_store.Value = "Usando var";

        var nova_conta = new BankAccount("Nova Conta",100,novo_logger);

        var var_contas = new List<BankAccount>{
            conta1,
            conta2,
            nova_conta
        };

        foreach(var var_conta in var_contas){
            System.Console.WriteLine(var_conta.Balance);
        }
        #endregion

        #region Delegates
        //São objetos que sabem executar métodos
        //armazenar métodos em variáveis ou passar métodos como argumento
        var calculo = new Calcular(Soma);
        var result = calculo(2,1);
        System.Console.WriteLine(result);

        //método anonimo
        var multiplicacao = delegate (int x, int y) { return x * y; };
        System.Console.WriteLine(multiplicacao(10,5));

        //passando o método anonimo pra uma funcao
        Rodar(multiplicacao);

        //Action: Delegate void que não retorna nada
        Action<string> test_nome = delegate (string name){
            System.Console.WriteLine($"\n Olá {name}");
        };
        test_nome("Levi");

        //Func: Delegate de algum tipo que retorna algum valor
        Func<decimal> test_decimal = delegate{ return 4.2m; };//Esse m é para especificar um decimal
        System.Console.WriteLine(test_decimal());

        Func<string,bool> checar_nome = delegate(string nome){
            return nome.Contains('a');
        };
        checar_nome("Levi");

        #endregion

        #region Expressões lambda
        //exemplo de uso da expressão lambda
        //reescrevendo as funções dos delegates usando lambda
        var nova_multiplicacao = (int x, int y) => { return x * y; };
        Rodar(nova_multiplicacao);
        //quando possui somente uma declaração no corpo, pode ser abstraído pra
        var outra_multiplicacao = (int x, int y) => x*y;

        var nova_string = (string nome) => System.Console.WriteLine($"\n Olá {nome}");
        nova_string("Levi");

        Func<decimal> novo_decimal = () => 4.2m;

        var checar_nome_novo = (string novo_nome) => novo_nome.Contains('a');
        System.Console.WriteLine(checar_nome_novo("Levi"));
        //ou assim, são equivalentes
        Func<string,bool> checar_nome_novo2 = novo_nome => novo_nome.Contains('a');
        System.Console.WriteLine(checar_nome_novo2("Levi"));

        //Passando lambda direto pra método
        Rodar((x,y) => x*y);

        #endregion

        #region Métodos de extensão
        //Extender qualquer tipo, criando métodos de extensão
        //extender tipos de valor ou tipos selados (tipos que não temos controle)
        //métodos de extensão existem graças aos métodos estáticos
        //método de extensão, tem a inclusão da palavra this no primeiro parametro
        //o this só pode ser usado no primeiro parametro
        //que é o parametro onde o método vai ser acessivel
        //agora podemos chamar direto de uma string UAU
        "Teste direto da string".WriteLine(ConsoleColor.Blue);
        //método limpando o valor da string
        System.Console.WriteLine($"Valor da string: {"String limpa".LimpaString()}");
        //testando num logger
        var extensao_logger = new ConsoleLogger();
        extensao_logger.TestLogger();
        //Sempre ficar atento ao namespace
        #endregion

        #region Serialização JSON
        //usa namespace System.Text.JSON
        BankAccount conta_serializar = new BankAccount("JSON",100,logger);
        //Quando serializa uma instancia de classe ele segue a visibilidade definida
        //ou seja, campos privados n aparecem no JSON
        //campos publicos vao aparecer

        //Serializando uma instancia
        string json = JsonSerializer.Serialize(conta_serializar);
        Console.WriteLine(json);

        //Deserializando uma instancia
        //Como esse construtor espera espera parametros como loger, vai dar errro se
        //não sinalizarmos o novo construtor com a tag JsonConstructor
        BankAccount conta_deserializada = JsonSerializer.Deserialize<BankAccount>(json);
        System.Console.WriteLine(conta_deserializada.Balance);

        #endregion

        #region LINQ (Query Integrated Language) e Enumerables
        // Conjunto de tecnologias que permite que a gente crie consultas em coleções
        // documentos XML ou até mesmo banco de dados, usando somente codigo C#
        
        //exemplo com inteiros
        int[] array_numeros = {0,5,10,15,20,25,30};
        //consultar buscar os números menores que 10
        //Sintaxe de consulta (Query Syntax)
        var consulta = from numero in array_numeros
                        where  numero < 10
                        select numero;

        //LINQ usando lambda e método de extensão Where
        var consulta2 = array_numeros.Where(numero => numero < 10);
        //System.Console.WriteLine(consulta2);

        //métodos que chamam novamente a query podem aumentar muito o tempo de processamento
        foreach(var number in consulta2){//chamar consulta2 vai rodar a query denovo
            System.Console.WriteLine(number);
        }
        //para contornar esse problema usamos método To
        var resultado = consulta2.ToList();//a consulta é executada somente uma vez e então manipulamos o resultado
        System.Console.WriteLine(resultado.Count());

        //contornando só o resultado
        foreach(var number in resultado)
        {
            System.Console.WriteLine(number);
        }

        //retorna o primeiro elemento da soleção
        var resultado2 = array_numeros.First();
        //da pra encadear os métodos
        var resultado3 = array_numeros.Where(number => number > 8).First();
        //também da pra fazer assim
        var resultado4 = array_numeros.First(number => number > 8);
        //primeiro elemento ou padrão (como é inteiro o valor vai ser 0)
        var resultado5 = array_numeros.FirstOrDefault(number => number > 50);
        //ordenar os itens da coleção
        var resultado6 = array_numeros.OrderByDescending(number => number);
        //ordenar por campo especifico
        var outras_contas = new List<BankAccount>(){
            new BankAccount("Maria", 70){
                Branch="123"
            },
            new BankAccount("Levi", 50){Branch="321"},
            new BankAccount("Maite",100){Branch="321"}
        };
        var acc = outras_contas.OrderBy(conta => conta.Balance).ToArray();

        //criar agrupamentos
        var grupos = outras_contas.GroupBy(account => account.Branch);

        foreach(var group in grupos){
            System.Console.WriteLine($"Agencia: {group.Key}");
            System.Console.WriteLine("---");
            foreach(var account in group){
                System.Console.WriteLine($"{account.Name} possui ${account.Balance}");
            }
            System.Console.WriteLine("---");
        }

        //Select, pegar somente os nomes dos titulares
        var nomes_titulares = outras_contas.Select(conta => conta.Name);
        //usando método anonimo no select
        var titulares = outras_contas.Select(conta => new {conta.Name, conta.Branch});
        foreach(var titular in titulares){
            System.Console.WriteLine(titular.Name);
        }

        //enum vazio
        var enum_vazio = Enumerable.Empty<int>();

        //usando rangeaplicação
        var random = new Random();
        var range = Enumerable.Range(0,5);
        //usando o range para pegar 5 números aleatórios de 1 a 99
        var range_random = Enumerable.Range(0,5).Select(number => random.Next(1, 100));
        //para o exemplo acima da pra usar parâmetro discard também, descartável, usando _
        var random_random_com_discard = Enumerable.Range(0,5).Select(_ => random.Next(0, 100));

        #endregion

        #region Programação Assíncrona
        //uma operação sincrona vai fazer todo o seu trabalho antes de retornar, a aplicação fica
        System.Console.WriteLine("Exemplificando um método sincrono, thread.sleep, executando...");
        Thread.Sleep(5000);
        System.Console.WriteLine("Pronto");
        //uma operação assincrona vai fazer parte ou todo o seu trabalho depois de retornar pra quem inciou a operacao
        //Classe task abstrai a classe de baixo nível Thread, facilitando as async
        System.Console.WriteLine("Exemplificando um método assincrono, thread.sleep, executando...");
        //o que a gente passar pro método run vai ser executado de forma assincrona
        //
        /*var task = Task.Run(() => 
        {
            Thread.Sleep(5000);
            System.Console.WriteLine("Acordou");
        });
        System.Console.WriteLine("Pronto");
        System.Console.ReadLine();*/
        Task<int> mult_assincrona = calculo_async(3,3);
        int result_assync = await mult_assincrona;
        Console.WriteLine(result_assync);
        Console.ReadKey();
        #endregion

        #region Para publicar a aplicação
        //dotnet publish
        #endregion
    }

    //método usando a palavra Func
    static void Rodar(Func<int,int,int> calculo){
        System.Console.WriteLine(calculo(20,30));
    }

    //método compatível com delegate
    static int Soma(int a, int b){
        return a+b;
    }

    //método com palavra reservada async, permitindo usar a palaavra await em Task métodos
    //métodos assincronos sempre retornam uma task
    public static async Task<int> calculo_async(int n1, int n2){
        System.Console.WriteLine("Calculando...");
        await Task.Delay(5000);
        return n1+n2;
    }
}

namespace testando_namespace{
    //classe criada para criar os métodos de extensão
    static class Extensoes_String{
        public static void WriteLine(this string texto, ConsoleColor cor){
            Console.ForegroundColor = cor;
            System.Console.WriteLine(texto);
            Console.ResetColor();
        }
        public static string LimpaString(this string texto){
            texto = "";
            return texto;
        }

        //métodos de extensão pode ser usado para quase qualquer coisa
        public static void TestLogger(this ILogger logger){
            
        }
    }

    //Criando um delegate: delegate <tipo_retorno>
    delegate int Calcular(int x, int y);

    //Criando tipo generico: class <nome><palavra reservada T>
    class DataStore<T>
    {
        public T Value{get;set;}
    }

    class FileLogger : ILogger //outra classe concreta implementando a interface
    {
        private readonly string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }
        public void Log(string message)
        {
            File.AppendAllText(filePath, message);//gera um arquivo de log
        }
    }

    class ConsoleLogger : ILogger //classe concreta implementando a interface
    {
        public void Log(string message)
        {
            System.Console.WriteLine($"\n LOGGER: {message}{Environment.NewLine}");
        }
    }

    interface ILogger//por padrão todos os membros da interface são publicos
    {
        void Log(string message);//métodos abstratos por padrão não tem corpo,mas no c# 8 em diante pode ter uma implementacao
        //exemplificando implementacao padrao
        /*void Log(string message){
            System.Console.WriteLine($"\n LOGGER: {message}{Environment.NewLine}");
        }*/
    }

    class BankAccount //declaração de uma classe
    {
        private readonly ILogger logger; //criando o logger

        public string Branch;

        public string Name{
            get; private set;
        }

        public decimal Balance 
        { 
            get; private set;
        }

        //Esse construtor redireciona para o outro construtor
        [JsonConstructor]//atributo necessário
        public BankAccount(string name, decimal balance) : this(name, balance, new ConsoleLogger())
        {
            
        }

        public BankAccount(string nome, decimal balance, ILogger logger){
            if(string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido",nameof(nome));
            if(balance < 0)
                throw new Exception("Saldo não pode ser negativo");
            Name = nome;
            Balance = balance;
            this.logger = logger; //interface readonly só pode ser atribuida no construtor, fora acusa erro
        }

        public void Deposit(decimal amount)//mexer na variável direto não é correto, pra isso cria-se um método
        {
            if(amount <= 0){
                logger.Log($"Não é possível depositar {amount} na conta de {Name}");
                return;
            }
            Balance += amount;//soma composta com atribuição
        }
    }
}