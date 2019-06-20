namespace FC.SC.AccountManager.Platform.Application.Accounts.Commands
{
    public class CreateAccountCommand
    {
        public decimal Value { get; set; }

        public CreateAccountCommand(decimal value)
        {
            Value = value;
        }
    }
}
