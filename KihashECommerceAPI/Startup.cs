//using KihashECommerceAPI.Data;
//using KihashECommerceAPI.Repositories;
//using KihashECommerceAPI.Repository;
//using KihashECommerceAPI.Services;
//using Microsoft.EntityFrameworkCore;

//namespace KihashECommerceAPI
//{
//    public class Startup
//    {
//        private readonly IConfiguration _configuration;
//        private readonly Configuration

//        public Startup(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }


        

//public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddCors(options =>
//            {
//                options.AddPolicy(name: "corsPolicy",
//                    policy =>
//                    {
//                        policy.WithOrigins("https://localhost:4200", "http://localhost:4200") // No trailing slashes
//                              .AllowCredentials()
//                              .AllowAnyHeader()
//                              .AllowAnyMethod();
//                    });
//            });

//            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
//            services.AddControllers();
//            services.AddScoped<ICustomerRepository, CustomerRepository>();
//            services.AddScoped<IContactUsRepository, ContactUsRepository>();
//            services.AddScoped<IOrderRepository, OrderRepository>();
//            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
//            services.AddScoped<IPaymentRepository, PaymentRepository>();
//            services.AddScoped<IProductRepository, ProductRepository>();
//            services.AddScoped<TokenService>();
//            services.AddAuthentication("Bearer")
//                .AddJwtBearer(options =>
//                {
//                    options.TokenValidationParameters = new()
//                    {
//                        ValidateIssuer = true,
//                        ValidateAudience = true,
//                        ValidateLifetime = true,
//                        ValidateIssuerSigningKey = true,
//                        ValidIssuer = services.Configuration["Jwt:Issuer"],
//                        ValidAudience = builder.Configuration["Jwt:Audience"],
//                        IssuerSigningKey = new SymmetricSecurityKey(
//                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
//                        )
//                    };
//                });



//            services.AddEndpointsApiExplorer();
//            services.AddSwaggerGen();
//        }
        
//        public void Configure(WebApplication app)
//        {
//            app.UseCors("corsPolicy");
//            app.UseAuthentication();
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
               
//            }
   
//            app.UseHttpsRedirection();
//            app.UseAuthorization();
//            app.MapControllers();
            
//        }
//    }
//}
