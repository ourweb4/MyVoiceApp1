using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVoiceApp.UserAPI.Models
{
    public class User
    {

        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the first.0
        /// </summary>
        /// <value>The first.</value>

        public string First { get; set; }
        /// <summary>
        /// Gets or sets the last.
        /// </summary>
        /// <value>The last.</value>

        public string Last { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>The company.</value>
        public string Company { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>

        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        public string Zip { get; set; }
        /// <summary>
        /// Gets or sets the coutry.
        /// </summary>
        /// <value>The coutry.</value>
        public string Coutry { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }

        public string  UserName { get; set; }
        public string Password { get; set; }
        public string UKey { get; set; }
        public DateTime  RegDateTime { get; set; }
    }
}