using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Contracts;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;
        public ActorController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        [HttpGet]
        public ActionResult<List<Actor>> GetAll()
        {
            return _actorRepository.GetActors();
        }

        [HttpPost]
        public ActionResult CreateActor(Actor actor)
        {
            try
            {
                _actorRepository.AddActor(actor);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Actor> GetActorById(int id)
        {
            try
            {
                var actor = _actorRepository.GetActorById(id);
                return Ok(actor);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /*[HttpPatch("{id}/{nombre}/{apellido}")]
        public ActionResult UpdateActor(int id, string nombre, string apellido)
        {
            try
            {
                var actor = _actorRepository.GetActorById(id);
                if (actor == null)
                {
                    return NotFound();
                }
                actor.Nombre = nombre;
                actor.Apellido = apellido;
                _actorRepository.UpdateActor(id, actor);
                return actor;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpPatch("{id}/{nombre}/{apellido}")]
        public ActionResult<Actor> UpdateActor(int id, string nombre, string apellido, [FromBody] Actor actorToUpdate)
        {
            Actor actor = _actorRepository.GetActorById(id);
            actor.Nombre = nombre;
            actor.Apellido = apellido;
            return actor;
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteActor(int id)
        {
            try
            {
                _actorRepository.DeleteActor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}