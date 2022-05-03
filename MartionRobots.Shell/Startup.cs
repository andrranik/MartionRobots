using Autofac;
using MartionRobots.Core;
using MartionRobots.Models;

namespace MartionRobots.Shell;

public static class Startup
{
    
    public static void ConfigureContainer(ContainerBuilder builder)
    {
        //builder.RegisterType<Surface>().As<ISurface>();
        builder.RegisterType<DefaultSurfaceFactory>().As<ISurfaceFactory>();
        builder.RegisterType<DefaultRobotFactory>().As<IRobotFactory>();
        builder.RegisterType<RobotDispatcher>().As<IRobotDispatcher>();
    }
}