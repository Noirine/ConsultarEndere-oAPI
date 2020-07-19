using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultarEndereçoAPI.Dal;
using ConsultarEndereçoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultarEndereçoAPI.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class EnderecosAPIController : ControllerBase
    {
        private readonly EnderecoDAO _enderecoDAO;
        public EnderecosAPIController(EnderecoDAO enderecoDAO)
        {
            _enderecoDAO = enderecoDAO;

        }
        //GET: /api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult ListarEnderecos()
        {
            return Ok (_enderecoDAO.Listar());
        }

        //GET: /api/Endereco/ListarEndereco/81730000
        [HttpGet]
        [Route("ListarEndereco")]
        public IActionResult ListarEndereco(int cep)
        {
            Endereco endereco = _enderecoDAO.BuscarEndereco(cep);
            return Ok (endereco);
        }

        //POST: /api/Endereco/CadastrarEndereco
        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult CadastrarEndereco(Endereco endereco)
        {
            _enderecoDAO.Cadastrar(endereco);
            return Created("", endereco);
        }

        //PUT: /api/Endereco/AlterarEndereco
        [HttpPut]
        [Route("AlterarEndereco")]
        public IActionResult AlterarEndereco(int id)
        {
            Endereco endereco = _enderecoDAO.ReceberDado(id);
            _enderecoDAO.Alterar(endereco);
            return Created("", endereco);
        }

        //DELETE: /api/Endereco/DeletarEndereco/2
        [HttpDelete]
        [Route("DeletarEndereco")]
        public IActionResult DeletarEndereco(int id)
        {
            _enderecoDAO.Remover(id);
            return Ok ();
        }
    }
}
