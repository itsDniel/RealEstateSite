<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBuyer.Master" AutoEventWireup="true" CodeBehind="BuyerOffer.aspx.cs" Inherits="RealEstateSite.BuyerOffer" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Stylesheet/BuyerOffer.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="OfferDiv">
        <asp:Label ID="homeidplaceholder" runat="server" CssClass="hidden"></asp:Label>
        <asp:Button ID="OfferHiddenbutton" runat="server" CssClass="hidden" OnClick="offerHiddenbutton_click"/>
        <asp:Label ID="offerlbl" runat="server" Font-Size="X-Large" Font-Strikeout="False" Text="Here you can check out the status of your offer"></asp:Label>
        <asp:DropDownList ID="OfferStatusddl" runat="server">
            <asp:ListItem>Pending</asp:ListItem>
            <asp:ListItem>Approved</asp:ListItem>
            <asp:ListItem>Denied</asp:ListItem>
            <asp:ListItem>Awaiting Offer</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="OfferSearchbtn" runat="server" Text="Search" OnClick="OfferSearchbtn_Click" />
    </div>

    <asp:Panel ID="OverlayPanel" runat="server" CssClass="overlay" Visible="false"></asp:Panel>

    <asp:Panel ID="FeedbackedPanel" runat="server" CssClass="Searchrpr" Visible="true">
        <asp:Repeater ID="rprDisplay" runat="server" OnItemCommand="rptDisplay_ItemCommand">
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
                            <asp:Label ID="pricelbl" runat="server" Visible="true" Text='<%#"Price: $" + DataBinder.Eval(Container.DataItem, "Price") %>'></asp:Label>
                        </p>
                        <p class="card-text">
                            <asp:Label ID="statuslbl" runat="server" Visible="false" Text='<%#"Status: " + DataBinder.Eval(Container.DataItem, "Status") %>'></asp:Label>
                        </p>
                        <asp:Button ID="offerbtn" Text="Make An Offer" runat="server" OnClick="offerbtn_Click" Visible ="true"/>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>

    <asp:Panel ID="OfferPanel" runat="server" CssClass="feedbackModal" BorderStyle="Solid" Visible = "false">
        <asp:Label ID="Label1" runat="server" Text="Please Leave Your Offer For This Home" Font-Size="X-Large"></asp:Label>
        <asp:Label ID="offermsg" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="Q1lbl" runat="server" Text="How much would you like to offer?"></asp:Label>
        <asp:TextBox ID="A1txt" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="Q2lbl" runat="server" Text="What's your preferred payment method?"></asp:Label>
        <asp:DropDownList ID="A2ddl" runat="server">
            <asp:ListItem>Mortgage</asp:ListItem>
            <asp:ListItem>Cash</asp:ListItem>
            <asp:ListItem>Bank Transfer</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Q3lbl" runat="server" Text="Any condition that needs to be met in order for the sale to happen?"></asp:Label>
        <asp:TextBox ID="A3txt" runat="server"></asp:TextBox>
        <asp:Button ID="OfferSubmitbtn" runat="server" Text ="Submit Offer" OnClick="offerSubmitbtn_Click" />
        <asp:Button ID="OfferClosebtn" runat="server" Text="Close" OnClick="offerClosebtn_Click"/>
        <ajaxtoolkit:modalpopupextender ID="OfferModal" runat="server" TargetControlID="OfferHiddenbutton" PopupControlID="FeedbackedPanel, OfferPanel" OkControlID="OfferClosebtn"> 
        </ajaxToolkit:ModalPopupExtender>
    </asp:Panel>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>