namespace ExaminationSysProj
{
    public class Helpers
    {
        public static void Printline(string Patt, int RN)
        {
            int i = 0;
            for (; i < RN; i++)
            {
                Console.Write(Patt);
            }

            Console.WriteLine("");
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            #region CreateQuestions


            //#region HTML QuestionList
            //string htmlQ1Body = @"HTML stands for 'Hyper Text Markup Language'";
            //Question htmlQ1 = new TrueOrFalseQuestion(AnswerList.AnswerListTF(true), true, htmlQ1Body);


            //Answer HTMLQ2ans1 = new Answer("h1", true);
            //Answer HTMLQ2ans2 = new Answer("head", false);
            //Answer HTMLQ2ans3 = new Answer("title", false);
            //Answer HTMLQ2ans4 = new Answer("header", false);

            //AnswerList htmlQ2AnsLis = new AnswerList();
            //htmlQ2AnsLis?.Add(HTMLQ2ans1);
            //htmlQ2AnsLis?.Add(HTMLQ2ans2);
            //htmlQ2AnsLis?.Add(HTMLQ2ans3);
            //htmlQ2AnsLis?.Add(HTMLQ2ans4);

            //string htmlQ2Body = @"Which tag is used to define the main heading of an HTML document?";
            //Question htmlQ2 = new ChooseOneQuestion(htmlQ2AnsLis, htmlQ2Body);


            //QuestionList HtmlQuestions = new QuestionList("HTML", false);

            //HtmlQuestions?.Add(htmlQ1);
            //HtmlQuestions?.Add(htmlQ2);

            //#endregion


            //#region JSQuesionList Creation
            //string JSQ1Body = "Can't use js in styling elements of HTML?";
            //Question JSQ1 = new TrueOrFalseQuestion(AnswerList.AnswerListTF(true), false, JSQ1Body);

            //Answer JSQ2ans1 = new Answer("getElementById", true);
            //Answer JSQ2ans2 = new Answer("getElementsByClassName", false);
            //Answer JSQ2ans3 = new Answer("getElementsByTagName", false);
            //Answer JSQ2ans4 = new Answer("getElementsByNames", false);

            //AnswerList JSQ2AnsLis = new AnswerList();
            //JSQ2AnsLis?.Add(JSQ2ans1);
            //JSQ2AnsLis?.Add(JSQ2ans2);
            //JSQ2AnsLis?.Add(JSQ2ans3);
            //JSQ2AnsLis?.Add(JSQ2ans4);

            //string JSQ2Body = @"Which selector is more specific ?";
            //Question JSQ2 = new ChooseOneQuestion(htmlQ2AnsLis, JSQ2Body);


            //QuestionList JSQuestions = new QuestionList("JS", false);

            //JSQuestions?.Add(JSQ1);
            //JSQuestions?.Add(JSQ2);
            //#endregion

            #endregion

            Console.WriteLine("What subject?");
            Console.WriteLine("1- HTML");
            Console.WriteLine("2- Javascript");
            int subjectID;
            Subject ExamSubj = default;
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
            ExamSubj.CreateExam(ExamType);

            Console.WriteLine($"Exam of {ExamSubj.SubjectTitle}");
            Helpers.Printline("*", 25);

            ExamSubj.SubjExam.ShowExam();


        }
    }
}