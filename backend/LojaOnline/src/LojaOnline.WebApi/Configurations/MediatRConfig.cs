﻿using System.Reflection;

namespace LojaOnline.WebApi.Configurations
{
    public static class MediatRConfig
    {
        public static WebApplicationBuilder AddMediatRConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.RegisterServicesFromAssembly(typeof(LojaOnline.Application.Shared.Result<>).Assembly);
            });

            return builder;
        }
    }
}
