using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Newtonsoft.Json;

public class Cliente
{
    //string _mensagem;
    private string _cliente_id;
    public int cliente_matricula;
    public string cliente_nome;

    public Cliente(string cliente_nome, int cliente_matricula)
    {
        this._cliente_id = Guid.NewGuid().ToString();
        this.cliente_matricula = cliente_matricula;
        this.cliente_nome = cliente_nome;
    }

    public string ID => _cliente_id;
}

class Receive {

    public static void Main(string[] args)
    {
        //cria fabrica
        var fabrica = new ConnectionFactory()
        {
            HostName = "localhost",//hostname e o ip de acesso
        };

        //cria a conexão
        using (var conexao = fabrica.CreateConnection())
        //cria o canal
        using (var canal = conexao.CreateModel())
        {
            //declara a fila e os parâmetros
            canal.QueueDeclare(
                queue: "queue_principal",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            //manipulador de evento para o consumer
            var consumidor = new EventingBasicConsumer(canal);
            consumidor.Received += (modelo, argumentos_evento) =>
            {
                var corpo = argumentos_evento.Body.ToArray();
                Cliente? cliente1 = JsonConvert.DeserializeObject<Cliente>(Encoding.UTF8.GetString(corpo));
                Console.WriteLine($" [x] Recebido Cliente: {cliente1.ID}");
            };

            //consumir
            canal.BasicConsume(
                queue: "queue_principal", //Nome da fila
                autoAck: true, //Aceite
                consumer: consumidor //passa o consumidor
            );

            Console.ReadLine();
        }
    }
}