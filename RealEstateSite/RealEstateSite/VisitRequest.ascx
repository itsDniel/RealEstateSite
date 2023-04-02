<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisitRequest.ascx.cs" Inherits="RealEstateSite.VisitRequest" %>
<link href="Stylesheet/BuyerVisitRequest.css" rel="stylesheet" />

<asp:DataList ID="visitddl" runat="server">
    <ItemTemplate>
    <div>
        <asp:Label ID="Homeidlbl" runat="server" CssClass="hidden" Text='<%# "Address: " + DataBinder.Eval(Container.DataItem, "HomeID") %>'></asp:Label>
        <asp:Label ID="addresslbl" runat="server" Text='<%# "Address: " + DataBinder.Eval(Container.DataItem, "Address") %>'></asp:Label>
        <asp:Label ID="datelbl" runat="server" Text='<%# "Date: " + DataBinder.Eval(Container.DataItem, "DateRequested") %>'></asp:Label>
        <asp:Label ID="statuslbl" runat="server"  Text='<%# "Status: " + DataBinder.Eval(Container.DataItem, "Status") %>'></asp:Label>
        <asp:Button ID="visitedbtn" runat="server" Text="I have visited" Visible ="true" />
    </div>
    </ItemTemplate>
</asp:DataList>

