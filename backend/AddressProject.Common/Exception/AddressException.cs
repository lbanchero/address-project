using System;

namespace AddressProject.Common.Exception
{
    public class AddressProviderCommunicationException : SystemException
    {
        public AddressProviderCommunicationException(System.Exception originalException) : base("There was an error communicating with the Address Provider.", originalException) { }
    }
    
    public class AddressProviderUnsuccessfulResponseException : SystemException
    {
        public AddressProviderUnsuccessfulResponseException() : base("There was an unsuccessful response when communicating with the Address Provider.") { }
    }
    
    public class EmptyResultOnAddressProviderResponseException : SystemException
    {
        public EmptyResultOnAddressProviderResponseException() : base("There was no results retrieved from the Address Provider.") { }
    }
}