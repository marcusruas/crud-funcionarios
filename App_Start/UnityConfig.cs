using Funcionarios.Repository.Helpers;
using Funcionarios.Repository.Implementation;
using Funcionarios.Repository.Interface;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Funcionarios
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //Repository
            container.RegisterType<IFuncionarioRepository, FuncionarioRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}