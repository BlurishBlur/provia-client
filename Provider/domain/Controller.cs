﻿using Provider.domain.page;
using Provider.domain.users;
using System;
using System.Collections.Generic;
using Provider.domain.bulletinboard;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Provider.domain
{
    public class Controller : IController
    {
        private static IController _instance;
        private UserManager userManager;
        private PageManager pageManager;
        private Bulletinboard bulletinboard;
        private ControllerApi api;

        public static IController instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Controller();
                }
                return _instance;
            }
        }

        private Controller()
        {
            userManager = new UserManager();
            pageManager = new PageManager();
            bulletinboard = new Bulletinboard();
            //api = new ControllerApi("http://10.126.12.113:8080");
            //api = new ControllerApi("http://127.0.0.1:8080");
            //api = new ControllerApi("http://tek-sb3-glo0a.tek.sdu.dk:8080");
            api = new ControllerApi("http://10.126.12.57:8080");
        }

        public List<Page> GetPages()
        {
            return pageManager.pages;
        }
        
        public bool LogIn(string userName, string password)
        {
            try
            {
                User user = api.Validate(userName, password);
                if (user != null)
                {
                    userManager.loggedInUser = user;
                    GetSuppliers();
                    ViewAllPosts();
                    return true;
                }
                return false;
            }
            catch (ApiException e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void LogOut()
        {
            userManager.LogOut();
        }

        public User GetLoggedInUser()
        {
            return userManager.loggedInUser;
        }

        public void GetSuppliers()
        {
            pageManager.pages = api.GetSuppliers();
        }

        public List<Post> ViewAllPosts()
        {
            bulletinboard.posts = api.GetAllPosts();
            return bulletinboard.ViewAllPosts();
        }

        public List<Post> ViewWarningPosts()
        {
            return bulletinboard.GetPosts(PostType.Warning);
        }
        public List<Post> ViewRequestPosts()
        {
            return bulletinboard.GetPosts(PostType.Request);
        }
        public List<Post> ViewOfferPosts()
        {
            return bulletinboard.GetPosts(PostType.Offer);
        }

        public void CreatePost(string owner, string title, string description, PostType type)
        {
            bulletinboard.AddPost(api.CreatePost(owner, title, description, type));
        }

        public void DeletePost(Post post)
        {
            api.DeletePost(post);
            bulletinboard.DeletePost(post);
        }

        public void EditPost(Post post, string newDescription, string newTitle)
        {
            api.EditPost(post, newDescription, newTitle);
        }

        public void AddNoteToSupplier(string supplierName, string editor, string text)
        {
            api.AddNoteToSupplier(supplierName, editor, text);
        }

        public List<Page> Search(string searchTerm)
        {
            return pageManager.Search(searchTerm);
        }

        public void EditProduct(Product product)
        {

            if ((GetLoggedInUser() == GetLoggedInUser() /*product.producer*/) || (GetLoggedInUser().Rights==User.RightsEnum.Admin))
            {

            }
            else
            {
                //Some error since user not allowed to use this function
            }


        }

        public void CreateProduct(string name, string description, string price, string package)
        {
            pageManager.pages.Find(page.owner== GetLoggedInUser().Username);
            pageManager.pages.Find(Page.);
            GetLoggedInUser();
            new Product(name, description, price, package);
        }

        public void DeleteProduct(Product product)
        {
            if ((GetLoggedInUser() == GetLoggedInUser() /*product.producer*/) || (GetLoggedInUser().Rights == User.RightsEnum.Admin))
            {

            }
            else
            {
                //Some error since user not allowed to use this function
            }

        }

    }
}
