using SimpleToDoListDDD.Core.Results;
using SimpleToDoListDDD.Core.Validations;
using SimpleToDoListDDD.Core.Validations.Entries;

namespace SimpleToDoListDDD.Domain.ValueTypes
{
    public sealed class Description
    {
        public string Value { get; }

        private Description(string value)
        {
            Value = value;
        }

        public static Result<Description> Create(string value)
        {
            var validator = new SimpleValidator().ValidateOneOf(
                StringValidations.IsNotNullOrEmpty("Description.Required", value));

            return !validator.IsValid
                ? Result<Description>.Failure(validator.Errors)
                : Result<Description>.Success(new Description(value));
        }
    }
}
