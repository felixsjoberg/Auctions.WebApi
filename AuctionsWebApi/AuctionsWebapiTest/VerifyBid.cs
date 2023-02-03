using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionsTest
{
    public class VerifyBid
    {
        public bool VerifyNewBid(int BidPrice, int NewBidPrice)
        {
            if (BidPrice < NewBidPrice) {
                return true;
            }
            else { return false; }
        }

    }
}
