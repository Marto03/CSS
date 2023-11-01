using WpfApp1.ViewModel;

namespace WpfApp1.Validations
{
    internal class StudentValidations
    {
        StudentViewModel? viewModel;
        public StudentValidations(StudentViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool IsValid()
        {
            if (viewModel != null)
            {
                if (viewModel.Fname != null && viewModel.Lname != null && viewModel.Age != 0 && viewModel.IdS.Length == 10
                    && viewModel.Speciality != null && viewModel.Course != 0)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
