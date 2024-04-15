using System;
using Autofac;

namespace autofac_learn
{
	public class LambdaExpressionComponent
	{
		public static void Run()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<ConsoleLog>().As<ILog>();

			builder.Register((IComponentContext context)=> new Engine(context.Resolve<ILog>(), 123));

			builder.RegisterType<Car>();

			builder.RegisterGeneric(typeof(List<>)).As(typeof(IList<>));
			IContainer container = builder.Build();

			var car = container.Resolve<Car>();

			car.GO();

			var myList = container.Resolve<IList<int>>();
			Console.WriteLine(myList.GetType());
		}
	}
}

