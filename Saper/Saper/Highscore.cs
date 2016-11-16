using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saper
{
    public class Highscore                      // PUBLIC 
    {
        public const int SIZE = 10;
        private HighscoreEntry[] m_highscore_entries = new HighscoreEntry[SIZE];


        public Highscore()
        {
            for (int i = 0; i < SIZE; i++)
                m_highscore_entries[i] = new HighscoreEntry("abc", 30 * (i + 1));
        }

        public string get_name(int index)
        {
            return m_highscore_entries[index].name;
        }

        public int get_time(int index)
        {
            return m_highscore_entries[index].time;
        }

        public int insert(int time, string name)
        {
            for (int i = 0; i < SIZE; i++)
            {
                if (time < m_highscore_entries[i].time)
                {
                    for (int j = SIZE - 1; j > i; j--)
                    {
                        m_highscore_entries[j] = m_highscore_entries[j - 1];
                        
                    }
                    m_highscore_entries[i].time = time;
                    m_highscore_entries[i].name = "";
                    return i;
                }

            }
            return -1;
        }

    }
}
