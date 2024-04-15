using System;
using Autofac;

namespace autofac_learn
{
	public class WithAutofac
	{
		public static void Run()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<Engine>();
			builder.RegisterType<ConsoleLog>().As<ILog>().As<IConsole>()
                .AsSelf() ; //var log = container.Resolve<ConsoleLog>();
			builder.RegisterType<Car>()
				.UsingConstructor(typeof(Engine));
			//builder.RegisterType<Car>();
            builder.RegisterType<EmailLog>().As<ILog>().PreserveExistingDefaults();

			//var log = new ConsoleLog();
			//builder.RegisterInstance(log).As<ILog>();
            IContainer container = builder.Build();

			var car = container.Resolve<Car>();
			car.GO();
		}
	}
}

