using Ninject;

namespace Practice_Window.Core.ioc; 

public static class IoC
{
        
        
        #region MyRegion
        public static IKernel Kernel { get; private set; } = new StandardKernel();
        #endregion
        
        #region construct

        public static void Setup()
        {
                BindViewModels();
        }
        private static void BindViewModels()
        {
                Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
        #endregion
        
        public static T Get<T>()
        {
                return Kernel.Get<T>();
        }
}