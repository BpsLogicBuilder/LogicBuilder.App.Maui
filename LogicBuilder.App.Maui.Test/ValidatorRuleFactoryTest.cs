using Contoso.Domain.Entities;
using LogicBuilder.App.Maui.Forms.Configuration.Validation;
using LogicBuilder.App.Maui.Validators.Rules;
using System.Collections.ObjectModel;

namespace LogicBuilder.App.Maui.Test
{
    public class ValidatorRuleFactoryTest
    {
        [Fact]
        public void TypeFor_AtLeastOneRequiredRule_MustBeAnObservable()
        {
            //arrange
            ValidatorRuleFactory validatorRuleFactory = new(null);

            //act
            var result = validatorRuleFactory.GetValidatorRule<ICollection<EnrollmentModel>>
            (
                new ValidatorDefinitionDescriptor("AtLeastOneRequiredRule", "Check", null),
                "Enrollments",
                null,
                new Dictionary<string, List<ValidationRuleDescriptor>>
                {
                    ["Enrollments"] = [new ValidationRuleDescriptor("AtLeastOneRequiredRule", "Select at least one")]
                },
                []
            );

            //assert
            Assert.IsType<AtLeastOneRequiredRule<ObservableCollection<EnrollmentModel>>>(result, exactMatch: false);
        }

        [Fact]
        public void AtLeastOneRequiredRule_ThrowsIfTypeIsNotEnumerable()
        {
            //arrange
            ValidatorRuleFactory validatorRuleFactory = new(null);

            //act
            var exception = Assert.Throws<InvalidOperationException>
            (
                () => validatorRuleFactory.GetValidatorRule<EnrollmentModel>
                (
                    new ValidatorDefinitionDescriptor("AtLeastOneRequiredRule", "Check", null),
                    "Enrollments",
                    null,
                    new Dictionary<string, List<ValidationRuleDescriptor>>
                    {
                        ["Enrollments"] = [new ValidationRuleDescriptor("AtLeastOneRequiredRule", "Select at least one")]
                    },
                    []
                )
            );

            //assert
            Assert.Contains("Type must be IEnumerable", exception.Message);
        }
    }
}
