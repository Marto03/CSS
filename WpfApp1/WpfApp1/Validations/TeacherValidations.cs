using WpfApp1.ViewModel;

namespace WpfApp1.Validations
{
    internal class TeacherValidations
    {
        TeacherViewModel? viewModel;
        public TeacherValidations(TeacherViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool IsValid()
        {
            if (viewModel != null)
            {
                if (viewModel.Fname != null && viewModel.Lname != null && viewModel.Age != 0 && viewModel.Id.Length == 10 && viewModel.YearsExperience != 0
                && viewModel.Title != null && viewModel.Speciality != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
