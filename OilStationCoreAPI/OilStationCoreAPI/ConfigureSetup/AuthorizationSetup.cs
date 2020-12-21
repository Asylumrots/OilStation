using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OilStationCoreAPI.ConfigureSetup
{
    public static class AuthorizationSetup
    {
        public static void AddAuthorizationSetup(this IServiceCollection services)
        {
            //[Authorize(Policy = "Admin")]
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrators", policy => policy.RequireRole("Administrators"));

                options.AddPolicy("Roles_Get", policy => policy.RequireClaim("Roles", "Get"));
                options.AddPolicy("Roles_Update", policy => policy.RequireClaim("Roles", "Update"));

                options.AddPolicy("Claim_Get", policy => policy.RequireClaim("Claim", "Get"));
                options.AddPolicy("Claim_Update", policy => policy.RequireClaim("Claim", "Update"));

                options.AddPolicy("UserInfo_Get", policy => policy.RequireClaim("UserInfo", "Get"));
                options.AddPolicy("UserInfo_Update", policy => policy.RequireClaim("UserInfo", "Update"));
                options.AddPolicy("UserInfo_Delete", policy => policy.RequireClaim("UserInfo", "Delete"));

                options.AddPolicy("Job_Get", policy => policy.RequireClaim("Job", "Get"));
                options.AddPolicy("Job_Add", policy => policy.RequireClaim("Job", "Add"));
                options.AddPolicy("Job_Update", policy => policy.RequireClaim("Job", "Update"));
                options.AddPolicy("Job_Delete", policy => policy.RequireClaim("Job", "Delete"));

                options.AddPolicy("Organization_Get", policy => policy.RequireClaim("Organization", "Get"));
                options.AddPolicy("Organization_Add", policy => policy.RequireClaim("Organization", "Add"));
                options.AddPolicy("Organization_Update", policy => policy.RequireClaim("Organization", "Update"));
                options.AddPolicy("Organization_Delete", policy => policy.RequireClaim("Organization", "Delete"));

                options.AddPolicy("Entry_Get", policy => policy.RequireClaim("Entry", "Get"));
                options.AddPolicy("Entry_CheckGet", policy => policy.RequireClaim("Entry", "CheckGet"));
                options.AddPolicy("Entry_Add", policy => policy.RequireClaim("Entry", "Add"));
                options.AddPolicy("Entry_Check", policy => policy.RequireClaim("Entry", "Check"));
                options.AddPolicy("Entry_Delete", policy => policy.RequireClaim("Entry", "Delete"));

                options.AddPolicy("Leave_Get", policy => policy.RequireClaim("Leave", "Get"));
                options.AddPolicy("Leave_CheckGet", policy => policy.RequireClaim("Leave", "CheckGet"));
                options.AddPolicy("Leave_Add", policy => policy.RequireClaim("Leave", "Add"));
                options.AddPolicy("Leave_Check", policy => policy.RequireClaim("Leave", "Check"));
                options.AddPolicy("Leave_Delete", policy => policy.RequireClaim("Leave", "Delete"));

                options.AddPolicy("OilOrder_Get", policy => policy.RequireClaim("OilOrder", "Get"));
                options.AddPolicy("OilOrder_CheckGet", policy => policy.RequireClaim("OilOrder", "CheckGet"));
                options.AddPolicy("OilOrder_Add", policy => policy.RequireClaim("OilOrder", "Add"));
                options.AddPolicy("OilOrder_Check", policy => policy.RequireClaim("OilOrder", "Check"));
                options.AddPolicy("OilOrder_Delete", policy => policy.RequireClaim("OilOrder", "Delete"));

            });
        }
    }
}
