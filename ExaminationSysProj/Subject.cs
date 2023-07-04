using System.IO;
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
            Subject ExamSubj = default;
            Console.WriteLine("What subject?");
            Console.WriteLine("1- HTML");
            Console.WriteLine("2- Javascript");
            int subjectID;
            do
            {

                Console.Write("Your Answer : ");
                if (!int.TryParse(Console.ReadLine(), out subjectID))
                {
                    continue;
                }

            } while (subjectID < 0 || subjectID > 2);

            Helpers.Printline("*", 25);


            switch (subjectID)
            {
                case (1):
                    ExamSubj = new Subject("HTML");
                    break;
                case (2):
                    ExamSubj = new Subject("Javascript");
                    break;
            }
            return ExamSubj;
        }
        public void GenerateExamForSubj()
        {

            int ExamTypeID;
            string ExamType = "";
            Console.WriteLine("Exam Type");
            Console.WriteLine("1- Practice");
            Console.WriteLine("2- Final");
            do
            {

                Console.Write("Your Answer : ");
                if (!int.TryParse(Console.ReadLine(), out ExamTypeID))
                {
                    continue;
                }

            } while (ExamTypeID < 0 || ExamTypeID > 2);

            switch (ExamTypeID)
            {
                case (1):
                    ExamType = "ExaminationSysProj.PracticeExam";
                    break;
                case (2):
                    ExamType = "ExaminationSysProj.FinalExam";
                    break;

            }
            Type examType = Type.GetType(ExamType);

            var constructor = examType.GetConstructor(new Type[] { typeof(QuestionList) });

            SubjExam = (Exam)constructor.Invoke(new object[] { GetSubjQuestionList() });

        }


    }
}