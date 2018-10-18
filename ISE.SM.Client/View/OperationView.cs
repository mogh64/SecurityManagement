using ISE.SM.Client.Common.Presenter;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ISE.SM.Client.View
{
    public class OperationView
    {
        OperationPresenter presenter = new OperationPresenter();
        public BindingList<OperationDto> OperationBindingList { get; set; }
        public BindingList<OperationDto> LoadOperations(bool withDefaults=true)
        {
            var container = presenter.GetAll();
            if(withDefaults)
              OperationBindingList = new BindingList<OperationDto>(container.OperationDtoList);
            else
                OperationBindingList = new BindingList<OperationDto>(container.OperationDtoList.Where(it=>!it.IsDefaultBool).ToList());
            OperationBindingList.AllowNew = true;
            OperationBindingList.AllowEdit = true;
            OperationBindingList.AllowRemove = true;
            OperationBindingList.RaiseListChangedEvents = true;
            return OperationBindingList;
        }
        public bool Insert(OperationDto operation)
        {
            if (presenter.Insert(operation) != null)
            {
                OperationBindingList.Add(operation);
                return true;
            }
            return false;
        }
        public bool Update(OperationDto operation)
        {
            if (presenter.Update(operation))
            {

                OperationBindingList.ResetBindings();
                return true;
            }
            return false;
        }
        public bool Remove(OperationDto operation)
        {
            if (presenter.Remove(operation))
            {
                OperationBindingList.Remove(operation);
                return true;
            }
            return false;
        }
    }
}
