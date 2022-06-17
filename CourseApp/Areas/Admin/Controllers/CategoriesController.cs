using AutoMapper;
using CourseApp.App_Start;
using CourseApp.Areas.Admin.Models;
using CourseApp.Data;
using CourseApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseApp.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryService service;
        private readonly IMapper mapper;

        public CategoriesController()
        {
            service = new CategoryService();
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Categories
        public ActionResult Index()
        {
            var categories = service.ReadAll();
            var categoriesList = mapper.Map < List<CategoryModel>> (categories);
            //var categoriesList = new List<CategoryModel>();
            //foreach (var item in categories)
            //{
            //    categoriesList.Add(new CategoryModel
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        ParentName= item.Category2?.Name

            //    });
            //}
            return View(categoriesList);
        }

        public ActionResult Create()
        {
            var categoryModel = new CategoryModel();
            InitMainCategories( null, ref categoryModel);
            return View(categoryModel);
        }
        [HttpPost]
        public ActionResult Create(CategoryModel categoryInfo)
        {
          
                var result = service.AddCategory(new Category
                {
                    Name = categoryInfo.Name,
                    ParentId= categoryInfo.ParentId
                });

                if (result == -2)
                {
                InitMainCategories( null,ref categoryInfo);

                ViewBag.Message = " Category Name is Exists";
                    return View(categoryInfo);
                }
                return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Index", "Default");
            }

            var currentCategory = service.GetById(id.Value);
            if (currentCategory == null)
            {
                return HttpNotFound($"This Category id {{id}} not found");
            }
            var category = new CategoryModel
            {
                Id = currentCategory.Id,
                Name = currentCategory.Name,
                ParentId = currentCategory.ParentId,
            };
            InitMainCategories(category.Id,ref category);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel data)
        {
            try
            {
                var updatedCategory = new Category
                {
                    Id= data.Id,
                    Name = data.Name,
                    ParentId = data.ParentId
                };
                var result = service.UpdateCategory(updatedCategory);
                if (result == -2)
                {
                    InitMainCategories(data.Id, ref data);
                    ViewBag.Message = " Category Name is Exists";
                    return View(data);
                }
                else if (result > 0)
                {
                    ViewBag.Success = true;
                    ViewBag.Message = $" Category ({updatedCategory.Id}) Updated Succefully";
                }
                else
                {
                    ViewBag.Message = $" An Error Occured";

                }

                InitMainCategories(data.Id, ref data);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return View(data);
        }

        public ActionResult Delete(int? id)
        {
            if(id != null)
            {
                var category = service.GetById(id.Value);
                var categoryInfo = new CategoryModel
                {
                    Id=category.Id,
                    Name= category.Name,
                    ParentName= category.Category2 ?.Name
                    };
                return View(categoryInfo);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteConfirm(int? id)
        {
            if(id != null)
            {
                var categoryDeleted = service.Delete(id.Value);
                if(categoryDeleted )
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Delete", new { Id = id });
            }
            return HttpNotFound();
        }
            private void InitMainCategories( int? categoryToExclude, ref CategoryModel categoryModel)
        {
            var categoriesList = service.ReadAll();
            if (categoryToExclude != null)
            {
                var currentCategory = categoriesList.Where(x => x.Id == categoryToExclude).FirstOrDefault();
                categoriesList.Remove(currentCategory);
            }
                categoryModel.MainCategories = new SelectList(categoriesList, "Id", "Name");
           
            
            
        }
    }
}