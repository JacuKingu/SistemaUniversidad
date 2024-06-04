using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CapaPresentacion
{
    public partial class Matricula : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMatriculas();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Lógica para guardar matrícula
            GuardarMatricula(txtPeriodo.Text, txtPromedio.Text, txtCourseID.Text, txtStudentID.Text);

            // Después de guardar, recargar la lista
            CargarMatriculas();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Lógica para buscar matrículas
            BuscarMatriculas(txtBuscar.Text);
        }

        protected void gvMatriculas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMatriculas.EditIndex = e.NewEditIndex;
            CargarMatriculas();
        }

        protected void gvMatriculas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Lógica para actualizar matrícula
            GridViewRow row = gvMatriculas.Rows[e.RowIndex];
            int enrollmentID = Convert.ToInt32(gvMatriculas.DataKeys[e.RowIndex].Values[0]);
            string periodo = (row.FindControl("txtPeriodo") as TextBox).Text;
            string promedio = (row.FindControl("txtPromedio") as TextBox).Text;
            string courseID = (row.FindControl("txtCourseID") as TextBox).Text;
            string studentID = (row.FindControl("txtStudentID") as TextBox).Text;

            ActualizarMatricula(enrollmentID, periodo, promedio, courseID, studentID);

            gvMatriculas.EditIndex = -1;
            CargarMatriculas();
        }

        protected void gvMatriculas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Lógica para eliminar matrícula
            int enrollmentID = Convert.ToInt32(gvMatriculas.DataKeys[e.RowIndex].Values[0]);
            EliminarMatricula(enrollmentID);

            CargarMatriculas();
        }

        protected void gvMatriculas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMatriculas.EditIndex = -1;
            CargarMatriculas();
        }

        private void CargarMatriculas()
        {
            // Simulando datos para el ejemplo
            DataTable dt = new DataTable();
            dt.Columns.Add("EnrollmentID");
            dt.Columns.Add("Periodo");
            dt.Columns.Add("Promedio");
            dt.Columns.Add("CourseID");
            dt.Columns.Add("StudentID");
            dt.Rows.Add(1, "2023-01", 85, 1, 1);
            dt.Rows.Add(2, "2023-02", 90, 2, 2);
            gvMatriculas.DataSource = dt;
            gvMatriculas.DataBind();
        }

        private void BuscarMatriculas(string criterio)
        {
            // Simulando búsqueda para el ejemplo
            DataTable dt = new DataTable();
            dt.Columns.Add("EnrollmentID");
            dt.Columns.Add("Periodo");
            dt.Columns.Add("Promedio");
            dt.Columns.Add("CourseID");
            dt.Columns.Add("StudentID");
            if (criterio == "2023-01")
            {
                dt.Rows.Add(1, "2023-01", 85, 1, 1);
            }
            else
            {
                dt.Rows.Add(2, "2023-02", 90, 2, 2);
            }
            gvMatriculas.DataSource = dt;
            gvMatriculas.DataBind();
        }

        private void GuardarMatricula(string periodo, string promedio, string courseID, string studentID)
        {
            // Lógica para guardar en base de datos
        }

        private void ActualizarMatricula(int enrollmentID, string periodo, string promedio, string courseID, string studentID)
        {
            // Lógica para actualizar en base de datos
        }

        private void EliminarMatricula(int enrollmentID)
        {
            // Lógica para eliminar en base de datos
        }
    }
}
