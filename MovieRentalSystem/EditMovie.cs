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
    public partial class EditMovie : Form
    {
        string MovieId;
        public EditMovie()
        {
            InitializeComponent();
        }

        public EditMovie(string Id)
        {
            MovieId = Id;
            InitializeComponent();
            DataTable table = new Database().findmoviebyid(MovieId);
            rating.Text = table.Rows[0]["Rating"].ToString();
            title.Text = table.Rows[0]["Title"].ToString();
            year.Text = table.Rows[0]["Year"].ToString();
            copies.Text = table.Rows[0]["Copies"].ToString();
            plot.Text = table.Rows[0]["Plot"].ToString();
            genre.Text = table.Rows[0]["Genre"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b;

            if (rating.Text == "" || title.Text == "" || year.Text == "" || copies.Text == "" || plot.Text == "" || genre.Text == "")
            {
                MessageBox.Show("All fields are required");
            }
            else if (!int.TryParse(year.Text, out a) || !(int.TryParse(copies.Text, out b)))
            {
                MessageBox.Show("Year and Copies must be a valid integer");
            }
            else
            {
                int rental = 0;
                if ((DateTime.Now.Year - a) > 5)
                {
                    rental = 2;
                }
                else
                {
                    rental = 5;
                }

                Database database = new Database();
                database.editmovie(rating.Text, title.Text, year.Text, rental.ToString(), copies.Text, plot.Text, genre.Text, MovieId);
                MessageBox.Show("Movie Updated");
                Dispose();
            }
        }
    }
}
