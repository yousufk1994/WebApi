using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetApi.Crud;
using DotNetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly CrudDb dbContext;
        public ValuesController(CrudDb dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var getterFromDatabase = dbContext.forModel.ToList();
            return Ok(getterFromDatabase);

        }
        [HttpGet("{id:int}")]
        //[Route("{id:int}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var getterFromId = dbContext.forModel.Find(id);
            if (getterFromId == null)
            {
                return NotFound();
            }
            return Ok(getterFromId);

        }


        [HttpPost]

        public ActionResult PostRequest(DbValues dbValues)
        {
            try
            {
                dbContext.Add(dbValues);
                 dbContext.SaveChanges();

                return Ok(dbValues); // Use Ok() to return a 200 response with the saved object
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while saving the data.");
            }
        }
        [HttpPut]
        //[HttpPut("{id:int}")]
        //[Route("{id:int}")]
        public ActionResult UpdateData(DbValues dbValues)
        {

            //if (id != dbValues.id)
            //{
            //    return BadRequest();
            //}
            //else
            //{
                //dbContext.Entry(updateId).CurrentValues.SetValues(dbValues);
                dbContext.Update(dbValues);
                dbContext.SaveChanges();
                return Ok(dbValues);
            //}

        }

        [HttpDelete("{id:int}")]
        //[Route("{id:int}")]
        public ActionResult Delete(int id)
        {
            var deleteId = dbContext.forModel.Find(id);
            if (deleteId == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Remove(deleteId);
                dbContext.SaveChanges();
                return Ok(deleteId);
            }
          
                //return dbValues;
        }
    }
}

