using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Threading;
using PlataformaComercio.FrameWork.Exceptions;

namespace PlataformaComercio.Business
{
    public static class Util
    {
        static ValidatorFactory factory = null;
        public static void Validate<T>(T objectToValidate)
        {
            if (factory == null)
            {
                try
                {
                    factory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
                }
                catch (SynchronizationLockException) { }
            }

            Validator<T> entBaseProductValidator = factory.CreateValidator<T>();

            // Validate the instance to obtain a collection of validation errors.
            ValidationResults r = entBaseProductValidator.Validate(objectToValidate);
            if (!r.IsValid)
            {
                throw new UserException("Errores de validación", r);
            }
        }
    }
}
