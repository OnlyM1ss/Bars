using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Bars_Client.Model;
using Prism.Mvvm;

namespace Bars_Client.ModelView
{
    class MainWindowViewModel : BindableBase
    {
        private Contract contractModel { get; }

        public MainWindowViewModel()
        {
            contractModel = new Contract();
            contracts = contractModel.GetContracts();
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
    }
}