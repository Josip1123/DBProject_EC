/*using System.Text.Json;
using Business.Dtos;
using Business.Factories;
using Business.Helpers;
using Business.Services;
using Data.Contexts;
using Data.Entities;
using Data.Repositories;

namespace ConsoleApp1;

class Program
{
    static async Task Main(string[] args)
    {
        using (var context = new DataContext())
        {

            string json = @"{
                        ""Name"": ""Json Test"",
                        ""DateDue"": ""2027-01-01"",
                        ""IsCompleted"": false
                        }";

            ProjectDto project = JsonSerializer.Deserialize<ProjectDto>(json)!;

            var projectToDb = ProjectFactory.Create(project);
            var repo = new ProjectsRepository(context);
            var service = new ProjectService(repo);

            //await service.DeleteAsync("PO - IRygM");

            await service.CreateProjectAsync(projectToDb);

            Console.WriteLine("Evo valjda radi, runna u svakom slucaju, brisem prvi");

        }
        Console.ReadKey();
    }
}*/