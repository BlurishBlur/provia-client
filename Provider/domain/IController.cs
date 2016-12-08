﻿using System;
using System.Collections.Generic;
using System.IO;
using Provider.domain.page;
using Provider.domain.bulletinboard;
using Provider.domain.users;
using IO.Swagger.Model;

namespace Provider.domain
{
    public interface IController
    {
        Object GetUpdateLock();
        List<IO.Swagger.Model.Page> GetPages();

        void GetPosts();
        void GetSuppliers();

        void EditPost(Post post, string newDescription, string newTitle);

        void DeletePost(Post post);

        void CreatePost(string owner, string title, string description, PostType type);

        void DeleteProduct(Product product);

        void EditProduct(Product product, string newProductName, string newChemicalName, Double newMolWeight,
            string newDescription, Double newPrice, string newPackaging, string newDeliveryTime);

        void CreateProduct(string ProductName, string ChemicalName, Double MolWeight, string Description, Double Price,
            string Packaging, string DeliveryTime, string Producer);

        bool LogIn(string userName, string password);

        void LogOut();

        IO.Swagger.Model.User GetLoggedInUser();

        /// Retuns a list of posts.
        /// If type = "0" all posts are returned
        /// If type = "1" warningPost are returned
        /// If type = "2" requestPost are returned
        /// If type = "3" offerPost are returned
        List<Post> ViewAllPosts();

        List<Post> ViewWarningPosts();

        List<Post> ViewRequestPosts();

        List<Post> ViewOfferPosts();

        void AddNoteToSupplier(string supplierName, string editor, string text);

        List<Page> Search(string searchTerm);

        void GetPDF(int? id);

        void DeleteTempFiles();
        void ManageSupplerPage(Page page);
    }
}
    