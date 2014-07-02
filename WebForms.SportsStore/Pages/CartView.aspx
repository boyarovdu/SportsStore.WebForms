<%@ Page EnableSessionState="True" EnableEventValidation="true" Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="WebForms.SportsStore.Pages.CartView" MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <h2>Your cart</h2>
    <%if(GetCartItems().Count() > 0){ %>
    <table id="cartItems">
        <thead>
            <tr>
                <th>Quantity</th>
                <th align="left">Item</th>
                <th align="right">Price</th>
                <th align="right">Subtotal</th>
            </tr>
        </thead>
        <tbody>

            <asp:Repeater EnableViewState="false" SelectMethod="GetCartItems" ItemType="WebForms.SportsStore.Models.CartItem" runat="server">
                <ItemTemplate>
                    <tr>
                        <td align='center'>
                            <%#Item.Quantity%>
                        </td>
                        <td>
                            <%#Item.Product.Name%>
                        </td>
                        <td align='right'>$<%#Item.Product.Price%>
                        </td>
                        <td align='right'>$<%#Item.Product.Price * Item.Quantity%>
                        </td>
                        <td align="center">
                            <button type="submit" name="delete" value="<%#Item.Product.ProductID%>">Delete</button>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td align="right" colspan="3">
                    <h4>Total:</h4>
                </td>
                <td align="right">
                    <h4>$<%=GetCart().ComputeTotalValue()%></h4>
                </td>
            </tr>
        </tfoot>
    </table>
    <% 
    }
      else
      {
          Response.Write("<p style='text-align:center; font-size:1em;'>You have no items in your cart<p>");   
      }
    %>
    <p style="text-align: center">
        <button name="contShopping" class="item" type="submit" runat="server">Continue Shopping</button>
    </p>
</asp:Content>
