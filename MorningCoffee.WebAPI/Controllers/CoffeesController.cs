using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MorningCoffee.Business.Abstract;
using MorningCoffee.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MorningCoffee.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeesController : ControllerBase
    {
        ICoffeeService _coffeeService;

        public CoffeesController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _coffeeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var result = _coffeeService.GetByName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbyhotcoffee")]
        public IActionResult GetAllByHotCoffee(int hotCoffeeId)
        {
            var result = _coffeeService.GetAllByHotCoffeeId(hotCoffeeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Coffee coffee)
        {
            var result = _coffeeService.Add(coffee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Coffee coffee)
        {
            var result = _coffeeService.Update(coffee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Coffee coffee)
        {
            var result = _coffeeService.Delete(coffee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
