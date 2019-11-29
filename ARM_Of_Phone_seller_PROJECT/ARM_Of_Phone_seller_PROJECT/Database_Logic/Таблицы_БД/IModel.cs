using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM_Of_Phone_seller_PROJECT.Model
{
    public interface IModel<T>
    {
        void Update(T item);
        void Delete(T item);
        void Insert(T item);
        IEnumerable<T> Select();
    }
}