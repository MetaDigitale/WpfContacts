using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfContacts.Dtos;
using System.Linq;
using System.Windows;

namespace WpfContacts.ViewModels
{
    class ContattiViewModel : IContattiViewModel, INotifyPropertyChanged
    {
        public ContattiViewModel()
        {
            //this.InitializeElencoContatti();
        }

        private void InitializeElencoContatti()
        {
            var contatto = new Contatto();
            contatto.Nome = "Alberto";
            contatto.Cognome = "Acerbis";
            contatto.Email = "mail@dominio.com";
            this.ElencoContatti.Add(contatto);

            this.ElencoContatti.Add(new Contatto
            {
                Nome = "Alberto",
                Cognome = "Acerbis",
                Email = "mail@dominio.com"
            });
        }

        #region Public Properties
        private ObservableCollection<Contatto> _elencoContatti;
        public ObservableCollection<Contatto> ElencoContatti
        {
            get
            {
                return this._elencoContatti ?? 
                    (this._elencoContatti = new ObservableCollection<Contatto>());
            }
            set
            {
                if (this._elencoContatti == value) return;

                this._elencoContatti = value;
                InvokePropertyChanged("ElencoContatti");
            }
        }

        private Contatto _currentContatto;
        public Contatto CurrentContatto
        {
            get { return this._currentContatto; }
            set
            {
                if (this._currentContatto == value) return;

                this._currentContatto = value;
                InvokePropertyChanged(nameof(CurrentContatto));
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void InvokePropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private int CodiceContattoFactory()
        {
            if (ElencoContatti.Any())
                return ElencoContatti.Count + 1;
            else
                return 1;
        }

        #region Metodi da Interfaccia
        public void CreateContatto()
        {
            CurrentContatto = new Contatto();
            CurrentContatto.Codice = CodiceContattoFactory();
            CurrentContatto.Nome = "Nuovo";
        }

        public void DeleteContatto()
        {
            if (MessageBox.Show("Confermi La Cancellazione del Contatto Selezionato", "WpfContacts", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var chkContatto =
                ElencoContatti.FirstOrDefault(c => c.Codice == CurrentContatto.Codice);

                if (chkContatto != null)
                {
                    ElencoContatti.Remove(chkContatto);
                }
            }
            
        }

        public Contatto GetContatto()
        {
            return ElencoContatti.FirstOrDefault(c => c.Codice == CurrentContatto.Codice);
        }

        public void SaveContatto()
        {
            var chkContatto = 
                ElencoContatti.FirstOrDefault(c => c.Codice == CurrentContatto.Codice);

            if (chkContatto == null)
            {
                ElencoContatti.Add(CurrentContatto);
            }
            else
            {
                chkContatto.Nome = CurrentContatto.Nome;
                chkContatto.Cognome = CurrentContatto.Cognome;
                chkContatto.Email = CurrentContatto.Email;
            }
        }
        #endregion
    }
}
