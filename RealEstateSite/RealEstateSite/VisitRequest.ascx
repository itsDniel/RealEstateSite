<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisitRequest.ascx.cs" Inherits="RealEstateSite.VisitRequest" %>
<div class="h1 title">
    <asp:Label ID="requestlbl" runat="server" Font-Strikeout="False" Text="Here you can see the status of your visit request"></asp:Label>
</div>
<div class="d-flex justify-content-center">
    <div class="container">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:DataList ID="visitddl" runat="server" OnItemCommand="visitddl_ItemCommand">
                <ItemTemplate>
                    <div class="col">
                        <div class="card w-75 text-center mt-3">
                            <asp:Image ID="HomeImg" runat="server" ImageUrl='<%# Eval("Image") %>' />
                            <div class="card-body">
                                <h1 class="card-title">
                                    <asp:Label ID="homeidlbl" runat="server" CssClass="hidden" Text='<%#DataBinder.Eval(Container.DataItem, "HomeID") %>'></asp:Label>
                                    <asp:Label ID="addresslbl" runat="server" Text='<%# "Address: " + DataBinder.Eval(Container.DataItem, "Address") %>'></asp:Label>
                                </h1>
                                <p class="card-text">
                                    <asp:Label ID="datelbl" runat="server" Text='<%# "Date: " + ((DateTime)Eval("DateRequested")).ToString("MM/dd/yyyy") %>'></asp:Label>
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
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</div>
<asp:Label ID="homeidplaceholder" runat="server" CssClass="hidden"></asp:Label>