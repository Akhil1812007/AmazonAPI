﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Amazon.Models;
using Amazon.Repository;

namespace Amazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }

        //getting all carts of a particular customer
        [HttpGet]
        public async Task<ActionResult<List<Cart>>> Getcarts(int id)
        {
         
            return await _repository.GetAllCart(id);
        }
        //delete a cart
        [HttpDelete]
        public async Task<ActionResult> DeleteCart(int id)
        {
             await _repository.DeleteFromCart(id);
            return NoContent();
           
        }
        [HttpPut]
        public async Task<ActionResult<Cart>> updateCart(int id)
        {
            return await _repository.ModifyCart(id);
        }


       

        
    }
}
