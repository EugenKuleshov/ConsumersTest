<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConsumersTest._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="pull-right add-link">
                <a href="#">Add Consumer</a>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <asp:GridView ID="ConsumersList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
                ItemType="ConsumersTest.ConsumerServiceReference.Consumer" SelectMethod="GetConsumers"
                CssClass="table table-striped table-bordered table-consumers"
                AllowPaging="true" PageSize="5">
                <PagerSettings Mode="NumericFirstLast"
                    FirstPageText="First"
                    LastPageText="Last"
                    PageButtonCount="5"
                    Position="Bottom" />
                <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right"/>

                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <%#: $"{Item.FirstName} {Item.LastName}"%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" DataFormatString="{0:d}" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <a href="#">Delete</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
