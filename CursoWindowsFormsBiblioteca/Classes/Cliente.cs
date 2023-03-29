using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CursoWindowsFormsBiblioteca.Classes
{
    public class Cliente
    {
        public class Unit 
        { 
            [Required(ErrorMessage = "Código do cliente é obrigatório")]
            [RegularExpression("([0-9]+)",ErrorMessage = "Código do Cliente é somente valores númericos")]
            [StringLength(6,MinimumLength = 6,ErrorMessage = "O Código do cliente deve ter 6 dígitos")]
            public string Id
            {
                get;
                set;
            }
            [Required(ErrorMessage = "Nome do cliente é obrigatório")]
            [StringLength(50, ErrorMessage = "O Nome do cliente deve ter no máximo 50 caracteres")]
            public string Nome
            {
                get;
                set;
            }
            [StringLength(50, ErrorMessage = "O Nome do Pai deve ter no máximo 50 caracteres")]
            public string NomePai
            {
                get;
                set;
            }
            [Required(ErrorMessage = "Nome do cliente é obrigatório")]
            [StringLength(50, ErrorMessage = "O Nome da Mãe deve ter no máximo 50 caracteres")]
            public string NomeMae
            {
                get;
                set;
            }
            public bool NaoTemPai
            {
                get;
                set;
            }
            [Required(ErrorMessage = "CPF é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Código do Cliente é somente valores númericos")]
            [StringLength(11,MinimumLength = 11,ErrorMessage = "O CPF deve ter 11 dígitos")]
            public string Cpf
            {
                get;
                set;
            }
            [Required(ErrorMessage = "Gênero é obrigatório")]
            public int Genero
            {
                get;
                set;
            }
            [Required(ErrorMessage = "Gênero é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Código do Cliente é somente valores númericos")]
            [StringLength(8, MinimumLength = 8, ErrorMessage = "O CPF deve ter 8 dígitos")]
            public string Cep
            {
                get;
                set;
            }
            [Required(ErrorMessage = "O Logradouro é obrigatório")]
            [StringLength(100, ErrorMessage = "O Logradouro deve ter no máximo 100 caracteres")]
            public string Logradouro
            {
                get;
                set;
            }
            [Required(ErrorMessage = "O Complemento é obrigatório")]
            [StringLength(100, ErrorMessage = "O Complemento deve ter no máximo 100 caracteres")]
            public string Complemento
            {
                get;
                set;
            }
            [Required(ErrorMessage = "O Bairro é obrigatório")]
            [StringLength(50, ErrorMessage = "O Bairro deve ter no máximo 50 caracteres")]
            public string Bairro
            {
                get;
                set;
            }
            [Required(ErrorMessage = "A Cidade é obrigatória")]
            [StringLength(50, ErrorMessage = "O Cidade deve ter no máximo 50 caracteres")]
            public string Cidade
            {
                get;
                set;
            }
            [Required(ErrorMessage = "O Estado é obrigatório")]
            [StringLength(50, ErrorMessage = "O Estado deve ter no máximo 50 caracteres")]
            public string Estado
            {
                get;
                set;
            }
            [Required(ErrorMessage = "Telefone é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Telefone é somente valores númericos")]
            public string Telefone
            {
                get;
                set;
            }
            public string Profissao
            {
                get;
                set;
            }
            [Required(ErrorMessage = "Renda Familiar é obrigatória")]
            [Range(0,double.MaxValue,ErrorMessage = "Renda familiar deve ser um valor positivo")]
            public double RendaFamiliar
            {
                get;
                set;
            }

            public void ValidaClasse()
            {
                ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
                List<ValidationResult> results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(this, context, results, true);

                if (isValid == false)
                {
                    StringBuilder sbrErrors = new StringBuilder();
                    foreach (var validationResult in results)
                    {
                        sbrErrors.AppendLine(validationResult.ErrorMessage);
                    }
                    throw new ValidationException(sbrErrors.ToString());
                }
            }

            public void ValidaComplemento()
            {
                if(this.NomePai == this.NomeMae)
                {
                    throw new Exception("Nome do pai e da mãe não podem ser iguais");
                }
                if(this.NaoTemPai == false)
                {
                    if(this.NomePai == "")
                    {
                        throw new Exception("Nome do pai não pode estar vazio quando a propriedade Pai desconhecido não estiver selecionada");
                    }
                }
                bool validaCPF = Cls_Uteis.Valida(this.Cpf);
                if(validaCPF == false)
                {
                    throw new Exception("Cpf inválido");
                }
            }
        }
        public class List 
        {
            public List<Unit> ListUnit
            {
                get;
                set;
            }
        }
    }
}
