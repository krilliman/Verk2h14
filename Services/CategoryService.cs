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

        public List<MainCategoryViewModel> GetMainCategoryList(int? id)
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
            // Hérna bryndís!!! h'ernaaaaaaaaaaaaaaaa!!!
            return MainCategoriesWithTop10Books; // Muna ad breyta thessu
        }

        public List<MainCategoryViewModel> GetMainCategoryAndChildLists(int? id) //
        {
            var MainAndSubCategories = (from m in GetMainCategoryList(id)
                                        select new MainCategoryViewModel
                                        {
                                            ID = m.ID,
                                            Name = m.Name,
                                            SubCategories = GetSubCategoryAndChildList(m.ID),
                                        }).ToList();
            return MainAndSubCategories;
        }

        public  List<SubCategoryViewModel> GetSubCategoryAndChildList(int? id)
        {
            var SubCategoriesAndBooks = (from s in GetSubCategoryList(id)
                                                    select new SubCategoryViewModel
                                                    {
                                                        ID = s.ID,
                                                        Name = s.Name,
                                                        BookList = (GetBookList(s.ID)),
                                                    }).ToList();
            return SubCategoriesAndBooks;
        }
    }
}