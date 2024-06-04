<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CapaPresentacion.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <title>Menú Principal</title>
    <style>
        .menu-container {
            margin-top: 50px;
        }
        .menu-header {
            text-align: center;
            margin-bottom: 30px;
        }
        .menu-item {
            font-size: 18px;
            padding: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container menu-container">
            <div class="row">
                <div class="col-md-12">
                    <h1 class="menu-header">Menú Principal</h1>
                    <div class="list-group">
                        <a href="Estudiante.aspx" class="list-group-item list-group-item-action menu-item">Gestión de Estudiantes</a>
                        <a href="Asignatura.aspx" class="list-group-item list-group-item-action menu-item">Gestión de Asignaturas</a>
                        <a href="Matricula.aspx" class="list-group-item list-group-item-action menu-item">Gestión de Matrículas</a>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>