using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestTK
{
    public static class Calculations
    {
        /// <summary>
        /// Формула для расчета стоимости билета согласно формуле указанной в ТЗ
        /// </summary>
        /// <param name="dist">Расстояние указанное в км</param>
        /// <param name="kol">Количество билетов</param>
        /// <param name="ticketClass">Класс обслуживания где 0-плацкарт, 1-купе, 2-полулюкс 3-люкс</param>
        /// <returns>Стоимость билета в рублях</returns>
        static public double TicketPrice(string dist_str, string kol_str, int ticketClass)
        {
            double multiplier;
            if (string.IsNullOrEmpty(dist_str) || string.IsNullOrEmpty(kol_str))
            {
                MessageBox.Show("Заполните поля");
                return 0;
            }
            if (ticketClass == -1)
            { 
                MessageBox.Show("Выбирете класс обслуживания");
                return 0;
            }
            dist_str = dist_str.Replace('.', ',');
            double dist;
            bool dist_to_d = double.TryParse(dist_str, out dist);
            int kol;
            bool kol_to_i = int.TryParse(kol_str, out kol);
            if (!dist_to_d || !kol_to_i)
            { MessageBox.Show("Введите корректные значения"); return 0; }
            if (kol <= 0)
            { MessageBox.Show("Количество билетов должно быть больше 0"); return 0; }
            switch (ticketClass)
            {
                case 1:
                    multiplier = 1.1;
                    break;
                case 2:
                    multiplier = 1.2;
                    break;
                case 3:
                    multiplier = 1.3;
                    break;
                default:
                    multiplier = 1;
                    break;
            }
            return Math.Round(dist * 8 * multiplier * kol, 2);
        }
    }
}
