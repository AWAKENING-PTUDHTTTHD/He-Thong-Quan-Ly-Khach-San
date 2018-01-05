using Distributor.Dao.Interfaces;
using Distributor.POCO;
using Management_Distributor.ExceptionHandler;
using Management_Distributor.Service.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Management_Distributor.Service.Implementations
{
    public class OrderService : IOrderService
    {

        #region member
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow = null;
        private IRepository<Order> repoOrder = null;
        #endregion

        public OrderService(IUnitOfWork uow)
        {
            _uow = uow;
            repoOrder = _uow.Repository<Order>();
        }


        public Order FindById(int Id)
        {
            return repoOrder.GetById(Id);
        }
        public int Add(Order order)
        {
            int success;
            _logger.Info("Start add new Order");
            try
            {
                repoOrder.Add(order);
                int Nrow = (_uow.SaveChange() > 0) ? 1 : 0;
                if (Nrow > 0)
                    success = order.OrderId;
                else success = 0;
            }
            catch(Exception ex)
            {
                //Console.WriteLine(e.ToString());
                //HttpContext.Current.Response.Write(e);

                //string filePath = @"C:\Error.txt";

                //using (StreamWriter writer = new StreamWriter(filePath, true))
                //{
                //    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                //       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                //    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                //}

                string strPath = @"C:\Order.Error.Logger.txt";
                ExceptionProofer.LogToFile(strPath, ex);

                success = -1;
            }
           
            _logger.Info("End add new Order");
           ;
            if (success > 0 )
                _logger.Info("successfull added Order");
            else
                _logger.Info("failed to add");
            _logger.Info("End add a Order");
            return success;
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }



    }
}