using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionsTest
{
    public class PlaceBid
    {
        public bool TryPlaceBid(int bidUserID, int auctionOwnerUserID)
        {
            if (bidUserID != auctionOwnerUserID)
            {
                return true;
            }
            else { return false; }
        }

    }
}
