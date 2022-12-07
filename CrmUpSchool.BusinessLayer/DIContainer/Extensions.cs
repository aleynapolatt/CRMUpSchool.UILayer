using CrmUpSchool.BusinessLayer.Abstract;
using CrmUpSchool.BusinessLayer.Concrete;
using CrmUpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.BusinessLayer.DIContainer
{
   public static class Extensions
    {
        //halihazırda framwork methodunu kullanabilecek şekilde değiştirmek 
        //static sınıf içerisinde static method olarak yazılmalı 
        //bir bakıma override
        public static void ContainerDependencies(this IServiceCollection services)
        {
            //this olmalı mı? diğer alanlarda yolun bildirilmesi için //işlem yapılacak IServiceCollection startuptakini alabilir
            //startup a eklenecek 

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeDal, EfEmployeeDal>();

            services.AddScoped<IEmployeeTaskService, EmployeeTaskManager>();
            services.AddScoped<IEmployeeTaskDal, EfEmployeeTaskDal>();

            services.AddScoped<IEmployeeTaskDetailService, EmployeeTaskDetailManager>();
            services.AddScoped<IEmployeeTaskDetailDal, EfEmployeeTaskDetail>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EFMessageDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

        }
    }
}
