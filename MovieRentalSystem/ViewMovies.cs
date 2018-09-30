using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRentalSystem
{
    public partial class ViewMovies : Form
    {
        public ViewMovies()
        {
            InitializeComponent();
        }

        private void ViewMovies_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Database().findallmovies();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditMovie editMovie = new EditMovie(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            editMovie.ShowDialog();
            dataGridView1.DataSource = new Database().findallmovies();
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AvailableCopies = new Database().getavailablecopies(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            if (AvailableCopies > 0)
            {
                Issue issueRental = new Issue(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                issueRental.StartPosition = FormStartPosition.CenterScreen;
                issueRental.ShowDialog();
                dataGridView1.DataSource = new Database().findallmovies();
            }
            else
            {
                MessageBox.Show("No copy available to rent");
            }
        }
    }
}
