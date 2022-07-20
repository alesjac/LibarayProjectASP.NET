using LibraryASPNETAlesja.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace LibraryASPNETAlesja.Controllers.API
{
    public class CategoriesController : ApiController
    {
        private DataContext _dataContext;

        public CategoriesController()
        {
            _dataContext = new DataContext();
        }
        // metoden GET -> /api/categories
        public IEnumerable<Category> GetCategory()
        {
            return _dataContext.Categories.ToList();
        }

        public IHttpActionResult GetCategory(int id)
        {
            var category = _dataContext.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }


        [HttpPost]
        public IHttpActionResult CreateCategory(Category category)
        {
            //validate object
            if (!ModelState.IsValid)
                return BadRequest();

            _dataContext.Categories.Add(category);
            _dataContext.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + category.Id), category);

        }


  
        [HttpPut]
        public void UpdateCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var categoryInDb = _dataContext.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dataContext.SaveChanges();
        }


    
        [AcceptVerbs("DELETE")]
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var categoryInDb = _dataContext.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryInDb == null)
                return NotFound();

            _dataContext.Categories.Remove(categoryInDb);

            _dataContext.SaveChanges();

            return Ok();

        }
    }
}
