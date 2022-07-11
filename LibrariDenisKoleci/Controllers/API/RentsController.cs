using LibrariDenisKoleci.DbModel;
using LibrariDenisKoleci.DTO;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace LibrariDenisKoleci.Controllers.API
{
    public class RentsController : ApiController
    {

        private DataContext _dataContext;

        public RentsController()
        {
            _dataContext = new DataContext();
        }

        public IEnumerable<Rent> GetRents()
        {
            return _dataContext.Rents.
                    Include(c => c.Book).Include(c => c.Reader).ToList();

        }
        //DELETE /api/rents
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult DeleteRent(int id)
        {
            var rentsInDb = _dataContext.Rents.SingleOrDefault(c => c.Id == id );

            if (rentsInDb == null)
                return NotFound();


            _dataContext.Rents.Remove(rentsInDb);

            _dataContext.SaveChanges();

            return Ok();

        }

        [HttpPut]
        public void UpdateCategory(int id, Rent category)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var rentInDb = _dataContext.Rents.SingleOrDefault(c => c.Id == id);

            if (rentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dataContext.SaveChanges();
        }
    }
}