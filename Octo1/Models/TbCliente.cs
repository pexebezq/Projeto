using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Octo1.Models
{
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbEndereco = new HashSet<TbEndereco>();
            TbTelefone = new HashSet<TbTelefone>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Tipo { get; set; }
        public string CpfCnpj { get; set; }
        public string RgIe { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascFund { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataCadastro { get; set; }

        public virtual ICollection<TbEndereco> TbEndereco { get; set; }
        public virtual ICollection<TbTelefone> TbTelefone { get; set; }
    }
}
