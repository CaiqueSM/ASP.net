using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExemploValidacao.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage ="Nome deve ser preenchido")]
        public string Nome { get; set; }

        [StringLength(50,MinimumLength = 5, ErrorMessage =  "A observação deve ter entre 5 e 50 caracteres")]
        [Required(ErrorMessage = "Preencha a obsservação")]
        public string Observacao { get; set; }

        [Range(18, 50, ErrorMessage = "A idade deve estar entre 18 e 50 anos")]
        [Required(ErrorMessage ="Informe uma idade")]
        public int Idade { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O Email não é valido")]
        public string Email { get; set; }

        [RegularExpression(@"[a-zA-Z]{5,15}",ErrorMessage ="O login deve possuir somente letres e ter entre 5 e 15 caracteres")]
        [Required(ErrorMessage ="O login deve ser preechido")]
        [Remote("LoginUnico","Pessoa",ErrorMessage ="Este nome de login já exite.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada")]
        public string Senha { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmarSenha { get; set; } 
    }
}