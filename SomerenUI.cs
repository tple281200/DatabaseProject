using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_Rooms.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if (panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Rooms.Hide();

                // show students
                pnl_Students.Show();



                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Clear();
                

                foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Name);
                    listViewStudents.Items.Add(li);
                }
            }
            else if (panelName == "Rooms")
            {
                // hiding other panels except for rooms
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();

                // show room panel
                pnl_Rooms.Show();

                // filling rooms listview with a list of rooms (from room 201 - 225)
                SomerenLogic.Room_Service roService = new SomerenLogic.Room_Service();
                List<Room> roomList = roService.GetRooms();

                // clear the listview, also add columns
                listView_room.Clear();
                listView_room.Columns.Add("Number");
                listView_room.Columns.Add("Type");
                listView_room.Columns.Add("Capacity");

                foreach (SomerenModel.Room r in roomList)
                {
                    ListViewItem li = new ListViewItem(r.Number.ToString());
                    if (r.Type == false)
                    {
                        string x = "student";
                        li.SubItems.Add(x);
                    }
                    else
                    {
                        string y = "lecturer";
                        li.SubItems.Add(y);
                    }
                    li.SubItems.Add(r.Capacity.ToString());
                    listView_room.Items.Add(li);
                }

            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // display the panel room
            showPanel("Rooms");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pnl_Rooms_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnl_Students_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
