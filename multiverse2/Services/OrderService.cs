//using Data;
//using Entities;
//using Multiverse.IServices;

//namespace Multiverse.Services
//{
//    public class OrderService : BaseContextService, IOrderService
//    {
//        public OrderService(ServiceContext serviceContext) : base(serviceContext)
//        {
//        }




//        public int insertOrder(OrderItem orderItem)
//        {
//            try
//            {
//                _serviceContext.Orders.Add(orderItem);
//                _serviceContext.SaveChanges();

//                return orderItem.IdOrder;
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }



//        void IOrderService.UpdateOrder(OrderItem existingOrderItem)
//        {
//            _serviceContext.Orders.Update(existingOrderItem);
//            _serviceContext.SaveChanges();
//        }

//        public void DeleteOrder(int IdOrder)
//        {
//            var order = _serviceContext.Orders.Find(IdOrder);
//            if (order != null)
//            {
//                _serviceContext.Orders.Remove(order);
//                _serviceContext.SaveChanges();
//            }
//            else
//            {
//                throw new InvalidOperationException("El pedido no existe.");
//            }
//        }


//    }


//}

