﻿namespace ProductsAPI.DAL.ViewModels.Account
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public List<int>? FavoriteIds { get; set; }
        public List<int>? CartIds { get; set; }
    }
}