<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Persons.aspx.cs" Inherits="WebAppForms.Persons" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link href="Content/bootstrap.css" rel="stylesheet" />
  <link href="Content/bootstrap-theme.css" rel="stylesheet" />
  <script src="Scripts/jquery-3.4.1.min.js"></script>
  <script src="Scripts/bootstrap.min.js"></script>
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <div style="width: 75%; margin: 0 auto; margin-top: 60px">
      <div class="row">
        <div class="col-md-8">
          <asp:TextBox ID="TxtName" runat="server"
            CssClass="form-control"
            AutoCompleteType="None" class="col-lg-10"
            Placeholder="Digite o nome" AutoFocus="AutoFocus"></asp:TextBox>
        </div>
        <div class="col-md-4">
          <asp:Button ID="BtnFilter" runat="server"
            Text="Filtrar"
            CssClass="btn btn-primary btn-block"
            OnClick="BtnFilter_Click" />
        </div>
      </div>
      <div style="margin-top: 15px">
        <asp:GridView ID="GridViewPerson" runat="server" BorderWidth="0px"
          HeaderStyle-VerticalAlign="Middle"
          HeaderStyle-HorizontalAlign="Center"
          AutoGenerateColumns="False" CssClass="table table-bordered" Caption="List Of Person" CaptionAlign="Top">
          <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True">
              <ControlStyle Width="10%" />
              <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
              <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True">
              <ControlStyle Width="65%" />
              <ItemStyle HorizontalAlign="Left" Width="65%" />
            </asp:BoundField>
            <asp:BoundField DataField="CreatedAt" HeaderText="CreatedAt" ReadOnly="True">
              <ControlStyle Width="15%" />
              <ItemStyle HorizontalAlign="Center" Width="15%" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="Active" HeaderText="Active" ReadOnly="True">
              <ControlStyle Width="10%" />
              <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:CheckBoxField>
          </Columns>
          <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
      </div>
    </div>
  </form>
</body>
</html>
