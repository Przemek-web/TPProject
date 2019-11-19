using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Zadanie1
{
    public class DataContext
    {
        public List<Wykaz> czytelnicy = new List<Wykaz>();
        public Dictionary<int, Katalog> katalogi = new Dictionary<int, Katalog>();
        public ObservableCollection<Zdarzenie> zdarzenia = new ObservableCollection<Zdarzenie>();
        public List<OpisStanu> egzemplarze = new List<OpisStanu>();
    }
}
