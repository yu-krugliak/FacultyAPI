using System.Collections.Generic;
using System.Windows.Forms;

namespace FacultyApiClientWinForms.Extensions
{
    public static class DataGridViewExtensions
    {
        public static T GetCurrentRowData<T>(this DataGridView dataGridView)
        {
            var index = dataGridView.CurrentCell.RowIndex;
            return dataGridView.GetRowData<T>(index);
        }

        public static T GetRowData<T>(this DataGridView dataGridView, int index)
        {
            return (T)dataGridView.Rows[index].DataBoundItem;
        }

        public static void Fill(this DataGridView dataGridView, object data)
        {
            var source = new BindingSource();
            source.DataSource = data;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = source;
        }

        public static void ResetEndEdit(this DataGridView dataGridView)
        {
            var bs = (BindingSource)dataGridView.DataSource;
            bs.ResetBindings(true);

            dataGridView.EndEdit();
        }
    }
}