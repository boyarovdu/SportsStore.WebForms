using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.SportsStore.Models;
using WebForms.SportsStore.Models.Repository;
using System.Text;
using System.Web.Routing;
using WebForms.SportsStore.Pages.Helpers;
using System.Data.Entity;

namespace WebForms.SportsStore
{
    public partial class Listing : System.Web.UI.Page
    {
        Repository repo = new Repository();
        int pageSize = 4;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Cart cart = SessionHelper.GetCart(Session);

                int requestedProductId;

                if (int.TryParse(Request.Form["add"], out requestedProductId))
                {
                    Product prod = repo.Products.FirstOrDefault(p => p.ProductID == requestedProductId);

                    if (prod != null)
                    {
                        cart.Add(prod, 1);
                    }
                }

                Session["returnUrl"] = Request.RawUrl;
                Response.Redirect("/Cart");
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return FilterProducts().OrderBy(p => p.Name).Skip(CurrentPage * pageSize).Take(pageSize);
        }

        protected int CurrentPage { get { return GetPageFromRequest(); } }

        public int PagesCount { get { return (int)Math.Ceiling((double)FilterProducts().Count() / pageSize); } }

        public int GetPageFromRequest()
        {
            int result = 0;
            int.TryParse((string)RouteData.Values["page"], out result);
            return result;
        }

        protected string CreatePagingLinks()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < PagesCount; i++)
            {
                builder.Append(string.Format("<a class='{2}' href='/list/{0}'>{1}</a>", i, i + 1, i == CurrentPage ? "selected" : ""));
            }
            return builder.ToString();
        }

        private IEnumerable<Product> FilterProducts()
        {
            var category = (string)RouteData.Values["category"];

            if (category == null)
            {
                return repo.Products;
            }

            return repo.Products.Where(p => p.Category == category);
        }
    }
}