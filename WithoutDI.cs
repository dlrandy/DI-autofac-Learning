using System;
namespace autofac_learn
{
	public class WithoutDI
	{
		public static void Run()
		{
			var log = new ConsoleLog();
			var engine = new Engine(log);
			var car = new Car(engine, log);

			car.GO();
		}
	}
}

