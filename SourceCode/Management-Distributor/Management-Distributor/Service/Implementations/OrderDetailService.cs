using Management_Distributor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Distributor.POCO;
using NLog;
using Distributor.Dao.Interfaces;
using Management_Distributor.ExceptionHandler;
using Distributor.Service.Interfaces;

namespace Management_Distributor.Service.Implementations
{
    public class OrderDetailService : IOrderDetailService
    {

        #region member
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private IUnitOfWork _uow = null;
        private IRepository<OrderDetail> repoOrderDetail = null;
        private IProductService productService= null;
        #endregion

        public OrderDetailService(IUnitOfWork uow, IProductService _productService)
        {
            this._uow = uow;
            repoOrderDetail = _uow.Repository<OrderDetail>();
            productService = _productService;

        }

        public List<OrderDetail> FindByOrderId(int Id)
        {
            return repoOrderDetail.GetAll().Where(d => d.OrderId == Id).ToList();
        }
        public bool Add(OrderDetail detail)
        {
            bool success;
            _logger.Info("Start add new OrderDetail");
            repoOrderDetail.Add(detail);
            _logger.Info("End add new OrderDetail");
            success = (_uow.SaveChange() > 0) ? true : false;
            if (success == true)
                _logger.Info("successfull added OrderDetail");
            else
                _logger.Info("failed to add");
            return success;
        }

        public int AddListDetail(int OrderId, string[] productId, string[] price, string[] DemandQty, string[] ActualQty)
        {
            {
                int SuccessNumb = 0;

                int count = productId.Count();
                for (int i = 0; i < count; i++)
                {
                    OrderDetail detail = new OrderDetail()
                    {
                        OrderId = OrderId,
                        ProductId = Convert.ToInt32(productId[i]),
                        Price = Convert.ToDecimal(price[i]),
                        DemandQuantity = Convert.ToInt32(DemandQty[i]),
                        ActualQuantity = Convert.ToInt32(ActualQty[i])

                    };
                    try
                    {
                        Add(detail);
                        productService.DecreaseAvailableQty(Convert.ToInt32(productId[i]), Convert.ToInt32(ActualQty[i]));
                        SuccessNumb++;

                    }
                    catch(Exception ex )
                    {
                        string strPath = @"C:\OrderDetails.Error.Logger.txt";
                        ExceptionProofer.LogToFile(strPath, ex);
                        break;
                    }
                }
                return SuccessNumb;
            }
        }

        // Update some and Add some 
        public int AddOrEditListDetail(int OrderId, string[] DetailId, string[] productId, string[] price, string[] DemandQty, string[] ActualQty, string[] flag)
        {
            int _Edit, Add;
            _Edit = Add = 0;

            int count = productId.Count();
            for (int i = 0; i < count; i++)
            {
                if (Convert.ToBoolean(flag[i]) == true)
                {
                    // add new
                    OrderDetail detail = FindById(Convert.ToInt32(DetailId));
                    detail.DemandQuantity = Convert.ToInt32(DemandQty[i]);
                    detail.ActualQuantity = Convert.ToInt32(ActualQty[i]);
                    try
                    {
                        this.Edit(detail);
                        _Edit++;
                    }
                    catch
                    {
                        // dont'n no what to do next!
                    }
                }

                else if (Convert.ToBoolean(flag[i]) == false)
                {
                    OrderDetail detail = new OrderDetail()
                    {
                        OrderId = OrderId,
                        ProductId = Convert.ToInt32(productId[i]),
                        Price = Convert.ToDecimal(price[i]),
                        DemandQuantity = Convert.ToInt32(DemandQty[i]),
                        ActualQuantity = Convert.ToInt32(ActualQty[i])

                    };
                    try
                    {
                        this.Add(detail);
                        productService.DecreaseAvailableQty(Convert.ToInt32(productId[i]), Convert.ToInt32(ActualQty[i]));
                        Add++;

                    }
                    catch
                    {
                        // dont'n no what to do next!
                    }
                }
            }
                
                return (Add+_Edit);
        }

        public OrderDetail FindById(int id)
        {
            _logger.Info("Start fetch single category");
            OrderDetail detail = null;
            detail = repoOrderDetail.GetById(id);
            if (detail == null)
                _logger.Info("this category not existed");
            else _logger.Info("Got this category");
            _logger.Info("End fetch single category");
            return detail;
        }

        public bool Edit(OrderDetail detail)
        {
            bool success;
            _logger.Info("Start Editing");
            repoOrderDetail.Attach(detail);
            success = (_uow.SaveChange() > 0);
            if (success == true)
                _logger.Info("successfull Edited OrderDetail");
            else _logger.Info("failed to Edit");
            _logger.Info("End Edit a OrderDetail");
            return success;
        }
    }
}