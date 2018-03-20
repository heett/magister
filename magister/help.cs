using magister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magister
{
    class help
    {
        //Singleton pattern с ленивой загрузкой
        public sealed class Singleton // sealed запрещает наследование
        {
            private Singleton() { } // конструктор 
                                    // тип System.Lazy<T>
            private static readonly Lazy<Singleton> lazy =
            new Lazy<Singleton>(() => new Singleton());

            public static Singleton Source { get { return lazy.Value; } }
        }

       public class  exemple{
        //класс
        private int years = 1; //поле
        private int age = 0; //поле

            // КОНСТРУКТОР   ВЫЗОВ exemple ex = new exemple(int, int);
            public exemple(int s, int b)
            {
                years = s;
                age = b;
            }
            // ДЕСТРУКТОР
            ~exemple()
            {
                Console.WriteLine("Объект уничтожен");
            }


            /////////////////////////////
            //START перегруженные методы// 
            //////////////////////////////

            //void если ничего не возвращает
            public void Grow() //ВХОДНЫЕ Параметры должны отличаться
        {
            Grow(1);//передаём в функцию
        }
        public int Grow(int age) //ВХОДНЫЕ Параметры должны отличаться
        {
            return age + years;
        }
            /////////////////////////////
            //END перегруженные методы// 
            ////////////////////////////

            // Метод 
            public int AGE
        {
            get { return age; } // код аксессора для чтения из поля
            set { age = value; } // код аксессора для записи в поле
        }
}
        //////////////////////
        //ДЕЛЕГАТЫ И СОБЫТИЯ//
        /////////////////////

        class ClassCounter  //Это класс - в котором производится счет.
        {
            /*  ВЫЗОВ
             * static void Main(string[] args)
        {
            ClassCounter Counter = new ClassCounter();
            Handler_I Handler1 = new Handler_I();
            Handler_II Handler2 = new Handler_II();
            
                //Подписались на событие
            Counter.onCount += Handler1.Message;
            Counter.onCount += Handler2.Message;

            //Запустили счетчик
            Counter.Count();
        }

            */
            public delegate void MethodContainer(); //delegate <выходной тип> ИмяДелегата(<тип входных параметров>) 
                                                    // имеет такой же тип как и  void Message()
           
            public event MethodContainer onCount; //Событие(ключевое слово event) OnCount c типом делегата MethodContainer.
            public void Count()
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 71 || onCount != null)
                    {
                            onCount();   //запускаем событие

                    }
                }
            }
        }

        class Handler_I //Это класс, реагирующий на событие (счет равен 71).
        {
            public void Message()
            {
                Console.WriteLine("Пора действовать, ведь уже 71!");
            }
        }

        class Handler_II //Это класс, реагирующий на событие (счет равен 71).
        {
            public void Message()
            {
                Console.WriteLine("Точно, уже 71!");
            }
        }
        ////////////////////////
        // обобщенный делегат //
        ////////////////////////


        public delegate T MyDel<T>(T obj1, T obj2);    // Создадим обобщенный делегат

        public class MySum
        {
            public static int SumInt(int a, int b)
            {
                return a + b;
            }

            public static string SumStr(string s1, string s2)
            {
                return s1 + " " + s2;
            }
        }

        /* ВЫЗОВ
            MyDel<int> del1 = MySum.SumInt;
            Console.WriteLine("6 + 7 = " + del1(6, 7));
            MyDel<string> del2 = MySum.SumStr;
            Console.WriteLine("\"Отличная\" + \"погода\" = " + del2("Отличная", "погода"));
         */

        ////////////////////////////
        // END обобщенный делегат //
        ////////////////////////////

        ////////////////////////////
        // END ДЕЛЕГАТЫ И СОБЫТИЯ//
        ///////////////////////////

        /////////////////////////////////////
        // START НАСЛЕДОВАНИЕ И ПОЛИМОРФИЗМ//
        ////////////////////////////////////

        public class original { private int price; protected int price_1; //Родительский класс
            public virtual string Move(string d){ return d; } } //virtual позволяет переопределить метод
        public class child : original { //Дочерний класс класс
            public override string Move(string b) { return b = base.Move("Move из класса original"); } //переопределение с помощью слова override
            public void Start() {
                price_1 = 10; //можем обратиться, если она protected и public
            }
            

            /* ПРИМЕР ОБРАЩЕНИЯ К МЕТОДУ
            child tt = new child();
            string b = tt.Move("lol");
             */

            //ПОЛИМОРФИЗМ - изменение поведения базового класса в дочернем классе

        }

    }



}
