using System.Text.Json;

namespace Configuration
{

    public class Answer
    {
        public string body { get; set; }
        public bool isRight { get; set; }

    }
    public class configuration
    {

        public List<Answer> QuestionAnswers { get; set; }
        public string Body { get; set; }
        public string Header { get; set; }
        public int Marks { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            string jsonString = File.ReadAllText("appsettings.json");
            var jsonObject = JsonSerializer.Deserialize<List<configuration>>(jsonString);

            var newQuestion = new configuration
            {
                Body = "New question",
                Header = "New header",
                Marks = 20,
                QuestionAnswers = new List<Answer>
            {
                    new Answer { body = "Option 1", isRight = false },
                    new Answer { body = "Option 2", isRight = true }
            }
            };

            jsonObject.Add(newQuestion);


            string updatedJson = JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });

            Console.WriteLine(updatedJson);


            File.WriteAllText("appsettings.json", updatedJson);
        }
    }
}