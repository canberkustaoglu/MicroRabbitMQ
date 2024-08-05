using MediatR;
using MicroRabbit.Transfer.Domain.Commands;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.CommandHandlers
{
    public class TransferTransferCommandHandler : IRequestHandler<TransferCreateTransferCommand, bool>
    {
        private readonly ITransferRepository _transferRepository;

        public TransferTransferCommandHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public async Task<bool> Handle(TransferCreateTransferCommand request, CancellationToken cancellationToken)
        {
            var transferLog = new TransferLog
            {
                FromAccount = request.FromAccount,
                ToAccount = request.ToAccount,
                TransferAmount = request.TransferAmount
            };

            _transferRepository.Add(transferLog);
            return await Task.FromResult(true);
        }
    }
}
//dosyayı kendim oluşturdum ekstradan projede yoktu aklında olsun