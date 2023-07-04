using System.IO;
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
                string typeOfQuestion = "";
                if (i % 2 != 0)

                {
                    typeOfQuestion = jsonQuestions[i - 1];
                    if (typeOfQuestion == "tf")
                    {
                        TrueOrFalseQuestion q = JsonSerializer.Deserialize<TrueOrFalseQuestion>(jsonQuestions[i]);
                        deserializedSubjQs.Add(q);
                    }
                    else
                    {
                        ChooseOneQuestion q = JsonSerializer.Deserialize<ChooseOneQuestion>(jsonQuestions[i]);
                        deserializedSubjQs.Add(q);
                    }
                }

            }



            //deserializedSubjQs = JsonSerializer.Deserialize<QuestionList>(ReadTxt);

            return deserializedSubjQs;
        }


        //public void CreateExam(int ExamTID,string userExamType)
        public void CreateExam(string userExamType)
        {
            Type examType = Type.GetType(userExamType);

            var constructor = examType.GetConstructor(new Type[] { typeof(QuestionList) });

            SubjExam = (Exam)constructor.Invoke(new object[] { GetSubjQuestionList() });

        }
    }
}