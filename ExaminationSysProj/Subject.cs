using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace ExaminationSysProj
{
    public class Subject
    {

        public string SubjectTitle { get; set; }
        public Exam SubjExam { get; set; }

        public Subject(string _SubjectTitle)
        {
            SubjectTitle = _SubjectTitle;
        }


        public QuestionList GetSubjQuestionList()
        {
            QuestionList deserializedSubjQs = new QuestionList(false);

            string path = new DirectoryInfo("SubjList").FullName;


            string[] jsonQuestions = File.ReadAllLines(@$"{path}\{SubjectTitle}.txt");



            for (int i = 0; i <= jsonQuestions.Length; i++)
            {
                string typeOfQuestion;
                if (i % 2 != 0)

                {
                    typeOfQuestion = jsonQuestions[i - 1];
                    Type QuestionType = Assembly.GetExecutingAssembly().GetType(typeOfQuestion);

                    Question q = (Question)JsonSerializer.Deserialize(jsonQuestions[i], QuestionType);
                    deserializedSubjQs.Add(q);
                }

            }



            return deserializedSubjQs;
        }
        public static Subject ChooseSubj()
        {
            string path;
            var isExist = Directory.Exists("SubjList");
            if (!isExist)
            {
                path = Directory.CreateDirectory("SubjList").FullName;
            }
            else
            {
                path = new DirectoryInfo("SubjList").FullName;
            }

            Console.WriteLine("What subject?");

            string[] textFiles = Directory.GetFiles(path, "*.txt").Select(file => Path.GetFileName(file).Substring(0, Path.GetFileName(file).Length - 4)).ToArray();
            foreach (var fileName in textFiles)
            {
                Console.WriteLine($"--> {fileName}");
            }

            Subject ExamSubj;

            string subjectNameInput;

            do
            {
                Console.Write("Your Answer : ");
                subjectNameInput = Console.ReadLine();
            } while (!textFiles.Contains(subjectNameInput.ToUpper()));

            Helpers.Printline("*", 25);


            ExamSubj = new Subject(subjectNameInput);

            return ExamSubj;
        }
        public void GenerateExamForSubj()
        {
            Type baseType = typeof(Exam);

            var ExamChildsNames = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.IsSubclassOf(baseType))
                .Select(type => type.Name.Substring(0, type.Name.Length - 4));


            Console.WriteLine("Exam Types");
            foreach (string className in ExamChildsNames)
            {
                Console.WriteLine($"--> {className}");

            }
            string ExamTypeInput;

            do
            {
                Console.Write("Your Answer : ");
                ExamTypeInput = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());

            } while (!ExamChildsNames.Contains(ExamTypeInput));

            ExamTypeInput = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ExamTypeInput);


            string ExamType = $"ExaminationSysProj.{ExamTypeInput}Exam";


            Type examType = Type.GetType(ExamType);

            var constructor = examType.GetConstructor(new Type[] { typeof(QuestionList) });

            SubjExam = (Exam)constructor.Invoke(new object[] { GetSubjQuestionList() });

        }


    }
}