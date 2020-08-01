using System;

namespace Domain
{
    public class Bidding
    {
         public  long Id { get; set; }
        //
        public string AuctionProductId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

         public int Sum { get; set; }
        //
         public DateTime DateTime { get; set; }


    }
}