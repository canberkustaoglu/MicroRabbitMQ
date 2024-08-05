using MicroRabbit.Domain.Core.Commands;

namespace MicroRabbit.Transfer.Domain.Commands
{
    public class TransferCreateTransferCommand : Command
    {
        public int FromAccount { get; protected set; }
        public int ToAccount { get; protected set; }
        public decimal TransferAmount { get; protected set; }

        public TransferCreateTransferCommand(int fromAccount, int toAccount, decimal transferAmount)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            TransferAmount = transferAmount;
        }
    }
}
//dosyayı kendim oluşturdum ekstradan projede yoktu aklında olsun