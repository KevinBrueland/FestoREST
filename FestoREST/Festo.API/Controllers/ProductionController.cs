using Festo.Common.DataMapperInterfaces;
using Festo.Common.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Festo.API.Controllers
{
    public class ProductionController : ApiController
    {
        private readonly IUnitOfWork _uOW;
        private readonly IOrderMapper _orderMapper;
        private readonly IItemMapper _itemMapper;

        public ProductionController(IUnitOfWork uOW, IOrderMapper orderMapper, IItemMapper itemMapper)
        {
            _uOW = uOW;
            _orderMapper = orderMapper;
            _itemMapper = itemMapper;
        }

        public ProductionController()
        {

        }

        [HttpGet]
        [Route("api/production/orderinproduction")]
        public IHttpActionResult GetCurrentOrderInProduction(string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var currentProductionOrder = _uOW.PRODUCTION.GetCurrentOrderInProduction();
                if (currentProductionOrder == null)
                {
                    return NotFound();
                }

                return Ok(_orderMapper.CreateOrderDTOFromOrder(currentProductionOrder));
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/production/nextitemtoproduce")]
        public IHttpActionResult GetNextItemToProduce(string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var nextItemToProduce = _uOW.PRODUCTION.GetNextItemToProduce();

                if (nextItemToProduce == null)
                {
                    return NotFound();
                }

                return Ok(_itemMapper.CreateItemDTOFromItem(nextItemToProduce));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/production/nextordertoproduce")]
        public IHttpActionResult GetNextOrderToProduce(string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var nextOrderToProduce = _uOW.PRODUCTION.GetNextOrderToProduce();
                if (nextOrderToProduce == null)
                {
                    return NotFound();
                }

                return Ok(_orderMapper.CreateOrderDTOFromOrder(nextOrderToProduce));
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/production/ordercompletionstatus/{orderId}")]
        public IHttpActionResult IsOrderComplete(int orderId, string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var isOrderComplete = _uOW.PRODUCTION.CheckIsOrderComplete(orderId);


                return Ok(isOrderComplete);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/production/orderitemscompletionstatus/{orderId}")]
        public IHttpActionResult AreAllItemsInOrderComplete(int orderId, string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var areAllItemsInOrderComplete = _uOW.PRODUCTION.CheckIsAllItemsInOrderComplete(orderId);
                if(areAllItemsInOrderComplete == null)
                {
                    return NotFound();
                }


                return Ok(areAllItemsInOrderComplete);
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }
    }
}
