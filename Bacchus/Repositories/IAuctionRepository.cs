using System;
using System.Collections.Generic;
using Domain;

namespace Repositories
{
    public interface IAuctionRepository

    {
        List<Auction> GetItems();
    }
}