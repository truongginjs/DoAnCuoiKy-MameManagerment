using Design.Context;
using Design.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
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
                try
                {
                    SelectedMode = selectedTrans.ModePayment;
                    SelectedPlace = SelectedTrans.PlacePayment;
                    GameInCart.Clear();
                    selectedTrans.Games.ToList().ForEach(g => GameInCart.Add(g));
                }
                catch { };

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

        private long subTotal;
        public string SubTotal
        {
            get => subTotal.ToString(); set
            {
                subTotal = long.Parse(value);
                OnPropertyChanged();
            }
        }

        private long sales;
        public string Sales
        {
            get =>sales.ToString(); set
            {
                sales = long.Parse(value);
                OnPropertyChanged();
            }
        }

        private long total;
        public string Total
        {
            get => total.ToString(); set
            {
                total = long.Parse(value);
                OnPropertyChanged();
            }
        }



        public int kindOfSales;
        public int KindOfSales { get => kindOfSales; set {
                kindOfSales = value;
                OnPropertyChanged();
                switch (kindOfSales)
                {
                    case 0:
                        //none
                        Sales = "0";
                        break;
                    case 1:
                        //blackFriday
                        Sales = (subTotal * 0.2).ToString();
                        break;
                    case 2:
                        //cyperMonday
                        Sales = (subTotal * 0.15).ToString();
                        break;
                    case 3:
                        //Coupon
                        Sales = (subTotal - 20000).ToString();
                        break;
                    case 4:
                        //voicher
                        Sales = (subTotal * 0.2).ToString();
                        break;
                }
                SetTotal();
            }
        }

        private string searchCommand;
        public string SearchCommand {
            get => searchCommand; set
            {
                searchCommand = value;      
                OnPropertyChanged();
            }
        }

        private PlacePayment selectedPlace { get; set; }
        public PlacePayment SelectedPlace { get => selectedPlace; set { selectedPlace = value; } }

        public ICommand AddToCart { get; set; }
        public ICommand RemoveToCart { get; set; }
        public ICommand ClearFormCommand { get; set; }
        public ICommand ComfirmOrder { get; set; }

        

        

        public TransactionViewModel()
        {
            LoadData();
            ComfirmOrder = new RelayCommand<object>(
                p => CheckDisplayIsOK()
                , p =>
                {
                    try
                    {
                        var trans = GetTransaction();
                        ListTransaction.Add(trans);
                        Common.Instance.transactions.Add(trans);
                        Common.Instance.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                    }
                    
                });
            ClearFormCommand = new RelayCommand<object>(p => true, p => clearForm());
            AddToCart = new RelayCommand<object>(
                p => true,
                p =>
                {
                    if (SelectedStore != null)
                    {
                        var gameTran = new GameInTran { Game = SelectedStore, Amount = 1, Name=SelectedStore.Name };
                        GameInCart.Add(gameTran);
                        long sum = 0;
                        GameInCart.ToList().ForEach(g => sum += g.Game.SaleCost);
                        SubTotal = sum.ToString();
                        SetTotal();
                    }
                    OnPropertyChanged();
                }
            );
            RemoveToCart = new RelayCommand<object>(
                p => true,
                p =>
                {
                    GameInCart.Remove(selectedCart);
                    long sum = 0;
                    GameInCart.ToList().ForEach(g => sum += g.Game.SaleCost);
                    SubTotal = sum.ToString();
                    SetTotal();

                    OnPropertyChanged();
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
            return total;
        }

        private void clearForm()
        {
            
        }

        private bool CheckDisplayIsOK()
        {
            if (GameInCart.Count > 0 && Mode!=null && place!=null&& total>0)
                return true;
            return false;
        }

        void LoadData()
        {
            var trans= Common.Instance.transactions.Where(c => c.Deleted == false).ToList();
            trans.ForEach(t =>  listTransaction.Add(t));
            var games = Common.Instance.games.Where(g => g.Deleted == false).ToList();
            games.ForEach(g => GameInStore.Add(g));
        }

        void SetTotal()
        {
            Total = (subTotal - sales).ToString();
        }
    }
}
