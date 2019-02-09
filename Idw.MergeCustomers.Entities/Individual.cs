using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idw.MergeCustomers.Entities
{
    public class Individual
    {
        /// <summary>
        /// The Record number.
        /// </summary>
        private int recordNumber;

        /// <summary>
        /// The First Number.
        /// </summary>
        private string firstName;

        /// <summary>
        /// The Last name.
        /// </summary>
        private string lastName;

        /// <summary>
        /// The Gender.
        /// </summary>
        private string gender;

        /// <summary>
        /// The Username.
        /// </summary>
        private string username;

        /// <summary>
        /// The Password.
        /// </summary>
        private string password;

        /// <summary>
        /// The addressId.
        /// </summary>
        private int addressId;

        /// <summary>
        /// The streetName;
        /// </summary>
        private string streetName;

        /// <summary>
        /// The city.
        /// </summary>
        private string city;

        /// <summary>
        /// The state.
        /// </summary>
        private string state;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Idw.MergeCustomers.Entities.Individual"/> class.
        /// </summary>
        public Individual()
        {
        }

        /// <summary>
        /// Gets or sets the recordNumber.
        /// </summary>
        public int RecordNumber { get => recordNumber; set => recordNumber = value; }

        /// <summary>
        /// Gets or sets the firstName.
        /// </summary>
        public string FirstName { get => firstName; set => firstName = value; }

        /// <summary>
        /// Gets or sets the lastName.
        /// </summary>
        public string LastName { get => lastName; set => lastName = value; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public string Gender { get => gender; set => gender = value; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get => username; set => username = value; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get => password; set => password = value; }

        /// <summary>
        /// Gets or sets the addressId.
        /// </summary>
        public int AddressId { get => addressId; set => addressId = value; }

        /// <summary>
        /// Gets or sets the streetName.
        /// </summary>
        public string StreetName { get => streetName; set => streetName = value; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get => city; set => city = value; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get => state; set => state = value; }
    }
}
