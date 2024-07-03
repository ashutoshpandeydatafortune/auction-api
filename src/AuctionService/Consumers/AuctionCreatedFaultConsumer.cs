﻿using Contracts;
using MassTransit;

namespace AuctionService.Consumers
{
    public class AuctionCreatedFaultConsumer : IConsumer<Fault<AuctionCreated>>
    {
        public async Task Consume(ConsumeContext<Fault<AuctionCreated>> context)
        {
            Console.WriteLine("==> Consuming faulty creation");

            var exception = context.Message.Exceptions.First();

            if(exception.ExceptionType == "System.ArgumentException")
            {
                await context.Publish("Error");
            }
            else
            {
                Console.WriteLine("==> Not an argument exception");
            }
        }
    }
}
