﻿using System.Collections.Generic;
using Provider.domain.page;
using Provider.domain.bulletinboard;
using Provider.domain.users;

namespace Provider.db
{
    public interface IDatabase
    {
        User GetLogin(string username, string password);
        List<Page> GetSuppliers();
        List<Product> GetProducts(string supplier);
        void AddNote(string supplierName, Note note);
        void UpdateNote(string supplierName, Note note);
        int AddPost(string owner, Post post);
        void UpdatePost(string owner, Post post);
        void DeletePost(Post post);
        List<Post> GetPosts();
    }
}
