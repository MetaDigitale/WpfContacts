using System.Collections.ObjectModel;
using WpfContacts.Dtos;

namespace WpfContacts.ViewModels
{
    interface IContattiViewModel
    {
        ObservableCollection<Contatto> ElencoContatti { get; set; }

        void CreateContatto();
        void DeleteContatto();
        Contatto GetContatto();
        void SaveContatto();
    }
}
