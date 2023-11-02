using WpfApp1.ViewModel;

namespace WpfApp1.Validations
{
    internal class TeacherValidations
    {
        public static bool IsValid(TeacherViewModel viewModel)
        {
            if (viewModel != null)
            {
                if (viewModel.Fname != null && viewModel.Lname != null && viewModel.Age != 0 && viewModel.IdS.Length == 10 && viewModel.YearsExperience != 0
                && viewModel.Title != null && viewModel.Speciality != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
