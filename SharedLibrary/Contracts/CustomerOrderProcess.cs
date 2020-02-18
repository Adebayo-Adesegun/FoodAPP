using System;

namespace SharedLibrary.Contracts
{
    public class ICustomerOrderProcess
    {
        public string OrderDate { get; set; }
        public string Item { get; set; }
        public int CustomerId { get; set; }
    }
}
