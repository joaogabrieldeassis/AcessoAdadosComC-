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
                //OneToMany(connection);
                //QueryMultiple(connection);
                //SelectIn(connection);
                //Like(connection);
                Transaction(connection);


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
            var careers = new List<Career>();
            var items = connection.Query<Career, CareerItem, Career>
            (
                sql,
                (career, item) =>
                {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car == null)
                    {
                        car = career;
                        car.Items.Add(item);
                        careers.Add(car);
                    }
                    else
                    {
                        car.Items.Add(item);
                    }
                    return career;
                },
                splitOn: "CareerId"
            //splitOn vai servir para dividirmos as nossas tabelas no iner join, para sabermos qual é a careerItem e qual é o corse
            );
            foreach (var career in items)
            {
                Console.WriteLine($"{career.Title}");
                foreach (var item in career.Items)
                {
                    Console.WriteLine($"{item.Title}");
                }
            }
        }
        // metodo abaixo é relacionamento muitos para muitos
        static void QueryMultiple(SqlConnection connection)
        {
            var sqlMultiple = "SELECT * FROM [Category]; SELECT * FROM [Course]";
            using (var catCourse = connection.QueryMultiple(sqlMultiple))
            {
                var category = catCourse.Read<Category>();
                var courses = catCourse.Read<Course>();
                foreach (var item in category)
                {
                    Console.WriteLine(item.Id);
                }
                foreach (var items in courses)
                {
                    Console.WriteLine(items.Title);
                }
            }
        }
        //metodo abaixo serve para buscar os id de cada carreira e exibir seus devidos nomes
        static void SelectIn(SqlConnection connection)
        {
            var selIn = @"SELECT  * FROM [Career] WHERE [Id] IN ('01ae8a85-b4e8-4194-a0f1-1c6190af54cb','e6730d1c-6870-4df3-ae68-438624e04c72')";
            var jhon = connection.Query<Career>(selIn);
            foreach (var item in jhon)
            {
                Console.WriteLine(item.Title);
            }
        }
        //Metodo para buscar titlos dos cursos
        static void Like(SqlConnection connection)
        {
            var selectLike = "SELECT * FROM [Course] WHERE [Title] LIKE @exp ";
            var toReceiveLike = connection.Query<Course>(selectLike, new
            {
                exp = "%api%"
            }
            );
            foreach (var item in toReceiveLike)
            {
                Console.WriteLine(item.Title);
            }
        }
        // trabalhando com transações no método abaixo
        static void Transaction(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Minha categoria que vou ser um ótimo programador";
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
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
                var rows = connection.Execute(insert, new
                {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                }, transaction
                );
                //transaction.Rollback();
                //Comitando a nossa transação
                transaction.Commit();
                Console.WriteLine($"{rows} linhas inseridas");
            }


        }
    }
}

