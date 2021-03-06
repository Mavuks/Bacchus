﻿using System;
using System.Collections.Generic;
using System.Net.Mime;
using Domain;
using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace Repositories
{
    public class AuctionRepository : IAuctionRepository

        
    
    {
        private IConfiguration Configuration { get; }

        public AuctionRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Auction> GetItems()
        {
            var client = new RestClient(Configuration["ApiUrl"]);
            var request = new RestRequest(Method.GET);
           
            
            IRestResponse response = client.Execute(request);
            
            
            
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                List<Auction> auctions = content.ToObject<List<Auction>>();
                List<Auction> auctionList = new List<Auction>();

                if (auctions != null)
                {
                    foreach (var auction in auctions)
                    {
                        var endDate = auction.biddingEndDate.AddHours(3);
                        auction.biddingEndDate = endDate;
                        
                        
                       int result = DateTime.Compare(DateTime.Now, auction.biddingEndDate);
                        if (result < 0)
                        {
                                auctionList.Add(auction); 
                            
                        }
                       
                    }
                    
                    return auctionList;
                }
            }

            return null;
        }

    }
} 