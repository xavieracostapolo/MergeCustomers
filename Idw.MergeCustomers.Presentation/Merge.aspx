<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Merge.aspx.cs" Inherits="Idw.MergeCustomers.Presentation.Merge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Select two customers and merge.</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-8">
                            <asp:GridView ID="gvCustomers" runat="server"
                                AutoGenerateColumns="false"
                                AllowSorting="true"
                                AllowPaging="true"
                                PageSize="10"
                                CssClass="table table-bordered" OnPageIndexChanging="gvCustomers_PageIndexChanging">
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:Button ID="btnMerge" runat="server" Text="Select" CssClass="btn btn-success btn-flat btn-xs pull-left" OnClick="btnMerge_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RecordNumber" HeaderText="ID" />
                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                                    <asp:BoundField DataField="LastName" HeaderText="LastName" />
                                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                    <asp:BoundField DataField="StreetName" HeaderText="StreetName" />
                                    <asp:BoundField DataField="City" HeaderText="City" />
                                    <asp:BoundField DataField="State" HeaderText="State" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="col-md-4">
                            <div class="panel panel-default">
                                <div class="panel-heading">Customers selected for merge</div>
                                <div class="panel-body">
                                    <asp:GridView ID="gvMerge" runat="server" CssClass="table table-bordered"></asp:GridView>
                                    <div class="alert alert-warning" role="alert">
                                        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Button ID="btnMerge" runat="server" Text="Merge" CssClass="btn btn-success btn-flat btn-sm pull-left" OnClick="btnMerge_SendMerge" />
                                        <asp:Button ID="btnClear" runat="server" Text="Cancel" CssClass="btn btn-danger btn-flat btn-sm pull-right" OnClick="btnClear_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
