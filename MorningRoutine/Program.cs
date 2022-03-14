using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorningRoutine
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyMorningRoutine myRoutine = new MyMorningRoutine();
            
            WakingUp(myRoutine);
            MakeCoffee(myRoutine);

            myRoutine.myCoffee.SipCoffee();

            TakeShower(myRoutine);
            
            myRoutine.myCoffee.SipCoffee();
            myRoutine.myCoffee.SipCoffee();

            GetDressed();
            myRoutine.myCoffee.SipCoffee();

            Breakfast();
            myRoutine.myCoffee.SipCoffee();

            GoToWork();
            

            Console.ReadKey();
        }

        public static void WakingUp(MyMorningRoutine myRoutine)
        {
            Console.WriteLine("Alarm is going off!");
            myRoutine.OpenEyes();

            do
            {
                if (myRoutine.TooTiredToGetUp && !myRoutine.SnoozePressed)
                {
                    myRoutine.HitSnooze();
                    myRoutine.CloseEyes();
                    Console.WriteLine(".......Sleeping for 10 more minutes.......");
                }
                else
                {
                    Console.WriteLine();
                    myRoutine.OpenEyes();
                    myRoutine.GetOutOfBed();
                }
            } while (!myRoutine.OutOfBed);
        }

        public static void MakeCoffee(MyMorningRoutine myRoutine)
        {
            myRoutine.myCoffee.FillCoffee();
            myRoutine.myCoffee.SipCoffee();
        }

        public static void TakeShower(MyMorningRoutine myRoutine)
        {
            int showerMinTemp = 105;
            int showerMaxTemp = 110;

            myRoutine.myShower.TurnOn();

            do
            {
                if (myRoutine.myShower.GetTemp() < showerMinTemp)
                {
                    myRoutine.myShower.Hotter();
                }
                else if (myRoutine.myShower.GetTemp() > showerMaxTemp)
                {
                    myRoutine.myShower.Colder();
                }
            } while (myRoutine.myShower.GetTemp() < showerMinTemp ||
                     myRoutine.myShower.GetTemp() > showerMaxTemp);

            myRoutine.myShower.TurnOff();
        }

        public static void GetDressed()
        {
            Console.WriteLine("Put on shirt.");
            Console.WriteLine("Put on pants.");
            Console.WriteLine("Put on shoes.");
        }

        public static void Breakfast()
        {
            Console.WriteLine("Skipping breakfast.");
        }

        public static void GoToWork()
        {
            Console.WriteLine("Going to work.");
        }

    }

    public class MyMorningRoutine
    {
        public bool TooTiredToGetUp { get; set; } = true;
        public bool SnoozePressed { get; set; } = false;
        public bool OutOfBed { private set; get; } = false;

        public Coffee myCoffee;
        public Shower myShower;

        public MyMorningRoutine()
        {
            TooTiredToGetUp = true;
            SnoozePressed = false;
            OutOfBed = false;

            myCoffee = new Coffee(100);
            myShower = new Shower();
        }

        public void OpenEyes()
        {
            Console.WriteLine("Slowly opening eyes");
        }

        public void CloseEyes()
        {
            Console.WriteLine("Ahhh..... more sleep.");
        }

        public void HitSnooze()
        {
            Console.WriteLine("Not yet.  First, more sleep.");
            SnoozePressed = true;
        }

        public void GetOutOfBed()
        {
            OutOfBed = true;
            Console.WriteLine("Ugh.  I need coffee.");
        }
    }

    public struct Coffee
    {
        public float amountRemaining;

        public Coffee(float amount)
        {
            this.amountRemaining = amount;
        }

        public void FillCoffee()
        {
            Console.WriteLine("Coffee is full.  Resist urge to chug!");
            amountRemaining = 100;
        }

        public void SipCoffee()
        {
            if (amountRemaining > 10)
            {
                Console.WriteLine("Mmmmmm.... coffee");
                amountRemaining -= 10;
                Console.WriteLine($"\tCoffee remaining: { amountRemaining }");
            }
            else
            {
                Console.WriteLine("Gone already?!?!");
                amountRemaining = 0;
            }
        }
    }

    public class Shower
    {
        private bool isOn;
        private int temp;

        private const int MAX_TEMP = 120;
        private const int MIN_TEMP = 50;

        public Shower()
        {
            isOn = false;
            temp = 60;
        }

        public void TurnOn()
        {
            Console.WriteLine("Shower is on.");
            isOn = true;
        }

        public void TurnOff()
        {
            Console.WriteLine("Shower is off.");
            isOn = false;
        }

        public void Hotter()
        {
            if (isOn)
            {
                if (temp + 10 > MAX_TEMP)
                {
                    temp = MAX_TEMP;
                }
                else
                {
                    temp += 10;
                }
                Console.WriteLine($"Temp set to { temp }");
            }
            else
            {
                Console.WriteLine("Turn shower on first");
            }
            
        }

        public void Colder()
        {
            temp -= 10;
        }

        public int GetTemp()
        {
            return temp;
        }
    }

 
}


    

