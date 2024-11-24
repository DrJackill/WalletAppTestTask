using System.Drawing;

namespace WalletAppTestTask.Models.Transactions
{
    public class UserTransaction
    {

        public UserTransaction(
            Guid userDataId,
            UserTransactionType transactionType,
             double value,
              string name,
               string description,
                string authorizedUser,
                 bool isPending,
                  DateTimeOffset date,
                  string iconUrl)
        {
            Id = Guid.Empty;
            UserDataId = userDataId;
            TransactionType = transactionType;
            Value = value;
            Name = name;
            Description = description;
            AuthorizedUser = authorizedUser;
            IsPending = isPending;
            Date = date;
            IconUrl = iconUrl;
        }

        private UserTransaction(
            Guid id,
            Guid userDataId,
            UserTransactionType transactionType,
             double value,
              string name,
               string description,
                string authorizedUser,
                 bool isPending,
                  DateTimeOffset date,
                  string iconUrl)
        {
            Id = id;
            UserDataId = userDataId;
            TransactionType = transactionType;
            Value = value;
            Name = name;
            Description = description;
            AuthorizedUser = authorizedUser;
            IsPending = isPending;
            Date = date;
            IconUrl = iconUrl;
        }

        public Guid Id { get; set; }

        public Guid UserDataId { get; set; }

        public UserTransactionType TransactionType { get; set; }

        public double Value { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset Date { get; set; }

        public bool IsPending { get; set; }

        public string AuthorizedUser { get; set; }

        public string IconUrl { get; set; }
    }

    public enum UserTransactionType
    {
        Payment,
        Credit
    }
}