namespace AxelPIGNOL
{
    public partial class SettingsPage : ContentPage
    {
        private List<Question> questions;
        private int currentQuestionIndex = 0;

        public SettingsPage()
        {
            InitializeComponent();
            SetupQuestions();
            ShowNextQuestion();
        }

        private void SetupQuestions()
        {
            questions = new List<Question>
            {
                new Question("Bigflo et Oli est-il un groupe de Rappeur Francais ?", true),
                new Question("La Terre est-elle plate ?", false),
                new Question("Le BUT Informatique est-elle la meilleure promotion ?", true),
                new Question("Les poissons peuvent-ils voler", false),
                new Question("Les chats sont des chiens ?", false)
            };
        }

        private void ShowNextQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                var question = questions[currentQuestionIndex];
                questionLabel.Text = question.Text;
                resultLabel.Text = "Choisissez une réponse";
                trueButton.IsEnabled = true;
                falseButton.IsEnabled = true;
            }
            else
            {
                questionLabel.Text = "Quiz terminé!";
                trueButton.IsEnabled = false;
                falseButton.IsEnabled = false;
                resultLabel.Text = "Vous avez terminé toutes les questions.";
            }
        }

        private async void OnAnswerClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            bool userAnswer = button.Text == "Vrai";
            var correctAnswer = questions[currentQuestionIndex].Answer;

            resultLabel.Text = userAnswer == correctAnswer ? "Correct!" : "Faux!";
            trueButton.IsEnabled = false;
            falseButton.IsEnabled = false;

            await Task.Delay(1000);  // Attendre 1 seconde avant de montrer la prochaine question

            currentQuestionIndex++;
            ShowNextQuestion();
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public bool Answer { get; set; }

        public Question(string text, bool answer)
        {
            Text = text;
            Answer = answer;
        }
    }
}
