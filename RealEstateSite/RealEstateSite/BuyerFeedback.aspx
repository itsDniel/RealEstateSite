<%@ Page Title="" Language="C#" MasterPageFile="~/MasterBuyer.Master" AutoEventWireup="true" CodeBehind="BuyerFeedback.aspx.cs" Inherits="RealEstateSite.BuyerFeedback" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Stylesheet/BuyerFeedback.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center h1 title">
        <asp:Label ID="homeidplaceholder" runat="server" CssClass="hidden"></asp:Label>
        <asp:Button ID="feedbackHiddenbutton" runat="server" CssClass="hidden" OnClick="feedbackHiddenbutton_click"/>
        <asp:Label ID="requestlbl" runat="server" Font-Strikeout="False" Text="Here are the homes that you have visited"></asp:Label>
    </div>

    <asp:Panel ID="OverlayPanel" runat="server" CssClass="overlay" Visible="false"></asp:Panel>
     
    <div class="d-flex justify-content-center">
            <div class="container">
    <asp:Panel ID="ApprovedRequestPanel" runat="server" Visible="true">
        <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="rprDisplay" runat="server" OnItemCommand="rptDisplay_ItemCommand">
            <ItemTemplate>
                <div class="col"> 
                <div class="card w-75 text-center mt-3">
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
                        <p class="card-text">
                            <asp:Label ID="dateVisitedlbl" runat="server" Text='<%#"Date Visited: " + DataBinder.Eval(Container.DataItem, "DateRequested") %>'></asp:Label>
                        </p>
                        <asp:Button ID="feedbackbtn" Text="Leave Feedback" runat="server" OnClick="feedbackbtn_Click"/>
                    </div>
                </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
            </div>
    </asp:Panel>
                </div>
        </div>

    <asp:Panel ID="FeedbackPanel" runat="server" CssClass="feedbackModal" BorderStyle="Solid" Visible = "false">
            <asp:Label ID="feedbacklbl" runat="server" Text="Please Leave Your Feedback For This Home" Font-Size="X-Large"></asp:Label>
            <asp:Label ID="feedbackmsg" runat="server" ForeColor="Red"></asp:Label>
            <asp:Label ID="Q1lbl" runat="server" Text="Is the asking price reasonable?"></asp:Label>
            <asp:DropDownList ID="A1ddl" runat="server">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Q2lbl" runat="server" Text="Is the location convenient for your needs?"></asp:Label>
            <asp:DropDownList ID="A2ddl" runat="server">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Q3lbl" runat="server" Text="Do you have any comment about this home?"></asp:Label>
            <asp:TextBox ID="A3txt" runat="server"></asp:TextBox>
            <asp:Label ID="Q4lbl" runat="server" Text="On a scale of 5 what rating would you give this home?"></asp:Label>
            <asp:DropDownList ID="A4txt" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="feedbackSubmitbtn" runat="server" Text ="Leave Feedback" OnClick="feedbackSubmitbtn_Click"/>
            <asp:Button ID="feedbackClosebtn" runat="server" Text="Close" OnClick="feedbackClosebtn_Click"/>
            
            <ajaxtoolkit:modalpopupextender ID="feedbackModal" runat="server" TargetControlID="feedbackHiddenbutton" PopupControlID="FeedbackPanel, ApprovedRequestPanel" OkControlID="feedbackClosebtn"> 
            </ajaxToolkit:ModalPopupExtender>
        </asp:Panel>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
</asp:Content>