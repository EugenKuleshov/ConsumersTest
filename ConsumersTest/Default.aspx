<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConsumersTest._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:UpdatePanel ID="addUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="pull-right add-consumer-block">
                        <asp:LinkButton ID="AddConsumerButton"
                            Text="Add consumer"
                            OnClick="AddConsumer_Click"
                            runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <asp:UpdatePanel ID="gridUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="ConsumersList" runat="server" AutoGenerateColumns="False" ShowFooter="false" GridLines="Vertical" CellPadding="4"
                        ItemType="ConsumersTest.ConsumerServiceReference.Consumer" SelectMethod="GetConsumers"
                        CssClass="table table-striped table-bordered table-consumers"
                        AllowPaging="true" PageSize="5">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="5"
                            Position="Bottom" />
                        <PagerStyle CssClass="grid-pagination" HorizontalAlign="Right" />

                        <Columns>
                            <asp:BoundField DataField="ConsumerId" HeaderText="ConsumerId" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="fullNameLabel" runat="server" Text='<%# $"{Item.FirstName} {Item.LastName}"%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" DataFormatString="{0:d}" />
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="TryDeleteConsumerButton"
                                        Text="Delete"
                                        OnClick="TryDeleteConsumer_Click"
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>

    <!-- Delete Dialog -->
    <div class="modal fade" id="delete-modal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="deleteModalUpdatePanel" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">Delete consumer</h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="deleteModalBody" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <asp:HiddenField ID="ConsumerIdField" runat="server"></asp:HiddenField>
                            <asp:Button ID="DeleteConsumerButton"
                                Text="Yes"
                                OnClick="DeleteConsumer_Click"
                                CssClass="btn btn-danger"
                                runat="server" />
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">No</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <!-- Add Dialog -->
    <div class="modal fade" id="add-modal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="addModalUpdatePanel" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">Add consumer</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="email">First name</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox runat="server" ID="FirstNameBox" CssClass="form-control" />
                                        <asp:RequiredFieldValidator
                                            ControlToValidate="FirstNameBox"
                                            ID="FirstNameRequiredValidator" runat="server"
                                            ErrorMessage="First name is required!"
                                            ForeColor="Red"
                                            ValidationGroup="ConsumerValidators">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="email">Last name</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox runat="server" ID="LastNameBox" CssClass="form-control" />
                                        <asp:RequiredFieldValidator
                                            ControlToValidate="LastNameBox"
                                            ID="LastNameRequiredValidator" runat="server"
                                            ErrorMessage="Last name is required!"
                                            ForeColor="Red"
                                            ValidationGroup="ConsumerValidators">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="email">Email</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox runat="server" placeholder="Enter email" ID="EmailBox" CssClass="form-control" />
                                        <asp:RequiredFieldValidator
                                            ControlToValidate="EmailBox"
                                            ID="EmailRequiredValidator" runat="server"
                                            ErrorMessage="Email is required!"
                                            ForeColor="Red"
                                            ValidationGroup="ConsumerValidators">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="regexEmailValid"
                                            runat="server"
                                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ControlToValidate="EmailBox"
                                            ErrorMessage="Invalid Email Format"
                                            ForeColor="Red"
                                            ValidationGroup="ConsumerValidators">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="email">Date of birth</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox TextMode="Date" runat="server" placeholder="MM/dd/YYYY" ID="DateOfBirthBox" CssClass="form-control datepicker-field" />
                                        <asp:RequiredFieldValidator
                                            ControlToValidate="DateOfBirthBox"
                                            ID="RequiredFieldValidator1" runat="server"
                                            ErrorMessage="Date of birthBox is required!"
                                            ForeColor="Red"
                                            ValidationGroup="ConsumerValidators">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="SubmitConsumerButton"
                                ValidationGroup="ConsumerValidators"
                                Text="Submit"
                                OnClick="SubmitConsumer_Click"
                                CssClass="btn btn-primary"
                                runat="server" />
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cancel</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
