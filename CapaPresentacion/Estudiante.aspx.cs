using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CapaPresentacion
{
    public partial class Estudiante : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEstudiantes();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Lógica para guardar estudiante
            GuardarEstudiante(txtCodEstudiante.Text, txtNombreEstudiante.Text);

            // Después de guardar, recargar la lista
            CargarEstudiantes();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Lógica para buscar estudiantes
            BuscarEstudiantes(txtBuscar.Text);
        }

        protected void gvEstudiantes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEstudiantes.EditIndex = e.NewEditIndex;
            CargarEstudiantes();
        }

        protected void gvEstudiantes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Lógica para actualizar estudiante
            GridViewRow row = gvEstudiantes.Rows[e.RowIndex];
            int studentID = Convert.ToInt32(gvEstudiantes.DataKeys[e.RowIndex].Values[0]);
            string codEst = (row.FindControl("txtCodEst") as TextBox).Text;
            string nombEst = (row.FindControl("txtNombEst") as TextBox).Text;

            ActualizarEstudiante(studentID, codEst, nombEst);

            gvEstudiantes.EditIndex = -1;
            CargarEstudiantes();
        }

        protected void gvEstudiantes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Lógica para eliminar estudiante
            int studentID = Convert.ToInt32(gvEstudiantes.DataKeys[e.RowIndex].Values[0]);
            EliminarEstudiante(studentID);

            CargarEstudiantes();
        }

        protected void gvEstudiantes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEstudiantes.EditIndex = -1;
            CargarEstudiantes();
        }

        private void CargarEstudiantes()
        {
            // Simulando datos para el ejemplo
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentID");
            dt.Columns.Add("CodEst");
            dt.Columns.Add("NombEst");
            dt.Rows.Add(1, "E101", "Juan Perez");
            dt.Rows.Add(2, "E102", "Maria Gomez");
            gvEstudiantes.DataSource = dt;
            gvEstudiantes.DataBind();
        }

        private void BuscarEstudiantes(string criterio)
        {
            // Simulando búsqueda para el ejemplo
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentID");
            dt.Columns.Add("CodEst");
            dt.Columns.Add("NombEst");
            if (criterio == "E101")
            {
                dt.Rows.Add(1, "E101", "Juan Perez");
            }
            else
            {
                dt.Rows.Add(2, "E102", "Maria Gomez");
            }
            gvEstudiantes.DataSource = dt;
            gvEstudiantes.DataBind();
        }

        private void GuardarEstudiante(string codEst, string nombEst)
        {
            // Lógica para guardar en base de datos
        }

        private void ActualizarEstudiante(int studentID, string codEst, string nombEst)
        {
            // Lógica para actualizar en base de datos
        }

        private void EliminarEstudiante(int studentID)
        {
            // Lógica para eliminar en base de datos
        }
    }
}
