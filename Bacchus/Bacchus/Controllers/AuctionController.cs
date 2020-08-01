using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories;

namespace Bacchus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionRepository _auction;




        public AuctionController(IAuctionRepository auctionRepository)
        {
            _auction = auctionRepository;
        }


        [HttpGet]
        public List<Auction> GetAuction()
        {

            
            return _auction.GetItems();

        }

    }
           
}