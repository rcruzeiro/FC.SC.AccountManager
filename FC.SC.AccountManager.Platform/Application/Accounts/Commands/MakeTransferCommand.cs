namespace FC.SC.AccountManager.Platform.Application.Accounts.Commands
{
    public class MakeTransferCommand
    {
        internal int SourceAccountId { get; set; }
        public int DestinyAccountId { get; set; }
        public decimal Value { get; set; }

        public MakeTransferCommand(int sourceAccountId, int destinyAccountId, decimal value)
        {
            SourceAccountId = sourceAccountId;
            DestinyAccountId = destinyAccountId;
            Value = value;
        }
    }
}
