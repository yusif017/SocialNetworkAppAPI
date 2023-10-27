using MassTransit;
using SocialNetwork.Entities.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.Consumer
{
    public class ReceiveEmailCommand : IConsumer<SendEmailCommand>
    {
        public async Task Consume(ConsumeContext<SendEmailCommand> context)
        {
        }
    }
}
