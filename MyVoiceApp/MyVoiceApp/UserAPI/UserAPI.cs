// ***********************************************************************
// Assembly         : MyVoiceApp
// Author           : Bill   Banks
// Created          : 06-04-2019
//
// Last Modified By : Bill   Banks
// Last Modified On : 06-06-2020
// ***********************************************************************
// <copyright file="UserAPI.cs" company="MyVoiceApp">
//     Copyright (c) Ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;

using MyVoiceApp.UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;


namespace MyVoiceApp.UserAPI
{
    /// <summary>
    /// Class UserAPI.
    /// </summary>
    class UserAPI
    {
        /// <summary>
        /// The client
        /// </summary>
        private HttpClient client;
        /// <summary>
        /// The base URL
        /// </summary>
        public string BaseURL;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAPI"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public UserAPI(string url = "http://voiceapp.ourweb.net/api/user?")
        {
            BaseURL = url;
            client = new HttpClient();
            client.BaseAddress = new Uri(BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        /// <summary>
        /// Writes the specified record.
        /// </summary>
        /// <param name="rec">The record.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public async Task<User> Write(User rec)
        {
            string ep = "";
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(ep, rec);
            rec = await responseMessage.Content.ReadAsAsync<User>();
            return rec;
        }

        /// <summary>
        /// Gets the user by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public async Task<User> GetUserByKey(string key)
        {
            string ep = "key=" + key;
            User rec = new User();
            var rm = await client.GetAsync(ep);
            rec = await rm.Content.ReadAsAsync<User>();

            return rec;
        }
        /// <summary>
        /// Gets the user by pw.
        /// </summary>
        /// <param name="un">The un.</param>
        /// <param name="pw">The pw.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public async Task<User> GetUserByPW(string un, string pw)
        {
            string ep = "un=" + un  + "&pw=" + pw ;
            User rec = new User();
            var rm = await client.GetAsync(ep);
            rec = await rm.Content.ReadAsAsync<User>();

            return rec;
        }
    }

}