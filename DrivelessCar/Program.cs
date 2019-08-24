using Autofac;
using DrivelessCar.Commands;
using DrivelessCar.CarModule;
using DrivelessCar.Interfaces;
using DrivelessCar.Components;

namespace DrivelessCar
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            //IOC
            var builder = new ContainerBuilder();
            builder.RegisterType<Car>().As<ICar>().SingleInstance();
            builder.RegisterType<Printer>().As<IPrinter>();
            builder.RegisterType<MoveCommand>().As<ICommand>();
            builder.RegisterType<CommandGenerator>().As<ICommandGenerator>();

            Container = builder.Build();
            Run();
        }

        public static void Run()
        {
            using(var scope = Container.BeginLifetimeScope())
            {
                var generator = scope.Resolve<ICommandGenerator>();
                generator.GenerateCommand();
            }
        }
    }
}
