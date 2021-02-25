using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using notes.Core;
using notes.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notes.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly ILogger<NotesController> _logger;
        private INoteServices _notesServices;

        public NotesController(ILogger<NotesController> logger, INoteServices notesServices)
        {
            _logger = logger;
            _notesServices = notesServices;
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_notesServices.GetNotes());
        }

        [HttpGet("{id}", Name ="GetNote")]
        public IActionResult GetNote(int id)
        {
            return Ok(_notesServices.GetNote(id));
        }

        [HttpPost]
        public IActionResult CreateNote(Note note)
        {
            var newNote = _notesServices.CreateNote(note);

            return CreatedAtRoute("GetNote", new { newNote.Id }, newNote);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            _notesServices.DeleteNote(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditNote([FromBody] Note note)
        {
            _notesServices.EditNote(note);
            return Ok();
        }
    }
}
