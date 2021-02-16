using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;

namespace DesignPatterns.Mediator
{
    public class PingCommand:IRequest<PongResponse>
    {

    }
    public class PongResponse
    {
        public DateTime Timestamp;

        public PongResponse(DateTime timestamp)
        {
            Timestamp = timestamp;
        }
    }

    [UsedImplicitly]
    public class PingCommandHanlder : IRequestHandler<PingCommand, PongResponse>
    {
        public async Task<PongResponse> Handle(PingCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new PongResponse(DateTime.UtcNow))
                .ConfigureAwait(false);
         
        }
    }
}
