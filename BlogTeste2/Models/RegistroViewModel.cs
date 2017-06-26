using System.ComponentModel.DataAnnotations;

namespace BlogTeste2.Models
{
    public class RegistroViewModel
    {
        [Required]
        public string LoginName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [Compare("Senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}