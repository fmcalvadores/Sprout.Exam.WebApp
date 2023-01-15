using Sprout.Exam.Business.DataTransferObjects;
using Xunit;

namespace Sprout.Exam.Business.TestServices
{
    public class UnitTest : BaseTest
    {
        
        public UnitTest()
        {
            var result = _employeeService.GetDates(2023, 2);
            Assert.True(result != 0);
        }

        [Fact(DisplayName = "CalculateSalaryForRegular")]
        public void CalculateSalaryForRegular()
        {
            var result = _employeeService.CalculateSalaryForRegular(20000, 0);
            Assert.NotNull(result.ToString());
        }

        [Fact(DisplayName = "CalculateSalaryForContractual")]
        public void CalculateSalaryForContractual()
        {
            var result = _employeeService.CalculateSalaryForContractual(500, (float)15.5);
            Assert.NotNull(result.ToString());
        }



    }
}
