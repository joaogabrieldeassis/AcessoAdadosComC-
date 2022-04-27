using System;
using Modulo3.Model;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Modulo3 // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            //variavel de conexão 
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
            //Meus using de conexão 
            using (var connection = new SqlConnection(connectionString))
            {
                //Meus métodos
                // UpdateCategory(connection);
                //ListCategorys(connection);
                //CreateManyCategory(connection);
                //ExecuteReadProcedure(connection);
                //ExecuteEscalar(connection);
                //ExecuteViws(connection);
                //OneToOne(connection);
                OneToMany(connection);


            }
        }
        //Listando minha catgoria 
        static void ListCategorys(SqlConnection connection)
        {
            var categorys = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categorys)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");

            }
        }
        //Inserindo valores na minha categoria
        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Kabum";
            category.Url = "https: kabum.com";
            category.Description = "Venha comprar no melhor site do brasil";
            category.Order = 8;
            category.Summary = "João developer";
            category.Featured = false;
            var insert = @"INSERT INTO 
            [Category] 
            VALUES(
            @Id,
            @Title,
            @Url,
            @Description,
            @Order,
            @Summary,
            @Featured)";
            var linhasInsert = connection.Execute(insert, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Description,
                category.Order,
                category.Summary,
                category.Featured
            }
                );
            Console.WriteLine($"{linhasInsert} linhas inseridas");
        }
        //Executando o Update "Inserindo novos valores"
        static void UpdateCategory(SqlConnection connection)
        {
            var update = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
            var executeUpdate = connection.Execute(update, new
            {
                id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                title = "Joao developer front-end 2022"
            });
            Console.WriteLine($"{executeUpdate} Linhas nodificadas");
        }

        static void CreateManyCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Kabum";
            category.Url = "https: kabum.com";
            category.Description = "Venha comprar no melhor site do brasil";
            category.Order = 8;
            category.Summary = "João developer";
            category.Featured = false;

            var categoryTwo = new Category();
            categoryTwo.Id = Guid.NewGuid();
            categoryTwo.Title = "New Category";
            categoryTwo.Url = "New category";
            categoryTwo.Description = "category new";
            categoryTwo.Order = 9;
            categoryTwo.Summary = "category";
            categoryTwo.Featured = true;
            var insert = @"INSERT INTO 
            [Category] 
            VALUES(
            @Id,
            @Title,
            @Url,
            @Description,
            @Order,
            @Summary,
            @Featured)";
            var linhasInsert = connection.Execute(insert, new[]{
             new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Description,
                category.Order,
                category.Summary,
                category.Featured
            },
            new
            {
                categoryTwo.Id,
                categoryTwo.Title,
                categoryTwo.Url,
                categoryTwo.Description,
                categoryTwo.Order,
                categoryTwo.Summary,
                categoryTwo.Featured
            }
            }
                );
            Console.WriteLine($"{linhasInsert} linhas inseridas");
        }

        //Executar uma procedure que faz uma leitura de dados
        static void ExecuteProcedure(SqlConnection connection)
        {
            var executeProcedure = "[spDeleteStudent]";
            var pars = new { StudentId = "baa7118e-b49f-4ed0-8012-fbeb1a2180b4" };
            var affectedRows = connection.Execute(executeProcedure, pars, commandType: System.Data.CommandType.StoredProcedure);
            Console.WriteLine($"{affectedRows} foram as linhas afetadas");
        }
        static void ExecuteReadProcedure(SqlConnection connection)
        {
            var executeProcedure = "[spGetCoursesByCategory]";
            var pars = new { CategoryId = "25d510c8-3108-44c2-86c5-924d9832aa8c" };
            var courses = connection.Query<Category>(executeProcedure, pars, commandType: System.Data.CommandType.StoredProcedure);
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        //O ExecuteEscalar é para inserir um item na base, que vai ser o Id, e nesse método tmb irei mostrar o Id que foi adicionado
        static void ExecuteEscalar(SqlConnection connection)
        {
            var category = new Category();
            category.Title = "Kabum";
            category.Url = "https: kabum.com";
            category.Description = "Venha comprar no melhor site do brasil";
            category.Order = 8;
            category.Summary = "João developer";
            category.Featured = false;
            var insert = @"INSERT INTO 
            [Category] 
            OUTPUT inserted.[Id]
            VALUES(
            NEWID(),
            @Title,
            @Url,
            @Description,
            @Order,
            @Summary,
            @Featured) SELECT SCOPE_IDENTITY()";
            var IenteredAnId = connection.ExecuteScalar<Guid>(insert, new
            {
                category.Title,
                category.Url,
                category.Description,
                category.Order,
                category.Summary,
                category.Featured
            }
            );
            Console.WriteLine($"O id inserido foi : {IenteredAnId} ");
        }
        static void ExecuteViws(SqlConnection connection)
        {
            var sqlViws = "SELECT * FROM [VwCourse]";
            var course = connection.Query(sqlViws);
            foreach (var item in course)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }
        //Mapeando o INNER JOIN no banco com o relacionamento 1 para 1
        static void OneToOne(SqlConnection connection)
        {
            var sql = @"SELECT * FROM [CareerItem] INNER JOIN [Course] ON [CareerItem].[CourseId] = [Course].[Id];";
            var course = connection.Query<CareerItem, Course, CareerItem>
            (
                sql,
                (careerItem, course) =>
                {
                    careerItem.Course = course;
                    return careerItem;
                },
                splitOn: "Id"
            //splitOn vai servir para dividirmos as nossas tabelas no iner join, para sabermos qual é a careerItem e qual é o corse
            );
            foreach (var item in course)
            {
                Console.WriteLine($"Career :{item.Title} - Course :{item.Id}");
            }
            // var studentd = @"SELECT * FROM [Student] INNER JOIN [Course] ON [Student].[CourseId] = [Course].[Id]";
            // var studenSql = connection.Query<Student, Course, Student>
            // (
            //     studentd,
            //     (student, course1) =>
            //     {
            //         student.Course = course1;
            //         return student;
            //     }
            // );
            // foreach (var item in studenSql)
            // {
            //     Console.WriteLine($"Aluno{item.Name} - {item.Name}");
            // }
        }
        static void OneToMany(SqlConnection connection)
        {
            var sql = @"SELECT
                [Career].[Id],
                [Career].[Title],
                [CareerItem].[CareerId],
                [CareerItem].[Title]
                FROM [Career] INNER JOIN [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id] ORDER BY [Career].[Title]";
            var listCareer = new List<Career>();
            var Items = connection.Query<Career, CareerItem, Career>
            (
                sql,
                (career, courseItem) =>
                {
                    var car = listCareer.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car == null)
                    {
                        car = career;
                        car.Items.Add(courseItem);
                        listCareer.Add(car);
                    }
                    else
                    {
                        car.Items.Add(courseItem);
                    }
                    return career;
                },
                splitOn: "CareerId"
            //splitOn vai servir para dividirmos as nossas tabelas no iner join, para sabermos qual é a careerItem e qual é o corse
            );
            foreach (var career in Items)
            {
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.Items)
                {
                    Console.WriteLine($"{item.Title}");
                }
            }
        }
    }
}
