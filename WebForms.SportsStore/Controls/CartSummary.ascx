<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartSummary.ascx.cs" Inherits="WebForms.SportsStore.Controls.CartSummary" %>

<div id="cartSummary">
    Your cart: <%=GetCartItems()%> item(s), $<%=GetCartTotal()%> 
    <a href="/Cart">Checkout</a>
</div>
