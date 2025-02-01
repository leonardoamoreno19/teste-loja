﻿namespace LojaOnline.WebApi.Configurations
{
    public static class AutoMapperConfig
    {
        public static WebApplicationBuilder AddAutoMapperConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            
            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(Application.Customer.MappingProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(Application.Order.MappingProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(Application.Product.MappingProfile).Assembly);

            return builder;
        }
    }
}
