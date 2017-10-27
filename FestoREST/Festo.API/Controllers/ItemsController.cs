using Festo.Common.DataMapperInterfaces;
using Festo.Common.Enums;
using Festo.Common.RepositoryInterfaces;
using Festo.DataTables.Tables;
using Festo.DTOs;
using Festo.Utility.RepositoryHelpers;
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
    }
}