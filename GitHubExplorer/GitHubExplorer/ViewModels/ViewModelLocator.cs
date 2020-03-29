using AutoMapper;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GitHubExplorer.Helpers;
using GitHubExplorer.Interfaces;
using GitHubExplorer.Models;
using GitHubExplorer.Utils;
using System;
using Xamarin.Forms;

namespace GitHubExplorer.ViewModels
{
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<HomePageViewModel>();
            SimpleIoc.Default.Register<UserRepositoriesPageViewModel>();
            SimpleIoc.Default.Register<IRepoHostingClient, GitHubClientHelper>(createInstanceImmediately: false);

            // Configuring Mapper
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>().ConvertUsing(MapperUtil.MapUserDTOToUserViewModel);
                cfg.CreateMap<Repository, RepositoryViewModel>().ConvertUsing(MapperUtil.MapRepoDTOToRepoViewModel);

            });
            if(!SimpleIoc.Default.IsRegistered<IMapper>()) SimpleIoc.Default.Register<IMapper>(() => configuration.CreateMapper(), createInstanceImmediately: false);
            SimpleIoc.Default.Register<ILogger>(() => DependencyService.Get<ILogManager>().GetLog(), createInstanceImmediately: false);
        }

        public HomePageViewModel HomePage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomePageViewModel>();
            }
        }

        public UserRepositoriesPageViewModel UserRepositoriesPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserRepositoriesPageViewModel>();
            }
        }
    }
}
