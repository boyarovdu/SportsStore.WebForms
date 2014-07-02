using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.SportsStore.Models;
using WebForms.SportsStore.Pages.Helpers;

namespace WebForms.SportsStore.Pages
{
    public partial class CartView : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int productId;
                if (int.TryParse(Request.Form["delete"], out productId))
                {
                    var cart = SessionHelper.GetCart(Session);
                    Product productToDelete = new Product { ProductID = productId };
                    cart.Remove(productToDelete);
                }
                else
                {
                    Response.Redirect(ReturnUrl);
                }
            }
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            var cart = SessionHelper.GetCart(Session);

            return cart.Items;
        }

        protected Cart GetCart()
        {
            return SessionHelper.GetCart(Session);
        }

        protected string ReturnUrl { get { return Session["returnUrl"].ToString(); } }
    }
}