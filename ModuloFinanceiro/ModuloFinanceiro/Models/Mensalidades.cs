using System;
using System.ComponentModel.DataAnnotations;

namespace ModuloFinanceiro.Models
{
    public class Mensalidades
    {
        [Key]
        [Required(ErrorMessage = "Informe o nome do curso.")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "Informe o tipo de formação escolar.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Informe o valor do curso.")]
        [Display(Name = "Valor do Curso")]
        public float ValorDoCurso { get; set; }

        [Required(ErrorMessage = "Informe o valor da taxa de juros.")]
        public float Juros { get; set; }

        [Required(ErrorMessage = "Informe o valor da bolsa.")]
        public float Bolsa { get; set; }

        [Required(ErrorMessage = "Informe o valor da Mensalidade.")]
        public float Mensalidade { get; set; }

        [Required]
        [Display(Name = "Data de Pagamento")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida, preencha no formato dd/mm/aaaa.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataDePagamento { get; set; }

        [Required]
        [Display(Name = "Data de Vencimento")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida, preencha no formato dd/mm/aaaa.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataDeVencimento { get; set; }
    }
}