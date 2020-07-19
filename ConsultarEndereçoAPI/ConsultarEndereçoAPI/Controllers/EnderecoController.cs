using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ConsultarEndereçoAPI.Dal;
using ConsultarEndereçoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// Ariane Noirine Pimentel Silva Assis Neves, Matricula 1621586

namespace ConsultarEndereçoAPI.Controllers
{
    public class EnderecoController : Controller
    {

        private readonly EnderecoDAO _enderecoDAO;
        public EnderecoController(EnderecoDAO enderecoDAO)
        {
            _enderecoDAO = enderecoDAO;
            
        }        
      
        public IActionResult Inicial()
        {
            
            if (TempData["resultado"] != null)
            {
                string resultado = TempData["resultado"].ToString();
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);

                    _enderecoDAO.Cadastrar(endereco);
                    return View(_enderecoDAO.Listar());              

            }
            return View(_enderecoDAO.Listar());            
        }       

        [HttpPost]
        public IActionResult ConsultaCep (string cep) 
        {         
                string url = $@"http://viacep.com.br/ws/{cep}/json/";
                WebClient endereco = new WebClient();
                TempData["resultado"] = endereco.DownloadString(url);
                      
                return RedirectToAction("Inicial");           
                        
        }

        public ActionResult Remover(int id)
        {
            _enderecoDAO.Remover(id);

            return RedirectToAction("Inicial");
        }

        public IActionResult Alterar(int id)
        {

            Endereco endereco = _enderecoDAO.ReceberDado(id);
            return View(endereco);
        }

        [HttpPost]
        public IActionResult Alterar(Endereco endereco)
        {
            _enderecoDAO.Alterar(endereco);
            return RedirectToAction("Inicial");
        }

    }
}
