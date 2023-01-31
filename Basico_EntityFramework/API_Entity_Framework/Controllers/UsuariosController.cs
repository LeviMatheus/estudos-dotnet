using Comercio.API.Repositories;
using Comercio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Comercio.API.Controllers
{
    [Route("api/[controller]")]//rota na API
    [ApiController]//Notation com comportamentos préconfigurados
    public class UsuariosController : ControllerBase//extendendo a classe base de controlador
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;/* Chamando dentro do construtor para não ter que ficar chamando
                                      * dentro de cada método */
        }

        // {endereco_site}/api/usuarios
        [HttpGet]
        public IActionResult Get()//IActionResult é uma classe o asp.net para responder no formato http response
        {
            var userList = _repository.Get();//pegar os usuários

            return Ok(userList);//returna um ok object result devolvendo o JSON do objeto lista de usuários
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _repository.Get(id);

            if (user == null)
                return NotFound($"Usuário com id {id} não encontrado");
            
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Usuario usuario)
        {
            if (usuario == null)
                return NotFound($"Usuário não existe");

            _repository.Add(usuario);

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody]Usuario usuario, int id)
        {
            if (usuario == null)
                return NotFound($"Usuário não existe");
            else if (id != usuario.Id)
                return BadRequest($"IDs de usuário não coincidem");

            _repository.Update(usuario);

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);

            return Ok();
        }
    }
}
