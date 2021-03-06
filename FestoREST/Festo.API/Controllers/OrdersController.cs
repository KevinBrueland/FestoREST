﻿using Festo.Common.DataMapperInterfaces;
using Festo.Common.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Festo.API.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IUnitOfWork _uOW;
        private readonly IOrderMapper _orderMapper;


        public OrdersController(IUnitOfWork uOW, IOrderMapper orderMapper)
        {
            _uOW = uOW;
            _orderMapper = orderMapper;
        }

        public OrdersController()
        {

        }

        [HttpGet]
        [Route("api/orders")]
        public IHttpActionResult GetAllOrders(string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if(fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var orders = _uOW.ORDERs.GetAllOrders();


                return Ok(orders.ToList().Select(o => _orderMapper.CreateOrderDTOFromOrder(o)));
            }

            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/orders/{orderId}")]
        public IHttpActionResult GetSingleOrderById(int orderId, string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var order = _uOW.ORDERs.GetOrderByOrderId(orderId);


                return Ok(_orderMapper.CreateOrderDTOFromOrder(order));
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

    }
}