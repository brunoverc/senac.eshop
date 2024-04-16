﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senac.eShop.Application.DTOs.Response
{
    public class UserLoginResponse
    {
        public bool Sucess { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Token { get; private set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ExpirationDate { get; private set; }

        public List<string> Errors { get; private set; }

        public UserLoginResponse() =>
            Errors = new List<string>();

        public UserLoginResponse(bool success = true) : this()
        {
            Sucess = success;
        }

        public UserLoginResponse(bool success, string token, DateTime expirationDate) : this(success)
        {
            Token = token;
            ExpirationDate = expirationDate;
        }

        public void AddError(string error) =>
            Errors.Add(error);

        public void AddErrors(IEnumerable<string> strings) => 
            Errors.AddRange(strings);
    }
}
