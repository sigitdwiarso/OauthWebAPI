using Microsoft.AspNet.Identity;
using OauthWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OauthWebAPI.Controllers
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        Model1 db = new Model1();

        public class DefaultMessage
        {
            public List<Product> products { get; set; }
            public string status { get; set; }
            public string message { get; set; }
        }

        public class ErrorMessage
        {
            public int code { get; set; }
            public string message { get; set; }
        }

        [Route("HelloWorld")]
        [Authorize]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            var userName = User.Identity.GetUserName();
            return Request.CreateResponse(HttpStatusCode.OK, "Hello "+userName);
        }

        DefaultMessage response = new DefaultMessage();

        [Route("GetAllProduct")]
        [Authorize]
        [HttpGet]
        public DefaultMessage GetAllProduct()
        {
           
            try
            {
                response.products = db.Product.ToList();
                response.status = "OK";
                response.message = "Success";
            }
            catch(Exception ex)
            {
                response.status = "Error";
                response.message = ex.Message;
            }
            return response;
        }

        [Route("GetProduct")]
        [Authorize]
        [HttpGet]
        public Product GetProduct(int id)
        {
            return db.Product.Find(id);
        }

        [Route("CreateProduct")]
        [Authorize]
        [HttpPost]
        public ErrorMessage CreateProduct([FromBody]Product product)
        {
            ErrorMessage response = new ErrorMessage();

            try
            {
                product.CreatedById = int.Parse(User.Identity.GetUserId());
                product.CreatedTime = DateTime.Now;
                db.Product.Add(product);
                db.SaveChanges();

                response.code = 1;
                response.message = "Product Created";
            }
            catch (Exception ex)
            {
                response.code = 0;
                response.message = ex.Message;
            }
            return response;
        }

        [Route("UpdateProduct")]
        [Authorize]
        [HttpPost]
        public ErrorMessage UpdateProduct([FromBody]Product product)
        {
            ErrorMessage response = new ErrorMessage();

            try
            {
                var productToUpdate = db.Product.Find(product.Id);
                productToUpdate.Name = product.Name;
                productToUpdate.Stock = product.Stock;
                productToUpdate.Sell_Price = product.Sell_Price;
                productToUpdate.Buy_Price = product.Buy_Price;
                productToUpdate.UpdatedById = int.Parse(User.Identity.GetUserId());
                productToUpdate.UpdatedTime = DateTime.Now;
                db.Entry(productToUpdate).State = EntityState.Modified;
                db.SaveChanges();

                response.code = 1;
                response.message = "Product Updated";
            }
            catch (Exception ex)
            {
                response.code = 0;
                response.message = ex.Message;
            }
            return response;
        }

        [Route("DeleteProduct")]
        [Authorize]
        [HttpPost]
        public ErrorMessage DeleteProduct(int id)
        {
            ErrorMessage response = new ErrorMessage();

            try {
                var productToDelete = db.Product.Find(id);
                db.Product.Remove(productToDelete);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                response.code = 0;
                response.message = ex.Message;
            }
            return response;
        }

    }
}