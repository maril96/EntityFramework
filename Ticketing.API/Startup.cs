using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ticketing.Core.BusinessLayer;
using Ticketing.Core.EF.Repository;
using Ticketing.Core.Repository;

namespace Ticketing.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                   .AddNewtonsoftJson(options=>{
                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                   }); //Questo evita i loop nelle navigation properties
            services //TicketController ha bisogno di un DataService
                .AddTransient<DataService>() //ora l'injector sa che serve una classe DataService deve istanziarla e passargliela.
                .AddTransient<ITicketRepository, EFTicketRepository>() //DataService ha bisogno di un ITicketRepository: quando la richiede l'injector gli istanzia un EFTicketRepository
                .AddTransient<INoteRepository, EFNoteRepository>();
                //Alla fine quello che cambierà saranno solo queste due righe di codice!
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Configura la PipeLine di esecuzione: il client fa una richiesta che arriva all'API. Prima di essere eseguita fa una serie di passaggi tra classi
            //che possono andarla a modificare in modo opportuno
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //Mappatura del Routing: l'URL viene spacchettato. Ciò permette di andare a selezionare l'azione da svolgere.
            /*Se avessimo hhtps://localhost/api/weatherforecast (HTTP GET), le componenti /api/weatherforecast fanno parte del Routing 
             *Si definiscono le classi di Controller, che è il codice da eseguire. Quando si legge weatherforecast, c'è una regola di Routing che si chiama come il Controller 
             *(nei controllers c'è scritto [Route("[controller]")]. A quel punto si va ad identificare il metodo associato.
             *In questo caso ad esempio non c'è un metodo di get che prende anche un argomento, per cui non posso fare il GetByID. Se provo a fare una richiesta scrivendo
             *  /API/weatherforecast/1, non trova il risultato cercato.
             */
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
