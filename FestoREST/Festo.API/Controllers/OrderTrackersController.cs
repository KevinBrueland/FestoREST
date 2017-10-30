using Festo.Common.DataMapperInterfaces;
using Festo.Common.Enums;
using Festo.Common.RepositoryInterfaces;
using Festo.DataAccess.ConcreteRepositories;
using Festo.DataTables.Tables;
using Festo.DTOs;
using Festo.Utility.DataMappers;
using Festo.Utility.RepositoryHelpers;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Festo.API.Controllers
{
    public class OrderTrackersController : ApiController
    {
        private readonly IUnitOfWork _uOW;
        private readonly IOrderTrackerMapper _orderTrackerMapper;


        public OrderTrackersController(IUnitOfWork uOW, IOrderTrackerMapper orderTrackerMapper)
        {
            _uOW = uOW;
            _orderTrackerMapper = orderTrackerMapper;
        }

        public OrderTrackersController()
        {

        }

        [HttpGet]
        [Route("api/ordertrackers/{orderId}")]
        public IHttpActionResult GetSingleOrderTracker(int orderId, string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var orderTracker = _uOW.ORDERTRACKERs.GetSingleOrderTrackerByOrderId(orderId);


                return Ok(_orderTrackerMapper.CreateOrderTrackerDTOFromOrderTracker(orderTracker));
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpPut]
        [HttpPatch]

        public IHttpActionResult PatchUpdateOrderTracker(int orderid, int itemid, [FromBody]JsonPatchDocument<OrderTrackerDTO> OrderTrackerPatchDocument)
        {
            try
            {
                if (OrderTrackerPatchDocument == null)
                {
                    BadRequest();
                }

                var orderTracker = _uOW.ORDERTRACKERs.GetSingleOrderTrackerByOrderId(orderid);

                if (orderTracker == null)
                {
                    return NotFound();
                }

                //mapping 
                var orderTrackerToUpdate = _orderTrackerMapper.CreateOrderTrackerDTOFromOrderTracker(orderTracker);

                //apply changes to the DTO
                OrderTrackerPatchDocument.ApplyTo(orderTrackerToUpdate);

                //map the DTO with the applied changes to the entity
                var mappedOrderTracker = _orderTrackerMapper.CreateOrderTrackerFromOrderTrackerDTO(orderTrackerToUpdate);

                //update it
                var result = (RepositoryActionResult<ORDERTRACKER>)_uOW.ORDERTRACKERs.UpdateOrderTracker(mappedOrderTracker);

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    //map to DTO
                    var patchedItemTracker = _orderTrackerMapper.CreateOrderTrackerDTOFromOrderTracker(result.Entity);
                    return Ok(patchedItemTracker);
                }

                return BadRequest();

            }

            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("api/ordertrackers")]
        public IHttpActionResult AddSingleOrderTracker([FromBody] OrderTrackerDTO orderTrackerDTO)
        {
            try
            {
                if(orderTrackerDTO == null)
                {
                    return BadRequest();
                }

                var orderTrackerToAdd = _orderTrackerMapper.CreateOrderTrackerFromOrderTrackerDTO(orderTrackerDTO);

                var result = (RepositoryActionResult<ORDERTRACKER>)_uOW.ORDERTRACKERs.Insert(orderTrackerToAdd);

                if(result.Status == RepositoryActionStatus.Created)
                {
                    var newOrderTracker = _orderTrackerMapper.CreateOrderTrackerDTOFromOrderTracker(result.Entity);

                    return Created(Request.RequestUri, newOrderTracker);
                }

                return BadRequest();
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

    }
}
