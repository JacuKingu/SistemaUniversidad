using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CapaPresentacion
{
    public partial class Asignatura : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAsignaturas();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Lógica para guardar asignatura
            GuardarAsignatura(txtCodAsignatura.Text, txtNombreAsignatura.Text, txtCreditos.Text);

            // Después de guardar, recargar la lista
            CargarAsignaturas();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Lógica para buscar asignaturas
            BuscarAsignaturas(txtBuscar.Text);
        }

        protected void gvAsignaturas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAsignaturas.EditIndex = e.NewEditIndex;
            CargarAsignaturas();
        }

        protected void gvAsignaturas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Lógica para actualizar asignatura
            GridViewRow row = gvAsignaturas.Rows[e.RowIndex];
            int courseId = Convert.ToInt32(gvAsignaturas.DataKeys[e.RowIndex].Values[0]);
            string codAsignatura = (row.FindControl("txtCodAsignatura") as TextBox).Text;
            string nombAsignatura = (row.FindControl("txtNombAsignatura") as TextBox).Text;
            string creditos = (row.FindControl("txtCreditos") as TextBox).Text;

            ActualizarAsignatura(courseId, codAsignatura, nombAsignatura, creditos);

            gvAsignaturas.EditIndex = -1;
            CargarAsignaturas();
        }

        protected void gvAsignaturas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Lógica para eliminar asignatura
            int courseId = Convert.ToInt32(gvAsignaturas.DataKeys[e.RowIndex].Values[0]);
            EliminarAsignatura(courseId);

            CargarAsignaturas();
        }

        protected void gvAsignaturas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAsignaturas.EditIndex = -1;
            CargarAsignaturas();
        }

        private void CargarAsignaturas()
        {
            // Simulando datos para el ejemplo
            DataTable dt = new DataTable();
            dt.Columns.Add("CourseID");
            dt.Columns.Add("CodAsignatura");
            dt.Columns.Add("NombAsignatura");
            dt.Columns.Add("Creditos");
            dt.Rows.Add(1, "CS101", "Programación", 4);
            dt.Rows.Add(2, "CS102", "Matemáticas", 3);
            gvAsignaturas.DataSource = dt;
            gvAsignaturas.DataBind();
        }

        private void BuscarAsignaturas(string criterio)
        {
            // Simulando búsqueda para el ejemplo
            DataTable dt = new DataTable();
            dt.Columns.Add("CourseID");
            dt.Columns.Add("CodAsignatura");
            dt.Columns.Add("NombAsignatura");
            dt.Columns.Add("Creditos");
            if (criterio == "CS101")
            {
                dt.Rows.Add(1, "CS101", "Programación", 4);
            }
            else
            {
                dt.Rows.Add(2, "CS102", "Matemáticas", 3);
            }
            gvAsignaturas.DataSource = dt;
            gvAsignaturas.DataBind();
        }

        private void GuardarAsignatura(string codAsignatura, string nombAsignatura, string creditos)
        {
            // Lógica para guardar en base de datos
        }

        private void ActualizarAsignatura(int courseId, string codAsignatura, string nombAsignatura, string creditos)
        {
            // Lógica para actualizar en base de datos
        }

        private void EliminarAsignatura(int courseId)
        {
            // Lógica para eliminar en base de datos
        }
    }
}
