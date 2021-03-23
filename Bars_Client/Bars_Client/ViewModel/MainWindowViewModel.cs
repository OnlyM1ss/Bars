using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Bars_Client.Model;
using Prism.Commands;
using Prism.Mvvm;

namespace Bars_Client.ModelView
{
    class MainWindowViewModel : BindableBase
    {
        private Contract contractModel { get; }

        public MainWindowViewModel()
        {
            contractModel = new Contract();
            GetContracts = new DelegateCommand((() =>
            {
                Task.Run((() =>
                {
                    contracts = contractModel.GetContracts();
                    OnPropertyChanged("Contracts");
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

        private List<Contract> contracts { get; set; }
        public DelegateCommand GetContracts { get; }
    }
}