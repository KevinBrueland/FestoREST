using Festo.Common.RepositoryInterfaces;
using Festo.DataAccess.ConcreteRepositories;
using Festo.Utility.DataMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Festo.API.Controllers
{
    public class OrderTrackerController : ApiController
    {
        private UnitOfWork _uOW;
        private readonly OrderTrackerMapper _orderTrackerMapper;


        //public OrderController(UnitOfWork uOW, IOrderMapper orderMapper)
        //{
        //    _uOW = new UnitOfWork(new DataTables.Tables.FestoContext());
        //    _orderMapper = orderMapper;
        //}

        public OrderTrackerController()
        {
            _uOW = new UnitOfWork(new DataTables.Tables.FestoContext());
            _orderTrackerMapper = new OrderTrackerMapper();
        }

        [HttpGet]
        public IHttpActionResult GetAllOrders(string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var orders = _uOW.ORDERs.GetAllOrders();


                //return Ok(orders.ToList().Select(o => _orderTrackerMapper.CreateShapeDataObject(o, listOfFields)));
                return Ok();
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
    }
}
