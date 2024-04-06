using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PockemonAPI.Models;
using PockemonAPI22.DataAccess;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class PokemonController : ControllerBase
    {
        const string ANTON_SEXY_PHOTO = "https://sun9-67.userapi.com/impg/QgARul5E7-HDUoXI1kofHEhtiKha1xvGFXQzWw/vvEidU6kjdg.jpg?size=640x640&quality=96&sign=9e0598b52203312fc3059ac2e306186f&type=album";
        private static List<Pockemon> data = new List<Pockemon>()
        {
            new Pockemon { Id = 1, Name = "First", ImageURL = ANTON_SEXY_PHOTO, Breeding = new Breeding{ Height=200, Weight=100} },
            new Pockemon { Id = 2, Name = "Second", ImageURL = ANTON_SEXY_PHOTO, Breeding = new Breeding{ Height=2400, Weight=6100}},
            new Pockemon { Id = 3, Name = "Anton", ImageURL = ANTON_SEXY_PHOTO, Breeding = new Breeding{ Height=2600, Weight=180}},
            new Pockemon { Id = 4, Name = "Ne Anton", ImageURL = ANTON_SEXY_PHOTO, Breeding = new Breeding{ Height=2200, Weight=1400} },
        };

        private readonly AppDbContext _context;

        public  PockemonController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод для получения всех покемонов
        /// </summary>
        /// <returns>Возвращает список всех покемонов в системе</returns>
        // GET: api/Pokemon
        [HttpGet]
        public IEnumerable<object> GetAll([FromQuery] string? page, [FromQuery] string? count)
        {
            return data.Select(p => new { p.Id, p.Name, p.ImageURL });
        }

        /// <summary>
        /// Метод для получения покемонов по указанной строке пользователя
        /// </summary>
        /// <returns>Возвращает список всех найденых покемонов в системе</returns>
        [HttpGet("GetByFilter")]
        public IEnumerable<object> GetByFilter([FromQuery] string? name, [FromQuery] string? page, [FromQuery] string? count)
        {
            return data.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Select(p => new { p.Id, p.Name, p.ImageURL});
            ;
        }

        /// <summary>
        /// Метод для получения всей информации по одному покемону
        /// </summary>
        /// <returns>Возвращает полную информацию о покемоне по заданному Id или Name</returns>
        // GET: api/Pokemon/5
        [HttpGet("{nameOrId}")]
        public Pockemon GetByIdOrName([FromRoute] string nameOrId)
        {
            int id = 0;
            if (int.TryParse(nameOrId, out id))
                return data.FirstOrDefault(p => p.Id == id);
            else
                return data.FirstOrDefault(p => p.Name.Equals(nameOrId, StringComparison.OrdinalIgnoreCase));
        }
    }
}
