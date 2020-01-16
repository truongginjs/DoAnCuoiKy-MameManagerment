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
    public class CategoryViewModel : BaseViewModel
    {
        private ObservableCollection<Category> listCategory = new ObservableCollection<Category>();
        public ObservableCollection<Category> ListCategory { get => listCategory; }

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get => selectedCategory; set
            {
                selectedCategory = value;
                
                OnPropertyChanged();
                if (selectedCategory != null)
                {
                    TextButton = "Update";
                    Name = selectedCategory.Name;
                    Detail = selectedCategory.Detail;
                }
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

        private String name;
        public String Name
        {
            get => name; set
            {
                name = value;
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
        public string SearchCommand {
            get => searchCommand; set
            {
                searchCommand = value;
                if (!string.IsNullOrEmpty(searchCommand))
                {

                    var result=Common.Instance.categories.Where(g => g.Name.Contains(searchCommand) && g.Deleted == false).ToList();
                    ListCategory.Clear();
                    result.ForEach(r => ListCategory.Add(r));  
                    
                }
                else
                {
                    var cat = Common.Instance.categories.Where(g => g.Deleted == false).ToList();
                    ListCategory.Clear();
                    cat.ForEach(c => ListCategory.Add(c));
                }
                              
                OnPropertyChanged();
            }
        }

        

        public CategoryViewModel()
        {
            LoadData();
            EditCommand = new RelayCommand<object>(
                p => CheckDisplayIsOK()
                , p =>
                {

                    if (SelectedCategory == null)
                    {
                        var current = Common.Instance.categories.Where(c => c.Name == Name && c.Deleted == true).FirstOrDefault();
                        if (current != null) 
                        {
                            current.Deleted = false;
                            ListCategory.Add(current);
                        }
                        else
                        {
                            var cat = GetCategory();
                            Common.Instance.categories.Add(cat);
                            ListCategory.Add(cat);
                            ListCategory.Remove(SelectedCategory);
                            SelectedCategory = cat;
                        }
                        Common.Instance.SaveChanges();
                    }
                    else
                    {


                        var index = ListCategory.IndexOf(SelectedCategory);

                        SelectedCategory.Name = Name;
                        SelectedCategory.Detail = Detail;
                        Common.Instance.SaveChanges();
                        var cat = ListCategory.Where(c => c.Id == SelectedCategory.Id).FirstOrDefault();
                        ListCategory.Remove(SelectedCategory);
                        ListCategory.Insert(index, cat);
                        SelectedCategory = cat;

                    }
                    //LoadData();
                    clearForm();
                });
            ClearFormCommand = new RelayCommand<object>(p => true, p => clearForm());
            DeleteCommand = new RelayCommand<object>(p => true, p =>
            {
                if (SelectedCategory != null)
                {
                    SelectedCategory.Deleted = true;
                    Common.Instance.games.Include("Category")
                        .Where(g => g.Category.Id == selectedCategory.Id)
                        .ToList()
                        .ForEach(g => g.Deleted = true);

                    Common.Instance.SaveChanges();
                    LoadData();
                }
            });

        }

        private Category GetCategory()
        {
            return new Category
            {
                Name = Name,
                Detail = Detail
            };
        }

        private void clearForm()
        {
            SelectedCategory = null;
            Name = null;
            Detail = null;
            TextButton = "Add";
        }

        private bool CheckDisplayIsOK()
        {
            int find = Common.Instance.categories.Where(p => p.Name == Name&& p.Deleted==false).Count();
            
            return !string.IsNullOrEmpty(Name) && (SelectedCategory != null || find < 1)  ;

        }

        void LoadData()
        {
            var categories= Common.Instance.categories.Where(c => c.Deleted == false).ToList();
            categories.ForEach(c =>  listCategory.Add(c));
        }


    }
}
