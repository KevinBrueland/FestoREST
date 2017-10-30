using Festo.Common.DataMapperInterfaces;
using Festo.Common.Enums;
using Festo.Common.RepositoryInterfaces;
using Festo.DataTables.Tables;
using Festo.DTOs;
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
    public class ItemTrackersController : ApiController
    {
        private readonly IUnitOfWork _uOW;
        private readonly IItemTrackerMapper _itemTrackerMapper;

        public ItemTrackersController(IUnitOfWork uOW, IItemTrackerMapper itemTrackerMapper)
        {
            _uOW = uOW;
            _itemTrackerMapper = itemTrackerMapper;
        }
        public ItemTrackersController()
        {

        }

        [HttpPost]
        [Route("api/itemtrackers")]
        public IHttpActionResult AddSingleItemTracker([FromBody] ItemTrackerDTO itemTrackerDTO)
        {
            try
            {
                if (itemTrackerDTO == null)
                {
                    return BadRequest();
                }

                var itemTrackerToAdd = _itemTrackerMapper.CreateItemTrackerFromItemTrackerDTO(itemTrackerDTO);

                var result = (RepositoryActionResult<ITEMTRACKER>)_uOW.ITEMTRACKERs.Insert(itemTrackerToAdd);

                if (result.Status == RepositoryActionStatus.Created)
                {
                    var newItemTracker = _itemTrackerMapper.CreateItemTrackerDTOFromItemTracker(result.Entity);

                    return Created(Request.RequestUri, newItemTracker);
                }

                return BadRequest();
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpPatch]
        public IHttpActionResult PatchUpdateItemTracker(int orderid, int itemid, [FromBody]JsonPatchDocument<ItemTrackerDTO> itemTrackerPatchDocument)
        {
            try
            {
                if(itemTrackerPatchDocument == null)
                {
                    BadRequest();
                }

                var itemTracker = _uOW.ITEMTRACKERs.GetSingleItemTrackerByOrderAndItemId(orderid, itemid);

                if(itemTracker == null)
                {
                    return NotFound();
                }

                //mapping 
                var itemTrackerToUpdate = _itemTrackerMapper.CreateItemTrackerDTOFromItemTracker(itemTracker);

                //apply changes to the DTO
                itemTrackerPatchDocument.ApplyTo(itemTrackerToUpdate);

                //map the DTO with the applied changes to the entity
                var mappedItemTracker = _itemTrackerMapper.CreateItemTrackerFromItemTrackerDTO(itemTrackerToUpdate);

                //update it
                var result = (RepositoryActionResult<ITEMTRACKER>)_uOW.ITEMTRACKERs.UpdateItemTracker(mappedItemTracker);

                if(result.Status == RepositoryActionStatus.Updated)
                {
                    //map to DTO
                    var patchedItemTracker = _itemTrackerMapper.CreateItemTrackerDTOFromItemTracker(result.Entity);
                    return Ok(patchedItemTracker);
                }

                return BadRequest();

            }

            catch (Exception)
            {

                return InternalServerError();
            }
           
        }

        [HttpGet]
        [Route("api/itemtrackers/{itemId}", Name = "ItemTrackers")]
        public IHttpActionResult GetSingleItemTracker(int itemId, string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var itemTracker = _uOW.ITEMTRACKERs.GetItemTrackerByItemId(itemId);

                if (itemTracker == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_itemTrackerMapper.CreateItemTrackerDTOFromItemTracker(itemTracker));
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        
    }
}
