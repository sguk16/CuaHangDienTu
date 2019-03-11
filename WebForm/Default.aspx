<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="frmProduct">
            <div class="col-sm-12">
                <table class="table table-bordered" id="tblProduct" >
                    <thead>
                        <tr>
                            <th></th>
                            <th>Tên thiết bị</th>
                            <th>Loại thiết bị</th>
                            <th>Đơn giá</th>
                            <th>Số lượng tồn</th>
                        </tr>
                    </thead>
                    <tbody id="tbl_ThietBi" runat="server"></tbody>
                </table>
            </div>
        </form>

</asp:Content>
