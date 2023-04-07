<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisitRequest.ascx.cs" Inherits="RealEstateSite.VisitRequest" %>
<link href="Stylesheet/BuyerVisitRequest.css" rel="stylesheet" />

<asp:DataList ID="visitddl" runat="server" OnItemCommand="visitddl_ItemCommand">
    <ItemTemplate>
        <div class="card" style="width: 18rem;">
            <asp:Image ID="HomeImg" runat="server" ImageUrl='<%# Eval("Image") %>' />
            <div class="card-body">
                <h1 class="card-title">
                    <asp:Label ID="homeidlbl" runat="server" CssClass="hidden" Text='<%#DataBinder.Eval(Container.DataItem, "HomeID") %>'></asp:Label>
                    <asp:Label ID="addresslbl" runat="server" Text='<%# "Address: " + DataBinder.Eval(Container.DataItem, "Address") %>'></asp:Label>
                </h1>
                <p class="card-text">
                    <asp:Label ID="datelbl" runat="server" Text='<%# "Date: " + DataBinder.Eval(Container.DataItem, "DateRequested") %>'></asp:Label>
                </p>
                <p class="card-text">
                    <asp:Label ID="statuslbl" runat="server"  Text='<%# "Status: " + DataBinder.Eval(Container.DataItem, "Status") %>'></asp:Label>
                </p>
                <p class="card-text">
                    <asp:Label ID="msglbl" runat="server" Visible ="false"></asp:Label>
                </p>
                <asp:Button ID="visitedbtn" runat="server" Text="I have visited" Visible ="false"/>
            </div>
        </div>
    </ItemTemplate>
</asp:DataList>

<asp:Label ID="homeidplaceholder" runat="server" CssClass="hidden"></asp:Label>