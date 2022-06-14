using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Octo1.Models
{
    public partial class TbTelefone
    {
        public int Codigo { get; set; }
        public int CodPessoa { get; set; }
        public byte Tipo { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }
        public string Observacoes { get; set; }

        public virtual TbCliente CodPessoaNavigation { get; set; }
    }
}
