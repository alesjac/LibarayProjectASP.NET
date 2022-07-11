using LibrariDenisKoleci.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace LibrariDenisKoleci.Controllers.API
{
    public class ReadersController : ApiController
    {
        private DataContext _dataContext;

        public ReadersController()
        {
            _dataContext = new DataContext();
        }

       
        public IEnumerable<Reader> GetReader(string query = null)
        {
            return _dataContext.Readers.ToList();
        }

        public IHttpActionResult GetReader(int id)
        {
            var reader = _dataContext.Readers.SingleOrDefault(c => c.Id == id);
            if (reader == null)
                return NotFound();

            return Ok(reader);
        }


        [HttpPost]
        public IHttpActionResult CreateReader(Reader reader)
        {
            //validate object
            if (!ModelState.IsValid)
                return BadRequest();

            _dataContext.Readers.Add(reader);
            _dataContext.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + reader.Id), reader);

        }


        [HttpPut]
        public void UpdateReader(int id, Reader reader)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var readerInDb = _dataContext.Readers.SingleOrDefault(c => c.Id == id);

            if (readerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dataContext.SaveChanges();
        }


        
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult DeleteReader(int id)
        {
            var readerInDb = _dataContext.Readers.SingleOrDefault(c => c.Id == id);

            if (readerInDb == null)
                return NotFound();

            _dataContext.Readers.Remove(readerInDb);

            _dataContext.SaveChanges();

            return Ok();

        }
    }
}
