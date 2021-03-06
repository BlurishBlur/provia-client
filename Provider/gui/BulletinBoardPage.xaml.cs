﻿using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Provider.domain;
using Provider.domain.bulletinboard;


namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for BulletinBoardPage.xaml
    /// </summary>
    public partial class BulletinBoardPage : Page
    {
        private bool isItMyList; // false = its all the post, true = its the loggedin users posts OR a specifik group post, 'all warning post' ect.

        public BulletinBoardPage()
        {
            InitializeComponent();
            listView.ItemsSource = Controller.instance.ViewAllPosts();
            Update();
        }

        private void Update()
        {
            new Thread(() =>
            {
                while (true)
                {
                    lock (Controller.instance.GetUpdateLock())
                    {
                        Monitor.Wait(Controller.instance.GetUpdateLock());
                        RefreshPage(false);
                    }
                }
            }).Start();
        }

        public void SetPostInformation(IO.Swagger.Model.Post selectedItem)
        {
            frame.Content = new BulletinBoardProductPage(selectedItem, this);
        }

        private void ViewPostInformation(object sender, MouseButtonEventArgs e)
        {
            groupBox.Header = "Opslag information";
            frame.Content = new BulletinBoardProductPage((IO.Swagger.Model.Post) listView.SelectedItem, this);
        }

        private void CreateNewPost(object sender, RoutedEventArgs e)
        {
            groupBox.Header = "Opret nyt opslag";
            frame.Content = new CreateNewPostPage(this);
        }
        /// <summary>
        /// Refresh BulletinBoardPage
        /// True = refresh product information
        /// False = refreshs only the ListView
        /// </summary>
        /// <param name="refreshFrameToo">bool</param>
        public void RefreshPage(bool refreshFrameToo)
        {
            Dispatcher.Invoke((ThreadStart) delegate
            {
                listView.ItemsSource = null;
                listView.ItemsSource = Controller.instance.ViewAllPosts();
                groupBox.Header = "Opslag information";
                typeOfList.Text = "Alle opslag";
                if (refreshFrameToo)
                {
                    frame.Content = null;
                }
            });
        }

        private void ListMyPosts(object sender, RoutedEventArgs e)
        {
            List<IO.Swagger.Model.Post> myPosts = new List<IO.Swagger.Model.Post>();
            foreach (IO.Swagger.Model.Post post in Controller.instance.ViewAllPosts())
            {
                if (post.Owner.Equals(Controller.instance.GetLoggedInUser().Username))
                {
                    myPosts.Add(post);
                }
            }
            listView.ItemsSource = null;
            if (!isItMyList)
            {
                listView.ItemsSource = myPosts;
                myPostButton.Content = "Alle opslag";
                isItMyList = true;
                typeOfList.Text = "Mine opslag";
            }
            else
            {
                listView.ItemsSource = Controller.instance.ViewAllPosts();
                myPostButton.Content = "Mine opslag";
                isItMyList = false;
                typeOfList.Text = "Alle opslag";
            }

        }
        public void SetListToWarning()
        {
            listView.ItemsSource = null;
            listView.ItemsSource = Controller.instance.ViewWarningPosts();
            isItMyList = true;
            myPostButton.Content = "Alle opslag";
            typeOfList.Text = "Alle advarelser";
        }
        public void SetListToRequest()
        {
            listView.ItemsSource = null;
            listView.ItemsSource = Controller.instance.ViewRequestPosts();
            isItMyList = true;
            myPostButton.Content = "Alle opslag";
            typeOfList.Text = "Alle efterspørgelser";
        }
        public void SetListToOffer()
        {
            listView.ItemsSource = null;
            listView.ItemsSource = Controller.instance.ViewOfferPosts();
            isItMyList = true;
            myPostButton.Content = "Alle opslag";
            typeOfList.Text = "Alle tilbud";
        }
    }
}
