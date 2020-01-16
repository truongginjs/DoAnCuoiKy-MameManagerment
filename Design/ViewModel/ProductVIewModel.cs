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
    public class ProductViewModel : BaseViewModel
    {
        private ObservableCollection<Game> listProduct = new ObservableCollection<Game>();
        public ObservableCollection<Game> ListProduct { get => listProduct; }

        private ObservableCollection<Category> listCategory = new ObservableCollection<Category>();
        public ObservableCollection<Category> ListCategory { get => listCategory; }

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get => selectedCategory; set
            {
                selectedCategory = value;
                
                OnPropertyChanged();
            }
        }

        private String textButton = "Add";
        public String TextButton
        {
            get => textButton; set
            {
                textButton = value;
                OnPropertyChanged();
            }
        }


        private Game selectedProduct;
        public Game SelectedProduct
        {
            get => selectedProduct; set
            {
                selectedProduct = value;
                OnPropertyChanged();
                if (selectedProduct != null)
                {
                    TextButton = "Update";
                    Name = selectedProduct.Name;
                    Amount = selectedProduct.Amount;
                    Publisher = selectedProduct.Publisher;
                    SCost = selectedProduct.SaleCost;
                    PCost = selectedProduct.PurchaseCost;
                    SelectedCategory = selectedProduct.Category;
                    Detail = selectedProduct.Detail;
                }
            }
        }

        private String name;
        public String Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private int amount;
        public int Amount
        {
            get => amount; set
            {
                amount = value;
                OnPropertyChanged();
            }
        }

        private String publisher;
        public String Publisher
        {
            get => publisher; set
            {
                publisher = value;
                OnPropertyChanged();
            }
        }

        private long pCost;
        public long PCost
        {
            get => pCost; set
            {
                pCost = value;
                OnPropertyChanged();

            }
        }

        private long sCost;
        public long SCost
        {
            get => sCost; set
            {
                sCost = value;
                OnPropertyChanged();

            }
        }

        private string detail;
        public string Detail
        {
            get => detail; set
            {
                detail = value;
                OnPropertyChanged();
            }
        }
        


        public ICommand EditCommand { get; set; }
        public ICommand ClearFormCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private string searchCommand;
        public string SearchCommand { get=> searchCommand; set
            {
                searchCommand = value;
                if (!string.IsNullOrEmpty(searchCommand))
                {

                    var result=Common.Instance.games.Where(g => g.Name.Contains(searchCommand) && g.Deleted == false).ToList();
                    ListProduct.Clear();
                    result.ForEach(r => ListProduct.Add(r));  
                    
                }
                else
                {
                    var games = Common.Instance.games.Include("Category").Where(g => g.Deleted == false).ToList();
                    listProduct.Clear();
                    games.ForEach(g => listProduct.Add(g));
                }
                              
                OnPropertyChanged();
            }
        }

        

        public ProductViewModel()
        {
            LoadData();
            EditCommand = new RelayCommand<object>(
                p => CheckDisplayIsOK()
                , p =>
                {

                    if (selectedProduct == null)
                    {
                        var game = GetGame();
                        Common.Instance.games.Add(game);
                        ListProduct.Add(game);

                    }
                    else
                    {


                        var index = ListProduct.IndexOf(SelectedProduct);

                        SelectedProduct.Name = Name;
                        SelectedProduct.Publisher = Publisher;
                        SelectedProduct.PurchaseCost = SCost;
                        SelectedProduct.SaleCost = SCost;
                        SelectedProduct.Amount = Amount;
                        SelectedProduct.Category = SelectedCategory;
                        SelectedProduct.Detail = Detail;
                        Common.Instance.SaveChanges();
                        var game = ListProduct.Where(g => g.Id == SelectedProduct.Id).FirstOrDefault();
                        ListProduct.Remove(SelectedProduct);
                        ListProduct.Insert(index, game);
                        selectedProduct = game;

                    }
                    //LoadData();
                    clearForm();
                });
            ClearFormCommand = new RelayCommand<object>(p => true, p => clearForm());
            DeleteCommand= new RelayCommand<object>(p => true, p =>
            {
                if (selectedProduct != null)
                {
                    SelectedProduct.Deleted = true;
                    Common.Instance.SaveChanges();
                    ListProduct.Remove(selectedProduct);
                }
            });

        }

        private Game GetGame()
        {
            return new Game
            {
                Name = Name,
                Publisher = Publisher,
                PurchaseCost = SCost,
                SaleCost = SCost,
                Amount = Amount,
                Detail = Detail,
                Category = SelectedCategory
            };
        }

        private void clearForm()
        {
            selectedProduct = null;
            selectedCategory = null;
            Name = null;
            Amount = 0;
            Publisher = null;
            SCost = 0;
            PCost = 0;
            Detail = null;
            TextButton = "Add";
        }

        private bool CheckDisplayIsOK()
        {
            return !string.IsNullOrEmpty(Name) && SelectedCategory != null;

        }

        void LoadData()
        {
            var games = Common.Instance.games.Include("Category").Where(g => g.Deleted == false).ToList();
            var categories= Common.Instance.categories.Where(c => c.Deleted == false).ToList();
            games.ForEach(g =>  listProduct.Add(g));
            categories.ForEach(c =>  listCategory.Add(c));
             
        }


    }
}
