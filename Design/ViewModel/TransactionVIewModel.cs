using Design.Context;
using Design.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Design.ViewModel
{
    public class TransactionViewModel : BaseViewModel
    {
        private ObservableCollection<Transaction> listTransaction = new ObservableCollection<Transaction>();
        public ObservableCollection<Transaction> ListTransaction { get => listTransaction; }

        private Transaction selectedTrans;
        public Transaction SelectedTrans
        {
            get => selectedTrans; set
            {
                selectedTrans = value;

                OnPropertyChanged();
            }
        }


        private ObservableCollection<Game> gameInStore = new ObservableCollection<Game>();
        public ObservableCollection<Game> GameInStore { get => gameInStore; }

        private Game selectedStore;
        public Game SelectedStore
        {
            get => selectedStore; set
            {
                selectedStore = value;
                
                OnPropertyChanged();                
            }
        }

        private ObservableCollection<GameInTran> gameInCart = new ObservableCollection<GameInTran>();
        public ObservableCollection<GameInTran> GameInCart { get => gameInCart; }

        private GameInTran selectedCart;
        public GameInTran SelectedCart
        {
            get => selectedCart; set
            {
                selectedCart = value;

                OnPropertyChanged();
            }
        }


        private List<ModePayment> mode = new List<ModePayment> { ModePayment.TienMat, ModePayment.ChuyenKhoan };
        public List<ModePayment> Mode
        {
            get => mode; set
            {
                mode = value;
                OnPropertyChanged();
            }
        }

        private ModePayment selectedMode { get; set; }
        public ModePayment SelectedMode { get => selectedMode; set { selectedMode = value; } }

        private List<PlacePayment> place = new List<PlacePayment> { PlacePayment.TrucTiep, PlacePayment.GiaoHang };
        public List<PlacePayment> Place
        {
            get => place; set
            {
                place = value;
                OnPropertyChanged();
            }
        }

        private long deposit;
        public long Deposit
        {
            get => deposit; set
            {
                deposit = value;

                OnPropertyChanged();
            }
        }

        private PlacePayment selectedPlace { get; set; }
        public PlacePayment SelectedPlace { get => selectedPlace; set { selectedPlace = value; } }

        public ICommand AddToCart { get; set; }
        public ICommand RemoveToCart { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand ClearFormCommand { get; set; }
        public ICommand ComfirmOrder { get; set; }

        
        private string searchCommand;
        public string SearchCommand {
            get => searchCommand; set
            {
                searchCommand = value;
                
                              
                OnPropertyChanged();
            }
        }

        

        public TransactionViewModel()
        {
            LoadData();
            EditCommand = new RelayCommand<object>(
                p => CheckDisplayIsOK()
                , p =>
                {
                    
                });
            ClearFormCommand = new RelayCommand<object>(p => true, p => clearForm());
            AddToCart = new RelayCommand<object>(            
                p=>true,
                p =>
                {
                    var gameTran = new GameInTran { Game = SelectedStore, Amount = 1 };
                    GameInCart.Add(gameTran);
                }
            );
            RemoveToCart = new RelayCommand<object>(
                p => true,
                p =>
                {
                    GameInCart.Remove(selectedCart);
                }
            );
        }

        private Transaction GetTransaction()
        {
            return new Transaction
            {
                Games = GameInCart,
                Deposit = Deposit,
                ModePayment = SelectedMode,
                PlacePayment = selectedPlace,
                paymentAmount = CalculateAmount(),
                Name = DateTime.Now.ToShortDateString() + ", " + SelectedMode + ", " + selectedPlace              
            };
        }
        private long CalculateAmount()
        {
            return 0;
        }

        private void clearForm()
        {
            
        }

        private bool CheckDisplayIsOK()
        {
            return true;

        }

        void LoadData()
        {
            var trans= Common.Instance.transactions.Where(c => c.Deleted == false).ToList();
            trans.ForEach(t =>  listTransaction.Add(t));
            var games = Common.Instance.games.Where(g => g.Deleted == false).ToList();
            games.ForEach(g => GameInStore.Add(g));
        }


    }
}
