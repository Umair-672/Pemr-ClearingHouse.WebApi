using PemrClearingHouse.Api.Configurations;
using PemrClearingHouse.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PemrClearingHouse.Api.Repositories.UnitOfWork;

namespace PemrClearingHouse.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<MongoDBSettings>(
                builder.Configuration.GetSection("MongoDBSettings"));
            builder.Services.AddSingleton(res =>
            {
                var settings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
                return new MongoDbContext(settings);
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<OrganizationService>();
            builder.Services.AddScoped<DialupSettingsService>();
            builder.Services.AddScoped<PatientService>();
            builder.Services.AddScoped<InterpretationEntityService>();
            builder.Services.AddScoped<InterpretedResponseService>();
            builder.Services.AddScoped<InterpretedResponseFieldService>();
            builder.Services.AddScoped<OutboundClaimService>();
            builder.Services.AddScoped<ResponseKeywordService>();
            builder.Services.AddScoped<ResponseKeywordFieldService>();
            builder.Services.AddScoped<InterpretationFieldService>();
            builder.Services.AddScoped<ClaimStatusService>();
            builder.Services.AddScoped<OutboundTransactionService>();
            builder.Services.AddScoped<OutboundClaimFileService>();
            builder.Services.AddScoped<PaytoAddressService>();
            builder.Services.AddScoped<PayerService>();
            builder.Services.AddScoped<SubscriberService>();
            builder.Services.AddScoped<ClaimEntityService>();
            builder.Services.AddScoped<ClaimService>();
            builder.Services.AddScoped<BillingPrvSecondaryIdentificationService>();
            builder.Services.AddScoped<BillingProviderService>();
            builder.Services.AddScoped<InboundTransactionService>();
            builder.Services.AddScoped<InboundClaimFileService>();
            builder.Services.AddScoped<RTTransactionSettingsService>();
            builder.Services.AddScoped<TransactionRouteService>();
            builder.Services.AddScoped<X12TransactionService>();
            builder.Services.AddScoped<X12StandardService>();
            builder.Services.AddScoped<VPNSettingsService>();
            builder.Services.AddScoped<FTPSettingsService>();
            builder.Services.AddScoped<GatewayService>();
            builder.Services.AddScoped<InsuranceCarrierService>();
            builder.Services.AddScoped<InsuranceService>();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var jwtKey = builder.Configuration["Jwt:Key"];
            var jwtIssuer = builder.Configuration["Jwt:Issuer"];

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = "http://pemrpk-265/identity";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
