using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Behavior
{
    public sealed class ValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, ICommand<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Validator olup olmadığını kontrol ediyoruz. Validator yoksa direkt olarak bir sonraki işleme geçiyoruz.
            if (!_validators.Any())
            {
                return await next();
            }

            // Validator varsa, doğrulama işlemi için ValidationContext oluşturuyoruz.
            var context = new ValidationContext<TRequest>(request);

            // Validator'ları çalıştırarak doğrulama hatalarını topluyoruz. Hataları PropertyName'e göre gruplandırarak bir sözlük oluşturuyoruz.
            var errorDictionary = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage, (propertyName, errorMessage) => new
                {
                    Key = propertyName,
                    Values = errorMessage.Distinct().ToArray()
                })
                .ToDictionary(x => x.Key, x => x.Values[0]);

            // Eğer doğrulama hataları varsa, bu hataları ValidationException olarak fırlatıyoruz. Hataları ValidationFailure nesnelerine dönüştürerek hata kodu ve hata mesajını belirtiyoruz.
            if (errorDictionary.Any())
            {
                var errors = errorDictionary.Select(s => new ValidationFailure
                {
                    PropertyName = s.Value,
                    ErrorCode = s.Key
                });
                throw new ValidationException(errors);
            }

            return await next();
        }
    }
}
