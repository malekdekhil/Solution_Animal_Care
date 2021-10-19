using Animal_Care_WebAPI.Resources.EventResources;
using Animal_Care_WebAPI.Validations;
using AutoMapper;
using DAO.Services;
using Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Animal_Care_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEvent eventService;
        private IMapper MapperService;

        public EventController(IEvent eventService, IMapper MapperService)
        {
            this.eventService = eventService;
            this.MapperService = MapperService;
        }

        // GET: api/<EventController>
        [HttpGet("Events")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            try
            {
                var events = await eventService.GetAllEventsAsync();
                var eventResource = MapperService.Map<IEnumerable<Event>, IEnumerable<EventResourceUpdate>>(events);
                return Ok(eventResource);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            try
            {
                var eventId = await eventService.GetEventByIdAsync(id);
                if (eventId == null) return NotFound();
                var eventResource = MapperService.Map<Event, EventResource>(eventId);
                
                return Ok(eventResource);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
         


        // POST api/<EventController>
        [HttpPost("")]
        public async Task<ActionResult<SaveEventResouce>> CreateEvent(SaveEventResouce saveEvent)
        {
            try
            {
                //Validation
                var validation = new EventValidator();
                var resultValidation = await validation.ValidateAsync(saveEvent);
                if (!resultValidation.IsValid) return BadRequest(resultValidation.Errors);
                //mapp view to bdd 
                var _event = MapperService.Map<SaveEventResouce, Event>(saveEvent);
                //Create
                var createEvent = await eventService.CreateEventAsync(_event);
                //mapp bdd to view
                var eventResource = MapperService.Map<Event, SaveEventResouce>(createEvent);
                return Ok(eventResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EventResourceUpdate>> UpdateEvent(EventResourceUpdate SaveUpdateEvent, int id)
        {
            try
            {
                // je recuperer le current event depuis la bdd
                var currentEvent = await eventService.GetEventByIdAsync(id);
                var validation = new EventUpdateValidator();
                var resultValidation = await validation.ValidateAsync(SaveUpdateEvent);
                 if (!resultValidation.IsValid) return BadRequest(resultValidation.Errors);
                //verif id 
                if (SaveUpdateEvent.IdEvent != id) return BadRequest();
                // je mapp la saisie 
                var newEvent = MapperService.Map<EventResourceUpdate, Event>(SaveUpdateEvent);
                //update 
                await eventService.UpdateEventAsync(currentEvent, newEvent);
                // je recupere le nv event
                var _event = await eventService.GetEventByIdAsync(id);
                // je mapp de la bdd a la view
                var eventResource = MapperService.Map<Event, EventResourceUpdate>(_event);

                return Ok(eventResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            try
            {
                var EventDelete = await eventService.GetEventByIdAsync(id);
                if (EventDelete == null) return NotFound();
                await eventService.RemoveEvent(EventDelete);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
