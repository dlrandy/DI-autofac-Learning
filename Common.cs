using System;
namespace autofac_learn
{
	public interface ILog {

		void Write(string message);
	}
    public interface IConsole
    {

        void Write(string message);
    }
    public class ConsoleLog : ILog,IConsole
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class EmailLog : ILog
    {
        private const string adminEmail = "admin@foo.com";

        public void Write(string message)
        {
            Console.WriteLine($"Email sent to {adminEmail} : {message}");
        }
    }

    public class Engine
    {
        private ILog log;
        private int id;
        public Engine(ILog _log) {
            log = _log;
            id = new Random().Next();
        }

        public Engine(ILog _log, int id)
        {
            log = _log;
            this.id = id;
        }

        public void Ahead(int power) {
            log.Write($"Engine [{id}] ahead {power}");
        }

    }

    public class Car
    {
        private Engine engine;
        private ILog log;

        public Car(Engine engine)
        {
            this.engine = engine;
            this.log = new EmailLog();
        }
        public Car(Engine  engine, ILog log)
        {
            this.engine = engine;
            this.log = log;
        }

        public void GO()
        {

            engine.Ahead(100);
            log.Write("Car going forward...");
        }

    }
}

