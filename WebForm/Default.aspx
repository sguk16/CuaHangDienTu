<%@ Page Title="Cửa hàng điện tử" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <form id="frmProduct" class="vh-container">
                <input id ="namesp" type="search" onkeyup="Search()" placeholder="Tên sản phẩm" class="vh-input"/>

            <div class="vh-table-all vh-padding-32">
                <table class="table table-bordered vh-center" id="tblProduct" >
                    <thead>
                        <tr>
                            <th>Mã thiết bị</th>
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
<script>
function Search() {
  // Declare variables 
  var input, filter, table, tr, td, i, txtValue;
  input = document.getElementById("namesp");
  filter = input.value.toUpperCase();
  table = document.getElementById("tblProduct");
  tr = table.getElementsByTagName("tr");

  // Loop through all table rows, and hide those who don't match the search query
  for (i = 0; i < tr.length; i++) {
    td = tr[i].getElementsByTagName("td")[1];
    if (td) {
      txtValue = td.textContent || td.innerText;
      if (txtValue.toUpperCase().indexOf(filter) > -1) {
        tr[i].style.display = "";
      } else {
        tr[i].style.display = "none";
      }
    } 
  }
}
</script>
</asp:Content>
