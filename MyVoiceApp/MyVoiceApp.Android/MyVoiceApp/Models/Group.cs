// ***********************************************************************
// Assembly         : MyVoiceApp
// Author           : Bill Banks
// Created          : 03-25-2019
//
// Last Modified By : Bill Banks
// Last Modified On : 03-25-2019
// ***********************************************************************
// <copyright file="Group.cs" company="MyVoiceApp">
//     Copyright (c) Ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyVoiceApp.Models
{
    /// <summary>
    /// Class Group.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public decimal Order { get; set; }

    }
}
