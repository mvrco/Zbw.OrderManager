using log4net;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Windows;
using System.Windows.Input;
using ZbW.ITB1821H.OrderManager.Controls;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Service.Interfaces;

namespace ZbW.ITB1821H.OrderManager.UserInterface.Windows
{
    public class SingleObjectWindowViewModel<T, U, V> : BaseViewModel where T : IValidate where V : IServiceBase<U, T>
    {
        public SingleObjectWindowViewModel(T currentBusinessObject, V currentService) : base(LogManager.GetLogger(nameof(SingleObjectWindowViewModel<T, U, V>)))
        {
            service = currentService;
            BusinessObject = currentBusinessObject;
            backup = currentBusinessObject;

            Save = new ActionCommand(OnSave);
        }

        private V service;

        private T backup;
        public T BusinessObject { get; set; }

        public ICommand Save { get; }

        private void OnSave()
        {
            try
            {
                service.Update(BusinessObject);
            }
            catch(Exception e)
            {
                MessageBox.Show("Problem saving");
            }
        }
    }
}