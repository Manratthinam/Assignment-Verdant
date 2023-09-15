using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void ApplyAllConfiguration(this ModelBuilder modelBuilder)
        {
            var typeOfRegister = Assembly.GetExecutingAssembly().GetTypes()
                 .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType &&
                 gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();
            foreach (var type in typeOfRegister)
            {
                dynamic instance = Activator.CreateInstance(type) ??
                                   throw new InvalidOperationException($"Unable to instance type {type.FullName}");
                modelBuilder.ApplyConfiguration(instance);
            }
        }
    }
}
