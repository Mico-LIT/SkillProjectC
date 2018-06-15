using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Base.Полиморфизм
{
    ///Ранней привязкой или перегрузкой метода

    /// <summary>
    /// https://www.c-sharpcorner.com/UploadFile/1492b1/diving-in-oop-polymorphism-and-inheritance-part-1/
    /// | 1.C # распознает метод по своим параметрам, а не только по его имени.                                    | 

    /// | 2.Возвращаемое значение / тип параметра метода                                                           |
    /// | никогда не является частью сигнатуры метода, если имена методов одинаковы. Так что это не полиморфизм.   |

    /// | 3.Модификаторы, такие как статические, не считаются частью сигнатуры метода.                             |

    /// | 4.Подпись метода состоит из его имени, количества и типов его формальных параметров.                     |
    /// | Тип возврата функции не является частью подписи. Два метода не могут иметь одну и ту же подпись,         |
    /// | а также не-члены не могут иметь то же имя, что и члены.                                                  |

    /// | 5.Имена параметров должны быть уникальными.                                                              |
    /// | А также мы не можем иметь имя параметра и объявленное имя переменной в той же функции.                   |

    /// | 6.В случае по значению значение переменной изменяется, а в случае ref и out - адрес ссылки.              |

    /// | 7.Ключевое слово params можно применить только к последнему аргументу метода.                            |
    /// | Таким образом, n количество параметров может быть только в конце.                                        |

    /// | 8.C # очень умный, чтобы распознать, имеет ли предпоследний аргумент и params один и тот же тип данных.  |

    /// | Параметр Array должен быть одномерным массивом.                                                          |
    /// ------------------------------------------------------------------------------------------------------------
    /// Класс Overload содержит три метода с именем DisplayOverload, 
    /// они различаются только по типу данных параметров, из которых они состоят. 
    /// В C # мы можем иметь методы с тем же именем, но типы данных их параметров различаются. 
    /// Эта функция C # называется перегрузкой метода.
    /// 
    /// Тип возвращаемого значения / параметра метода не является частью сигнатуры метода ,
    /// если имена методов одинаковы. 
    /// Так что это не полиморфизм. 
    /// </summary>

    public class Overload
    {
        //public void DisplayOverload() { } Ошибка! Методы с одинаковыми параметрами!
        //public int  DisplayOverload() { return 1; }

        //public void DisplayOverload1(int a, string a) { } Ошибка! 
        //public void Display(int a){string a;} Ошибка! 

        public void DisplayOverload(int a)
        {
            Console.WriteLine("DisplayOverload" + a);
        }

        public void DisplayOverload(string a)
        {
            Console.WriteLine("DisplayOverload" + a);
        }

        public void DisplayOverload(string a, int i)
        {
            Console.WriteLine("DisplayOverload" + a + i);
        }


        private string name = "Mico";
        public void Display()
        {
            Display2(ref name, ref name);
            Console.WriteLine(name);

            DisplayOverload(100, "Akhil", "Mittal", "OOP");
            DisplayOverload(200, "Akhil");

            DisplayOverload(100, 200, 300);
            DisplayOverload(200, 100);
        }
        private void Display2(ref string x, ref string y)
        {
            Console.WriteLine(name);
            x = "Mico 1";
            Console.WriteLine(name);
            y = "Mico 2";
            Console.WriteLine(name);
            name = "Mico 3";
        }

        /// <summary>
        /// В случае метода DisplayOverload первый аргумент
        /// должен быть целым числом, остальное может быть от нуля до бесконечного числа строк.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="param"></param>
        void DisplayOverload(int a, params string[] param)
        {
            foreach (var item in param)
            {
                Console.WriteLine(item + "" + a);
            }
        }


        private void DisplayOverload(int a, params int[] parameterArray)
        {
            foreach (var i in parameterArray)
                Console.WriteLine(i + "" + a);
        }
    }
}
