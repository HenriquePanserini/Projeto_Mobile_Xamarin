using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using System.Threading;
using static AppTol.Models.data_config;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml;
using EllipticCurve.Utils;

namespace AppTol.Validator
{
    public class ClienteValidator : AbstractValidator<cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.nome).Must(n => ValidateStringEmpty(n)).WithMessage("O nome não pode ser vazio");
            RuleFor(c => c.telefone).NotEmpty().WithMessage("Informe o telefone").Must(i =>ValidateIntEmpty(i)).WithMessage("Telefone nao pode ser vazio");
            RuleFor(c => c.atualizacao).NotEmpty().WithMessage("Informe a data").Must(DataNoZero).WithMessage("A data nao pode ser vazia");
            RuleFor(c => c.email).Must(n => ValidateStringEmpty(n)).WithMessage("Email nao pode ser vazio");
            RuleFor(c => c.endereco).Must(n => ValidateStringEmpty(n)).WithMessage("Endereco não pode ser vazio");
            RuleFor(c => c.bairro).Must(n => ValidateStringEmpty(n)).WithMessage("Bairro não pode ser vazio");

        }

        private static bool DataNoZero(DateTime dateTime)
        {

            return (dateTime != null);

        }

        private bool ValidateStringEmpty(string stringValue)
        {
            throw new NotImplementedException();
        }

        private bool ValidateIntEmpty(int integerValue)
        {
            throw new NotImplementedException();
        }
    }
}
