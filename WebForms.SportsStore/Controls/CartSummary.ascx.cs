using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.SportsStore.Pages.Helpers;

namespace WebForms.SportsStore.Controls
{
    public partial class CartSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected int GetCartItems()
        {
            return SessionHelper.GetCart(Session).Items.Count();
        }

        protected decimal GetCartTotal()
        {
            return SessionHelper.GetCart(Session).ComputeTotalValue();
        }
    }
}