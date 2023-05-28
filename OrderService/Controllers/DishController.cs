using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class DishController : ControllerBase{
        private readonly IDishRepository _dishRepository;
        public DishController(IDishRepository dishRepository){
            _dishRepository = dishRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishesAsync(){
            return Ok(await _dishRepository.GetAllDishesAsync());
        }

        [HttpGet("possible")]
        public async Task<ActionResult<IEnumerable<Dish>>> GetPossibleDishesAsync(){
            return Ok(await _dishRepository.GetAllPossibleDishesAsync());
        }
        
        [HttpPost, Authorize(Roles = "Manager")]
        public async Task<ActionResult<Dish>> CreateDishAsync(DishCreatingDto dish){
            try{
            Dish createdDish = await _dishRepository.CreateDishAsync(dish);
            return Ok(createdDish);
            } catch (ArgumentException e){
                return BadRequest(e.Message);
            }
        }
        [HttpPut, Authorize(Roles = "Manager")]
        public async Task<ActionResult> UpdateDishAsync(Dish dish){
            Dish updatedDish = await _dishRepository.UpdateDishAsync(dish);
            return Ok(updatedDish);
        }
        [HttpDelete("{id}"), Authorize(Roles = "Manager")]
        public async Task<ActionResult> DeleteDishAsync(int id){
            Dish deletedDish = await _dishRepository.DeleteDishAsync(id);
            return Ok(deletedDish);
        }
    }
}