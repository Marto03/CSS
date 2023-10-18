using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                string? idS = viewModel.Id.ToString();
                if (viewModel.Fname != null && viewModel.Lname != null && viewModel.Age != 0 && viewModel.Id != 0 && idS.Length == 10
                    && viewModel.Speciality != null && viewModel.Course != 0)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
