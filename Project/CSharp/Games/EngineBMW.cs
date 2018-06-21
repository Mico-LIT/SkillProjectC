using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Games
{
    class EngineBMW : IEngine
    {
        bool engineIsDead = false;
        int currentSpeed = 0;
        const int maxSpeed = 200;

        public EngineBMW()
        {

        }

        public int Accelerator(int delta = 10)
        {
            if (delta < 10)
            {
                throw new ArgumentOutOfRangeException("Для разгона, ускорение должно быть больше нуля ");
            }

            if (engineIsDead)
            {
                return 0;
            }
            else
            {
                currentSpeed += delta;

                if (currentSpeed > maxSpeed)
                {
                    engineIsDead = true;
                    currentSpeed = 0;
                    Console.Title = "Текущая скорость" + currentSpeed;
                    Exception ex = new Exception("Хана двигателю");
                    ex.HelpLink = "";

                    ex.Data.Add($"Время поломки:", DateTime.Now);
                    ex.Data.Add($"Причина поломки:", "Движок перегрел");

                    throw ex;
                }
                else
                {
                    Console.Title = $"Текущая скорость {currentSpeed}";
                    return currentSpeed;
                }
            }
        }

        public void Braking()
        {
            Console.WriteLine("Стоп машина");
        }
    }
}
