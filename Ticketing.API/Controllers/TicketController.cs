using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketing.Core.BusinessLayer;
using Ticketing.Core.EF.Context;
using Ticketing.Core.Model;

namespace Ticketing.API.Controllers
{//Questa API è Legata ad usare Entity Framework. Vogliamo invece usare i repositories, quindi portare fuori la parte di accesso al dato.
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private DataService _dataService;

        public TicketController(DataService service)
        {
            
            this._dataService = service;
        }
        
        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            var result = _dataService.List();
            return result;
            //Usando il DataService evitiamo di scrivere il codice dopo, che invece è legato ad EF


            //Andiamo diretti su Entity framework, senza pensare al repository
           /* using var _ctx = new TicketContext();
            return _ctx.Tickets
                .Include(t=> t.Notes) //Eager Loading (Il Lazy Loading non ha senso: con i servizi web non si rimane lì appesi ad aspettare)
                .ToList();*/


        }

        [HttpPut("{id}")] //lui prende tutti i parametri che ha a disposizione e cerca di costruire i parametri d'ingresso.
        //il body stavolta gli dà il Ticket, mentre l'Id sta nell'URL
        public IActionResult Put(int id, Ticket ticket) //Doppio Model Binding
        {
            using var _ctx = new TicketContext();
            if (ticket!= null && id == ticket.Id)
            {
                var result = _dataService.Edit(ticket); //? vero?
                if (result) return Ok();
              /*  bool saved = false;
                do
                {
                    try
                    {
                        //var originalTicket = _ctx.Tickets.Find(id);
                        //ticket.RowVersion = originalTicket.RowVersion; //questi perchè mi tira fuori l'eccezione usando la row version
                        //Nel db c'è una RowVersion, mentre nel mio oggetto è diversa (la mia entità ha gli Original Values vuoti, invece sul Db sono diversi, per cui
                        //li aggiorniamo e riproviamo a salvare)
                        //Ma possiamo gestire la concorrenza come segue:

                        //Siamo in Disconnected: il ticket non l'abbiamo preso dal contesto
                        _ctx.Entry<Ticket>(ticket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                       
                        _ctx.SaveChanges();
                        saved = true;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        foreach (var entity in ex.Entries)
                        {
                            var dbValues = entity.GetDatabaseValues();
                            entity.OriginalValues.SetValues(dbValues);
                        }
                        //return BadRequest("Error updating ticket"+ex.Message);
                        saved = false;
                    }
                } while (!saved);*/
                return Ok();
                
            }
            return BadRequest("Invalid Ticket");
        }

        [HttpDelete("{id}")]
        //da implementare
       

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ticket = _dataService.GetTicketById(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
           /* using var _ctx = new TicketContext();
            
            var ticket = _ctx.Tickets
                .SingleOrDefault(t => t.Id == id);

            if (ticket == null) return NotFound();
            return Ok(ticket);*/

        }

        [HttpPost]
        public IActionResult Post(Ticket ticket)
        {
            if (ticket != null)
            {
                var result = _dataService.Add(ticket);
                return Ok(ticket);
            }
            /*using var _ctx = new TicketContext();
            if(ticket != null)
            {
                _ctx.Tickets.Add(ticket);
                _ctx.SaveChanges();
                return Ok();
            }*/
            return BadRequest("Invalid Ticket");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var _ctx = new TicketContext();
            var ticket = _ctx.Tickets
                .SingleOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                _ctx.Tickets.Remove(ticket);
                _ctx.SaveChanges();
            }
            else return NotFound();

            return Ok();
        }
    }
}
