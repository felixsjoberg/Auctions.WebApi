﻿using System;
using Auctions.WebApi.Models;

namespace Auctions.WebApi.Repository.Interfaces
{
	public interface IAuctionRepository
	{

        //Det skall gå att välja en auktion och sedan se alla bud som finns för den auktionen.

        // public List<Auction> GetOpenAuctionById(int id);
         public Task <List<Bid>> GetBidsByAuctionId(int auctionId);
        public Task<Auction?> GetAuctionByID(int ID);




        // Är auktionen fortfarande öppen kan användaren lägga ett bud.

        // Detta måste vara högre än det tidigare högsta budet





    }
}

