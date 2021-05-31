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
    public class TeasController : ControllerBase
    {
        ITeaService _teaService;

        public TeasController(ITeaService teaService)
        {
            _teaService = teaService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _teaService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallbyicedtea")]
        public IActionResult GetAllByIcedTea(int icedTeaId)
        {
            var result = _teaService.GetAllByIcedTeaId(icedTeaId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var result = _teaService.GetByName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Tea tea)
        {
            var result = _teaService.Add(tea);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Tea tea)
        {
            var result = _teaService.Delete(tea);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Tea tea)
        {
            var result = _teaService.Update(tea);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
