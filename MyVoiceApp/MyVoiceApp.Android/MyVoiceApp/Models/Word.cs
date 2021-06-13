// ***********************************************************************
// Assembly         : MyVoiceApp
// Author           : Bill Banks
// Created          : 03-14-2019
//
// Last Modified By : Bill Banks
// Last Modified On : 03-14-2019
// ***********************************************************************
// <copyright file="Word.cs" company="MyVoiceApp">
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
    /// Class Word.
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public decimal Order
        {
            get; set; 

        }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [MaxLength(25)]
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the phrase.
        /// </summary>
        /// <value>The phrase.</value>
        public string Phrase { get; set; }
        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>The group identifier.</value>
        public int Group_Id { get; set; }
    }
}
