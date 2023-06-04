using Microsoft.VisualBasic.ApplicationServices;
using System.IO;

namespace _2048_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StreamReader reader = new StreamReader("C:\\Users\\Vladimir\\source\\repos\\2048 game\\2048 game\\best.txt");
        int[,] field = new int[4, 4];
        Random rnd = new Random();
        int[] values = new int[] { 2, 2, 2, 4 };
        public int score = 0;
        int count = 0;
        int count4 = 0;
        int a = 0;
        int b = 0;
        int rndi = 0;
        int rndj = 0;
        bool rndTrue = false;
        bool isTrue = false;
        bool haveZero = false;
        bool isLose = false;
        int i = 0;
        int j = 0;
        int cage = 0;
        int best = 0;
        PictureBox[,] pics = new PictureBox[4, 4];
        public void Draw_Feild(int i, int j)
        {
            pics[i, j].Image = Image.FromFile($"C:\\Users\\Vladimir\\source\\repos\\2048 game\\2048 game\\picts\\{field[i,j]}.jpg");
            this.Controls.Add(pics[i, j]);
        }
        public void Lose()
        { 
            Form2 newForm = new Form2(score);
            newForm.Show();
            this.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            int v = 0;
            best = Convert.ToInt32(reader.ReadLine());
            label2.Text = Convert.ToString(best);
            reader.Close();
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    field[i, j] = 0;
                }
            }
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    while (count < 2)
                    {
                        if (field[i, j] == 0)
                        {
                            count++;
                        }
                        if (count4<1)
                        {
                            field[rnd.Next(4),rnd.Next(4)] = values[rnd.Next(3)];
                            count4++;
                        }
                        else
                        {
                            field[rnd.Next(4), rnd.Next(4)] = 2;
                        }
                    }
                    var pic = new PictureBox();
                    pic.Size = new Size(175,175);
                    pic.Location = new Point(175 + 175*i,250+ 175*j);
                    pics[i, j] = pic;
                    Draw_Feild(i,j);
                }
            }
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    Draw_Feild(i, j);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isLose == false)
            {
                isTrue = false;
                rndTrue = false;
                haveZero = false;
                isLose = true;             
                if (e.KeyCode == Keys.Up)
                {
                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            if (field[i, j] != 0)
                            {
                                a = i;
                                b = j;
                                cage = field[a, b];
                                try
                                {
                                    while (field[a, b - 1] == 0)
                                    {
                                        field[a, b] = 0;
                                        field[a, b - 1] = cage;
                                        b--;
                                    }
                                    if (field[a, b - 1] == cage)
                                    {
                                        field[a, b - 1] = cage * 2;
                                        field[a, b] = 0;
                                        score = score + cage * 2;
                                    }
                                }
                                catch
                                {
                                }
                                isTrue = true;
                            }
                        }
                    }
                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            Draw_Feild(i, j);
                        }
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    for (i = 3; i > -1; i--)
                    {
                        for (j = 3; j > -1; j--)
                        {
                            if (field[i, j] != 0)
                            {
                                a = i;
                                b = j;
                                cage = field[a, b];
                                try
                                {
                                    while (field[a, b + 1] == 0)
                                    {
                                        field[a, b] = 0;
                                        field[a, b + 1] = cage;
                                        b++;
                                    }
                                    if (field[a, b + 1] == cage)
                                    {
                                        field[a, b + 1] = cage * 2;
                                        field[a, b] = 0;
                                        score = score + cage * 2;
                                    }
                                }
                                catch
                                {
                                }
                                isTrue = true;
                            }
                        }
                    }
                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            Draw_Feild(i, j);
                        }
                    }
                }
                else if (e.KeyCode == Keys.Left)
                {
                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            if (field[i, j] != 0)
                            {
                                a = i;
                                b = j;
                                cage = field[a, b];
                                try
                                {
                                    while (field[a - 1, b] == 0)
                                    {
                                        field[a, b] = 0;
                                        field[a - 1, b] = cage;
                                        a--;
                                    }
                                    if (field[a - 1, b] == cage)
                                    {
                                        field[a - 1, b] = cage * 2;
                                        field[a, b] = 0;
                                        score = score + cage*2;
                                    }
                                }
                                catch
                                {
                                }
                                isTrue = true;
                            }
                        }
                    }
                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            Draw_Feild(i, j);
                        }
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    for (i = 3; i > -1; i--)
                    {
                        for (j = 3; j > -1; j--)
                        {
                            if (field[i, j] != 0)
                            {
                                a = i;
                                b = j;
                                cage = field[a, b];
                                try
                                {
                                    while (field[a + 1, b] == 0)
                                    {
                                        field[a, b] = 0;
                                        field[a + 1, b] = cage;
                                        a++;
                                    }
                                    if (field[a + 1, b] == cage)
                                    {
                                        field[a + 1, b] = cage * 2;
                                        field[a, b] = 0;
                                        score = score + cage * 2;
                                    }
                                }
                                catch
                                {
                                }
                            }
                            isTrue = true;
                        }
                    }
                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            Draw_Feild(i, j);
                        }
                    }
                }
                if (score > best)
                {
                    StreamWriter writer = new StreamWriter("C:\\Users\\Vladimir\\source\\repos\\2048 game\\2048 game\\best.txt", false);
                    writer.WriteLine(score);
                    writer.Close();
                    best = score;
                    label2.Text = Convert.ToString(best);
                }              
                if (isTrue == true)
                {
                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            if (field[i, j] == 0)
                            {
                                haveZero = true;
                            }
                        }
                    }
                    if (haveZero)
                    {
                        while (rndTrue == false)
                        {
                            rndi = rnd.Next(4);
                            rndj = rnd.Next(4);
                            if (field[rndi, rndj] == 0)
                            {
                                field[rndi, rndj] = values[rnd.Next(3)];
                                rndTrue = true;
                                isLose = false;
                            }
                        }
                    }
                    else
                    {
                        for (i = 0; i < 4; i++)
                        {
                            for (j = 0; j < 4; j++)
                            {
                                try
                                {
                                    if ((field[i - 1, j] == field[i, j]) || (field[i + 1, j] == field[i, j]) || (field[i, j - 1] == field[i, j]) || (field[i, j + 1] == field[i, j]))
                                    {
                                        isLose = false;
                                    }
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                    if (isLose == true)
                    {
                        Lose();
                    }
                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 4; j++)
                        {
                            Draw_Feild(i, j);
                        }
                    }
                }
                label1.Text = score.ToString();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           reader = new StreamReader("C:\\Users\\Vladimir\\source\\repos\\2048 game\\2048 game\\best.txt");

        rnd = new Random();
         values = new int[] { 2, 2, 2, 4 };
         score = 0;
         count = 0;
         count4 = 0;
         a = 0;
         b = 0;
         rndi = 0;
         rndj = 0;
         rndTrue = false;
         isTrue = false;
        haveZero = false;
         isLose = false;
        i = 0;
        j = 0;
        cage = 0;
        best = 0;

            best = Convert.ToInt32(reader.ReadLine());
            label2.Text = Convert.ToString(best);
            reader.Close();
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    field[i, j] = 0;
                }
            }
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    while (count < 2)
                    {
                        if (field[i, j] == 0)
                        {
                            count++;
                        }
                        if (count4 < 1)
                        {
                            field[rnd.Next(4), rnd.Next(4)] = values[rnd.Next(3)];
                            count4++;
                        }
                        else
                        {
                            field[rnd.Next(4), rnd.Next(4)] = 2;
                        }
                    }
                    var pic = new PictureBox();
                    pic.Size = new Size(175, 175);
                    pic.Location = new Point(175 + 175 * i, 250 + 175 * j);
                    pics[i, j] = pic;
                    Draw_Feild(i, j);
                }
            }
            
        }
    }
}