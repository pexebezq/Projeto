using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Octo1.Models
{
    public partial class TbEndereco
    {
        public int Codigo { get; set; }
        public int CodPessoa { get; set; }
        public byte Tipo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }

        public virtual TbCliente CodPessoaNavigation { get; set; }
    }
}
