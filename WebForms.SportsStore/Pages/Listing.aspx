<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="WebForms.SportsStore.Listing" MasterPageFile="~/Pages/Store.Master" %>

<%@ Import Namespace="WebForms.SportsStore.Models.Repository" %>


<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="items">
        <asp:Repeater ItemType="WebForms.SportsStore.Models.Product" SelectMethod="GetProducts" runat="server">
            <ItemTemplate>
                <div class='item'>
                    <h3><%# Item.Name %></h3>
                    <%# Item.Description %>
                    <h4>$<%# Item.Price %></h4>
                    <button name="add" type="submit" value="<%# Item.ProductID %>">Add to Cart</button>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    <div id="pager" class="none">
        <% =CreatePagingLinks() %>
    </div>
</asp:Content>
