using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Bars_Client.Model;
using Prism.Commands;
using Prism.Mvvm;

namespace Bars_Client.ModelView
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            GetContracts = new DelegateCommand((() =>
            {
                contractModel = new Contract(Ip, Port);
                Task.Run((() =>
                {
                    contracts = contractModel.GetContracts();
                    if (contracts != null)
                    {
                        OnPropertyChanged("Contracts");
                    }
                }));
            }));
        }

        public List<Contract> Contracts
        {
            get => contracts;
            set
            {
                contracts = value;
                OnPropertyChanged();
            }
        }

        private Contract contractModel { get; set; }
        private string ip { get; set; }
        private int port { get; set; }
        private List<Contract> contracts { get; set; }

        public string Ip
        {
            get => ip;
            set
            {
                ip = value;
                OnPropertyChanged();
            }
        }

        public int Port
        {
            get => port;
            set
            {
                port = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand GetContracts { get; }
    }
}