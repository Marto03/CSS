using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
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
                string? idS = viewModel.Id.ToString();
                if (viewModel.Fname != null && viewModel.Lname != null && viewModel.Age != 0 && viewModel.Id != 0 && idS.Length == 10 && viewModel.YearsExperience != 0
                && viewModel.Title != null && viewModel.Speciality != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
