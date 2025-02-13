using System.Text.Json.Serialization;

namespace BankApp.Models
{
    public class BankUser
    {
        //[JsonPropertyName("name")]
        public string? Username { get; set; }
        public int Pin { get; set; }
        public int Balance { get; set; }

        // Explicit JSON constructor
       

        //public class TransactionHist
        //{
        //    public List<string> TransactionHistory { get; set; }

        //    public TransactionHist(List<TransactionHistory> th) {
        //            TransactionHistory = th;
        //    }
    }
}
