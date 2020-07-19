using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultarEndereçoAPI.Models
{
    [Table("Enderecos")]
    public class Endereco
    {
        [Key]
        public int enderecoId { get; set; }
        public string cep  { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
    }
}
