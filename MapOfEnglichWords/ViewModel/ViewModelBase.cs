
using MapOfEnglishWords.DAL.LocalStorage;
using MapOfEnglishWords.DAL.Rep;
using MapOfEnglishWords.View;
using MapOfEnglishWords.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglishWords.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        public IView View { get; set; }
        protected UnitOfWork manager;

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName]string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            //вызываем событие, уведомляем все подписчиков об изменении свойства
            NotifyPropertyChanged(propertyName);
            return true;
        }
        
        public ViewModelBase(IView view)
        {
            View = view;
            View.SetViewModel(this);
            manager = new UnitOfWork(LocalStorageCode.Instance);
        }
        
    }
}
