<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asignatura.aspx.cs" Inherits="CapaPresentacion.Asignatura" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <title>Gestión de Asignaturas</title>
    <style>
        .form-container {
            margin-top: 50px;
        }
        .form-header {
            text-align: center;
            margin-bottom: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container form-container">
            <div class="row">
                <div class="col-md-8 offset-md-2">
                    <h1 class="form-header">Gestión de Asignaturas</h1>
                    <asp:Panel ID="pnlForm" runat="server">
                        <div class="form-group">
                            <label for="codAsignatura">Código de la Asignatura</label>
                            <asp:TextBox ID="txtCodAsignatura" runat="server" CssClass="form-control" placeholder="Ingrese el código de la asignatura"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="nombreAsignatura">Nombre de la Asignatura</label>
                            <asp:TextBox ID="txtNombreAsignatura" runat="server" CssClass="form-control" placeholder="Ingrese el nombre de la asignatura"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="creditos">Créditos</label>
                            <asp:TextBox ID="txtCreditos" runat="server" CssClass="form-control" placeholder="Ingrese los créditos de la asignatura"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
                    </asp:Panel>
                    <asp:Panel ID="pnlGrid" runat="server" class="mt-5">
                        <h2 class="text-center">Lista de Asignaturas</h2>
                        <div class="form-group">
                            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Buscar por nombre o código"></asp:TextBox>
                            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-secondary mt-2" Text="Buscar" OnClick="btnBuscar_Click" />
                        </div>
                        <asp:GridView ID="gvAsignaturas" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="CourseID" OnRowEditing="gvAsignaturas_RowEditing" OnRowDeleting="gvAsignaturas_RowDeleting" OnRowUpdating="gvAsignaturas_RowUpdating" OnRowCancelingEdit="gvAsignaturas_RowCancelingEdit">
                            <Columns>
                                <asp:BoundField DataField="CourseID" HeaderText="ID" ReadOnly="True" />
                                <asp:BoundField DataField="CodAsignatura" HeaderText="Código" />
                                <asp:BoundField DataField="NombAsignatura" HeaderText="Nombre" />
                                <asp:BoundField DataField="Creditos" HeaderText="Créditos" />
                                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>