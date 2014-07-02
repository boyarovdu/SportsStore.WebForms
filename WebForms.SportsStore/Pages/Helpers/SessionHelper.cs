using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WebForms.SportsStore.Models;

namespace WebForms.SportsStore.Pages.Helpers
{
    public class SessionHelper
    {
        public static Cart GetCart(HttpSessionState session)
        {
            Cart myCart = (Cart)session["cart"];

            if (myCart == null)
            {
                myCart = new Cart();
                session["cart"] = myCart;
            }
            return myCart;
        }
    }
}