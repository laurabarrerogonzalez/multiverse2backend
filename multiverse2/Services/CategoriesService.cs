//using Data;
//using Entities;
//using Multiverse.IServices;

//namespace Multiverse.Services
//{
//    public class CategoriesService : BaseContextService, ICategoriesService
//    {
//        public CategoriesService(ServiceContext serviceContext) : base(serviceContext)
//        {
//        }

//        public int insertCategories(Categories categories)
//        {
//            _serviceContext.Categories.Add(categories);
//            _serviceContext.SaveChanges();
//            return categories.IdCategories;
//        }

//        void ICategoriesService.UpdateCategories(Categories existingCategories)
//        {
//            _serviceContext.Categories.Update(existingCategories);
//            _serviceContext.SaveChanges();
//        }


//        public void DeleteCategories(int IdCategories)
//        {
//            var categories = _serviceContext.Categories.Find(IdCategories);
//            if (categories != null)
//            {
//                _serviceContext.Categories.Remove(categories);
//                _serviceContext.SaveChanges();
//            }
//            else
//            {
//                throw new InvalidOperationException("La categoría no existe.");
//            }
//        }
//    }
//}
