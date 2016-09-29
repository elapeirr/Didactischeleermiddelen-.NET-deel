using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DidactischeLeermiddelen.Infrastructure
{
    public class UserModelBinder:IModelBinder

    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext.HttpContext.User.Identity.IsAuthenticated)
            {
                IUserRepository repos = (IUserRepository)DependencyResolver.Current.GetService(typeof(IUserRepository));
                return repos.FindBy(controllerContext.HttpContext.User.Identity.Name);



            }
            return null;
        }

    }
}