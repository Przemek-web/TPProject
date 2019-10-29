using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zadanie1
{
    public class DataContext
    {
        public List<Wykaz> czytelnicy = new List<Wykaz>();
        public Dictionary<int, Katalog> katalogi = new Dictionary<int, Katalog>();
        public ObservableCollection<Zdarzenie> zdarzenie = new ObservableCollection<Zdarzenie>();
        public List<OpisStanu> egzemplarze = new List<OpisStanu>();
    }
}
