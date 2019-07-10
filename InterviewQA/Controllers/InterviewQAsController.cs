using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InterviewQAApi.Models;

namespace InterviewQAApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class InterviewQAsController : ControllerBase
    {
        private readonly InterviewQAContext _context;

        public InterviewQAsController(InterviewQAContext context)
        {
            _context = context;
        }

        //GET:  api/
        [HttpGet]
        public ActionResult<IEnumerable<InterviewQA>> GetInterviewQAs()
        {
            return _context.InterviewQAs;
        }     

        //GET:  api/c sharp
        [HttpGet("{Language}")]
        public ActionResult<IEnumerable<InterviewQA>> GetInterviewQA(string Language)
        {
            var QAs = _context.InterviewQAs.Where(i => i.Language == Language ).ToList();

            if (QAs == null)
            {
                return NotFound();
            }

            return QAs;

        }
        
        //GET:  api/c sharp/overview
        [HttpGet("{Language}/{topic}")]
        public ActionResult<IEnumerable<InterviewQA>> GetInterviewQA(string Language,string Topic)
        {
            var QAs = _context.InterviewQAs.Where(i => i.Language == Language && i.Topic==Topic ).ToList();

            if (QAs == null)
            {
                return NotFound();
            }

            return QAs;

        }

        

        //POST:  api/
        [HttpPost]
        public ActionResult PostInterviewQAs(InterviewQA interviewQA)
        {
             _context.InterviewQAs.Add(interviewQA);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult PutInterviewQAs(int id,InterviewQA interviewQA)
        {
            if (id != interviewQA.Id)
            {
                return BadRequest();
            }
             _context.Entry(interviewQA).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<InterviewQA> DeleteInterviewQAs(int id)
        {
            var QA = _context.InterviewQAs.Find(id);
            if (QA == null)
            {
                return BadRequest();
            }
             _context.InterviewQAs.Remove(QA);
            _context.SaveChanges();

            return QA;
        }


    }
}
