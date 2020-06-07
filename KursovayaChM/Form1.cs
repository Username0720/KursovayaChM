using System;
using System.Windows.Forms;

namespace KursovayaChM
{
    public partial class Form1 : Form
    {
        //глобальные переменные для работы с заданной функцией
        public double a, b, c, d, e, f, g, h, i, j, x, y, first, end, step;

        private void button1_Click(object sender, EventArgs e)
        {
            Fill();//функция для извлечения и получения данных из полей ввода
            Euler();//функция реализации метода Эйлера
            RungeKutta();//метод Рунге-Кутта
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void Fill()//извлечение данных из полей ввода
        {
            try
            {
                //присваиваем коэффициенты функции глобальным переменным
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                c = Convert.ToDouble(textBox3.Text);
                d = Convert.ToDouble(textBox4.Text);
                e = Convert.ToDouble(textBox5.Text);
                f = Convert.ToDouble(textBox6.Text);
                g = Convert.ToDouble(textBox7.Text);
                h = Convert.ToDouble(textBox8.Text);
                i = Convert.ToDouble(textBox9.Text);
                j = Convert.ToDouble(textBox10.Text);
                x = Convert.ToDouble(textBox11.Text);
                y = Convert.ToDouble(textBox12.Text);
                first = Convert.ToDouble(textBox14.Text);
                end = Convert.ToDouble(textBox15.Text);
                //вычисляем шаг отрезка
                step = (end - first) / Convert.ToDouble(numericUpDown1.Value);
            }
            catch(Exception e) { MessageBox.Show(e.Message 
                + " Входная строка может включать в себя только числовые величины"); }
        }

        public double Function(double x, double y)//заданная функция
        {
            return Math.Round(a + b * x + c * y + d * Math.Pow(x, 2) + e * x * y + f * Math.Pow(y, 2) + g * Math.Pow(x, 3)
                + h * Math.Pow(x, 2) * y + i * x * Math.Pow(y, 2) + j * Math.Pow(y, 3), 5);
        }

        public void Euler()//метод Эйлера
        {
            //очищаем поле для вывода
            textBox13.Clear();
            //выводим шапку для таблицы значений
            textBox13.Text = "    x         y          f(x,y)        " + Environment.NewLine;
            for (double i = first; i < end;)
            {
                //инкрементируем итератор
                i += step;
                //выводим рез-ты первой итерации - х0, у0, f(x0, y0)
                textBox13.Text += x + "       " + y + "    " + Function(x, y).ToString() + Environment.NewLine;
                //получаем следующее значение у
                y += Math.Round(step * Function(x, y), 5);
                //выбираем другую точку на след шаг
                x += step;
            }
            //обновляем значения х и у, так как в методе мы изменили
            x = Convert.ToDouble(textBox11.Text);
            y = Convert.ToDouble(textBox12.Text);
        }

        public void RungeKutta()//метод Рунге-Кутта 4 порядка
        {
            //очищаем поле для вывода
            textBox16.Clear();
            //выводим шапку для таблицы значений
            textBox16.Text = "    x         y          f(x,y)        " + Environment.NewLine;
            //добавляем переменные, которые будут хранить вычисления функции
            double k1, k2, k3, k4;
            for (double i = first; i < end;)
            {
                //инкрементируем итератор
                i += step;
                //вычисляем значение функции 4 раза
                k1 = Function(x, y);
                k2 = Function(x + step / 2.0, y + (step * k1) / 2.0);
                k3 = Function(x + step / 2.0, y + (step * k2) / 2.0);
                k4 = Function(x + step, y + step * k3);
                //выводим рез-ты первой итерации
                textBox16.Text += x + "       " + y + "    " + Function(x, y).ToString() + Environment.NewLine;
                //получаем следующее значение у
                y += Math.Round(((k1 + 2 * k2 + 2 * k3 + k4) * step) / 6.0, 5);
                //выбираем другую точку на след шаг
                x += step;
            }
            //обновляем значения х и у, так как в методе мы изменили
            x = Convert.ToDouble(textBox11.Text);
            y = Convert.ToDouble(textBox12.Text);
        }
    }
}
