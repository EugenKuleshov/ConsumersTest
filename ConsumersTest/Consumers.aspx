<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consumers.aspx.cs" Inherits="ConsumersTest._Consumers" %>

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
                    <asp:GridView ID="ConsumersListGrid" runat="server" AutoGenerateColumns="False" ShowFooter="false" GridLines="Vertical" CellPadding="4"
                        ItemType="ConsumersTest.Services.DTO.ConsumerDTO" SelectMethod="GetConsumers"
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
                            <asp:BoundField DataField="FullName" HeaderText="Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" DataFormatString="{0:d}" />
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteConsumerButton"
                                        data-delete-consumer=""
                                        Text="Delete"
                                        CommandName="Delete"
                                        OnCommand="DeleteConsumer_Command"
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>

    <!-- Add Dialog -->
    <div class="modal fade" id="add-modal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="addModalUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">Add consumer</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-horizontal">

                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="<%= FirstNameBox.ClientID %>">First name</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox runat="server" ID="FirstNameBox" CssClass="form-control" />
                                        <asp:RequiredFieldValidator
                                            ControlToValidate="FirstNameBox"
                                            ID="FirstNameRequiredValidator" runat="server"
                                            ErrorMessage="First name is required!"
                                            ForeColor="Red"
                                            Display="Dynamic"
                                            ValidationGroup="ConsumerValidators">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="<%= LastNameBox.ClientID %>">Last name</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox runat="server" ID="LastNameBox" CssClass="form-control" />
                                        <asp:RequiredFieldValidator
                                            ControlToValidate="LastNameBox"
                                            ID="LastNameRequiredValidator" runat="server"
                                            ErrorMessage="Last name is required!"
                                            ForeColor="Red"
                                            Display="Dynamic"
                                            ValidationGroup="ConsumerValidators">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="<%= EmailBox.ClientID %>">Email</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox runat="server" placeholder="Enter email" ID="EmailBox" CssClass="form-control" />
                                        <asp:RequiredFieldValidator
                                            ControlToValidate="EmailBox"
                                            ID="EmailRequiredValidator" runat="server"
                                            ErrorMessage="Email is required!"
                                            ForeColor="Red"
                                            Display="Dynamic"
                                            ValidationGroup="ConsumerValidators">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="regexEmailValid"
                                            runat="server"
                                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ControlToValidate="EmailBox"
                                            ErrorMessage="Invalid Email Format"
                                            ForeColor="Red"
                                            Display="Dynamic"
                                            ValidationGroup="ConsumerValidators">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="<%= DateOfBirthBox.ClientID %>">Date of birth</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox runat="server" placeholder="MM/dd/YYYY" ID="DateOfBirthBox" 
                                            type="text"
                                            CssClass="form-control datepicker-field"
                                            data-provide="datepicker"
                                            data-date-autoclose="true"/>
                                        <asp:RequiredFieldValidator
                                            ControlToValidate="DateOfBirthBox"
                                            ID="DateOfBirthBoxRequiredFieldValidator" runat="server"
                                            ErrorMessage="Date of birthBox is required!"
                                            ForeColor="Red"
                                            Display="Dynamic"
                                            ValidationGroup="ConsumerValidators">
                                        </asp:RequiredFieldValidator>
                                        <asp:CustomValidator runat="server"
                                            ID="dateFormatValidator"
                                            ControlToValidate="DateOfBirthBox"
                                            OnServerValidate="DeteOfBirth_ServerValidate"
                                            ErrorMessage="Please, enter date in format MM/dd/YYYY"
                                            ForeColor="Red"
                                            Display="Dynamic"
                                            ValidationGroup="ConsumerValidators" />
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
    
    <script type="text/javascript">

        $(document).on("click", "[data-delete-consumer]", function () {
            var $link = $(this);
            var name = $('td:nth-child(2)', $link.closest('tr')).text();

            var settings = {
                title: "Delete consumer",
                message: "Are you sure you delete consumer " + name + "?",
                transition: "fade",
                onok: function() {
                    window.location = $link.attr("href");
                },
                oncancel: function(){}
            }
            alertify.dialog('confirm').set(settings).show(); 
            return false;
        });

    </script>

</asp:Content>
