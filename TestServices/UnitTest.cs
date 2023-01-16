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

        [Theory(DisplayName = "CalculateSalaryForRegular")]
        [InlineData(20000, 0)]
        public void CalculateSalaryForRegular(float salary, float absentDays)
        {
            var result = _employeeService.CalculateSalaryForRegular(salary, absentDays);
            Assert.True((result > 0 ));
        }

        [Theory(DisplayName = "CalculateSalaryForRegularAbsent")]
        [InlineData(20000, (float)22)]
        public void CalculateSalaryForRegularAbsent(float salary, float absentDays)
        {
            var result = _employeeService.CalculateSalaryForRegular(salary, absentDays);
            Assert.True((result == 0));
        }

        [Theory(DisplayName = "CalculateSalaryForContractual")]
        [InlineData(500, (float)15.5)]
        public void CalculateSalaryForContractual(float salary, float workedDays)
        {
            var result = _employeeService.CalculateSalaryForContractual(salary, workedDays);
            Assert.True((result > 0));
        }

        [Theory(DisplayName = "CalculateSalaryForContractualAbsent")]
        [InlineData(500, 0)]
        public void CalculateSalaryForContractualAbsent(float salary, float workedDays)
        {
            var result = _employeeService.CalculateSalaryForContractual(salary, workedDays);
            Assert.True((result == 0));
        }





    }
}
