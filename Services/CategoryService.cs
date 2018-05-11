using System.Collections.Generic;
using System.Linq;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class CategoryService
    {

        private CategoryRepo _categoryRepo;

        public CategoryService()
        {
            _categoryRepo = new CategoryRepo();
        }

        public List<CategoryViewModel> GetMainCategoryList(int? id)
        {
            var MainCategories = _categoryRepo.GetMainCategoryList(id);
            return MainCategories;
        }

        public List<SubCategoryViewModel> GetSubCategoryList(int? id)
        {
            var SubCategories = _categoryRepo.GetSubCategoryList(id);
            return SubCategories;
        }

        public List<BookViewModel> GetBookList(int? id)
        {
            var books = _categoryRepo.GetAllBooks(id);
            return books;
        }

        // Þessi föll sækja hina og þessa lista

        public List<BookViewModel> SearchBooks(string search)
        {  
            var BookResults = (from b in _categoryRepo.GetAllBooks(null)
                                where b.Name.ToLower().Contains(search.ToLower())
                                select b).OrderBy(x => x.Name).ToList();
                return BookResults;
        }

        public CategoryViewModel GetSubCategoryIndex(int id)
        {
            var IndexViewModel = new CategoryViewModel
            {
                Name = (from m in GetMainCategoryList(id)
                        select m.Name).FirstOrDefault(),
                BOTW = (from b in _categoryRepo.GetAllBooks(null)
                        select b).OrderByDescending(x => x.Views).FirstOrDefault(),
                UserFav = (from b in _categoryRepo.GetAllBooks(null)
                           select b).OrderByDescending(x => x.Rating).FirstOrDefault(),
                NewestRelease = (from b in _categoryRepo.GetAllBooks(null)
                                 select b).OrderByDescending(b => b.PublishDate.ToUniversalTime()).FirstOrDefault(),
                CheapestBook = (from b in _categoryRepo.GetAllBooks(null)
                                select b).OrderBy(x => x.TotalPrice).FirstOrDefault(),
                Top10AllCategories = (from s in GetSubCategoryTop10List()
                                        where s.ID == id
                                        select s).Take(1).ToList(),
                SubCategories = (from s in GetSubCategoryViewModel(null)
                                where s.CategoryID == id
                                select s).ToList(),

            };
            return IndexViewModel;
        }
        public CategoryViewModel GetCategoryViewModel(int? id) //ATH tekur top10 fyrir MainCategories
        {
            var IndexViewModel = new CategoryViewModel
            {
                Name = (from m in GetMainCategoryList(id)
                        select m.Name).FirstOrDefault(),
                BOTW = (from b in _categoryRepo.GetAllBooks(null)
                        select b).OrderByDescending(x => x.Views).FirstOrDefault(),
                UserFav = (from b in _categoryRepo.GetAllBooks(null)
                           select b).OrderByDescending(x => x.Rating).FirstOrDefault(),
                NewestRelease = (from b in _categoryRepo.GetAllBooks(null)
                                 select b).OrderByDescending(b => b.PublishDate.ToUniversalTime()).FirstOrDefault(),
                CheapestBook = (from b in _categoryRepo.GetAllBooks(null)
                                select b).OrderBy(x => x.TotalPrice).FirstOrDefault(),
                Top10AllCategories = GetMainCategoryTop10List(),
                SubCategories = GetSubCategoryViewModel(null),

            };
            return IndexViewModel;
        }

        public List<MainCategoryTop10ListViewModel> GetMainCategoryTop10List()
        {
            var MainCategoriesWithTop10Books = (from m in GetMainCategoryList(null)
                                                select new MainCategoryTop10ListViewModel
                                                {
                                                    ID = m.ID,
                                                    Name = m.Name,
                                                    Top10Books = (from b in GetBookList(null)
                                                                  where b.MainCategoryID == m.ID
                                                                  select b).OrderByDescending(x => x.Rating).Take(10).ToList()
                                                }).ToList();
            return MainCategoriesWithTop10Books;
        }

                public List<MainCategoryTop10ListViewModel> GetSubCategoryTop10List()
        {
            var SubCategoriesWithTop10Books = (from m in GetMainCategoryList(null)
                                                select new MainCategoryTop10ListViewModel
                                                {
                                                    ID = m.ID,
                                                    Name = m.Name,
                                                    Top10Books = (from b in GetBookList(null)
                                                                  where b.MainCategoryID == m.ID
                                                                  select b).OrderByDescending(x => x.Rating).Take(5).ToList()
                                                }).ToList();
            return SubCategoriesWithTop10Books;
        }

        //       public SubCategoryViewModel GetSingleSubCategoryViewModel(int id)
        //       {
        //           var SingleCategory = (from s in in)
        //      }


        public List<SubCategoryViewModel> GetSubCategoryViewModel(int? id)
        {
            // if(id < 4){ //1-4 eru maincategories
            var SubCategoryViewModelWithTop10 = (from s in GetSubCategoryList(id) // þetta fall virkar bara fyrir subcategories 1-4 því það skilar lista af top10 úr öllum subgategories
                                                 select new SubCategoryViewModel
                                                 {
                                                     ID = s.ID,
                                                     Name = s.Name,
                                                     CategoryID = s.CategoryID,
                                                     Top10Books = (from b in GetBookList(s.ID) //herna vel
                                                                   select b).OrderByDescending(x => x.Rating).Take(10).ToList(),
                                                     BookList = (from b in GetBookList(s.ID)
                                                                 select b).OrderBy(x => x.Name).ToList()
                                                 }).ToList();
            return SubCategoryViewModelWithTop10;
        }
    }
}