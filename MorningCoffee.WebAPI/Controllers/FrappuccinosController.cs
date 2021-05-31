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
    public class FrappuccinosController : ControllerBase
    {
        IFrappuccinoService _frappuccinoService;

        public FrappuccinosController(IFrappuccinoService frappuccinoService)
        {
            _frappuccinoService = frappuccinoService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _frappuccinoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallbyfrappuccinoblendedbeverage")]
        public IActionResult GetAllByFrappuccinoBlendedBeverage(int frappuccinoBlendedBeverageId)
        {
            var result = _frappuccinoService.GetAllByFrappuccinoBlendedBeverageId(frappuccinoBlendedBeverageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var result = _frappuccinoService.GetByName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Frappuccino frappuccino)
        {
            var result = _frappuccinoService.Add(frappuccino);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Frappuccino frappuccino)
        {
            var result = _frappuccinoService.Delete(frappuccino);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Frappuccino frappuccino)
        {
            var result = _frappuccinoService.Update(frappuccino);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
