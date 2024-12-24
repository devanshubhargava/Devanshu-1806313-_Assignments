using System;
using System.Collections.Generic;

namespace ASP_Assignment1
{
    public partial class Validator : System.Web.UI.Page
    {
        
        public class Product
        {
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public decimal Price { get; set; }

            public Product(string name, string imageUrl, decimal price)
            {
                Name = name;
                ImageUrl = imageUrl;
                Price = price;
            }
        }

        
        private List<Product> Products = new List<Product>
        {
            new Product("Gaming Pc", "images/Gaming_pc.jpg", 30000),
            new Product("Gaming Mouse", "images/gaming_mouse.jpg", 5000),
            new Product("Gaming Keyboard", "images/gaming_keyboard.jpg",3000)
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                ddlProducts.Items.Clear();
                ddlProducts.Items.Add(new System.Web.UI.WebControls.ListItem("Select a Product", "0"));
                foreach (var product in Products)
                {
                    ddlProducts.Items.Add(new System.Web.UI.WebControls.ListItem(product.Name, product.Name));
                }
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedProductName = ddlProducts.SelectedItem.Text;

            if (selectedProductName != "Select a Product")
            {
                
                Product selectedProduct = Products.Find(p => p.Name == selectedProductName);
                imgProduct.ImageUrl = selectedProduct.ImageUrl;
                lblPrice.Text = $"Price: Rs{selectedProduct.Price}";
                lblPrice.CssClass = "price";
            }
            else
            {
                imgProduct.ImageUrl = string.Empty;
                lblPrice.Text = string.Empty;
            }
        }

        protected void btnShowPrice_Click(object sender, EventArgs e)
        {
            
            string selectedProductName = ddlProducts.SelectedItem.Text;

            if (selectedProductName != "Select a Product")
            {
                
                Product selectedProduct = Products.Find(p => p.Name == selectedProductName);
                lblPrice.Text = $"Price: Rs{selectedProduct.Price}";
            }
        }
    }
}
