
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.ComponentModel;
using AppTol.Models;
using AppTol.Services;
using static AppTol.Models.data_config;

namespace AppTol.ViewsModels
{
    internal class BasePedidoViewModel : INotifyPropertyChanged
    {
        public cliente _cliente;
        public IValidator _pedidoValidator;
        public IClienteRepositorio _clienteService;

        protected IMesssageService _messageService;
        protected INavigationService _navigationService;

        public BasePedidoViewModel()
        {
            _messageService = DependencyService.Get<IMesssageService>();
            _navigationService = DependencyService.Get<INavigationService>();
        }

        public string nome
        {
            get => _cliente.nome;
            set
            {
                _cliente.nome = value;
                NotifyPropertyChanged(nameof(nome));
            }
        }

        public Int32 telefone
        {
            get => _cliente.telefone;
            set
            {
                _cliente.telefone = value;
                NotifyPropertyChanged(nameof(telefone));
            }
        }

        public DateTime atualizacao
        {
            get => _cliente.atualizacao; 
            set
            {
                _cliente.atualizacao = value;
                NotifyPropertyChanged(nameof(atualizacao));
            }
        }

        public string endereco
        {
            get => _cliente.endereco;
            set
            {
                _cliente.endereco = value;
                NotifyPropertyChanged(nameof(endereco));
            }
        }

        public string bairro
        {
            get => _cliente.bairro;
            set
            {
                _cliente.bairro = value;
                NotifyPropertyChanged(nameof(bairro));
            }
        }

        public string cidade
        {
            get => _cliente.cidade; 
            set
            {
                _cliente.cidade = value;
                NotifyPropertyChanged(nameof(cidade));
            }
        }

        public Int32 numero
        {
            get => (_cliente.numero);
            set
            {
                _cliente.numero = value;
                NotifyPropertyChanged(nameof(numero));
            }
        }

        public Int32 cep
        {
            get => _cliente.cep; 
            set
            {
                _cliente.cep = value;
                NotifyPropertyChanged(nameof(cep));
            }

        }

        public Int32 telefone1
        {
            get => _cliente.telefone1;
            set
            {
                _cliente.telefone1 = value;
                NotifyPropertyChanged(nameof(telefone1));
            }
        }

        public Int32 telefone2
        {
            get => (Int32)_cliente.telefone2;
            set
            {
                _cliente.telefone2 = value;
                NotifyPropertyChanged(nameof(telefone2));

            }
        }

        public Int32 celular
        {
            get => _cliente.celular; 
            set
            {
                _cliente.celular = value;
                NotifyPropertyChanged(nameof(celular));
            }
        }

        public Int32 contato
        {
            get => _cliente.contato; 
            set
            {
                _cliente.contato = value;
                NotifyPropertyChanged(nameof(contato));
            }
        }

        public Int32 cnpj
        {
            get => _cliente.cnpj;
            set
            {
                _cliente.cnpj = value;
                NotifyPropertyChanged(nameof(cnpj));
            }
        }

        public Int32 ie
        {
            get => _cliente.ie;
            set
            {
                _cliente.ie = value;
                NotifyPropertyChanged(nameof(ie));

            }
        }

        public Int32 cpf
        {
            get => _cliente.cpf;
            set
            {
                _cliente.cpf = value;
                NotifyPropertyChanged(nameof(cpf));
            }
        }

        public Int32 rg
        {
            get => _cliente.rg;
            set
            {
                _cliente.rg = value;
                NotifyPropertyChanged(nameof(rg));
            }
                
        }

        public String novo
        {
            get => _cliente.novo;
            set
            {
                _cliente.novo = value;
                NotifyPropertyChanged(nameof(novo));
            }
        }

        public String fantasia
        {
            get => _cliente.fantasia;
            set
            {
                _cliente.fantasia = value;
                NotifyPropertyChanged(nameof(fantasia));
            }
        }

        public String email
        {
            get => _cliente.email;
            set
            {
                _cliente.email = value;
                NotifyPropertyChanged(nameof(email));
            }
        }

        List<cliente> _clienteLista;
        public List<cliente> ClienteLista
        {
            get => _clienteLista;
            set
            {
                _clienteLista = value;
                NotifyPropertyChanged(nameof(ClienteLista));
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }
}
