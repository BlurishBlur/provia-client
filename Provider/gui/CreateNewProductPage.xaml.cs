﻿using System;
using System.Windows;
using Provider.domain;
using Page = System.Windows.Controls.Page;

namespace Provider.gui
{
    /// <summary>
    /// Interaction logic for CreateNewPost.xaml
    /// </summary>
    public partial class CreateNewProductPage : Page
    {
        SupplierInformation viewSupplierInformation;
        public CreateNewProductPage(SupplierInformation viewSupplierInformation)
        {
            InitializeComponent();
            OwnerTextBlock.Text = Controller.instance.GetLoggedInUser().Username;
            CreationDateTextBlock.Text = DateTime.Now.ToString();
            this.viewSupplierInformation = viewSupplierInformation;
        }

        private void CreateProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                double density = Double.Parse(ProductDensity.Text);
                double price = Double.Parse(ProductPrice.Text);
                Controller.instance.CreateProduct(ProductName.Text, ProductChemName.Text, ProductDensity.Text, ProductDescription.Text, ProductPrice.Text, ProductPackaging.Text, ProductDeliveryTime.Text, OwnerTextBlock.Text);
                viewSupplierInformation.Reloadpage(true);
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Fejl i molvægt og/eller pris´. Det skal være et tal.");
            }
        }
    }
}