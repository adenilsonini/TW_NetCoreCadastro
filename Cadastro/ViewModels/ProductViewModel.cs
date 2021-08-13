using Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.ViewModels
{
    public class ProductViewModel
    {

        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "valor")]
        [Required(ErrorMessage = "O Valor é requerido.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public Double Value { get; set; }
       
        [Display(Name = "Disponivel")]
        public bool Disponivel { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código Do Cliente é requerido.")]
        public int IdCliente { get; set; }
        public virtual Client Client { get; set; }

    }
}
