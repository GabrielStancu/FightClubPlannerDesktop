using Autofac;
using BusinessLayer.Helpers;
using BusinessLayer.ViewModels;
using DataLayer.DataAccess.DatabaseAccess;
using System.Reflection;

namespace FightClubPlanner
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //register the business logic helpers 
            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(BusinessLayer)))
            //    .Where(t => t.Namespace.Contains("Helpers"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name.Equals($"I{t.Name}")));
            builder.RegisterType<AlreadyRegisteredUserChecker>().As<IAlreadyRegisteredUserChecker>();
            builder.RegisterType<FighterDataLoader>().As<IFighterDataLoader>();
            builder.RegisterType<FighterHealthTester>().As<IFighterHealthTester>();
            builder.RegisterType<FighterInviteAnswerer>().As<IFighterInviteAnswerer>();
            builder.RegisterType<FightsGenerator>().As<IFightsGenerator>();
            builder.RegisterType<InviteSender>().As<IInviteSender>();
            builder.RegisterType<IsolationBubbleAdder>().As<IIsolationBubbleAdder>();
            builder.RegisterType<LogInChecker>().As<ILogInChecker>();
            builder.RegisterType<ManagerDataLoader>().As<IManagerDataLoader>();
            builder.RegisterType<SignUpChecker>().As<ISignUpChecker>();
            builder.RegisterType<TournamentBuilder>().As<ITournamentBuilder>();
            builder.RegisterType<TournamentCreator>().As<ITournamentCreator>();
            builder.RegisterType<TournamentDetailsDataLoader>().As<ITournamentDetailsDataLoader>();

            //register the DAOS
            builder.RegisterType<CovidTestEntity>().As<ICovidTestEntity>();
            builder.RegisterType<FightEntity>().As<IFightEntity>();
            builder.RegisterType<FighterEntity>().As<IFighterEntity>();
            builder.RegisterType<InviteEntity>().As<IInviteEntity>();
            builder.RegisterType<IsolationBubbleEntity>().As<IIsolationBubbleEntity>();
            builder.RegisterType<ManagerEntity>().As<IManagerEntity>();
            builder.RegisterType<TournamentEntity>().As<ITournamentEntity>();
            builder.RegisterType<TournamentFighterEntity>().As<ITournamentFighterEntity>();

            //register the ViewModels 
            builder.RegisterType<AddIsolationBubbleViewModel>().As<IAddIsolationBubbleViewModel>();
            builder.RegisterType<BaseViewModel>().As<IBaseViewModel>();
            builder.RegisterType<CustomMessageBoxViewModel>().As<ICustomMessageBoxViewModel>();
            builder.RegisterType<FighterMainWindowViewModel>().As<IFighterMainWindowViewModel>();
            builder.RegisterType<LoginViewModel>().As<ILoginViewModel>();
            builder.RegisterType<ManagerMainWindowViewModel>().As<IManagerMainWindowViewModel>();
            builder.RegisterType<ManagerTournamentDetailsViewModel>().As<IManagerTournamentDetailsViewModel>();
            builder.RegisterType<SignUpViewModel>().As<ISignUpViewModel>();

            //register the Views 
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(PresentationLayer)))
                .AsSelf();

            return builder.Build();
        }
    }
}
