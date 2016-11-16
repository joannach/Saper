using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{

    public partial class Form1 : Form
    {
        const int FIELDS_X = 12;
        const int FIELDS_Y = 12;
        Field[,] m_level = new Field[FIELDS_X, FIELDS_Y];
        Brush m_brush_uncovered = new SolidBrush(Color.Gray);
        Brush m_brush_covered = new SolidBrush(Color.LightGray);
        Brush m_brush_font = new SolidBrush(Color.Black);
        Brush m_brush_explosion = new SolidBrush(Color.Red);
        Brush m_brush_first = new SolidBrush(Color.Yellow);
        Pen m_pen_light = new Pen(Color.White);
        Pen m_pen_dark = new Pen(Color.Black);
        const int FIELD_WIDTH = 35;
        const int FIELD_HEIGHT = 35;
        Field m_first;

        public Form1()
        {
            InitializeComponent();
            for (int x = 0; x < FIELDS_X; x++)
            {
                for (int y = 0; y < FIELDS_Y; y++)
                    m_level[x, y] = new Field();
            }

            for (int x = 0; x < FIELDS_X; x++)
            {
                for (int y = 0; y < FIELDS_Y; y++)
                {
                    Field f = m_level[x, y]; 
                    f.neighbour_count = 0;
                    for (int nx = x - 1; nx <= x + 1; nx++)
                    {
                        for (int ny = y - 1; ny <= y + 1; ny++)
                        {
                            if (nx >= 0 && nx < FIELDS_X && ny >= 0 && ny < FIELDS_Y && (nx != x || ny != y))
                                f.neighbours[f.neighbour_count++] = m_level[nx, ny];
                        }
                    }
                }
            }
            start();

        }

        void start()
        {
            for (int x = 0; x < FIELDS_X; x++)
            {
                for (int y = 0; y < FIELDS_Y; y++)
                {
                    Field f = m_level[x, y];
                    f.uncovered = false;
                    f.mined = false;
                    f.mined_neighbours = 0;
                    f.explosion = false;
                    f.highlight = false;
                }
            }
            Random r = new Random();
            for (int i = 0; i < 15; i++)
            {
                while (true)
                {
                    int x = r.Next(FIELDS_X);
                    int y = r.Next(FIELDS_Y);
                    Field f = m_level[x, y];
                    if (f.mined == false)
                    {
                        f.mined = true;
                        for (int j = 0; j < f.neighbour_count; j++)
                            f.neighbours[j].mined_neighbours++;
                        break;
                    }
                }
            }

            for (int i = 0; i < FIELDS_X; i++)
            {
                for (int j = 0; j < FIELDS_Y; j++)
                {
                    if (!m_level[i, j].mined && m_level[i,j].mined_neighbours==0)
                    {
                        m_first = m_level[i, j];
                        m_first.highlight = true;
                        i = FIELDS_X;
                        break;
                    }
                }

            }
            pictureBox1.Refresh();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < FIELDS_X; i++)
            {
                for (int j = 0; j < FIELDS_Y; j++)
                {

                    Field f = m_level[i, j];
                    int left = i * FIELD_WIDTH;
                    int top = j * FIELD_HEIGHT;
                    if (f.uncovered == true)
                    {
                        if (!f.explosion)
                            g.FillRectangle(m_brush_uncovered, left, top, FIELD_WIDTH, FIELD_HEIGHT);
                        else
                            g.FillRectangle(m_brush_explosion, left, top, FIELD_WIDTH, FIELD_HEIGHT);
                        g.DrawLine(m_pen_dark, left, top, left, top + FIELD_HEIGHT - 1);
                        g.DrawLine(m_pen_dark, left, top, left + FIELD_WIDTH - 1, top);
                        g.DrawLine(m_pen_light, left + FIELD_WIDTH - 1, top, left + FIELD_WIDTH - 1, top + FIELD_HEIGHT - 1);
                        g.DrawLine(m_pen_light, left, top + FIELD_HEIGHT - 1, left + FIELD_WIDTH - 1, top + FIELD_HEIGHT - 1);
                        if (f.mined)
                            g.DrawString("B", this.Font, m_brush_font, left + 5, top + 5);
                        else
                            g.DrawString(f.mined_neighbours.ToString(), this.Font, m_brush_font, left + 5, top + 5);
                    }
                    else
                    {
                        if (f.highlight)
                            g.FillRectangle(m_brush_first, left, top, FIELD_WIDTH, FIELD_HEIGHT);
                        else
                            g.FillRectangle(m_brush_covered, left, top, FIELD_WIDTH, FIELD_HEIGHT);
                        g.DrawLine(m_pen_light, left, top, left, top + FIELD_HEIGHT - 1);
                        g.DrawLine(m_pen_light, left, top, left + FIELD_WIDTH - 1, top);
                        g.DrawLine(m_pen_dark, left + FIELD_WIDTH - 1, top, left + FIELD_WIDTH - 1, top + FIELD_HEIGHT - 1);
                        g.DrawLine(m_pen_dark, left, top + FIELD_HEIGHT - 1, left + FIELD_WIDTH - 1, top + FIELD_HEIGHT - 1);
                    }

                }
            }


        }

        private void game_over()
        {
            MessageBox.Show(string.Format("Koniec gry!"));
        }

        private void uncover_field(Field f)
        {
            if (f.uncovered == false)
            {
                f.uncovered = true;
                if (f.mined_neighbours == 0)
                {
                    for (int i = 0; i < f.neighbour_count; i++)
                    {
                        uncover_field(f.neighbours[i]);
                    }

                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int field_x = e.Location.X / FIELD_WIDTH;
            int field_y = e.Location.Y / FIELD_HEIGHT;
            if (field_x >= 0 && field_x < FIELDS_X && field_y >= 0 && field_y < FIELDS_Y)
            {
                Field f = m_level[field_x, field_y];
                uncover_field(f);



               /* while (f.mined_neighbours == 0)
                {
                    for (int nx = field_x - 1; nx <= field_x + 1; nx++)
                    {
                        for (int ny = field_y - 1; ny <= field_y + 1; ny++)
                        {
                            if (nx >= 0 && nx < FIELDS_X && ny >= 0 && ny < FIELDS_Y && (nx != field_x || ny != field_y ))
                                m_level[nx, ny].uncovered = true;
                        }
                    }
                }*/

                if (m_first != null)
                {
                    m_first.highlight = false;
                    m_first = null;
                }
                if (f.mined)
                {
                    f.explosion = true;
                }
                pictureBox1.Refresh();
                if (f.mined)
                {
                    game_over();
                }

            }



            //MessageBox.Show(string.Format("Kliknales ({0}, {1})", e.Location.X, e.Location.Y));
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            start();
        }
    }
}


//ZAD DOM
/* 1. przy rozpoczynaniu gry musi podswietlac sie bezpieczne pole, na ktorym mozna kliknac if ktore nie ma ani 
jednego sasiada z bomba
2. jesli pole na ktorym kliknieto ne ma zaminowanych sasiadow, pola sasiednie odslaniaja sie same
3. gra konczy sie gdy wszystkie niezaminowane pola zostana odsloniete lub po odslonieciu bomby
4. dodac timer mierzacy czas gry 
5. dodac przycisk start rozpoczynajacy gre od poczatku
*/




/*
- losowanie pierwszego pola
- dodac timer
- okno opcji (nowa klasa Opcje, jej obiekt bedzie parametrem klasy Form1)
- dostosowac gre do ustawienia opcji 
*/