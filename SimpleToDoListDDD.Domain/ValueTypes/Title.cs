using SimpleToDoListDDD.Core.Results;
using SimpleToDoListDDD.Core.Validations;
using SimpleToDoListDDD.Core.Validations.Entries;

namespace SimpleToDoListDDD.Domain.ValueTypes
{
    public sealed class Title
    {
        public string Value { get; }

        private Title(string title)
        {
            Value = title;
        }

        public static Result<Title> Create(string title)
        {
            var validator = new SimpleValidator().ValidateOneOf(
                StringValidationEntries.IsNotNullOrEmpty("Title.Required", title),
                StringValidationEntries.IsLengthInRange("Title.InvalidLength", title, 3, 200));

            if (!validator.IsValid)
                return Result<Title>.Failure(validator.Errors);

            return Result<Title>.Success(new Title(title));
        }
    }
}
