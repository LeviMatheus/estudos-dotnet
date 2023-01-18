using System;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace mensageria
{
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

    //clase do envio
    public class Send
    {
        public static void Main()
        {
            //cria uma fábrica com nome de host localhost
            var fabrica = new ConnectionFactory()
            {
                HostName = "localhost" //se fosse um host remoto teria que passar o nome e o IP aqui
            };

            //cria uma conexão a partir da fábrica
            using (var conexao = fabrica.CreateConnection())
            //cria um canal a partir da conexão
            using (var canal = conexao.CreateModel())
            {
                //agora criar a fila
                canal.QueueDeclare(
                    queue: "queue_principal",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                //Criação de uma mensagem
                Cliente cliente1 = new Cliente("Levi", 5568);
                string mensagem = JsonConvert.SerializeObject(cliente1);

                //Declarar corpo
                var corpo = Encoding.UTF8.GetBytes(mensagem);

                //Publicando o corpo
                canal.BasicPublish(
                    exchange: "",//configura a exchange
                    routingKey: "queue_principal",//passar o canal de comunicação
                    basicProperties: null,
                    body:corpo//corpo
                );

                //avisa do envio
                Console.WriteLine($" [x] Enviado {mensagem}");
            }

            //Bloqueia a finalização
            Console.ReadLine();
        }
    }
}