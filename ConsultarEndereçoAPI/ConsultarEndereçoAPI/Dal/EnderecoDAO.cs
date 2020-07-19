using ConsultarEndereçoAPI.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultarEndereçoAPI.Dal
{
    public class EnderecoDAO 
    {
        private readonly Contexto _context;
        public EnderecoDAO(Contexto context)
        {
            _context = context;
        }

        public void Cadastrar(Endereco endereco)
        {        
                _context.Enderecos.Add(endereco);
                _context.SaveChanges();          
        }

        public List<Endereco> Listar()
        {
            return _context.Enderecos.ToList();
        }

        public Endereco BuscarEndereco(int cep)
        {
            Endereco endereco = _context.Enderecos.Find(cep);
            return endereco;

        }
            
        public Endereco ReceberDado(int id)
        {
            Endereco endereco = _context.Enderecos.Find(id);
            _context.SaveChanges();
            return endereco;
        }

        public void Alterar(Endereco endereco)
        {
            _context.Update(endereco);
            _context.SaveChanges();
        }
                

        public void Remover(int id)
        {
            Endereco endereco = _context.Enderecos.Find(id);
            _context.Remove(endereco);
            _context.SaveChanges();

        }




    }
}
