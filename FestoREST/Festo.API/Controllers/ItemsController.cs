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
    public class ItemsController : ApiController
    {
        private readonly IUnitOfWork _uOW;
        private readonly IItemMapper _itemMapper;

        public ItemsController(IUnitOfWork uOW, IItemMapper itemMapper)
        {
            _uOW = uOW;
            _itemMapper = itemMapper;
        }

        public ItemsController()
        {

        }

        [HttpGet]
        [Route("api/items")]
        public IHttpActionResult GetAllItems(string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var items = _uOW.ITEMs.GetAllItems();


                return Ok(items.ToList().Select(i => _itemMapper.CreateItemDTOFromItem(i)));
            }

            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/items/{itemId}")]
        public IHttpActionResult GetSingleItem(int itemId, string fields = null)
        {
            try
            {
                List<string> listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                }

                var item = _uOW.ITEMs.GetSingleItemById(itemId);


                return Ok(_itemMapper.CreateItemDTOFromItem(item));
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult AddSingleItem([FromBody] ItemDTO itemDTO)
        {
            try
            {
                if (itemDTO == null)
                {
                    return BadRequest();
                }

                var itemToAdd = _itemMapper.CreateItemFromItemDTO(itemDTO);

                var result = (RepositoryActionResult<ITEM>)_uOW.ITEMs.Insert(itemToAdd);

                if (result.Status == RepositoryActionStatus.Created)
                {
                    var newItem = _itemMapper.CreateItemDTOFromItem(result.Entity);

                    return Created(Request.RequestUri + "/" + newItem.ItemID.ToString(), newItem);
                }

                return BadRequest();
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }

        [HttpPatch]
        [Route("api/items/{itemId}")]
        public IHttpActionResult UpdateItem(int itemId, string id1, [FromBody]JsonPatchDocument<ItemDTO> itemPatchDocument)
        {
            try
            {

                if (itemPatchDocument == null)
                {
                    BadRequest();
                }

                var item = _uOW.ITEMs.GetSingleItemById(itemId);
                if (item == null)
                {
                    return NotFound();
                }

                //map
                var itemToUpdate = _itemMapper.CreateItemDTOFromItem(item);

                //apply changes to the data transfer object
                itemPatchDocument.ApplyTo(itemToUpdate);

                //map the DTO with applied changes to the entity, and update it
                var result = (RepositoryActionResult<ITEM>)_uOW.ITEMs.UpdateItem(_itemMapper.CreateItemFromItemDTO(itemToUpdate));

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    //map to dto
                    var patchedItem = _itemMapper.CreateItemDTOFromItem(result.Entity);
                    return Ok(patchedItem);
                }
                return BadRequest();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        [Route("api/items/{itemId}")]
        public IHttpActionResult UpdateEntireItem(int itemId, [FromBody]ItemDTO itemDTO)
        {
            try
            {
                if (itemDTO == null)
                {
                    return BadRequest();
                }

                //map
                var itemToUpdate = _itemMapper.CreateItemFromItemDTO(itemDTO);
                var result = (RepositoryActionResult<ITEM>)_uOW.ITEMs.UpdateItem(itemToUpdate);

                if (result.Status == RepositoryActionStatus.Updated)
                {
                    //map to dto
                    var updatedItem = _itemMapper.CreateItemDTOFromItem(result.Entity);
                    return Ok(updatedItem);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
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