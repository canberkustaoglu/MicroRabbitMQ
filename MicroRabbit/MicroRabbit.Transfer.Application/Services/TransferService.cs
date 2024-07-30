using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Commands;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Banking.Application.Models;

namespace MicroRabbit.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _accountRepository;
        private readonly IEventBus _bus;

        public TransferService(ITransferRepository _transferRepository, IEventBus bus)
        {
            _accountRepository = transferRepository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            _accountRepository.GetAccounts();
        }
        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                    accountTransfer.FromAccount,
                    accountTransfer.ToAccount,
                    accountTransfer.TransferAmount
                );

            _bus.SendCommand( createTransferCommand );
        }
    }
}
