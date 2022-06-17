using CourseApp.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace CourseApp.Services
{
    public interface ICategoryService
    {
        List<Category> ReadAll();
        int AddCategory(Category categoryModel);
        Category GetById(int id);
        int UpdateCategory(Category category);
        bool Delete(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly CousesAppContext context;

        public CategoryService()
        {
            context = new CousesAppContext();
        }

        public int AddCategory(Category newCategory)
        {
            var categoryName = newCategory.Name.ToLower();
            var categoryNameExists=  context.Categories.Where(c => c.Name.ToLower() ==  categoryName).Any();
            if (categoryNameExists)
            {
                return -2;
            }
            else
            {
                context.Categories.Add(newCategory);
                return context.SaveChanges();
            }
        }

        public bool Delete(int id)
        {
            var category = GetById(id);
            if(category != null)
            {
                context.Categories.Remove(category);
                return context.SaveChanges() > 0 ? true : false;
            }
            return false;
          
        }

        public Category GetById(int id)
        {
            return context.Categories.Find(id);
        }

        public List<Category> ReadAll()
        {
            return context.Categories.ToList();
        }

        public int UpdateCategory(Category category)
        {
         
            var categoryName = category.Name.ToLower();
            var categoriesList = context.Categories.Where(c => c.Name.ToLower() != categoryName);
         
            if (categoriesList.Where(c => c.Name.ToLower() == categoryName).Any())
            {
                return -2;
            }
               context.Categories.Attach(category);
            context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            try{ 
              return  context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return context.SaveChanges();

            }
           
        }
    }
}