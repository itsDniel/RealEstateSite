<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBuyer.Master" AutoEventWireup="true" CodeBehind="BuyerFeedback.aspx.cs" Inherits="RealEstateSite.BuyerFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Stylesheet/BuyerFeedback.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="feedbackDiv">
    <asp:Label ID="homeidplaceholder" runat="server" CssClass="hidden"></asp:Label>
    <asp:Label ID="requestlbl" runat="server" Font-Size="X-Large" Font-Strikeout="False" Text="Here are the homes that you have visited"></asp:Label>
    </div>
     <asp:Panel ID="ApprovedRequestPanel" runat="server" CssClass="Searchrpr" Visible="true">
            <asp:Repeater ID="rprDisplay" runat="server">
                        <ItemTemplate>
                            <div class="card" style="width: 18rem;">
                                
                                <asp:Image ID="HomeImg" runat="server" ImageUrl='<%# Eval("Image") %>' />
                                <div class="card-body">
                                    <h1 class="card-title">
                                        <asp:Label ID="homeIDlbl" runat="server" CssClass="hidden" Text='<%#DataBinder.Eval(Container.DataItem, "HomeID") %>'></asp:Label>
                                        <asp:Label ID="addresslbl" runat="server" Text='<%# "Address: " + DataBinder.Eval(Container.DataItem, "Address") %>'></asp:Label>
                                    </h1>
                                    <p class="card-text">
                                        <asp:Label ID="citylbl" runat="server" Text='<%# "City: " + DataBinder.Eval(Container.DataItem, "City") %>'></asp:Label>
                                    </p>
                                    <p class="card-text">
                                        <asp:Label ID="propertylbl" runat="server" Text='<%# "Property Type: " + DataBinder.Eval(Container.DataItem, "PropertyType") %>'></asp:Label>
                                    </p>
                                    <p class="card-text">
                                        <asp:Label ID="pricelbl" runat="server" Text='<%#"Price: $" + DataBinder.Eval(Container.DataItem, "Price") %>'></asp:Label>
                                    </p>
                                    <asp:Button ID="feedbackbtn" Text="Leave Feedback" runat="server"/>
                                </div>
                            </div>
                     </ItemTemplate>
                    </asp:Repeater>
        </asp:Panel>
</asp:Content>
