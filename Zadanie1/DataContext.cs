using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class DataContext
    {
        public List<Wykaz> czytelnicy = new List<Wykaz>();
        public Dictionary<int, Katalog> katalogi = new Dictionary<int, Katalog>();
        public ObservableCollection<Zdarzenie> zdarzenie = new ObservableCollection<Zdarzenie>();
        public List<OpisStanu> egzemplarze = new List<OpisStanu>();
    }
}
