using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIEFCoreCodeFir.Models;
using WebAPIEFCoreCodeFir.Repositories;

namespace WebAPIEFCoreCodeFir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionItemController : ControllerBase
    {
        private readonly IReceptionItem _receptionItem;

        public ReceptionItemController(IReceptionItem receptionItem)
        {
            _receptionItem = receptionItem;
        }

        [HttpGet]
        public async Task<ActionResult> GetItems()
        {
            try
            {                
                return Ok(await _receptionItem.GetItems());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{itemId}")]
        public async Task<ActionResult> GetItem(int itemId)
        {
            try
            {
                var result = await _receptionItem.GetItem(itemId);
                if (result == null)
                {
                    return NotFound("Searched Item Not Found");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddItem(Items item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest();
                }
                var result = await _receptionItem.AddItem(item);
                return CreatedAtAction(nameof(GetItem), new { itemId = result.ItemId }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding data to the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateItem(Items item)
        {
            try
            {
                var result = await _receptionItem.GetItem(item.ItemId);
                if (result == null)
                {
                    return NotFound("Searched Item Not Found");
                }
                return Ok(await _receptionItem.UpdateItem(item));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{itemId}")]
        public async Task<ActionResult> DeleteItem(int itemId)
        {
            try
            {
                var result = await _receptionItem.GetItem(itemId);
                if (result == null)
                {
                    return NotFound("Searched Item Not Found");
                }
                await _receptionItem.DeleteItem(itemId);
                return Ok("Item Deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
