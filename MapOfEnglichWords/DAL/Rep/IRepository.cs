using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOfEnglichWords.DAL.Rep
{
    //crud операции
    public interface IRepository<T>
    {
        void Add(T value);
        void Remove(T value);
        void Update(ref T oldValue, T newValue);
        ObservableCollection<T> Get();
    }
}
