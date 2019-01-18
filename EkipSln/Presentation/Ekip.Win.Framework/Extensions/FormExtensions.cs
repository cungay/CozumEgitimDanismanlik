using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;

namespace Ekip.Framework.UI.Extensions
{
    public static class FormExtensions
    {
        public static string GeometryToString(this Form form)
        {
            return form.Location.X.ToString() + "|" +
                form.Location.Y.ToString() + "|" +
                form.Size.Width.ToString() + "|" +
                form.Size.Height.ToString() + "|" +
                form.WindowState.ToString();
        }

        private static bool GeometryIsBizarreLocation(Point loc, Size size)
        {
            bool locOkay;
            if (loc.X < 0 || loc.Y < 0)
            {
                locOkay = false;
            }
            else if (loc.X + size.Width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                locOkay = false;
            }
            else if (loc.Y + size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                locOkay = false;
            }
            else
            {
                locOkay = true;
            }
            return locOkay;
        }

        private static bool GeometryIsBizarreSize(Size size)
        {
            return (size.Height <= Screen.PrimaryScreen.WorkingArea.Height &&
                size.Width <= Screen.PrimaryScreen.WorkingArea.Width);
        }

        public static void GeometryFromString(this Form form, string windowGeometry)
        {
            if (string.IsNullOrEmpty(windowGeometry) == true)
            {
                return;
            }
            string[] numbers = windowGeometry.Split('|');
            string windowString = numbers[4];
            if (windowString == "Normal")
            {
                Point windowPoint = new Point(int.Parse(numbers[0]),
                    int.Parse(numbers[1]));
                Size windowSize = new Size(int.Parse(numbers[2]),
                    int.Parse(numbers[3]));

                bool locOkay = GeometryIsBizarreLocation(windowPoint, windowSize);
                bool sizeOkay = GeometryIsBizarreSize(windowSize);

                if (locOkay == true && sizeOkay == true)
                {
                    form.Location = windowPoint;
                    form.Size = windowSize;
                    form.StartPosition = FormStartPosition.Manual;
                    form.WindowState = FormWindowState.Normal;
                }
                else if (sizeOkay == true)
                {
                    form.Size = windowSize;
                }
            }
            else if (windowString == "Maximized")
            {
                form.Location = new Point(100, 100);
                form.StartPosition = FormStartPosition.Manual;
                form.WindowState = FormWindowState.Maximized;
            }
        }

        public static void DataBind(this BaseEdit edit, object dataSource)
        {
            if (edit.Tag != null && edit.Tag.ToString().Trim().Length > 0)
            {
                //BaseEdit edit = baseControl as BaseEdit;
                string dataMember = edit.Tag.ToString();
                string propertyName = edit is RadioGroup || edit is ComboBoxEdit ? "SelectedIndex" : "EditValue";
                edit.DataBindings.Clear();
                edit.DataBindings.Add(propertyName, dataSource, dataMember, true, DataSourceUpdateMode.OnValidation);
                edit.DataBindings[0].ReadValue();
            }
        }

        public static void DataBind(this Control parent, object dataSource)
        {
            foreach (Control c in parent.Controls)
            {
                DataBind(c, dataSource);
                if (c.Tag != null && c.Tag.ToString().Trim().Length > 0 && c is BaseEdit)
                {
                    BaseEdit edit = c as BaseEdit;
                    string dataMember = edit.Tag.ToString();
                    string propertyName = edit is RadioGroup || edit is ComboBoxEdit ? "SelectedIndex" : "EditValue";
                    edit.DataBindings.Clear();
                    edit.DataBindings.Add(propertyName, dataSource, dataMember, true, DataSourceUpdateMode.OnValidation);
                    edit.DataBindings[0].ReadValue();
                }
            }
        }
    }
}
