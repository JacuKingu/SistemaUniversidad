<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Matricula.aspx.cs" Inherits="CapaPresentacion.Matricula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <title>Gestión de Matrículas</title>
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
                    <h1 class="form-header">Gestión de Matrículas</h1>
                    <asp:Panel ID="pnlForm" runat="server">
                        <div class="form-group">
                            <label for="periodo">Período</label>
                            <asp:TextBox ID="txtPeriodo" runat="server" CssClass="form-control" placeholder="Ingrese el período de la matrícula"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="promedio">Promedio</label>
                            <asp:TextBox ID="txtPromedio" runat="server" CssClass="form-control" placeholder="Ingrese el promedio"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="courseID">ID de la Asignatura</label>
                            <asp:TextBox ID="txtCourseID" runat="server" CssClass="form-control" placeholder="Ingrese el ID de la asignatura"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="studentID">ID del Estudiante</label>
                            <asp:TextBox ID="txtStudentID" runat="server" CssClass="form-control" placeholder="Ingrese el ID del estudiante"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
                    </asp:Panel>
                    <asp:Panel ID="pnlGrid" runat="server" class="mt-5">
                        <h2 class="text-center">Lista de Matrículas</h2>
                        <div class="form-group">
                            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Buscar por período o ID de estudiante"></asp:TextBox>
                            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-secondary mt-2" Text="Buscar" OnClick="btnBuscar_Click" />
                        </div>
                        <asp:GridView ID="gvMatriculas" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="EnrollmentID" OnRowEditing="gvMatriculas_RowEditing" OnRowDeleting="gvMatriculas_RowDeleting" OnRowUpdating="gvMatriculas_RowUpdating" OnRowCancelingEdit="gvMatriculas_RowCancelingEdit">
                            <Columns>
                                <asp:BoundField DataField="EnrollmentID" HeaderText="ID" ReadOnly="True" />
                                <asp:BoundField DataField="Periodo" HeaderText="Período" />
                                <asp:BoundField DataField="Promedio" HeaderText="Promedio" />
                                <asp:BoundField DataField="CourseID" HeaderText="ID de Asignatura" />
                                <asp:BoundField DataField="StudentID" HeaderText="ID de Estudiante" />
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