
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using Shouldly;

namespace CSharp_Language.Testing.Stub.MailSender
{
    public class AddressObject
    {
        public string Name;
        public string Address;
    }

    public interface IAddressBook
    {
        void AddNewAddress(AddressObject record);
        List<AddressObject> GetAddresses();
    }

    public class AddressBook : IAddressBook
    {
        public List<AddressObject> Addresses { get; }

        public AddressBook()
        {
           Addresses = new List<AddressObject>(); 
        }

        public void AddNewAddress(AddressObject record)
        {
            Addresses.Add(record);
        }

        public List<AddressObject> GetAddresses()
        {
            return Addresses;
        }
    }

    public class AddressBookTest
    {
        [Fact]
        public void TestingStateVerification()
        {
            var addressBook = new AddressBook();
            addressBook.AddNewAddress(new AddressObject
            {
                Name = "bob",
                Address = "Somewhere"
            });

            addressBook
                .GetAddresses()
                .Count
                .ShouldBe(1);
            var address = addressBook.GetAddresses().First();
            address.Name.ShouldBe("bob"); 
            address.Address.ShouldBe("Somewhere"); 
        }

        [Fact]
        public void TestingBehaviorVerification()
        {
            var addressBookMock = new Mock<IAddressBook>();
            addressBookMock
                .Setup(x => x.AddNewAddress(It.Is<AddressObject>(y => y.Name == "Frank")))
                .Verifiable();

            var addressBook = addressBookMock.Object;
            addressBook.AddNewAddress(new AddressObject
            {
                Name = "Frank"
            });
            addressBookMock.VerifyAll();
        }
    }
}
